if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzComputeFleet' {
    It 'Delete' {
        {
            Remove-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName2
            $fleetList = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId
            $fleetList.Name | Should -Not -Contain $env.FleetName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName3
            Remove-AzComputeFleet -InputObject $fleet
            $fleetList = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId
            $fleetList.Name | Should -Not -Contain $env.FleetName3
        } | Should -Not -Throw
    }
}
