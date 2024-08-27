### Example 1: Capacity Name Available
```powershell
Test-AzFabricCapacityNameAvailability -Location "westus" -Name "newcapacity" -Type "Microsoft.Fabric/capacities"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

### Example 2: Capacity Name Unavailable - Already Exists
```powershell
Test-AzFabricCapacityNameAvailability -Location "westus" -Name "azsdktest" -Type "Microsoft.Fabric/capacities"
```

```output
Message                                           NameAvailable Reason
-------                                           ------------- ------
Fabric Capacity with same name is already present         False AlreadyExists
