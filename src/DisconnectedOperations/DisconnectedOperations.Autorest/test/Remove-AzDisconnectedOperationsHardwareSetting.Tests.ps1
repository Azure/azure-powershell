if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDisconnectedOperationsHardwareSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDisconnectedOperationsHardwareSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDisconnectedOperationsHardwareSetting' {
    It 'Delete' {
        # Create the Resource
        New-AzDisconnectedOperationsHardwareSetting -Name $env.Name -ResourceGroupName $env.ResourceGroupName -HardwareSettingName "default2" -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"2411.2","solutionBuilderExtension":"xyz","deviceId":"0f76428c-6fe6-476d-9943-6e994a1e849b"}}'

        # Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw
    }

    It 'DeleteViaIdentityDisconnectedOperation' {
        # Create the Resource
        New-AzDisconnectedOperationsHardwareSetting -Name $env.Name -ResourceGroupName $env.ResourceGroupName -HardwareSettingName "default2" -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"2411.2","solutionBuilderExtension":"xyz","deviceId":"0f76428c-6fe6-476d-9943-6e994a1e849b"}}'

        # Delete the Resource using DisconnectedOperationIdentity
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -DisconnectedOperationInputObject $disconnectedOperationInputObject

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw
    }

    It 'DeleteViaIdentity' {
        # Create the Resource
        New-AzDisconnectedOperationsHardwareSetting -Name $env.Name -ResourceGroupName $env.ResourceGroupName -HardwareSettingName "default2" -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"2411.2","solutionBuilderExtension":"xyz","deviceId":"0f76428c-6fe6-476d-9943-6e994a1e849b"}}'

        # Delete the Resource using DisconnectedOperationIdentity
        $inputObject = @{
            "HardwareSettingName" = "default2";
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        Remove-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw
    }
}
