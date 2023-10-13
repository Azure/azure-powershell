if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareResourcePool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareResourcePool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareResourcePool' {
    It 'CreateExpanded' {
        New-AzConnectedVMwareResourcePool -Name $env.resourcePoolName -ResourceGroupName $env.resourceGroupName -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/resgroup-724471"
    }

    It 'Get' {
        $rp = Get-AzConnectedVMwareResourcePool -ResourceGroupName $env.ResourceGroupName -Name $env.resourcePoolName
        $rp.Name | Should -Be $env.resourcePoolName
    }

    It 'Delete' {
        Remove-AzConnectedVMwareResourcePool -Name $env.resourcePoolName -ResourceGroupName $env.resourceGroupName
    }
}
