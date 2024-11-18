if(($null -eq $TestName) -or ($TestName -contains 'New-AzComputeFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzComputeFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzComputeFleet' {
    It 'Create' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
            $fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
            $fleet = New-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName "testFleet5" -Resource $fleet
            $fleet.Name | Should -Be "testFleet5"
        } | Should -Not -Throw
    }
    
    It 'CreateViaIdentity' {
        {
            $fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -FleetName $env.FleetName
            $fleet = New-AzComputeFleet -InputObject $fleet -Resource $fleet
            $fleet.Name | Should -Be $env.FleetName
        } | Should -Not -Throw
    }
}
