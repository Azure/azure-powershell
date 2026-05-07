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
            Remove-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest0040' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"

            Remove-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateAmlId' -ResourceGroupName 'acctest0040' -Confirm:$false
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"
            $identity.ExpansionJobName = "sampleDeleteId"

            Remove-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateIdentity' -ResourceGroupName 'acctest0040' -Confirm:$false
        } | Should -Not -Throw
    }
}
