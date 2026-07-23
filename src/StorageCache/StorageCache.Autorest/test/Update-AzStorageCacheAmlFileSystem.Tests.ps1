if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageCacheAmlFileSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageCacheAmlFileSystem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageCacheAmlFileSystem' {
    It 'UpdateExpanded' {
        {
            # Update AML filesystem with tags using expanded parameters
            Update-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511' -Tag @{'Environment'='Test'; 'Purpose'='AmlFileSystem'; 'Updated'='True'}
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            # Update AML filesystem with tags using JSON string
            $jsonString = '{"tags":{"Environment":"Production","Purpose":"AmlFileSystem","Method":"JsonString"}}'
            Update-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511' -JsonString $jsonString
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            # Update AML filesystem with tags using JSON file path
            $jsonFilePath = Join-Path $PSScriptRoot 'update-amlfilesystem.json'
            '{"tags":{"Environment":"Staging","Purpose":"AmlFileSystem","Method":"JsonFile"}}' | Out-File -FilePath $jsonFilePath -Encoding utf8
            Update-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511' -JsonFilePath $jsonFilePath
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            # Update AML filesystem with tags using identity object
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Update-AzStorageCacheAmlFileSystem -InputObject $identity -Tag @{'Environment'='Development'; 'Purpose'='AmlFileSystem'; 'Method'='Identity'}
        } | Should -Not -Throw
    }
}
