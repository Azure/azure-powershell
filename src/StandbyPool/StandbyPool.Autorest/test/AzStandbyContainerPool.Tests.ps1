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
            $standbycgpool = New-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName standbypool-powershell-sdk -SubscriptionId $env.SubscriptionId -Location centralindia -MaxReadyCapacity 3 -RefillPolicy always -ContainerProfileId "/subscriptions/$($env.SubscriptionId)/resourcegroups/standbypool-powershell-sdk/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG" -ProfileRevision 1 -Zone @("1", "2", "3")
            $standbycgpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $standbycgpool = Get-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName standbypool-powershell-sdk -SubscriptionId $env.SubscriptionId
            $standbycgpool.Name | Should -Be testCGPool
        } | Should -Not -Throw
    }

    It 'GetRuntimeView' {
        {
            $standbycgpoolRuntimeView = Get-AzStandbyContainerGroupPoolStatus -Name testCGPool -ResourceGroupName standbypool-powershell-sdk -SubscriptionId $env.SubscriptionId
            $standbycgpoolRuntimeView.Name | Should -Be latest
            $standbycgpoolRuntimeView.InstanceCountSummary.Count | Should BeGreaterThan 0
            $standbycgpoolRuntimeView.InstanceCountSummary.instanceCountsByState.Count | Should BeGreaterThan 0
            $standbycgpoolRuntimeView.StatusCode | Should -Not -BeNullOrEmpty   
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzStandbyContainerGroupPool -Name testCGPool -ResourceGroupName standbypool-powershell-sdk -SubscriptionId $env.SubscriptionId -NoWait
        } | Should -Not -Throw
    }
}
