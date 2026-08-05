if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageCacheExpansionJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageCacheExpansionJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageCacheExpansionJob' {
    It 'Delete' {
        {
            Remove-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Remove-AzStorageCacheExpansionJob -Name 'sampleCreateAmlId' -AmlFilesystemInputObject $identity -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.ExpansionJobName = "sampleDeleteId"

            Remove-AzStorageCacheExpansionJob -InputObject $identity -Confirm:$false
        } | Should -Not -Throw
    }
}
