$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStreamAnalyticsInput.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStreamAnalyticsInput' {
  It 'UpdateExpanded' {
    { Update-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.input01 -File (Join-Path $PSScriptRoot 'template-json\IotHub.json') } | Should -Not -Throw
  }

  It 'UpdateViaIdentityExpanded'  {
    $result = Get-AzStreamAnalyticsInput -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.input01
    { Update-AzStreamAnalyticsInput -InputObject $result -File (Join-Path $PSScriptRoot 'template-json\IotHub.json') } | Should -Not -Throw
  }
}
