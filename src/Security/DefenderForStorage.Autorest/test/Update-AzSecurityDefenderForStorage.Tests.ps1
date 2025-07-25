if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSecurityDefenderForStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSecurityDefenderForStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSecurityDefenderForStorage' {
    It 'UpdateExpandedEnableATP' {
        { 
            $defenderForStorageSettings = Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId0 -IsEnabled
            $defenderForStorageSettings.IsEnabled |  Should -Be 'True'
        } | Should -Not -Throw
    }

    It 'UpdateExpandedEnableATPAndScanningServices' {
        { 
            $defenderForStorageSettings = Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId1 -IsEnabled -OnUploadIsEnabled -SensitiveDataDiscoveryIsEnabled
            $defenderForStorageSettings.OnUploadIsEnabled |  Should -Be 'True'
            $defenderForStorageSettings.SensitiveDataDiscoveryIsEnabled |  Should -Be 'True'
        } | Should -Not -Throw
    }

    It 'UpdateExpandedDisableATPWhileScanningServicesAreOn' {
        { 
            Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId1 -IsEnabled:$false
        } | Should -Throw
    }

    It 'UpdateExpandedEnableScanningServicesWithoutATP' {
        { 
            Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId2 -OnUploadIsEnabled -SensitiveDataDiscoveryIsEnabled
        } | Should -Throw
    }

    It 'UpdateExpandedPassInvalidCap' {
        { 
            Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId1 -IsEnabled -OnUploadIsEnabled -OnUploadCapGbPerMonth -20
        } | Should -Throw
    }

    It 'UpdateExpandedDisableATPAndScanning' {
        { 
            $defenderForStorageSettings = Update-AzSecurityDefenderForStorage -ResourceId $env.ResourceId1 -IsEnabled:$false -OnUploadIsEnabled:$false -SensitiveDataDiscoveryIsEnabled:$false
            $defenderForStorageSettings.IsEnabled | Should -Be 'False'
            $defenderForStorageSettings.OnUploadIsEnabled | Should -Be 'False'
            $defenderForStorageSettings.SensitiveDataDiscoveryIsEnabled | Should -Be 'False'
        } | Should -Not -Throw
    }
}
