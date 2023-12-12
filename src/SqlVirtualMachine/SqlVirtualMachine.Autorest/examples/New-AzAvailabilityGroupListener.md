### Example 1
```powershell
New-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'sqlvmgroup01' -Name 'AgListener01' -AvailabilityGroupName 'AG01' -IpAddress '192.168.16.7' -LoadBalancerResourceId $LoadBalancerResourceId -SubnetId $SubnetResourceId -ProbePort 9999 -SqlVirtualMachineId $sqlvmResourceId1,$sqlvmResourceId2
```

```output
Name         ResourceGroupName
----         -----------------
AgListener01 ResourceGroup01
```

Create a new Availability Group Listener "AgListener01" with Load Balancer Configuration for the Availability Group "AG01" in SQL Virtual Machine Group "sqlvmgroup01".

### Example 2
```powershell
$msconfig1 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetResourceId1 -PrivateIPAddressIpaddress '192.168.16.9' -SqlVirtualMachineInstance $sqlvmResourceId1
$msconfig2 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetResourceId2 -PrivateIPAddressIpaddress '192.168.17.9' -SqlVirtualMachineInstance $sqlvmResourceId2

New-AzAvailabilityGroupListener -Name 'AgListener02' -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'sqlvmgroup01' -AvailabilityGroupName 'AG02' -MultiSubnetIPConfiguration $msconfig1,$msconfig2
```

```output
Name         ResourceGroupName
----         -----------------
AgListener02 ResourceGroup01
```

Create a new Availability Group Listener "AgListener02" with Multi Subnets Configuration for the Availability Group "AG02" in SQL Virtual Machine Group "sqlvmgroup01".

