if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWvdSessionHostConfiguration' {
    It 'UpdateExpanded' {    
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroupPersistent `
        -HostPoolName $env.SHMHostPoolPersistent `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion

        $configuration.VMNamePrefix | Should -Be $env.SHMSessionHostNamePrefix
    }

    It 'UpdateExpanded_EphemeralOSDisk' {
        # An ephemeral OS disk (DiffDiskSettingOption 'Local') can only be backed by a Premium_LRS or
        # StandardSSD_LRS managed disk. Combining it with Standard_LRS raises MultipleDiskTypesSpecified,
        # so the DiffDiskSettingPlacement scenario is validated separately from the case above.
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroupPersistent `
        -HostPoolName $env.SHMHostPoolPersistent `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
        -ManagedDiskType "Premium_LRS" `
        -DiffDiskSettingOption "Local" `
        -DiffDiskSettingPlacement "TempDisk"

        $configuration.DiffDiskSettingOption | Should -Be "Local"
        $configuration.DiffDiskSettingPlacement | Should -Be "TempDisk"
    }
}
