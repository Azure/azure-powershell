if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStorageCacheAmlFileSystemArchive'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageCacheAmlFileSystemArchive.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzStorageCacheAmlFileSystemArchive' {
    It 'ArchiveExpanded' {
        {
            # Test archive operation using expanded parameters
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName "acctest43511" -ResourceGroupName "acctest43511" -FilesystemPath "/" -PassThru
            $result | Should -Not -Be $null

            while ('Completed' -ne $(Get-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511').HsmArchiveStatus.StatusState)
            {
                Start-Sleep -Seconds 10
            }
        } | Should -Not -Throw
    }

    It 'ArchiveViaJsonString' {
        {
            # Test archive operation using JSON string
            $jsonString = @"
{
    "filesystemPath": "/"
}
"@
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName "acctest43511" -ResourceGroupName "acctest43511" -JsonString $jsonString -PassThru
            $result | Should -Not -Be $null
            
            while ('Completed' -ne $(Get-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511').HsmArchiveStatus.StatusState)
            {
                Start-Sleep -Seconds 10
            }
        } | Should -Not -Throw
    }

    It 'ArchiveViaJsonFilePath' {
        {
            # Test archive operation using JSON file path
            $jsonContent = @"
{
    "filesystemPath": "/"
}
"@
            $jsonFilePath = Join-Path $PSScriptRoot 'test-archive.json'
            $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -AmlFilesystemName "acctest43511" -ResourceGroupName "acctest43511" -JsonFilePath $jsonFilePath -PassThru
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
            $result | Should -Not -Be $null
            
            while ('Completed' -ne $(Get-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511').HsmArchiveStatus.StatusState)
            {
                Start-Sleep -Seconds 10
            }
        } | Should -Not -Throw
    }

    It 'ArchiveViaIdentityExpanded' {
        {
            # Test archive operation using identity object
            $identity = @{
                SubscriptionId = "0a715a3b-8a16-43ba-a6bb-1e38ad050791"
                ResourceGroupName = "acctest43511"
                AmlFilesystemName = "acctest43511"
            }
            $result = Invoke-AzStorageCacheAmlFileSystemArchive -InputObject $identity -FilesystemPath "/" -PassThru
            $result | Should -Not -Be $null
            
            while ('Completed' -ne $(Get-AzStorageCacheAmlFileSystem -Name 'acctest43511' -ResourceGroupName 'acctest43511').HsmArchiveStatus.StatusState)
            {
                Start-Sleep -Seconds 10
            }
        } | Should -Not -Throw
    }
}
