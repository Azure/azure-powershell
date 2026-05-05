if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageCacheAutoImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageCacheAutoImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

New-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoImportPrefix @('/path1', '/path2')

# Sleep for 30 seconds to let the job start
Start-Sleep -Seconds 30

Describe 'Update-AzStorageCacheAutoImportJob' {
    It 'UpdateExpanded' {
        {
            Update-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Tag @{'Environment'='Test'; 'Purpose'='AutoImport'}
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $jsonString = '{"tags":{"Environment":"Test","Purpose":"AutoImport"}}'
            Update-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -JsonString $jsonString
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'update-autoimportjob.json'
            '{"tags":{"Environment":"Test","Purpose":"AutoImport"}}' | Out-File -FilePath $jsonFilePath -Encoding utf8
            Update-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -JsonFilePath $jsonFilePath
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityAmlFilesystemExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Update-AzStorageCacheAutoImportJob -AmlFilesystemInputObject $identity -Name 'sampleAutoImportJob' -Tag @{'Environment'='Test'}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoImportJobName = "sampleAutoImportJob"

            Update-AzStorageCacheAutoImportJob -InputObject $identity -Tag @{'Environment'='Production'}
        } | Should -Not -Throw
    }
}

Remove-AzStorageCacheAutoImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleAutoImportJob' -ResourceGroupName 'acctest43511' -Confirm:$false
