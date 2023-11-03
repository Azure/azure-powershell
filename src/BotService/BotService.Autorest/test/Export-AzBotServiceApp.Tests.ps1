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

#this case use the cmdlet 'Invoke-WebRequest' and it can not be recorded.
Describe 'Export-AzBotServiceApp' {
    It '__AllParameterSets' -Skip {
        $DownloadAppService = Export-AzBotServiceApp -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService2
        $DownloadAppService.Name | Should -Be $env.NewBotService2
    }
}
