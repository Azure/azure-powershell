if(($null -eq $TestName) -or ($TestName -contains 'Sync-AzCommvaultStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzCommvaultStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# The first test creates the storage that the sync tests refresh. The last test removes it again.
Describe 'Sync-AzCommvaultStorage' {
    BeforeAll {
        # Not named $name: the test framework's It function has a parameter called Name that would shadow it.
        $storageName = 'azps-stg-syn'
    }

    It 'Refresh' {
        $null = New-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -Location $env.Location -StorageClassType 'HOT'
        $storage = Sync-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName
        $storage.Name | Should -Be $storageName
    }

    It 'RefreshViaIdentityCloudAccount' {
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $storage = Sync-AzCommvaultStorage -CloudAccountInputObject @{ Id = $account.Id } -Name $storageName
        $storage.Name | Should -Be $storageName
    }

    It 'RefreshViaIdentity' {
        $existing = Get-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName
        $storage = Sync-AzCommvaultStorage -InputObject @{ Id = $existing.Id }
        $storage.Name | Should -Be $storageName
    }

    It 'Cleanup' {
        Remove-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName
        { Get-AzCommvaultStorage -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -CloudAccountName $env.CloudAccountName -Name $storageName -ErrorAction Stop } | Should -Throw
    }
}
