function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

. (Join-Path $PSScriptRoot 'provision-common.ps1')

function setupEnv {
    [CmdletBinding(SupportsShouldProcess)]
    param([string]$RuntimeEnvPath = $env:AVD_TEST_RUNTIME_ENV_PATH)

    $script:AvdRuntimeEnvPath = $null
    $ErrorActionPreference = 'Stop'
    if (-not $PSCmdlet.ShouldProcess('AVD test run', 'Save runtime identity and create owned Private Link fixtures')) { return }
    $config = Get-AvdSelectedConfig
    Assert-AvdContext $config
    $runId = [guid]::NewGuid().ToString('N')
    if (-not $RuntimeEnvPath) {
        $RuntimeEnvPath = Join-Path (Split-Path -Parent $config.StatePath) "avd-$($config.Profile.ToLowerInvariant())-$runId.runtime.json"
    }
    if (-not [System.IO.Path]::IsPathFullyQualified($RuntimeEnvPath) -or $RuntimeEnvPath -eq $config.StatePath) {
        throw 'RuntimeEnvPath must be absolute and distinct from provisioning state.'
    }
    if (Test-Path -LiteralPath $RuntimeEnvPath) { throw 'Runtime manifest already exists. Clean up that run or select a new RuntimeEnvPath; it will not be overwritten.' }
    if (Test-Path -LiteralPath "$RuntimeEnvPath.playback.json") { throw 'A Playback snapshot already exists for this runtime path. Select a new RuntimeEnvPath to preserve the recording environment.' }
    $runtime = Build-AvdTestEnv -Config $config -RunId $runId
    $runtime.OwnedResources = @()
    $runtime.SetupComplete = $false
    Write-AvdJson -Path $RuntimeEnvPath -Value $runtime -Required
    $script:AvdRuntimeEnvPath = $RuntimeEnvPath
    Set-AvdProcessSelection -Config $config -RuntimeEnvPath $RuntimeEnvPath
    try {
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $runtime.ResourceGroup -Name $runtime.VnetName -ErrorAction Stop
        $subnet = $vnet.Subnets | Where-Object Id -eq $runtime.VnetSubnetId
        if (-not $subnet) { throw 'The configured default subnet is missing. Run the matching ControlPlane provisioning entry first.' }
        $image = Get-AzVMImage -Location $runtime.Location -PublisherName $runtime.MarketplaceInfoPublisher -Offer $runtime.MarketplaceInfoOffer -Skus $runtime.MarketplaceInfoSku -ErrorAction Stop | Sort-Object { [version]$_.Version } -Descending | Select-Object -First 1
        if (-not $image.Version) { throw 'The configured Marketplace image is unavailable.' }
        $runtime.MarketplaceImageVersion = $image.Version
        $definitions = @(
            @{ Kind = 'Workspace'; Name = $runtime.PvtLinkWS }
            @{ Kind = 'HostPool'; Name = $runtime.PvtLinkHP }
            @{ Kind = 'PrivateEndpoint'; Name = $runtime.PrivateEndpointNameWS; Connection = $runtime.PrivateEndpointConnectionNameWS; Parent = 'Workspace'; Group = $runtime.PECGroupIdWorkspace }
            @{ Kind = 'PrivateEndpoint'; Name = $runtime.PrivateEndpointNameWS1; Connection = $runtime.PrivateEndpointConnectionNameWS1; Parent = 'Workspace'; Group = $runtime.PECGroupIdWorkspace }
            @{ Kind = 'PrivateEndpoint'; Name = $runtime.PrivateEndpointNameHP; Connection = $runtime.PrivateEndpointConnectionNameHP; Parent = 'HostPool'; Group = $runtime.PECGroupIdHostPool }
            @{ Kind = 'PrivateEndpoint'; Name = $runtime.PrivateEndpointNameHP1; Connection = $runtime.PrivateEndpointConnectionNameHP1; Parent = 'HostPool'; Group = $runtime.PECGroupIdHostPool }
        )
        $existingNames = @((Get-AzWvdWorkspace -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -ErrorAction Stop).Name) +
            @((Get-AzWvdHostPool -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -ErrorAction Stop).Name) +
            @((Get-AzPrivateEndpoint -ResourceGroupName $runtime.ResourceGroup -ErrorAction Stop).Name)
        if ($definitions.Name | Where-Object { $_ -in $existingNames }) { throw 'A per-run resource name already exists; refusing to adopt it.' }
        $parents = @{}
        foreach ($definition in $definitions) {
            if (-not $PSCmdlet.ShouldProcess($definition.Name, "Create owned $($definition.Kind)")) { throw 'Setup was not completed because resource creation was declined.' }
            $runtime.OwnedResources += @{ Kind = $definition.Kind; Name = $definition.Name }
            Write-AvdJson -Path $RuntimeEnvPath -Value $runtime -Required
            switch ($definition.Kind) {
                Workspace {
                    $parents.Workspace = New-AzWvdWorkspace -Name $definition.Name -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -Location $runtime.Location -ErrorAction Stop
                }
                HostPool {
                    $parameters = @{
                        Name = $definition.Name; ResourceGroupName = $runtime.ResourceGroup; SubscriptionId = $runtime.SubscriptionId
                        Location = $runtime.Location; HostPoolType = 'Pooled'; LoadBalancerType = 'DepthFirst'
                        MaxSessionLimit = 5; PreferredAppGroupType = 'Desktop'; ErrorAction = 'Stop'
                    }
                    if ($runtime.Profile -eq 'Preview') { $parameters.ManagementType = 'Standard' }
                    $parents.HostPool = New-AzWvdHostPool @parameters
                }
                PrivateEndpoint {
                    $connection = New-AzPrivateLinkServiceConnection -Name $definition.Connection -PrivateLinkServiceId $parents[$definition.Parent].Id -GroupId $definition.Group -ErrorAction Stop
                    New-AzPrivateEndpoint -Name $definition.Name -ResourceGroupName $runtime.ResourceGroup -Location $runtime.Location -Subnet $subnet -PrivateLinkServiceConnection $connection -Force -ErrorAction Stop | Out-Null
                }
            }
        }
        $workspaceConnections = @(Get-AzWvdPrivateEndpointConnection -SubscriptionId $runtime.SubscriptionId -ResourceGroupName $runtime.ResourceGroup -WorkspaceName $runtime.PvtLinkWS -ErrorAction Stop)
        $hostPoolConnections = @(Get-AzWvdPrivateEndpointConnection -SubscriptionId $runtime.SubscriptionId -ResourceGroupName $runtime.ResourceGroup -HostPoolName $runtime.PvtLinkHP -ErrorAction Stop)
        if ($workspaceConnections.Count -ne 2 -or $hostPoolConnections.Count -ne 2) { throw 'Private Endpoint Connection discovery is incomplete. Cleanup this run and retry after service convergence.' }
        $runtime.PrivateEndpointConnectionNameWS = '^(?:' + (($workspaceConnections.Name | ForEach-Object { [regex]::Escape($_) }) -join '|') + ')$'
        $runtime.PrivateEndpointConnectionNameHP = '^(?:' + (($hostPoolConnections.Name | ForEach-Object { [regex]::Escape($_) }) -join '|') + ')$'
        $runtime.PrivateEndpointConnectionName0 = (@($workspaceConnections[0].Name, $hostPoolConnections[0].Name) | ForEach-Object { [regex]::Escape($_) }) -join '|'
        $runtime.PrivateEndpointConnectionName1 = (@($workspaceConnections[1].Name, $hostPoolConnections[1].Name) | ForEach-Object { [regex]::Escape($_) }) -join '|'
        $runtime.PrivateEndpointConnectionName = "$($runtime.PrivateEndpointConnectionName0)|$($runtime.PrivateEndpointConnectionName1)"
        $runtime.SetupComplete = $true
        Write-AvdJson -Path $RuntimeEnvPath -Value $runtime -Required
    } catch {
        Write-Warning "Setup failed. Cleanup identity and attempted resources are saved in $RuntimeEnvPath."
        throw
    }
}

