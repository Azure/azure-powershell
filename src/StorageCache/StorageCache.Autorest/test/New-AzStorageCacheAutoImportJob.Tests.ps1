if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageCacheAutoImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageCacheAutoImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageCacheAutoImportJob' {
    It 'CreateExpanded' {
        {
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJob' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $jsonString = '{"location":"canadacentral","properties":{"autoImportPrefixes":["/path1","/path2"],"conflictResolutionMode":"Skip"}}'
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJobJson' -ResourceGroupName 'acctest43511' -JsonString $jsonString
            Start-Sleep -Seconds 30
            Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJobJson' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-autoimportjob.json'
            '{"location":"canadacentral","properties":{"autoImportPrefixes":["/path1","/path2"],"conflictResolutionMode":"Skip"}}' | Out-File -FilePath $jsonFilePath -Encoding utf8
            New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJobFile' -ResourceGroupName 'acctest43511' -JsonFilePath $jsonFilePath
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
            Start-Sleep -Seconds 30
            Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'testAutoImportJobFile' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityAmlFilesystemExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            New-AzStorageCacheAutoImportJob -AmlFilesystemInputObject $identity -Name 'testAutoImportJobIdentity' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            Remove-AzStorageCacheAutoImportJob -AmlFilesystemInputObject $identity -Name 'testAutoImportJobIdentity' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoImportJobName = "testAutoImportJobIdentity2"

            New-AzStorageCacheAutoImportJob -InputObject $identity -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')
            Start-Sleep -Seconds 30
            
            # Create new identity for removal since the original was used for creation
            $removeIdentity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $removeIdentity.AmlFilesystemName = "acctest43511"
            $removeIdentity.ResourceGroupName = "acctest43511"
            $removeIdentity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $removeIdentity.AutoImportJobName = "testAutoImportJobIdentity2"
            
            Remove-AzStorageCacheAutoImportJob -InputObject $removeIdentity -Confirm:$false
        } | Should -Not -Throw
    }
}
