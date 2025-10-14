if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageCacheAutoExportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageCacheAutoExportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageCacheAutoExportJob' {
    It 'Delete' {
        {
            New-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleDelete' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoExportPrefix @('/path1')
            Start-Sleep 30
            Remove-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleDelete' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityAmlFilesystem' {
        {
            New-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleDeleteAmlId' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoExportPrefix @('/path1')
            Start-Sleep 30
            
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Remove-AzStorageCacheAutoExportJob -Name sampleDeleteAmlId -AmlFilesystemInputObject $identity -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            New-AzStorageCacheAutoExportJob -AmlFilesystemName 'acctest43511' -Name 'sampleDeleteId' -ResourceGroupName 'acctest43511' -Location 'Canada Central' -AutoExportPrefix @('/path1')
            Start-Sleep 30
            
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.AutoExportJobName = "sampleDeleteId"

            Remove-AzStorageCacheAutoExportJob -InputObject $identity -Confirm:$false
        } | Should -Not -Throw
    }
}
