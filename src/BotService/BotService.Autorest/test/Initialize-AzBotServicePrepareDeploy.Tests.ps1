$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzBotServicePrepareDeploy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Initialize-AzBotServicePrepareDeploy' {
    It '__AllParameterSets' -Skip {
        Initialize-AzBotServicePrepareDeploy -CodeDir $env.NewBotService2 -ProjFileName EchoBot.csproj
        $IsExit = Test-Path "$($env.NewBotService2)\.deployment"
        $IsExit | Should -Be $True
    }
}
