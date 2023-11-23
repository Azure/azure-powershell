### Example 1: Create an in-memory object for multi subnet ip configuration
```powershell
$multiSubnetIpConfig = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetId -PrivateIPAddressIpaddress $IPAddress -SqlVirtualMachineInstance $SqlVMResourceId
$multiSubnetIpConfig | Format-List
```

```output
PrivateIPAddressIpaddress        : 192.168.16.7
PrivateIPAddressSubnetResourceId : 
SqlVirtualMachineInstance        : 
```

*New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject* creates an in-memory object of type *MultiSubnetIPConfiguration*. This object represents a multi subnet ip configuration for an availability group listener. It will be used for parameter *MultiSubnetIPConfiguration* in cmdlet *New-AzAvailabilityGroupListener*.

