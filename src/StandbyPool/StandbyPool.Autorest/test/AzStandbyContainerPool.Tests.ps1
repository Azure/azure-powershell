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
            $standbycgpool = New-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-sdks -SubscriptionId $env.SubscriptionId -Location eastasia -MaxReadyCapacity 1 -RefillPolicy always -ContainerProfileId "/subscriptions/$($env.SubscriptionId)/resourcegroups/test-sdks/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG" -ProfileRevision 1 -SubnetId @{id="/subscriptions/$($env.SubscriptionId)/resourceGroups/test-sdks/providers/Microsoft.Network/virtualNetworks/test-sdks-vnet/subnets/default"}
            $standbycgpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $standbycgpool = Get-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-sdks -SubscriptionId $env.SubscriptionId
            $standbycgpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'GetRuntimeView' {
        {
            $standbycgpoolRuntimeView = Get-AzStandbyContainerGroupPoolStatus -Name testCGPool -ResourceGroupName test-sdks -SubscriptionId $env.SubscriptionId
            $standbycgpoolRuntimeView.Name | Should -Be latest
            $standbycgpoolRuntimeView.InstanceCountSummary.Count | Should BeGreaterThan 0
            $standbycgpoolRuntimeView.InstanceCountSummary.instanceCountsByState.Count | Should BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName test-sdks -SubscriptionId $env.SubscriptionId -NoWait
        } | Should -Not -Throw
    }
}
