### Example 1: Get a list of compute fleet resource's Virtual Machine Scale Sets (VMSS) information by ResourceGroupName and FleetName
```powershell
Get-AzComputeFleetVMSS -ResourceGroupName "test-fleet" -FleetName "testFleet"
```

```output
Name               OperationStatus
----               ---------------
testFleet_8553c385 Succeeded    

Code                    : 
Detail                  : 
Id                      : /subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/test-fleet/providers/Microsoft.Compute/virtualMac
                          hineScaleSets/testFleet_8553c385
InnererrorErrorDetail   : 
InnererrorExceptionType : 
Message                 : 
Name                    : testFleet_8553c385
OperationStatus         : Succeeded
Target                  : 
Type                    : 
```

This command gets a list of compute fleet resource's Virtual Machine Scale Sets (VMSS) information by ResourceGroupName and FleetName.
