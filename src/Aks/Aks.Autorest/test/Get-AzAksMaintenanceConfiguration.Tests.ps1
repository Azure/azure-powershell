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
        $MaintenanceConfigs.Name.Contains('aks_maintenance_config1') | Should -Be $true
        $MaintenanceConfigs.Name.Contains('aks_maintenance_config2') | Should -Be $true
    }

    It 'Get' {
        $MaintenanceConfig = Get-AzAksMaintenanceConfiguration -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -ConfigName 'aks_maintenance_config1'
        $MaintenanceConfig.Count | Should -Be 1
        $MaintenanceConfig.Name | Should -Be 'aks_maintenance_config1'
    }

    It 'GetViaIdentity' {
        $InputObject = @{Id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/aks-test/providers/Microsoft.ContainerService/managedClusters/aks/maintenanceConfigurations/aks_maintenance_config1" }
        $MaintenanceConfig = Get-AzAksMaintenanceConfiguration -InputObject $InputObject
        $MaintenanceConfig.Count | Should -Be 1
        $MaintenanceConfig.Name | Should -Be 'aks_maintenance_config1'
    }
}
