### Example 1: Create a in-memory object for NetworkInterfaceIPConfiguration
```powershell
New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
```

```output
DnsServer Gateway IPAddress IPAllocationMethod IPVersion Subnet
--------- ------- --------- ------------------ --------- ------
                            Dynamic            IPv4
```

Create a in-memory object for NetworkInterfaceIPConfiguration