function cleanupEnv {
    [CmdletBinding(SupportsShouldProcess)]
    param([string]$RuntimeEnvPath)

    $ErrorActionPreference = 'Stop'
    if (-not $RuntimeEnvPath) {
        $RuntimeEnvPath = $script:AvdRuntimeEnvPath
        if (-not $RuntimeEnvPath) { return }
    }
    if (-not $RuntimeEnvPath) { throw 'Cleanup requires the exact runtime manifest from setup.' }
    $runtime = Read-AvdState -Path $RuntimeEnvPath
    if ($runtime.PlaybackSnapshot) { throw 'A Playback snapshot is not a cleanup ownership manifest.' }
    $config = Get-AvdTestResourceConfig -Profile $runtime.Profile -TenantId $runtime.Tenant -SubscriptionId $runtime.SubscriptionId -ResourceGroupName $runtime.ResourceGroup -Location $runtime.Location -StatePath $runtime.StatePath
    if ($runtime.RunId -notmatch '^[0-9a-f]{32}$') { throw 'Invalid cleanup run identity.' }
    $expected = Build-AvdTestEnv -Config $config -RunId $runtime.RunId
    $allowed = @{
        Workspace = @($expected.PvtLinkWS); HostPool = @($expected.PvtLinkHP)
        PrivateEndpoint = @($expected.PrivateEndpointNameWS, $expected.PrivateEndpointNameWS1, $expected.PrivateEndpointNameHP, $expected.PrivateEndpointNameHP1)
    }
    foreach ($owned in $runtime.OwnedResources) {
        if ($owned.Name -notin $allowed[$owned.Kind]) { throw 'Runtime manifest contains a resource not owned by this setup run.' }
    }
    if (-not $PSCmdlet.ShouldProcess("$($runtime.Tenant)/$($runtime.SubscriptionId)/$($runtime.ResourceGroup)", 'Clean up saved run resources')) { return }
    if ($runtime.SetupComplete) {
        $snapshot = $runtime.Clone()
        $snapshot.Remove('OwnedResources')
        $snapshot.PlaybackSnapshot = $true
        Write-AvdJson -Path "$RuntimeEnvPath.playback.json" -Value $snapshot -Required
    }
    $context = Get-AzContext -ErrorAction Stop
    if ($context.Subscription.Id -ne $runtime.SubscriptionId -or $context.Tenant.Id -ne $runtime.Tenant) {
        if (-not $PSCmdlet.ShouldProcess($runtime.SubscriptionId, 'Select saved cleanup tenant/subscription context')) { return }
        Set-AzContext -SubscriptionId $runtime.SubscriptionId -Tenant $runtime.Tenant -ErrorAction Stop | Out-Null
    }
    Assert-AvdContext $config
    foreach ($kind in @('PrivateEndpoint', 'Workspace', 'HostPool')) {
        foreach ($owned in @($runtime.OwnedResources | Where-Object Kind -eq $kind)) {
            if (-not $PSCmdlet.ShouldProcess($owned.Name, "Remove owned $kind")) { continue }
            switch ($kind) {
                PrivateEndpoint {
                    $existing = Get-AzPrivateEndpoint -ResourceGroupName $runtime.ResourceGroup -ErrorAction Stop | Where-Object Name -eq $owned.Name
                    if ($existing) { Remove-AzPrivateEndpoint -ResourceGroupName $runtime.ResourceGroup -Name $owned.Name -Force -ErrorAction Stop | Out-Null }
                }
                Workspace {
                    $existing = Get-AzWvdWorkspace -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -ErrorAction Stop | Where-Object Name -eq $owned.Name
                    if ($existing) { Remove-AzWvdWorkspace -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -Name $owned.Name -Confirm:$false -ErrorAction Stop | Out-Null }
                }
                HostPool {
                    $existing = Get-AzWvdHostPool -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -ErrorAction Stop | Where-Object Name -eq $owned.Name
                    if ($existing) { Remove-AzWvdHostPool -ResourceGroupName $runtime.ResourceGroup -SubscriptionId $runtime.SubscriptionId -Name $owned.Name -Confirm:$false -ErrorAction Stop | Out-Null }
                }
            }
            $runtime.OwnedResources = @($runtime.OwnedResources | Where-Object { $_.Name -ne $owned.Name })
            $runtime.SetupComplete = $false
            Write-AvdJson -Path $RuntimeEnvPath -Value $runtime -Required
        }
    }
    if (-not $runtime.OwnedResources.Count -and $PSCmdlet.ShouldProcess($RuntimeEnvPath, 'Remove completed runtime manifest')) {
        Remove-Item -LiteralPath $RuntimeEnvPath -ErrorAction Stop
        if ($env:AVD_TEST_RUNTIME_ENV_PATH -eq $RuntimeEnvPath) { $env:AVD_TEST_RUNTIME_ENV_PATH = $null }
        if ($script:AvdRuntimeEnvPath -eq $RuntimeEnvPath) { $script:AvdRuntimeEnvPath = $null }
    }
}
