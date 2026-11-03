#Requires -Version 7.0
[CmdletBinding()]
param(
    [ValidateSet('Record', 'Playback')]
    [string]$Mode = 'Playback',
    [string]$SubscriptionId = '00000000-0000-0000-0000-000000000000',
    [string]$GatewayId,
    [string]$WorkDirectory
)

$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../../..')).Path
$artifactRoot = Join-Path $repoRoot 'artifacts'
if (-not $WorkDirectory) {
    $WorkDirectory = Join-Path $artifactRoot ('ptm-legacy-' + [guid]::NewGuid().ToString('N'))
}
$WorkDirectory = [IO.Path]::GetFullPath($WorkDirectory)
if (-not $WorkDirectory.StartsWith($artifactRoot + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase)) {
    throw 'Raw recordings must remain under ignored repository artifacts.'
}
if (Test-Path $WorkDirectory) { throw 'Use a new isolated work directory.' }
if ($Mode -eq 'Record') {
    if ($SubscriptionId -ne '6df253df-46b8-4dd6-908c-76be3e418edd') { throw 'Only the approved PTM development subscription is allowed.' }
    $approvedGateway = "/subscriptions/$SubscriptionId/resourceGroups/ptm-synthetics-probingplane/providers/Microsoft.Network/probinggateways/ptm-syn-probe-westcentralus-pgw"
    if ($GatewayId -ne $approvedGateway) { throw 'Only the approved reference-only probing gateway is allowed.' }
}

