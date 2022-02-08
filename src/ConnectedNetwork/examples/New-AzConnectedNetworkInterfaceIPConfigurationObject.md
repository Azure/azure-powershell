### Example 1: Create a in-memory object for NetworkInterfaceIPConfiguration
```powershell
PS C:\> New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"

DnsServer Gateway IPAddress IPAllocationMethod IPVersion Subnet
--------- ------- --------- ------------------ --------- ------
                            Dynamic            IPv4
```

Create a in-memory object for NetworkInterfaceIPConfiguration