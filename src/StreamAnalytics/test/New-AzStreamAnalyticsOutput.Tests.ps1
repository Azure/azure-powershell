$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStreamAnalyticsOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStreamAnalyticsOutput' {
  It 'CreateExpanded' {
    New-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.output01 -File (Join-Path $PSScriptRoot 'template-json\StroageAccount.json')
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.output01
    $result.Name | Should -Be $env.output01
  }
}
