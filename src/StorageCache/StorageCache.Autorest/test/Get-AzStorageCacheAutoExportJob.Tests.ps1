if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageCacheAutoExportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageCacheAutoExportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

New-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoExportJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoExportPrefix @('/path1')

Describe 'Get-AzStorageCacheAutoExportJob' {
    It 'List' {
        {
            Get-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoExportJob' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Get-AzStorageCacheAutoExportJob -Name sampleAutoExportJob -AmlFilesystemInputObject $identity

        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoExportJobName = "sampleAutoExportJob"

            Get-AzStorageCacheAutoExportJob -InputObject $identity
        } | Should -Not -Throw
    }
}

Remove-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoExportJob' -ResourceGroupName 'acctest43511' -Confirm:$false
