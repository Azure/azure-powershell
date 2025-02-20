### Example 1: Check if Capacity Name is Available
```powershell
Test-AzFabricCapacityNameAvailability -Location "westus" -Name "newcapacity" -Type "Microsoft.Fabric/capacities"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

The above command checks if the Fabric capacity name 'azsdktest' is available within the resource group 'testrg' in the location 'westus'
