$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStreamAnalyticsOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStreamAnalyticsOutput' {
  It 'Delete' {
    New-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01 -File (Join-Path $PSScriptRoot 'template-json\StroageAccount.json')
    Remove-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.output01
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02
    $result.Name | Should -Not -Contain $env.output01
  }

  It 'DeleteViaIdentity' {
    New-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.output02 -File (Join-Path $PSScriptRoot 'template-json\StroageAccount.json')
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.output02
    Remove-AzStreamAnalyticsOutput -InputObject $result
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job02
    $result.Name | Should -Not -Contain $env.output02
  }
}
