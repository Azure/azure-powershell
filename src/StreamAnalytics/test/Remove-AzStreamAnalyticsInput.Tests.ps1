$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStreamAnalyticsInput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStreamAnalyticsInput' {
  It 'Delete' {
    New-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input01 -File (Join-Path $PSScriptRoot 'template-json\IotHub.json')
    Remove-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input01
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02
    $result.Name | Should -Not -Contain $env.input01
  }

  It 'DeleteViaIdentity' {
    New-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input02 -File (Join-Path $PSScriptRoot 'template-json\IotHub.json')
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.input02
    Remove-AzStreamAnalyticsInput -InputObject $result
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job02
    $result.Name | Should -Not -Contain $env.input02
  }
}
