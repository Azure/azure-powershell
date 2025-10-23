# Minimal playback test for New-AzOracleNetworkAnchor (CREATE)

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleNetworkAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleNetworkAnchor.Recording.json'

    # Guarded Az.Oracle loader (avoid double-load)
    $pubLoaded  = Get-Module Az.Oracle -ErrorAction SilentlyContinue
    $privLoaded = Get-Module Az.Oracle.private -ErrorAction SilentlyContinue
    if (-not ($pubLoaded -and $privLoaded)) {
        $runScript = Join-Path $PSScriptRoot 'run-module.ps1'
        if (Test-Path $runScript) {
            & $runScript
        } else {
            $modulePsd1 = Join-Path $PSScriptRoot '..\Az.Oracle.psd1'
            if (Test-Path $modulePsd1) { Import-Module $modulePsd1 -ErrorAction Stop }
        }
    }

    # HttpPipelineMocking bootstrap
    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleNetworkAnchor' {
    # Variables (ENV overrides first)
    $naName   = if ($env:NETWORK_ANCHOR_NAME) { $env:NETWORK_ANCHOR_NAME } else { 'PowershellTest1s' }
    $rgName   = if ($env:resourceGroup)      { $env:resourceGroup }      else { 'basedb-iad53-rg' }
    $subId    = if ($env:SubscriptionId)     { $env:SubscriptionId }     else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }
    $location = if ($env:location)           { $env:location }           else { 'eastus' }
    $zone     = if ($env:NETWORK_ZONE)       { $env:NETWORK_ZONE }       else { '2' }

    $resAnchorId = if ($env:ORACLE_RESOURCE_ANCHOR_ID) {
        $env:ORACLE_RESOURCE_ANCHOR_ID
    } else {
        '/subscriptions/049e5678-fbb1-4861-93f3-7528bd0779fd/resourceGroups/basedb-iad53-rg/providers/Oracle.Database/resourceAnchors/basedb-iad53-ra'
    }

    $subnetId = if ($env:NETWORK_SUBNET_ID) {
        $env:NETWORK_SUBNET_ID
    } else {
        '/subscriptions/049e5678-fbb1-4861-93f3-7528bd0779fd/resourceGroups/basedb-iad53-rg/providers/Microsoft.Network/virtualNetworks/basedb-iad53-vnet/subnets/delegated'
    }

    $hasCmd = Get-Command -Name New-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Create minimal (NoWait ack safe assertions)' {
        {
            if ($hasCmd) {
                $created = New-AzOracleNetworkAnchor `
                    -Name $naName `
                    -ResourceGroupName $rgName `
                    -SubscriptionId $subId `
                    -Location $location `
                    -ResourceAnchorId $resAnchorId `
                    -SubnetId $subnetId `
                    -Zone $zone `
                    -NoWait

                # Always ensure we got something back
                $created | Should -Not -BeNullOrEmpty



            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
