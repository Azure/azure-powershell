### Example 1: List NIC on Virtual Machine
```powershell
Get-AzScVmmVMNic -vmName "test-vm" -ResourceGroupName "test-rg-01"
```
```output
DisplayName      : Network Adapter 1
Ipv4Address      : {x.x.x.x}
Ipv4AddressType  : Dynamic
Ipv6Address      : {x:x:x:x:x:x:x:x}
Ipv6AddressType  : Dynamic
MacAddress       : 00:00:00:00:00:00
MacAddressType   : Dynamic
Name             : nic_1
NetworkName      : 00000000-1111-2222-0001-000000000000
NicId            : 00000000-2222-2222-0001-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet

DisplayName      : Network Adapter 2
Ipv4Address      :
Ipv4AddressType  : Dynamic
Ipv6Address      :
Ipv6AddressType  : Dynamic
MacAddress       :
MacAddressType   : Dynamic
Name             : nic_2
NetworkName      : 00000000-1111-2222-0002-000000000000
NicId            : 00000000-2222-2222-0002-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet
```

List all NICs on Virtual Machine.

### Example 2: Get NIC on a Virtual Machine
```powershell
Get-AzScVmmVMNic -vmName "test-vm" -ResourceGroupName "test-rg-01" -NicName "nic_1"
```

```output
DisplayName      : Network Adapter 1
Ipv4Address      : {x.x.x.x}
Ipv4AddressType  : Dynamic
Ipv6Address      : {x:x:x:x:x:x:x:x}
Ipv6AddressType  : Dynamic
MacAddress       : 00:00:00:00:00:00
MacAddressType   : Dynamic
Name             : nic_1
NetworkName      : 00000000-1111-2222-0001-000000000000
NicId            : 00000000-2222-2222-0001-000000000000
VirtualNetworkId : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet
```

Get NIC with name `NicName` or id `NicId` on Virtual Machine.
