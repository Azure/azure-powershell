### Example 1: Create an in-memory object for VmHostPlacementPolicyProperties.
```powershell
New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"}  -Type 'VmHost' -VMMember @{"test"="test"}
```
```output
AffinityStrength       : 
AffinityType           : AntiAffinity
AzureHybridBenefitType : 
DisplayName            : 
HostMember             : {System.Collections.Hashtable}
ProvisioningState      : 
State                  : 
Type                   : VmHost
VMMember               : {System.Collections.Hashtable}
```

Create an in-memory object for VmHostPlacementPolicyProperties.