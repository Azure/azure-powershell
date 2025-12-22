if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudBareMetalMachineReplace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudBareMetalMachineReplace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudBareMetalMachineReplace' {
    # NOTE: A bug has been opened for this action - please see #868274.
    It 'ReplaceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Replace' {
        {
            $bmmConfig = $global:config.AzNetworkCloudBareMetalMachine
            $securePassword = ConvertTo-SecureString $bmmConfig.bmcCredsPassword -AsPlainText -Force
            Invoke-AzNetworkCloudBareMetalMachineReplace -Name $bmmConfig.replaceBmmName -ResourceGroupName $bmmConfig.bmmRg -SubscriptionId $bmmConfig.subscriptionId -BmcCredentialsPassword $securePassword -BmcCredentialsUsername $bmmConfig.bmcCredsUsername -BmcMacAddress $bmmConfig.bmcMacAddress -BootMacAddress $bmmConfig.bootMacAddress -MachineName $bmmConfig.newMachineName -SerialNumber $bmmConfig.serialNumber -SafeguardMode $bmmConfig.safeguardMode -StoragePolicy $bmmConfig.storagePolicy
        } | Should -Not -Throw
    }

    It 'ReplaceViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReplaceViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
