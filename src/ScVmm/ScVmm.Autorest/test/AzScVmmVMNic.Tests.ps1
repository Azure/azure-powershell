if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVMNic'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVMNic.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVMNic' -Tag 'LiveOnly' {
    It 'AddVMNic - Add-AzScVmmVMNic' {
        {
            Stop-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest

            $result = Add-AzScVmmVMNic -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -NicName $env.NicName -virtualNetworkName $env.VirtualNetworkName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.NetworkProfileNetworkInterface.Count | Should -Be 2
            $result.NetworkProfileNetworkInterface.Name | Should -Contain $env.NicName
            ($result.NetworkProfileNetworkInterface | Where-Object { $_.Name -eq $env.NicName }).VirtualNetworkId.ToLower() | Should -Be $env.vmNetworkIdVmTest.ToLower()
        } | Should -Not -Throw
    }

    It 'ListVMNic - Get-AzScVmmVMNic' {
        {
            $result = Get-AzScVmmVMNic -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName
            $result.Count | Should -Be 2 
        } | Should -Not -Throw
    }

    It 'UpdateVMNic - Update-AzScVmmVMNic' {
        {
            $result = Update-AzScVmmVMNic -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -NicName $env.NicName -virtualNetworkName $env.VirtualNetwork2Name
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.NetworkProfileNetworkInterface.Count | Should -Be 2
            $result.NetworkProfileNetworkInterface.Name | Should -Contain $env.NicName
            ($result.NetworkProfileNetworkInterface | Where-Object { $_.Name -eq $env.NicName }).VirtualNetworkId.ToLower() | Should -Be $env.vmNetwork2IdVmTest
        } | Should -Not -Throw
    }

    It 'GetVMNic - Get-AzScVmmVMNic' {
        {
            $result = Get-AzScVmmVMNic -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -NicName $env.NicName
            $result.Name | Should -Be $env.NicName
        } | Should -Not -Throw
    }

    It 'RemoveVMNic - Remove-AzScVmmVMNic' {
        {
            $result = Remove-AzScVmmVMNic -ResourceGroupName $env.ResourceGroupVmTest -vmName $env.VmName -NicName $env.NicName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.NetworkProfileNetworkInterface.Count | Should -Be 1
        } | Should -Not -Throw
    }
}
