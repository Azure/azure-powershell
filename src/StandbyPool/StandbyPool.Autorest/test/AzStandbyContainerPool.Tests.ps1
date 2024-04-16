if(($null -eq $TestName) -or ($TestName -contains 'AzStandbyContainerPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStandbyContainerPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStandbyContainerPool' {
    It 'CreateExpanded' {
        {
            $standbyvmpool = New-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId -Location eastus -MaxReadyCapacity 1 -RefillPolicy always -ContainerProfileId "/subscriptions/$($env.SubscriptionId)/resourcegroups/test-rg/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG" -ProfileRevision 1 -SubnetId @{id="/subscriptions/$($env.SubscriptionId)/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-rg-vnet/subnets/default"}
            $standbyvmpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $standbyvmpool = Get-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId
            $standbyvmpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId -NoWait
        } | Should -Not -Throw
    }
}
