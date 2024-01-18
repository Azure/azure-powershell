$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBotService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzBotService' {
    It 'List1' {
        $GetServiceList = Get-AzBotService
        $GetServiceList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $GetService = Get-AzBotService -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService1
        $GetService.Name | Should -Be $env.NewBotService1
    }

    It 'List' {
        $GetServiceList = Get-AzBotService -ResourceGroupName $env.ResourceGroupName
        $GetServiceList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $GetService = Get-AzBotService -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService1
        $GetBot = Get-AzBotService -InputObject $GetService
        $GetBot.Name | Should -Be $env.NewBotService1
    }
}
