if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareDatastore'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareDatastore.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareDatastore' {
    It 'CreateExpanded' {
        New-AzConnectedVMwareDatastore -Name $env.datastoreName -ResourceGroupName $env.resourceGroupName -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/datastore-563660"
    }

    It 'Get' {
        $datastore = Get-AzConnectedVMwareDatastore -ResourceGroupName $env.ResourceGroupName -Name $env.datastoreName
        $datastore.Name | Should -Be $env.datastoreName
    }

    It 'Delete' {
        Remove-AzConnectedVMwareDatastore -Name $env.datastoreName -ResourceGroupName $env.resourceGroupName
    }
}
