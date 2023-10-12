if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareVMGuestAgent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareVMGuestAgent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareVMGuestAgent' {
    It 'CreateExpanded' -Skip {
        New-AzConnectedVMwareVMGuestAgent -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-vm-ins-ps" -CredentialsUsername "arcvmware" -CredentialsPassword $Secure_String_Pwd -ProvisioningAction "install"
    }

    It 'Get' -Skip {
        $vm = Get-AzConnectedVMwareVMGuestAgent -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-vm-ins-ps"
        $vm.Name | Should -Be "default"
    }
}
