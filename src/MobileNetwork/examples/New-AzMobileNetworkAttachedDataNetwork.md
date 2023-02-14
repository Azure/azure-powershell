<<<<<<< HEAD
### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

=======
### Example 1: Creates or updates an attached data network.
```powershell
$dns=@("1.1.1.1", "1.1.1.2")

New-AzMobileNetworkAttachedDataNetwork -Name azps-mn-adn -PacketCoreControlPlaneName azps-mn-pccp -PacketCoreDataPlaneName azps-mn-pcdp -ResourceGroupName azps_test_group -DnsAddress $dns -Location eastus -UserPlaneDataInterfaceIpv4Address 10.0.0.10 -UserPlaneDataInterfaceIpv4Gateway 10.0.0.1 -UserPlaneDataInterfaceIpv4Subnet 10.0.0.0/24 -UserPlaneDataInterfaceName N6
```

```output
Location Name        ResourceGroupName ProvisioningState
-------- ----        ----------------- -----------------
eastus   azps-mn-adn azps_test_group   Succeeded
```

Creates or updates an attached data network.
Must be created in the same location as its parent packet core data plane.
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
