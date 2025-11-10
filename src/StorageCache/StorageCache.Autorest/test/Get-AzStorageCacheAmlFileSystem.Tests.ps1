if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageCacheAmlFileSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageCacheAmlFileSystem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageCacheAmlFileSystem' {
    It 'List' {
        {
            # List all AML file systems in the subscription
            $result = Get-AzStorageCacheAmlFileSystem
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            # Get specific AML file system by name and resource group
            $result = Get-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511'
            $result | Should -Not -Be $null
            $result.Name | Should -Be 'acctest43511'
            $result.ResourceGroupName | Should -Be 'acctest43511'
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            # List AML file systems in a specific resource group
            $result = Get-AzStorageCacheAmlFileSystem -ResourceGroupName 'acctest43511'
            $result | Should -Not -Be $null
            # Should contain at least the test AML file system
            $result.Name | Should -Contain 'acctest43511'
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            # Create identity object for the AML file system
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest43511"
            $identity.ResourceGroupName = "acctest43511"
            $identity.SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"

            # Get AML file system using identity object
            $result = Get-AzStorageCacheAmlFileSystem -InputObject $identity
            $result | Should -Not -Be $null
            $result.Name | Should -Be 'acctest43511'
            $result.ResourceGroupName | Should -Be 'acctest43511'
        } | Should -Not -Throw
    }
}
