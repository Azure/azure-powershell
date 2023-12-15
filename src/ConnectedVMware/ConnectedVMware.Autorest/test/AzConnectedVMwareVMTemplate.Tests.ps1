if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedVMwareVMTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedVMwareVMTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedVMwareVMTemplate' {
    It 'CreateExpanded' {
        New-AzConnectedVMwareVMTemplate -Name $env.vmTemplateName -ResourceGroupName $env.resourceGroupName -Location $env.location -ExtendedLocationName $env.extendedLocationName -ExtendedLocationType $env.extendedLocationType -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/vmtpl-vm-651858"
    }

    It 'Get' {
        $vmtmpl = Get-AzConnectedVMwareVMTemplate -ResourceGroupName $env.ResourceGroupName -Name $env.vmTemplateName
        $vmtmpl.Name | Should -Be $env.vmTemplateName
    }

    It 'Delete' {
        Remove-AzConnectedVMwareVMTemplate -Name $env.vmTemplateName -ResourceGroupName $env.resourceGroupName
    }
}
