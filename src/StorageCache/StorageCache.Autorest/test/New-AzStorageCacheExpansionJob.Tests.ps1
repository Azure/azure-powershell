if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageCacheExpansionJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageCacheExpansionJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageCacheExpansionJob' {
    It 'CreateExpanded' {
        {
            $job = New-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest0040' -Location 'australiaeast' -NewStorageCapacityTiB 56
            Wait-AzStorageCacheExpansionJobProvisioned -AmlFilesystemName 'acctest0040' -Name 'sampleCreateExpanded' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $json = @{
                location = "australiaeast"
                properties = @{
                    newStorageCapacityTiB = 64
                }
            } | ConvertTo-Json -Depth 3

            $job = New-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateJson' -ResourceGroupName 'acctest0040' -JsonString $json
            Wait-AzStorageCacheExpansionJobProvisioned -AmlFilesystemName 'acctest0040' -Name 'sampleCreateJson' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $json = @{
                location = "australiaeast"
                properties = @{
                    newStorageCapacityTiB = 72
                }
            } | ConvertTo-Json -Depth 3

            $tempFile = New-TemporaryFile
            $json | Out-File -FilePath $tempFile.FullName -Encoding UTF8

            try {
                $job = New-AzStorageCacheExpansionJob -AmlFilesystemName 'acctest0040' -Name 'sampleCreateFile' -ResourceGroupName 'acctest0040' -JsonFilePath $tempFile.FullName
                Wait-AzStorageCacheExpansionJobProvisioned -AmlFilesystemName 'acctest0040' -Name 'sampleCreateFile' -ResourceGroupName 'acctest0040'
            } finally {
                Remove-Item $tempFile.FullName -Force -ErrorAction SilentlyContinue
            }
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityAmlFilesystemExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"

            $job = New-AzStorageCacheExpansionJob -AmlFilesystemInputObject $identity -Name 'sampleCreateAmlId' -Location 'australiaeast' -NewStorageCapacityTiB 80
            Wait-AzStorageCacheExpansionJobProvisioned -AmlFilesystemName 'acctest0040' -Name 'sampleCreateAmlId' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.StorageCacheIdentity]::new()
            $identity.AmlFilesystemName = "acctest0040"
            $identity.ResourceGroupName = "acctest0040"
            $identity.SubscriptionId = "733b22ab-69e4-4f63-a7e5-0f2312c2e35f"
            $identity.ExpansionJobName = "sampleCreateIdentity"

            $job = New-AzStorageCacheExpansionJob -InputObject $identity -Location 'australiaeast' -NewStorageCapacityTiB 88
            Wait-AzStorageCacheExpansionJobProvisioned -AmlFilesystemName 'acctest0040' -Name 'sampleCreateIdentity' -ResourceGroupName 'acctest0040'
        } | Should -Not -Throw
    }
}
