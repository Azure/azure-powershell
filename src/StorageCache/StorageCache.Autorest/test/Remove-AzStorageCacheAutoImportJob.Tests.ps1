if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageCacheAutoImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageCacheAutoImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageCacheAutoImportJob' {
    It 'Delete' {
        {
            # Create the auto import job first
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            
            # Now remove it
            Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityAmlFilesystem' {
        {
            # Create the auto import job first
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob2' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            
            # Now remove it using identity
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Remove-AzStorageCacheAutoImportJob -AmlFilesystemInputObject $identity -Name 'sampleAutoImportJob2' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            # Create the auto import job first
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob3' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            
            # Now remove it using full identity
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoImportJobName = "sampleAutoImportJob3"

            Remove-AzStorageCacheAutoImportJob -InputObject $identity -Confirm:$false
        } | Should -Not -Throw
    }
}
