$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsOutput' {
  It 'List' {
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01
    $result.Count | Should -Be 1
  }

  It 'Get' {
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01
    $result.Name | Should -Be $env.output01   
  }

  It 'GetViaIdentity' {
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01
    $result = Get-AzStreamAnalyticsOutput -InputObject $result
    $result.Name | Should -Be $env.output01 
  }
}
