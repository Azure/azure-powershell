$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Publish-AzBotServiceApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Publish-AzBotServiceApp' {
    It '__AllParameterSets' -Skip {
        $PublishService = Publish-AzBotServiceApp -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService2 -CodeDir "./$($env.NewBotService2)"
        $PublishService.Name | Should -Be $env.NewBotService2
    }
}
