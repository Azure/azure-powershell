if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShare' {
    BeforeAll {
        # Ensure the test file share exists before running Get tests
        $existingShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01 -ErrorAction SilentlyContinue
        if (-not $existingShare) {
            New-AzFileShare -ResourceName $env.fileShareName01 `
                           -ResourceGroupName $env.resourceGroup `
                           -Location $env.location `
                           -MediaTier "SSD" `
                           -Protocol "NFS" `
                           -ProvisionedStorageGiB 1024 `
                           -ProvisionedIoPerSec 4024 `
                           -ProvisionedThroughputMiBPerSec 228 `
                           -Redundancy "Local" `
                           -PublicNetworkAccess "Enabled" `
                           -NfProtocolPropertyRootSquash "NoRootSquash" `
                           -Tag @{"environment" = "test"; "purpose" = "testing"}
        }
    }

    AfterAll {
        # Clean up the test file share
        Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01 -ErrorAction SilentlyContinue
    }

    It 'List' {
        {
            $config = Get-AzFileShare -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzFileShare
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config.Name | Should -Be $env.fileShareName01
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $fileShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config = Get-AzFileShare -InputObject $fileShare
            $config.Name | Should -Be $env.fileShareName01
        } | Should -Not -Throw
    }
}
