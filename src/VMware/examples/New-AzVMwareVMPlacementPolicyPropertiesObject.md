### Example 1: Create an in-memory object for VMPlacementPolicyProperties.
```powershell
PS C:\> New-AzVMwareVMPlacementPolicyPropertiesObject -AffinityType 'Affinity' -Type 'VmVm' -VMMember @{"abc"="123"}

DisplayName ProvisioningState State AffinityType VMMember
----------- ----------------- ----- ------------ --------
                                    Affinity     {System.Collections.Hashtable}
```

Create an in-memory object for VMPlacementPolicyProperties.