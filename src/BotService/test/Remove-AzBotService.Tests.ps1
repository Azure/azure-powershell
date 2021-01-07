$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzBotService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzBotService' {
    It 'Delete' {
        Remove-AzBotService -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService1
        $GetServiceList = Get-AzBotService
        $GetServiceList.Name | Should -Not -Contain $env.WebApplicationName1
    }

    It 'DeleteViaIdentity' {
        $GetService = Get-AzBotService -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService2
        Remove-AzBotService -InputObject $GetService
        $GetServiceList = Get-AzBotService
        $GetServiceList.Name | Should -Not -Contain $env.WebApplicationName2
    }
}
