# Minimal playback test for Get-AzOracleNetworkAnchor

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleNetworkAnchor'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleNetworkAnchor.Recording.json'

    # Guarded Az.Oracle loader
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

Describe 'Get-AzOracleNetworkAnchor' {
    # Match defaults used in the CREATE test
    $naName  = if ($env:NETWORK_ANCHOR_NAME) { $env:NETWORK_ANCHOR_NAME } else { 'PowershellTest1s' }
    $rgName  = if ($env:resourceGroup)      { $env:resourceGroup }      else { 'basedb-iad53-rg' }
    $subId   = if ($env:SubscriptionId)     { $env:SubscriptionId }     else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Get by name and resource group' {
        {
            $na = Get-AzOracleNetworkAnchor -Name $naName -ResourceGroupName $rgName -SubscriptionId $subId
            $na | Should -Not -BeNullOrEmpty
            $na.Name | Should -Be $naName
        } | Should -Not -Throw
    }

    It 'List in subscription (sanity)' {
        {
            $list = Get-AzOracleNetworkAnchor -SubscriptionId $subId
            $list.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
