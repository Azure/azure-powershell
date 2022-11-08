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
    It 'CreateExpanded' -Skip {
        New-AzConnectedVMwareVM -Name $env.vmName -ResourceGroupName $env.resourceGroupName -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc3/InventoryItems/vm-109264"
    }

    It 'Get' {
        $vm = Get-AzConnectedVMwareVM -ResourceGroupName $env.ResourceGroupName -Name $env.vmName
        $vm.Name | Should -Be $env.vmName
    }

    It 'Delete' -Skip {
        Remove-AzConnectedVMwareVM -Name $env.vmName -ResourceGroupName $env.resourceGroupName
    }
}
