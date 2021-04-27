$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebAppFunctionAppSetting.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebAppFunctionAppSetting' {
    It 'List' {
      # NOTE: This API is not allowed when using user provided functions.
      $settingList = Get-AzStaticWebAppFunctionAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01
      $settingList.Count | Should -BeGreaterOrEqual 1
    }
}
