if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVmVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVmVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVmVirtualMachine' {
    It 'Create Virtual Machine  '  {
        
        New-AzStackHciVMVirtualMachine -Name $env.vmName -OsType $env.osTypeLinux  -ImageName $env.vmImageName -VmSize $env.vmSize -AdminUsername $env.adminUsername -ComputerName $env.vmName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId  -Location $env.location -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false| Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
        } | Should -Not -Throw
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
        } | Should -Not -Throw
    }


    It 'Delete'{
        {

            Remove-AzStackHCIVMVirtualMachine -Name  $env.vmName -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

}
