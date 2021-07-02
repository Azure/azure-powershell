$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStaticWebAppBuild.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStaticWebAppBuild' {
    It 'Delete' {
      $environmentName = '8'
      { Remove-AzStaticWebAppBuild -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -EnvironmentName $environmentName } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
      $environmentName = '10'
      { 
        $build = Get-AzStaticWebAppBuild -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -EnvironmentName $environmentName
        Remove-AzStaticWebAppBuild -InputObject $build
      } | Should -Not -Throw
    }
}
