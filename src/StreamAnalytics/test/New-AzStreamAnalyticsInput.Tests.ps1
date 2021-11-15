$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStreamAnalyticsInput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStreamAnalyticsInput' {
  It 'CreateExpanded' {
    New-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input01 -File (Join-Path $PSScriptRoot 'template-json\IotHub.json')
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input01
    $result.Name | Should -Be $env.input01
  }
}
