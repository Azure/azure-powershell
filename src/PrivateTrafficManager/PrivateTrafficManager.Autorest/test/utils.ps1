function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    # Generate unique names for test resources
    $randomStr = RandomString -allChars $false -len 6
    $env.AddWithCache("randomStr", $randomStr, $UsePreviousConfigForRecord)

    $rgName = "ptm-test-rg-$randomStr"
    $env.AddWithCache("resourceGroupName", $rgName, $UsePreviousConfigForRecord)

    $location = "eastus"
    $env.AddWithCache("location", $location, $UsePreviousConfigForRecord)

    $profileName = "ptm-profile-$randomStr"
    $env.AddWithCache("profileName", $profileName, $UsePreviousConfigForRecord)

    $profileNameForDelete = "ptm-profile-del-$randomStr"
    $env.AddWithCache("profileNameForDelete", $profileNameForDelete, $UsePreviousConfigForRecord)

    $endpointName = "ptm-ep-$randomStr"
    $env.AddWithCache("endpointName", $endpointName, $UsePreviousConfigForRecord)

    $endpointNameForDelete = "ptm-ep-del-$randomStr"
    $env.AddWithCache("endpointNameForDelete", $endpointNameForDelete, $UsePreviousConfigForRecord)

    $healthPolicyName = "ptm-hp-$randomStr"
    $env.AddWithCache("healthPolicyName", $healthPolicyName, $UsePreviousConfigForRecord)

    $healthPolicyNameForDelete = "ptm-hp-del-$randomStr"
    $env.AddWithCache("healthPolicyNameForDelete", $healthPolicyNameForDelete, $UsePreviousConfigForRecord)

    $topologyMapName = "ptm-topo-$randomStr"
    $env.AddWithCache("topologyMapName", $topologyMapName, $UsePreviousConfigForRecord)

    $topologyMapNameForDelete = "ptm-topo-del-$randomStr"
    $env.AddWithCache("topologyMapNameForDelete", $topologyMapNameForDelete, $UsePreviousConfigForRecord)

    $siteName = "ptm-site-$randomStr"
    $env.AddWithCache("siteName", $siteName, $UsePreviousConfigForRecord)

    $siteNameForDelete = "ptm-site-del-$randomStr"
    $env.AddWithCache("siteNameForDelete", $siteNameForDelete, $UsePreviousConfigForRecord)

    # Create resource group
    Write-Host "Creating resource group '$rgName' in '$location'"
    New-AzResourceGroup -Name $rgName -Location $location

    # Create a PTM profile for Get/Update/Endpoint/HealthPolicy tests
    Write-Host "Creating PTM profile '$profileName'"
    $profileJson = @{
        location = "global"
        properties = @{
            trafficRoutingMethod = "Weighted"
            profileStatus = "Enabled"
            customTopologyMapMode = "Disabled"
            dnsConfig = @{
                recordType = "CNAME"
                ttl = 60
            }
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName $profileName `
        -ResourceGroupName $rgName -JsonString $profileJson

    # Create a PTM profile for delete test
    Write-Host "Creating PTM profile '$profileNameForDelete' (for delete test)"
    $profileDelJson = @{
        location = "global"
        properties = @{
            trafficRoutingMethod = "Priority"
            profileStatus = "Enabled"
            customTopologyMapMode = "Disabled"
            dnsConfig = @{
                recordType = "CNAME"
                ttl = 60
            }
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName $profileNameForDelete `
        -ResourceGroupName $rgName -JsonString $profileDelJson

    # Create an endpoint for Get/Update tests
    Write-Host "Creating endpoint '$endpointName'"
    New-AzPrivateTrafficManagerEndpoint -Name $endpointName `
        -PrivateTrafficManagerProfileName $profileName `
        -ResourceGroupName $rgName `
        -Target "app1.contoso.internal" `
        -EndpointStatus "Enabled" -Weight 50

    # Create an endpoint for delete test
    Write-Host "Creating endpoint '$endpointNameForDelete' (for delete test)"
    New-AzPrivateTrafficManagerEndpoint -Name $endpointNameForDelete `
        -PrivateTrafficManagerProfileName $profileName `
        -ResourceGroupName $rgName `
        -Target "app2.contoso.internal" `
        -EndpointStatus "Enabled" -Weight 50

    # Create a health policy for Get/Update tests
    Write-Host "Creating health policy '$healthPolicyName'"
    $hpJson = @{
        properties = @{
            name = $healthPolicyName
            probeConfig = @{
                protocol = "HTTPS"
                port = 443
                path = "/health"
                intervalInSeconds = 30
                timeoutInSeconds = 10
                toleratedNumberOfFailures = 3
            }
        }
        kind = "Probe"
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerHealthPolicy -Name $healthPolicyName `
        -PrivateTrafficManagerProfileName $profileName `
        -ResourceGroupName $rgName `
        -JsonString $hpJson

    # Create a health policy for delete test
    Write-Host "Creating health policy '$healthPolicyNameForDelete' (for delete test)"
    $hpDelJson = @{
        properties = @{
            name = $healthPolicyNameForDelete
            probeConfig = @{
                protocol = "HTTP"
                port = 80
                path = "/ping"
                intervalInSeconds = 30
                timeoutInSeconds = 10
                toleratedNumberOfFailures = 3
            }
        }
        kind = "Probe"
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerHealthPolicy -Name $healthPolicyNameForDelete `
        -PrivateTrafficManagerProfileName $profileName `
        -ResourceGroupName $rgName `
        -JsonString $hpDelJson

    # Create a topology map for Get/Update/Site tests
    Write-Host "Creating topology map '$topologyMapName'"
    $topoJson = @{
        location = "global"
        properties = @{
            sites = @()
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerTopologyMap -Name $topologyMapName `
        -ResourceGroupName $rgName -JsonString $topoJson

    # Create a topology map for delete test
    Write-Host "Creating topology map '$topologyMapNameForDelete' (for delete test)"
    $topoDelJson = @{
        location = "global"
        properties = @{
            sites = @()
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerTopologyMap -Name $topologyMapNameForDelete `
        -ResourceGroupName $rgName -JsonString $topoDelJson

    # Create a site for Get/Update tests
    Write-Host "Creating site '$siteName'"
    $siteJson = @{
        properties = @{
            virtualNetworkIds = @()
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerSite -Name $siteName `
        -TopologyMapName $topologyMapName `
        -ResourceGroupName $rgName `
        -JsonString $siteJson

    # Create a site for delete test
    Write-Host "Creating site '$siteNameForDelete' (for delete test)"
    $siteDelJson = @{
        properties = @{
            virtualNetworkIds = @()
        }
    } | ConvertTo-Json -Depth 5
    New-AzPrivateTrafficManagerSite -Name $siteNameForDelete `
        -TopologyMapName $topologyMapName `
        -ResourceGroupName $rgName `
        -JsonString $siteDelJson

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host "Cleaning up resource group '$($env.resourceGroupName)'"
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

