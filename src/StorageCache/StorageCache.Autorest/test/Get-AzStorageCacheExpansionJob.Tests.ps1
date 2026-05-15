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
            Get-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest43511' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest43511'
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAmlFilesystem' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            Get-AzStorageCacheExpansionJob -Name sampleCreateExpanded -AmlFilesystemInputObject $identity
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
            $identity.ExpansionJobName = "sampleCreateExpanded"

            Get-AzStorageCacheExpansionJob -InputObject $identity
        } | Should -Not -Throw
    }
}
