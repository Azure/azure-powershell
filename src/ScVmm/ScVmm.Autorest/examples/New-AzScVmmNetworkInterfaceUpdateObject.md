### Example 1: Create a NetworkInterfaceUpdate object in memory
```powershell
New-AzScVmmNetworkInterfaceUpdateObject -Name 'NIC-Obj-1' -macAddressType 'Dynamic' -ipv4AddressType 'Dynamic'
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

Create a NetworkInterfaceUpdate object in memory. Used internally for NIC patch operations on VM.
