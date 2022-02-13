$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsInput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsInput' {
  It 'List' {
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01
    $result.Count | Should -Be 1
  }

  It 'Get' {
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.input01
    $result.Name | Should -Be $env.input01   
  }

  It 'GetViaIdentity' {
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.input01
    $result = Get-AzStreamAnalyticsInput -InputObject $result
    $result.Name | Should -Be $env.input01 
  }
}
