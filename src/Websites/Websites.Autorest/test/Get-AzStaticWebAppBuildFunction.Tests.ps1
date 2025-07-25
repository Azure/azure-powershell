$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebAppBuildFunction.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebAppBuildFunction' {
    It 'List' {
      # NOTE: This API is not allowed when using user provided functions.
      $functionList = Get-AzStaticWebAppBuildFunction -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -EnvironmentName 'default'
      $functionList.Count | Should -BeGreaterOrEqual 1
    }
}
