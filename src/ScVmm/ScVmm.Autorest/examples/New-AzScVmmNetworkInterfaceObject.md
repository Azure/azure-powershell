### Example 1: Create a NetworkInterface object in memory
```powershell
New-AzScVmmNetworkInterfaceObject -Name 'NIC-Obj-1' -macAddressType 'Dynamic' -ipv4AddressType 'Dynamic'
```

```output
DisplayName      :
Ipv4Address      :
Ipv4AddressType  : Dynamic
Ipv6Address      :
Ipv6AddressType  :
MacAddress       :
MacAddressType   : Dynamic
Name             : NIC-Obj-1
NetworkName      :
NicId            :
VirtualNetworkId :
```

Create a NetworkInterface object in memory. Used in `New-AzScVmmVM` for NetworkInterface value.
