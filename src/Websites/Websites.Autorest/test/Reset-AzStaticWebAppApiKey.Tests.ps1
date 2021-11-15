$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzStaticWebAppApiKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Reset-AzStaticWebAppApiKey' {
    It 'ResetExpanded' {
        { Reset-AzStaticWebAppApiKey -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 } | Should -Not -Throw
    }

    It 'ResetViaIdentityExpanded' {
        { 
          $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 
          Reset-AzStaticWebAppApiKey -InputObject $web
        } | Should -Not -Throw
    }
}
