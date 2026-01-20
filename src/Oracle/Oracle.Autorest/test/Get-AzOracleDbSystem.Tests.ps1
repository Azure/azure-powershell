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

    It 'Get by name and resource group' -Skip {
        {
            $dbs = Get-AzOracleDbSystem -Name $env.baseDbName -ResourceGroupName $env.resourceAnchorRgName -SubscriptionId $env.networkAnchorSubId
            $dbs | Should -Not -BeNullOrEmpty
            $dbs.Name | Should -Be $env.baseDbName
        } | Should -Not -Throw
    }

    It 'List in subscription' -Skip {
        {
            $list = Get-AzOracleDbSystem -SubscriptionId $env.networkAnchorSubId
            $list.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
