if(($null -eq $TestName) -or ($TestName -contains 'Get-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzComputeFleet' {
    It 'ListBySubscriptionId' {
        {
            $fleetList = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId
            $fleetList.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $fleet.Name | Should -Be $env.FleetName
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        {
            $fleetList = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName
            $fleetList.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $fleet = Get-AzComputeFleet -InputObject $fleet
            $fleet.Name | Should -Be $env.FleetName
        } | Should -Not -Throw
    }
}
