if (($null -eq $TestName) -or ($TestName -contains 'New-AzAvailabilityGroupListener')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAvailabilityGroupListener.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAvailabilityGroupListener' {
    It 'CreateExpanded-LoadBalancerConfiguration' {
        $lbListner = New-AzAvailabilityGroupListener -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName -Name $env.SqlVMGroupLoadBalancerListnerName -AvailabilityGroupName $env.SqlVMGroupName1 -IpAddress $env.IPAddress1 -LoadBalancerResourceId $env.LoadBalancerResourceId -SubnetId $env.SubnetId1 -ProbePort $env.ProbePort -SqlVirtualMachineId $env.SqlVMName_HA1Id, $env.SqlVMName_HA2Id
        
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

    It 'CreateExpanded-MultiSubnetIPConfiguration' {
        $msconfig1 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $env.SubnetId1 -PrivateIPAddressIpaddress $env.IPAddress2 -SqlVirtualMachineInstance $env.SqlVMName_HA1Id
        $msconfig2 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $env.SubnetId2 -PrivateIPAddressIpaddress $env.IPAddress3 -SqlVirtualMachineInstance $env.SqlVMName_HA2Id

        $msListner = New-AzAvailabilityGroupListener -Name $env.SqlVMGroupMultiSubnetIPListnerName -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName -AvailabilityGroupName $env.SqlVMGroupName2 -MultiSubnetIPConfiguration $msconfig1, $msconfig2

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
