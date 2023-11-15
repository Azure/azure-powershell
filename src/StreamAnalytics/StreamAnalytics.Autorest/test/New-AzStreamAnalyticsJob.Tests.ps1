$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStreamAnalyticsJob' {
    It 'CreateExpanded'  {
      $result = New-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job03 -Location $env.location -SkuName 'Standard'
      $result.ProvisioningState | Should -Be 'Succeeded'
    }
}
