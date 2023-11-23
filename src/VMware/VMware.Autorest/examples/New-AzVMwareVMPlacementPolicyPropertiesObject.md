### Example 1: Create an in-memory object for VMPlacementPolicyProperties.
```powershell
New-AzVMwareVMPlacementPolicyPropertiesObject -AffinityType 'Affinity' -Type 'VmVm' -VMMember @{"abc"="123"}
```
```output
DisplayName ProvisioningState State AffinityType VMMember
----------- ----------------- ----- ------------ --------
                                    Affinity     {System.Collections.Hashtable}
```

Create an in-memory object for VMPlacementPolicyProperties.