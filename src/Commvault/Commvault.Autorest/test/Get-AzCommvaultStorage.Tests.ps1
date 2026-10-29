if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCommvaultStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommvaultStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCommvaultStorage' {
    It 'List' {
        $storages = @(Get-AzCommvaultStorage -CloudAccountName $env.CloudAccountName -ResourceGroupName $env.ResourceGroupName)
        $storages.Count | Should -BeGreaterOrEqual 1
        $storages.Name | Should -Contain $env.StorageName
    }

    It 'Get' {
        $storage = Get-AzCommvaultStorage -CloudAccountName $env.CloudAccountName -Name $env.StorageName -ResourceGroupName $env.ResourceGroupName
        $storage.Name | Should -Be $env.StorageName
        $storage.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'GetViaIdentityCloudAccount' {
        $account = Get-AzCommvaultCloudAccount -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $storage = Get-AzCommvaultStorage -CloudAccountInputObject @{ Id = $account.Id } -Name $env.StorageName
        $storage.Name | Should -Be $env.StorageName
    }

    It 'GetViaIdentity' {
        $storage = Get-AzCommvaultStorage -CloudAccountName $env.CloudAccountName -Name $env.StorageName -ResourceGroupName $env.ResourceGroupName
        $byIdentity = Get-AzCommvaultStorage -InputObject @{ Id = $storage.Id }
        $byIdentity.Name | Should -Be $env.StorageName
        $byIdentity.Id | Should -Be $storage.Id
    }
}
