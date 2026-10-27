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
    BeforeAll {
        $managedHostPoolName = $env.HostPool + '-shc-update-managed'
        $ephemeralHostPoolName = $env.HostPool + '-shc-update-ephemeral'
        $configurationHostPoolNames = @($managedHostPoolName, $ephemeralHostPoolName)
        foreach ($hostPoolName in $configurationHostPoolNames) {
            $hostPool = New-TestSessionHostConfigurationHostPool -TestEnvironment $env -Name $hostPoolName
        }
    }

    It 'UpdateExpanded' {    
        $configuration = New-TestSessionHostConfiguration -TestEnvironment $env -HostPoolName $managedHostPoolName -DiskMode Managed
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroup `
        -HostPoolName $managedHostPoolName `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion

        $configuration.VMNamePrefix | Should -Be $env.SHMSessionHostNamePrefix
    }

    It 'UpdateExpanded_EphemeralOSDisk' {
        $configuration = New-TestSessionHostConfiguration -TestEnvironment $env -HostPoolName $ephemeralHostPoolName -DiskMode Ephemeral
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroup `
        -HostPoolName $ephemeralHostPoolName `
        -VMNamePrefix $env.SHMSessionHostNamePrefix `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion `
        -DiffDiskSettingOption "Local" `
        -DiffDiskSettingPlacement "TempDisk"

        $configuration.DiffDiskSettingOption | Should -Be "Local"
        $configuration.DiffDiskSettingPlacement | Should -Be "TempDisk"
        $configuration.ManagedDiskType | Should -BeNullOrEmpty
    }

    AfterAll {
        foreach ($hostPoolName in $configurationHostPoolNames) {
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $hostPoolName
        }
    }
}
