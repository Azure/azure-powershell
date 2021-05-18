$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebAppBuild.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebAppBuild' {
    It 'List' {
      $buildList = Get-AzStaticWebAppBuild -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $buildList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
      $build = Get-AzStaticWebAppBuild -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default'
      $build.Name | Should -Be 'default'
    }

    It 'GetViaIdentity'  {
      $build = Get-AzStaticWebAppBuild -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default' 
      $build = Get-AzStaticWebAppBuild -InputObject $build
      $build.Name | Should -Be 'default'
    }
}
