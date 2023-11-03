$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStreamAnalyticsJob' {
    It 'Delete' {
      Remove-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job03
      $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup
      $result.Name | Should -Not -Contain $env.job03
    }

    It 'DeleteViaIdentity' {
      $jobName = $env.job03 + "new"
      New-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $jobName -Location $env.location -SkuName 'Standard'
      $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $jobName
      Remove-AzStreamAnalyticsJob -InputObject $result
      $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup
      $result.Name | Should -Not -Contain $jobName
    }
}
