if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageCacheAutoExportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageCacheAutoExportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

New-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleUpdateJob' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoExportPrefix @('/path1')
Start-Sleep 30

Describe 'Update-AzStorageCacheAutoExportJob' {
    It 'UpdateExpanded' {
        {
            Update-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleUpdateJob' -ResourceGroupName 'acctest43511' -Tag @{"testKey" = "testValue"}
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $json = @{
                tags = @{
                    "jsonKey" = "jsonValue"
                }
            } | ConvertTo-Json -Depth 3
            
            Update-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleUpdateJob' -ResourceGroupName 'acctest43511' -JsonString $json
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            $json = @{
                tags = @{
                    "fileKey" = "fileValue"
                }
            } | ConvertTo-Json -Depth 3
            
            $tempFile = New-TemporaryFile
            $json | Out-File -FilePath $tempFile.FullName -Encoding UTF8
            
            try {
                Update-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleUpdateJob' -ResourceGroupName 'acctest43511' -JsonFilePath $tempFile.FullName
            } finally {
                Remove-Item $tempFile.FullName -Force -ErrorAction SilentlyContinue
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityAmlFilesystemExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Update-AzStorageCacheAutoExportJob -Name sampleUpdateJob -AmlFilesystemInputObject $identity -Tag @{"amlKey" = "amlValue"}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoExportJobName = "sampleUpdateJob"

            Update-AzStorageCacheAutoExportJob -InputObject $identity -Tag @{"idKey" = "idValue"}
        } | Should -Not -Throw
    }
}

Remove-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleUpdateJob' -ResourceGroupName 'acctest43511' -Confirm:$false
