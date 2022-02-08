### Example 1: Create an in-memory object for VmHostPlacementPolicyProperties.
```powershell
PS C:\> New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"abc"="123"}  -Type 'VmHost' -VMMember @{"abc"="123"}

DisplayName ProvisioningState State AffinityType HostMember                     VMMember
----------- ----------------- ----- ------------ ----------                     --------
                                    AntiAffinity {System.Collections.Hashtable} {System.Collections.Hashtable}
```

Create an in-memory object for VmHostPlacementPolicyProperties.