if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVMVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVMVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVMVirtualMachine' {
    It 'Create Virtual Machine  '  {
        
        New-AzStackHciVMVirtualMachine -Name manualvmtest2 -OsType Windows  -ImageId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/galleryImages/gpuWinUnattend" -VmSize "Standard_K8S_v1"  -ComputerName "manualvmtest2" -ResourceGroupName "vpclus0724-rg" -CustomLocationId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.ExtendedLocation/customLocations/myResourceBridge-cl"  -Location "eastus" -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false -SubscriptionId $env.subscriptionId | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Stopped"
        } 
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Delete' {
         {
        
            Remove-AzStackHCIVMVirtualMachine -Name  manualvmtest2 -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
         } | Should -Throw
    }
}