$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzBotService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzBotService' {
    It 'UpdateExpanded' {
        $UpdateBotService = Update-AzBotService -Name $env.NewBotService2 -ResourceGroupName $env.ResourceGroupName -Kind bot
        $UpdateBotService.Kind | Should -Be 'bot'
    }

    It 'UpdateViaIdentityExpanded' {
        $GetService = Get-AzBotService -ResourceGroupName $env.ResourceGroupName -Name $env.NewBotService2
        $UpdateBotService = Update-AzBotService -InputObject $GetService -Kind sdk
        $UpdateBotService.Kind | Should -Be 'sdk'
    }
}
