if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksMaintenanceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksMaintenanceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksMaintenanceConfiguration' {
    It 'List' {
        $MaintenanceConfigs = Get-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName
        $MaintenanceConfigs.Count | Should -Be 2
        $MaintenanceConfigs.Name.Contains('aksManagedAutoUpgradeSchedule') | Should -Be $true
        $MaintenanceConfigs.Name.Contains('default') | Should -Be $true
    }

    It 'Get' {
        $MaintenanceConfig = Get-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName 'aksManagedAutoUpgradeSchedule'
        $MaintenanceConfig.Count | Should -Be 1
        $MaintenanceConfig.Name | Should -Be 'aksManagedAutoUpgradeSchedule'
    }

    It 'GetViaIdentity' {
        $InputObject = @{Id = "/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/maintenanceConfigurations/aksManagedAutoUpgradeSchedule" }
        $MaintenanceConfig = Get-AzAksMaintenanceConfiguration -InputObject $InputObject
        $MaintenanceConfig.Count | Should -Be 1
        $MaintenanceConfig.Name | Should -Be 'aksManagedAutoUpgradeSchedule'
    }
}
