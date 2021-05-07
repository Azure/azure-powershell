$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStaticWebApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStaticWebApp' {
    It 'UpdateExpanded' {
        { Update-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
          $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
          Update-AzStaticWebApp -InputObject $web
        } | Should -Not -Throw
    }
}
