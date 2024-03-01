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
        
        New-AzStackHciVMVirtualMachine -Name manualvmtest2 -OsType Linux  -ImageId "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/mkclus0824-rg/providers/Microsoft.AzureStackHCI/galleryImages/testImage1127" -VmSize "Standard_K8S_v1"  -ComputerName "manualvmtest2" -ResourceGroupName "mkclus0824-rg" -CustomLocationId "/subscriptions/0709bd7a-8383-4e1d-98c8-f81d1b3443fc/resourceGroups/mkclus0824-rg/providers/Microsoft.ExtendedLocation/customLocations/myResourceBridge-cl"  -Location "eastus" -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false -SubscriptionId $env.subscriptionId | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    
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
        } | Should -Not -Throw
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
        } | Should -Not -Throw
    }


    It 'Delete'{
        {

            Remove-AzStackHCIVMVirtualMachine -Name  manualvmtest2 -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

}