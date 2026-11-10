if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCommvaultCloudAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommvaultCloudAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCommvaultCloudAccount' {
    It 'List' {
        $accounts = @(Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId)
        $accounts.Count | Should -BeGreaterOrEqual 1
        $accounts.Name | Should -Contain $env.CloudAccountName
    }

    It 'Get' {
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $account.Name | Should -Be $env.CloudAccountName
        $account.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List1' {
        $accounts = @(Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName)
        $accounts.Count | Should -BeGreaterOrEqual 1
        $accounts.Name | Should -Contain $env.CloudAccountName
    }

    It 'GetViaIdentity' {
        $account = Get-AzCommvaultCloudAccount -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.CloudAccountName
        $byIdentity = Get-AzCommvaultCloudAccount -InputObject @{ Id = $account.Id }
        $byIdentity.Name | Should -Be $env.CloudAccountName
        $byIdentity.Id | Should -Be $account.Id
    }
}
