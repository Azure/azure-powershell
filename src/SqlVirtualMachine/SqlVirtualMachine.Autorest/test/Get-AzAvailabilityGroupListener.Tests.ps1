if (($null -eq $TestName) -or ($TestName -contains 'Get-AzAvailabilityGroupListener')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAvailabilityGroupListener.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAvailabilityGroupListener' {
    It 'List' {
        $listeners = Get-AzAvailabilityGroupListener -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName
        
        $listeners.Count | Should -Be 2
        $listeners.Name.Contains($env.SqlVMGroupLoadBalancerListnerName) | Should -Be $true
        $listeners.Name.Contains($env.SqlVMGroupMultiSubnetIPListnerName) | Should -Be $true
        
        $lbListner = $listeners | Where Name -eq $env.SqlVMGroupLoadBalancerListnerName 
        $lbListner.AvailabilityGroupName | Should -Be $env.SqlVMGroupName1
        $lbListner.Port | Should -Be 1433
        $lbListner.LoadBalancerConfiguration.LoadBalancerResourceId | Should -Be $env.LoadBalancerResourceId
        $lbListner.LoadBalancerConfiguration.PrivateIPAddressIpaddress | Should -Be $env.IPAddress1
        $lbListner.LoadBalancerConfiguration.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId1
        $lbListner.LoadBalancerConfiguration.ProbePort | Should -Be $env.ProbePort
        $SqlVirtualMachineInstances = $lbListner.LoadBalancerConfiguration.SqlVirtualMachineInstance.ToLower()
        ($SqlVirtualMachineInstances[0] -eq $env.SqlVMName_HA1Id) -or ($SqlVirtualMachineInstances[1] -eq $env.SqlVMName_HA1Id) | Should -Be $true
        ($SqlVirtualMachineInstances[0] -eq $env.SqlVMName_HA2Id) -or ($SqlVirtualMachineInstances[1] -eq $env.SqlVMName_HA2Id) | Should -Be $true

        $msListner = $listeners | Where Name -eq $env.SqlVMGroupMultiSubnetIPListnerName
        $msListner.AvailabilityGroupName | Should -Be $env.SqlVMGroupName2
        $msListner.Port | Should -Be 1433
        $msListner.MultiSubnetIPConfiguration.Count | Should -Be 2
        $MultiSubnetIPConfiguration1 = $msListner.MultiSubnetIPConfiguration | Where PrivateIPAddressIpaddress -eq $env.IPAddress2
        $MultiSubnetIPConfiguration1.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId1
        $MultiSubnetIPConfiguration1.SqlVirtualMachineInstance.ToLower() | Should -Be $env.SqlVMName_HA1Id
        $MultiSubnetIPConfiguration2 = $msListner.MultiSubnetIPConfiguration | Where PrivateIPAddressIpaddress -eq $env.IPAddress3
        $MultiSubnetIPConfiguration2.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId2
        $MultiSubnetIPConfiguration2.SqlVirtualMachineInstance.ToLower() | Should -Be $env.SqlVMName_HA2Id


    }

    It 'Get' {
        $lbListner = Get-AzAvailabilityGroupListener -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName -Name $env.SqlVMGroupLoadBalancerListnerName

        $lbListner.AvailabilityGroupName | Should -Be $env.SqlVMGroupName1
        $lbListner.Port | Should -Be 1433
        $lbListner.LoadBalancerConfiguration.LoadBalancerResourceId | Should -Be $env.LoadBalancerResourceId
        $lbListner.LoadBalancerConfiguration.PrivateIPAddressIpaddress | Should -Be $env.IPAddress1
        $lbListner.LoadBalancerConfiguration.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId1
        $lbListner.LoadBalancerConfiguration.ProbePort | Should -Be $env.ProbePort
        $SqlVirtualMachineInstances = $lbListner.LoadBalancerConfiguration.SqlVirtualMachineInstance.ToLower()
        ($SqlVirtualMachineInstances[0] -eq $env.SqlVMName_HA1Id) -or ($SqlVirtualMachineInstances[1] -eq $env.SqlVMName_HA1Id) | Should -Be $true
        ($SqlVirtualMachineInstances[0] -eq $env.SqlVMName_HA2Id) -or ($SqlVirtualMachineInstances[1] -eq $env.SqlVMName_HA2Id) | Should -Be $true
    }

    It 'GetViaIdentity' {
        $msListner = [Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.AvailabilityGroupListener]@{Id = $env.SqlVMGroupMultiSubnetIPListnerId }
        $msListner = Get-AzAvailabilityGroupListener -InputObject $msListner

        $msListner.AvailabilityGroupName | Should -Be $env.SqlVMGroupName2
        $msListner.Port | Should -Be 1433
        $msListner.MultiSubnetIPConfiguration.Count | Should -Be 2
        $MultiSubnetIPConfiguration1 = $msListner.MultiSubnetIPConfiguration | Where PrivateIPAddressIpaddress -eq $env.IPAddress2
        $MultiSubnetIPConfiguration1.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId1
        $MultiSubnetIPConfiguration1.SqlVirtualMachineInstance.ToLower() | Should -Be $env.SqlVMName_HA1Id
        $MultiSubnetIPConfiguration2 = $msListner.MultiSubnetIPConfiguration | Where PrivateIPAddressIpaddress -eq $env.IPAddress3
        $MultiSubnetIPConfiguration2.PrivateIPAddressSubnetResourceId | Should -Be $env.SubnetId2
        $MultiSubnetIPConfiguration2.SqlVirtualMachineInstance.ToLower() | Should -Be $env.SqlVMName_HA2Id
    }
}
