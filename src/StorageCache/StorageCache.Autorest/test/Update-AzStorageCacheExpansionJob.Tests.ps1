if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageCacheExpansionJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageCacheExpansionJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageCacheExpansionJob' {
    It 'UpdateExpanded' {
        {
            Update-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -Tag @{"testKey" = "testValue"}
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $json = @{
                tags = @{
                    "jsonKey" = "jsonValue"
                }
            } | ConvertTo-Json -Depth 3

            Update-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -JsonString $json
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
                Update-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -JsonFilePath $tempFile.FullName
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

            Update-AzStorageCacheExpansionJob -Name sampleCreateExpanded -AmlFilesystemInputObject $identity -Tag @{"amlKey" = "amlValue"}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.ExpansionJobName = "sampleCreateExpanded"

            Update-AzStorageCacheExpansionJob -InputObject $identity -Tag @{"idKey" = "idValue"}
        } | Should -Not -Throw
    }
}
