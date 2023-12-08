$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStreamAnalyticsTransformation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStreamAnalyticsTransformation' {
  It 'CreateExpanded' {
    New-AzStreamAnalyticsTransformation -ResourceGroupName $env.resourceGroup -JobName $env.job03 -Name $env.trnasf01 -StreamingUnit 6 -Query "SELECT * INTO $($env.output01) FROM $($env.input01) HAVING Temperature > 27"
    $result = Get-AzStreamAnalyticsTransformation -ResourceGroupName $env.resourceGroup -JobName $env.job03 -Name $env.trnasf01
    $result.Name | Should -Be $env.trnasf01
  }
}
