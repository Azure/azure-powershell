$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHealthBot.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzHealthBot' {
    It 'List1' {
        $getHealthBotList = Get-AzHealthBot
        $getHealthBotList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $getHealthBot = Get-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName
        $getHealthBot.Name | Should -Be $env.HealthBot1
    }

    It 'List' {
        $getHealthBotList = Get-AzHealthBot -ResourceGroupName $env.ResourceGroupName
        $getHealthBotList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $getHealthBotExample = Get-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName
        $getHealthBot = Get-AzHealthBot -InputObject $getHealthBotExample
        $getHealthBot.Name | Should -Be $env.HealthBot1
    }
}
