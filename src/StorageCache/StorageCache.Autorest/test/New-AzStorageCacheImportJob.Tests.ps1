if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageCacheImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageCacheImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageCacheImportJob' {
    It 'CreateExpanded' {
        {
            $job = New-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -ImportPrefix @('/path1', '/path2')
            Start-Sleep 30
            Remove-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $json = @{
                location = "Canada Central"
                properties = @{
                    importPrefixes = @("/path1", "/path2")
                }
            } | ConvertTo-Json -Depth 3
            
            $job = New-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateJson' -ResourceGroupName 'acctest43511' -JsonString $json
            Start-Sleep 30
            Remove-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateJson' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $json = @{
                location = "Canada Central"
                properties = @{
                    importPrefixes = @("/path1", "/path2")
                }
            } | ConvertTo-Json -Depth 3
            
            $tempFile = New-TemporaryFile
            $json | Out-File -FilePath $tempFile.FullName -Encoding UTF8
            
            try {
                $job = New-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateFile' -ResourceGroupName 'acctest43511' -JsonFilePath $tempFile.FullName
                Start-Sleep 30
                Remove-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateFile' -ResourceGroupName 'acctest43511' -Confirm:$false
            } finally {
                Remove-Item $tempFile.FullName -Force -ErrorAction SilentlyContinue
            }
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityAmlFilesystemExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            $job = New-AzStorageCacheImportJob -AmlFilesystemInputObject $identity -Name 'sampleCreateAmlId' -Location 'Canada Central' -ImportPrefix @('/path1', '/path2')
            Start-Sleep 30
            Remove-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateAmlId' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.ImportJobName = "sampleCreateIdentity"

            $job = New-AzStorageCacheImportJob -InputObject $identity -Location 'Canada Central' -ImportPrefix @('/path1', '/path2')
            Start-Sleep 30
            Remove-AzStorageCacheImportJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateIdentity' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }
}
