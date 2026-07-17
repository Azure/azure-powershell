if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageFileServiceUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageFileServiceUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageFileServiceUsage' {
    It 'Get' {

        $usage = Get-AzStorageFileServiceUsage -ResourceGroupName $env.ResourceGroupName -StorageAccountName $env.FilePV2AccountName

        $usage.Name | should -Be "default"
        $usage.ResourceGroupName | should -Be $env.ResourceGroupName
        $usage.BurstingConstantBurstFloorIops | should -BeGreaterThan 0
        $usage.BurstingConstantBurstIoScalar | should -BeGreaterThan 0
        $usage.BurstingConstantBurstTimeframeSecond | should -BeGreaterThan 0
        $usage.FileShareLimitMaxProvisionedBandwidthMiBPerSec | should -BeGreaterThan 0
        $usage.FileShareLimitMaxProvisionedIops | should -BeGreaterThan 0
        $usage.FileShareLimitMaxProvisionedStorageGiB | should -BeGreaterThan 0
        $usage.FileShareLimitMinProvisionedBandwidthMiBPerSec | should -BeGreaterThan 0
        $usage.FileShareLimitMinProvisionedIops | should -BeGreaterThan 0
        $usage.FileShareLimitMinProvisionedStorageGiB | should -BeGreaterThan 0
        $usage.FileShareRecommendationBandwidthScalar | should -BeGreaterThan 0
        $usage.FileShareRecommendationBaseBandwidthMiBPerSec | should -BeGreaterThan 0
        $usage.FileShareRecommendationBaseIops | should -BeGreaterThan 0
        $usage.FileShareRecommendationIoScalar | should -BeGreaterThan 0
        $usage.LiveShareFileShareCount | should -Be 0
        $usage.LiveShareProvisionedBandwidthMiBPerSec | should -Be 0
        $usage.LiveShareProvisionedIops | should -Be 0
        $usage.LiveShareProvisionedStorageGiB | should -Be 0
        $usage.SoftDeletedShareFileShareCount | should -Be 0
        $usage.SoftDeletedShareProvisionedBandwidthMiBPerSec | should -Be 0
        $usage.SoftDeletedShareProvisionedIops | should -Be 0
        $usage.SoftDeletedShareProvisionedStorageGiB | should -Be 0
        $usage.StorageAccountLimitMaxFileShare | should -BeGreaterThan 0
        $usage.StorageAccountLimitMaxProvisionedBandwidthMiBPerSec | should -BeGreaterThan 0
        $usage.StorageAccountLimitMaxProvisionedIops | should -BeGreaterThan 0
        $usage.StorageAccountLimitMaxProvisionedStorageGiB | should -BeGreaterThan 0

    }
}
