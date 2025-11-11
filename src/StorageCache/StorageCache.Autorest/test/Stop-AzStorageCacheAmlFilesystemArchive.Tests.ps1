if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzStorageCacheAmlFilesystemArchive'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzStorageCacheAmlFilesystemArchive.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzStorageCacheAmlFilesystemArchive' {
    It 'Cancel' {
        {
            # Start archive operation first
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName "acctest43511" -ResourceGroupName "acctest43511" -FilesystemPath "/" -PassThru
            $result | Should -Not -Be $null
            
            # Wait 10 seconds for the archive operation to start
            Start-Sleep -Seconds 10
            
            # Stop the archive operation
            $stopResult = Stop-AzStorageCacheAmlFilesystemArchive -AmlFilesystemName "acctest43511" -ResourceGroupName "acctest43511" -PassThru
            $stopResult | Should -Not -Be $null
            
            # Poll until HsmArchiveStatus becomes null
            do {
                Start-Sleep -Seconds 10
                $filesystem = Get-AzStorageCacheAmlFileSystem -Name "acctest43511" -ResourceGroupName "acctest43511"
            } while ($null -ne $filesystem.HsmArchiveStatus)
        } | Should -Not -Throw
    }

    It 'CancelViaIdentity' {
        {
            # Create identity object for the AML filesystem
            $identity = @{
                SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
                ResourceGroupName = "acctest43511"
                AmlFilesystemName = "acctest43511"
            }
            
            # Start archive operation using identity
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -InputObject $identity -FilesystemPath "/" -PassThru
            $result | Should -Not -Be $null
            
            # Wait 10 seconds for the archive operation to start
            Start-Sleep -Seconds 10
            
            # Stop the archive operation using identity
            $stopResult = Stop-AzStorageCacheAmlFilesystemArchive -InputObject $identity -PassThru
            $stopResult | Should -Not -Be $null
            
            # Poll until HsmArchiveStatus becomes null
            do {
                Start-Sleep -Seconds 10
                $filesystem = Get-AzStorageCacheAmlFileSystem -Name "acctest43511" -ResourceGroupName "acctest43511"
            } while ($null -ne $filesystem.HsmArchiveStatus)
        } | Should -Not -Throw
    }
}
