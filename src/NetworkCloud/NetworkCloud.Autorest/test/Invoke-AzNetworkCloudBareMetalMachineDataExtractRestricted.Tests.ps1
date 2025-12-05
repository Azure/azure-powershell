if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted' {
    It 'RunViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunExpanded' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            $command = @{
                command   = $bmmConfig.dataExtractRestrictedCommand
                arguments = $bmmConfig.dataExtractRestrictedArgs
            }

            Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName $bmmConfig.commandsBmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId -Command $command -LimitTimeSecond $bmmConfig.limitTimeSeconds
        } | Should -Not -Throw
    }
}
