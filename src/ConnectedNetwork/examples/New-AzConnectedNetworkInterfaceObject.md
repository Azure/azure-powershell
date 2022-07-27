### Example 1: Create a in-memory object for NetworkInterface
```powershell
PS C:\> New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"

MacAddress Name              VMSwitchType
---------- ----              ------------
           mrmmanagementnic1 Management
```

Create a in-memory object for NetworkInterface