if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareVM' {
    It 'CreateExpanded' {
        New-AzConnectedVMwareVM -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InfrastructureProfileInventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/vm-1528583" -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-guest9-ps"
    }

    It 'Get' {
        $vm = Get-AzConnectedVMwareVM -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-guest9-ps"
        $vm.Name | Should -Be "default"
    }

    It 'Delete' -Skip {
        Remove-AzConnectedVMwareVM -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.HybridCompute/machines/test-machine-guest9-ps"
    }
}