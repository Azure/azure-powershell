if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryNodePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryNodePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryNodePool' {
    It 'Delete' {
        Remove-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNew -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentitySupercomputer' -Skip {
        $supercomputer = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        Remove-AzDiscoveryNodePool -SupercomputerInputObject $supercomputer `
            -Name $env.NodePoolNameForNewViaPar -Confirm:$false
        { Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNewViaPar -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' -Skip {
        $identity | Remove-AzDiscoveryNodePool -Confirm:$false
        { Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForNewJson -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
