if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoverySupercomputer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoverySupercomputer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoverySupercomputer' {
    It 'Delete' {
        Remove-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNew -SubscriptionId $env.SubscriptionId -Confirm:$false
        Start-TestSleep -Seconds 10
        { Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNew -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' -Skip {
        $identity | Remove-AzDiscoverySupercomputer -Confirm:$false
        Start-TestSleep -Seconds 10
        { Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForNewJson -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
