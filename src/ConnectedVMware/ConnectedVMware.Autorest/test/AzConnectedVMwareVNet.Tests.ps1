if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareVNet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareVNet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareVNet' {
    It 'CreateExpanded' {
        New-AzConnectedVMwareVNet -Name $env.vNetName -ResourceGroupName $env.resourceGroupName -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/network-563661"
    }
    
    It 'Get' {
        $vnet = Get-AzConnectedVMwareVNet -ResourceGroupName $env.ResourceGroupName -Name $env.vNetName
        $vnet.Name | Should -Be $env.vNetName
    }

    It 'Delete' {
        Remove-AzConnectedVMwareVNet -Name $env.vNetName -ResourceGroupName $env.resourceGroupName
    }
}
