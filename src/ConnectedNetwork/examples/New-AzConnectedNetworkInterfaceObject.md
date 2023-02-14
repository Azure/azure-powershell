### Example 1: Create a in-memory object for NetworkInterface
```powershell
<<<<<<< HEAD
New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
```

```output
=======
PS C:\> New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
MacAddress Name              VMSwitchType
---------- ----              ------------
           mrmmanagementnic1 Management
```

Create a in-memory object for NetworkInterface