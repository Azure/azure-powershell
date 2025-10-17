# Minimal playback test for Get-AzOracleDbSystem

if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleDbSystem'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleDbSystem.Recording.json'

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleDbSystem' {
    # Vars (ENV overrides; keep in sync with your Create test)
    $dbsName = if ($env:DBSYSTEM_NAME) { $env:DBSYSTEM_NAME } else { 'PowershellSdk' }
    $rgName  = if ($env:resourceGroup) { $env:resourceGroup } else { 'basedb-rg929-ti-iad52' }
    $subId   = if ($env:SubscriptionId){ $env:SubscriptionId } else { '049e5678-fbb1-4861-93f3-7528bd0779fd' }

    It 'Get by name and resource group' {
        {
            $dbs = Get-AzOracleDbSystem -Name $dbsName -ResourceGroupName $rgName -SubscriptionId $subId
            $dbs | Should -Not -BeNullOrEmpty
            $dbs.Name | Should -Be $dbsName
        } | Should -Not -Throw
    }

    It 'List in subscription' {
        {
            $list = Get-AzOracleDbSystem -SubscriptionId $subId
            $list.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
