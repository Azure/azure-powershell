$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsTransformation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsTransformation' {
  It 'Get' {
    $result = Get-AzStreamAnalyticsTransformation -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.trnasf01
    $result.Name | Should -Be $env.trnasf01   
  }

  It 'GetViaIdentity' {
    $result = Get-AzStreamAnalyticsTransformation -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.trnasf01
    $result = Get-AzStreamAnalyticsTransformation -InputObject $result
    $result.Name | Should -Be $env.trnasf01 
  }
}
