if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageCacheAmlFileSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageCacheAmlFileSystem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageCacheAmlFileSystem' {
    It 'Delete' {
        {
            # Remove AML filesystem using direct parameters
            # This removes the filesystem created in New-AzStorageCacheAmlFileSystem CreateExpanded test
            $result = Remove-AzStorageCacheAmlFileSystem -Name "acctest43511-2" -ResourceGroupName "acctest43511" -PassThru
            $result | Should -Be $true
            
            # Poll until the filesystem is completely deleted
            do {
                Start-Sleep -Seconds 10
                try {
                    $filesystem = Get-AzStorageCacheAmlFileSystem -Name "acctest43511-2" -ResourceGroupName "acctest43511" -ErrorAction SilentlyContinue
                } catch {
                    $filesystem = $null
                }
            } while ($null -ne $filesystem)
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            # Remove AML filesystem using identity object
            # This removes the filesystem created in New-AzStorageCacheAmlFileSystem CreateViaJsonString test
            $identity = @{
                SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
                ResourceGroupName = "acctest43511"
                AmlFilesystemName = "acctest43511-3"
            }
            $result = Remove-AzStorageCacheAmlFileSystem -InputObject $identity -PassThru
            $result | Should -Be $true
            
            # Poll until the filesystem is completely deleted
            do {
                Start-Sleep -Seconds 10
                try {
                    $filesystem = Get-AzStorageCacheAmlFileSystem -Name "acctest43511-3" -ResourceGroupName "acctest43511" -ErrorAction SilentlyContinue
                } catch {
                    $filesystem = $null
                }
            } while ($null -ne $filesystem)
        } | Should -Not -Throw
    }
}
