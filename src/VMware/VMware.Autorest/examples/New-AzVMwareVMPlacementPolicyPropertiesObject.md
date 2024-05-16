### Example 1: Create an in-memory object for VMPlacementPolicyProperties.
```powershell
 New-AzVMwareVMPlacementPolicyPropertiesObject -AffinityType 'Affinity' -Type 'VmVm' -VMMember @{"test"="test"}
```
```output
AffinityType      : Affinity
DisplayName       : 
ProvisioningState : 
State             : 
Type              : VmVm
VMMember          : {System.Collections.Hashtable}
```

Create an in-memory object for VMPlacementPolicyProperties.