$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStreamAnalyticsOutput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStreamAnalyticsOutput' {
  It 'UpdateExpanded' {
    { Update-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01 -File (Join-Path $PSScriptRoot 'template-json\StroageAccount.json') } | Should -Not -Throw
  }

  It 'UpdateViaIdentityExpanded'  {
    $result = Get-AzStreamAnalyticsOutput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.output01
    { Update-AzStreamAnalyticsOutput -InputObject $result -File (Join-Path $PSScriptRoot 'template-json\StroageAccount.json') } | Should -Not -Throw
  }
}