Import-Module Pester -RequiredVersion 4.10.1 -ErrorAction Stop
Import-Module (Join-Path $artifactRoot 'Debug/Az.Accounts/Az.Accounts.psd1') -ErrorAction Stop
Import-Module (Join-Path $artifactRoot 'Debug/Az.PrivateTrafficManager/Az.PrivateTrafficManager.psd1') -ErrorAction Stop
$null = Disable-AzContextAutosave -Scope Process
$null = New-Item -ItemType Directory -Path $WorkDirectory
$testFiles = @(Get-ChildItem (Join-Path $PSScriptRoot '*-AzPrivateTrafficManager*.Tests.ps1') | Sort-Object Name)
foreach ($testFile in $testFiles) { Copy-Item $testFile.FullName $WorkDirectory }
Copy-Item (Join-Path $PSScriptRoot 'loadEnv.ps1') $WorkDirectory
Copy-Item (Join-Path $repoRoot 'generated/PrivateTrafficManager/PrivateTrafficManager.Autorest/generated/runtime/HttpPipelineMocking.ps1') $WorkDirectory
$fixture = Get-Content (Join-Path $PSScriptRoot 'env.json') -Raw | ConvertFrom-Json -AsHashtable
$created = $false
$module = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Module]::Instance
$onNewRequest = $module.OnNewRequest
$previousPlayback = $env:AzPSAutorestTestPlaybackMode
try {
    if ($Mode -eq 'Record') {
        $context = Set-AzContext -Subscription $SubscriptionId -Scope Process -ErrorAction Stop
        $null = Get-AzAccessToken -ResourceUrl 'https://management.azure.com/' -ErrorAction Stop
        $groupName = 'ptm-pwsh-oct-' + [guid]::NewGuid().ToString('N').Substring(0, 10)
        $exists = az group exists --name $groupName --subscription $SubscriptionId
        if ($LASTEXITCODE -ne 0 -or $exists -ne 'false') { throw 'Temporary group absence could not be confirmed.' }
        $null = az group create --name $groupName --location westcentralus --subscription $SubscriptionId --tags purpose=ptm-powershell-october-validation --output json
        if ($LASTEXITCODE -ne 0) { throw 'Temporary group creation failed.' }
        $created = $true
        Write-Host "Owned test group: $groupName"
        $null = az network vnet create --resource-group $groupName --name validation-vnet --location westcentralus --address-prefixes 10.1.0.0/16 --subscription $SubscriptionId --output json
        if ($LASTEXITCODE -ne 0) { throw 'Temporary VNet creation failed.' }
        $fixture.SubscriptionId = $SubscriptionId
        $fixture.Tenant = $context.Tenant.Id
        $fixture.resourceGroupName = $groupName
        $fixture.location = 'global'
        $fixture.gatewayId = $GatewayId
        $fixture.virtualNetworkId = "/subscriptions/$SubscriptionId/resourceGroups/$groupName/providers/Microsoft.Network/virtualNetworks/validation-vnet"
        $common = @{ SubscriptionId = $SubscriptionId; ResourceGroupName = $groupName; ErrorAction = 'Stop' }
        foreach ($profileName in @($fixture.profileName, $fixture.profileNameForDelete)) {
            $null = New-AzPrivateTrafficManagerProfile @common -PrivateTrafficManagerProfileName $profileName -Location global -TrafficRoutingMethod Weighted -ProfileStatus Enabled -CustomTopologyMapMode Disabled -DnsConfigRecordType CNAME -DnsConfigTtl 30 -Confirm:$false
        }
        foreach ($policyName in @($fixture.healthPolicyName, $fixture.healthPolicyNameForDelete)) {
            $null = New-AzPrivateTrafficManagerHealthPolicy @common -PrivateTrafficManagerProfileName $fixture.profileName -Name $policyName -ProbeConfigProtocol HTTPS -ProbeConfigPort 443 -ProbeConfigPath '/health' -ProbeConfigIntervalInSecond 30 -ProbeConfigTimeoutInSecond 10 -ProbeConfigToleratedNumberOfFailure 3 -Confirm:$false
        }
        foreach ($endpointName in @($fixture.endpointName, $fixture.endpointNameForDelete)) {
            $target = if ($endpointName -eq $fixture.endpointName) { 'app1.contoso.internal' } else { 'app2.contoso.internal' }
            $null = New-AzPrivateTrafficManagerEndpoint @common -PrivateTrafficManagerProfileName $fixture.profileName -Name $endpointName -Target $target -EndpointStatus Enabled -Weight 50 -Confirm:$false
        }
        foreach ($mapName in @($fixture.topologyMapName, $fixture.topologyMapNameForDelete)) {
            $null = New-AzPrivateTrafficManagerTopologyMap @common -Name $mapName -Location global -CatchAllSiteName $fixture.siteName -Site @(@{ Name = $fixture.siteName; ProbingGatewayId = @($GatewayId); VirtualNetworkId = @($fixture.virtualNetworkId) }) -Confirm:$false
        }
        $null = New-AzPrivateTrafficManagerSite @common -TopologyMapName $fixture.topologyMapName -Name $fixture.siteNameForDelete -ProbingGatewayId @($GatewayId) -Confirm:$false
    }
    else {
        foreach ($recording in Get-ChildItem (Join-Path $PSScriptRoot '*-AzPrivateTrafficManager*.Recording.json')) { Copy-Item $recording.FullName $WorkDirectory }
        $module.OnNewRequest = $null
        $env:AzPSAutorestTestPlaybackMode = 'true'
    }
    $fixture | ConvertTo-Json -Depth 20 | Set-Content (Join-Path $WorkDirectory 'env.json') -Encoding utf8NoBOM
    $TestMode = $Mode.ToLowerInvariant()
    $TestName = $null
    $mockingPath = Get-Item (Join-Path $WorkDirectory 'HttpPipelineMocking.ps1')
    $result = Invoke-Pester -Script @($testFiles | ForEach-Object { Join-Path $WorkDirectory $_.Name }) -PassThru -OutputFormat NUnitXml -OutputFile (Join-Path $WorkDirectory 'results.xml')
    Write-Host "Legacy $Mode results: $($result.PassedCount) passed; $($result.FailedCount) failed; $($result.SkippedCount) skipped."
    if ($result.FailedCount -gt 0) { throw "Legacy $Mode failed. Results: $WorkDirectory/results.xml" }
}
finally {
    $module.OnNewRequest = $onNewRequest
    $env:AzPSAutorestTestPlaybackMode = $previousPlayback
    if ($created) {
        foreach ($ownedProfile in @(Get-AzPrivateTrafficManagerProfile -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -ErrorAction Stop)) {
            Remove-AzPrivateTrafficManagerProfile -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -PrivateTrafficManagerProfileName $ownedProfile.Name -Confirm:$false -ErrorAction Stop
        }
        foreach ($ownedMap in @(Get-AzPrivateTrafficManagerTopologyMap -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -ErrorAction Stop)) {
            Remove-AzPrivateTrafficManagerTopologyMap -SubscriptionId $SubscriptionId -ResourceGroupName $groupName -Name $ownedMap.Name -Confirm:$false -ErrorAction Stop
        }
        az group delete --name $groupName --subscription $SubscriptionId --yes
        if ($LASTEXITCODE -ne 0) { throw "Cleanup failed for owned group $groupName" }
        $exists = az group exists --name $groupName --subscription $SubscriptionId
        if ($LASTEXITCODE -ne 0 -or $exists -ne 'false') { throw "Cleanup unverified for $groupName" }
        Write-Host "Cleanup verified: $groupName no longer exists."
    }
}
if ($Mode -eq 'Record') {
    $sanitizedDirectory = Join-Path $WorkDirectory 'sanitized'
    $null = New-Item -ItemType Directory -Path $sanitizedDirectory
    foreach ($recording in Get-ChildItem (Join-Path $WorkDirectory '*.Recording.json')) {
        & (Join-Path $PSScriptRoot 'Convert-OctoberRecording.ps1') -InputPath $recording.FullName -OutputPath (Join-Path $sanitizedDirectory $recording.Name) -SubscriptionId $SubscriptionId -OwnedResourceGroupName $groupName
    }
    & (Join-Path $PSScriptRoot 'Convert-OctoberRecording.ps1') -InputPath (Join-Path $WorkDirectory 'env.json') -OutputPath (Join-Path $sanitizedDirectory 'env.json') -SubscriptionId $SubscriptionId
    Write-Host "Sanitized recordings: $sanitizedDirectory"
}