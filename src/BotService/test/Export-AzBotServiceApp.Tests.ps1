$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBotServiceDownloadApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Export-AzBotServiceApp' {
    It '__AllParameterSets' {
        $DownloadAppService = Export-AzBotServiceApp -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService2
        $DownloadAppService.Name | Should -Be $env.NewBotService2
    }
}
