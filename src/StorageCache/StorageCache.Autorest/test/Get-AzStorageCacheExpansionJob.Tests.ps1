if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageCacheExpansionJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageCacheExpansionJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageCacheExpansionJob' {
    It 'List' {
        {
            Get-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"

            Get-AzStorageCacheExpansionJob -Name sampleCreateExpanded -AmlFilesystemInputObject $identity
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"
            $identity.ExpansionJobName = "sampleCreateExpanded"

            Get-AzStorageCacheExpansionJob -InputObject $identity
        } | Should -Not -Throw
    }
}
