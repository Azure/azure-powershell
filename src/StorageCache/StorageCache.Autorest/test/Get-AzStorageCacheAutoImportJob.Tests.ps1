if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageCacheAutoImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageCacheAutoImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')

Describe 'Get-AzStorageCacheAutoImportJob' {
    It 'List' {
        {
            Get-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Get-AzStorageCacheAutoImportJob -Name sampleAutoImportJob -AmlFilesystemInputObject $identity

        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoImportJobName = "sampleAutoImportJob"

            Get-AzStorageCacheAutoImportJob -InputObject $identity
        } | Should -Not -Throw
    }
}

Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Confirm:$false
