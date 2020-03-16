## Breaking changes in module Microsoft.Azure.PowerShell.Cmdlets.Compute.dll

 The following cmdlets were affected this release:




### **Remove-AzVmssDiagnosticsExtension**
 - Cmdlet : 'Remove-AzVmssDiagnosticsExtension'
 - The output type 'Microsoft.Azure.Commands.Compute.Automation.Models.PSAutomaticRepairsPolicy' is being deprecated without a replacement.
Note :The change is expected to take effect from the version :  'MaxInstanceRepairsPercent property will be removed.'



BreakingChangesAttributesCmdLetOutputTypeDeprecated: Microsoft.Azure.Commands.Compute.Automation.Models.PSAutomaticRepairsPolicy




### **New-AzProximityPlacementGroup**
 - Cmdlet : 'New-AzProximityPlacementGroup'
 - The output type 'Microsoft.Azure.Commands.Compute.Automation.Models.PSProximityPlacementGroup' is being deprecated without a replacement.
Note :The change is expected to take effect from the version :  'AvailabilitySetsColocationStatus, VirtualMachinesColocationStatus and VirtualMachineScaleSetsColocationStatus properties will be removed when the types of AvailabilitySets, VirtualMachines and VirtualMachineScaleSets are changed from SubResource to SubResourceWithColocationStatus.'



BreakingChangesAttributesCmdLetOutputTypeDeprecated: Microsoft.Azure.Commands.Compute.Automation.Models.PSProximityPlacementGroup




### **Get-AzProximityPlacementGroup**
 - Cmdlet : 'Get-AzProximityPlacementGroup'
 - The output type 'Microsoft.Azure.Commands.Compute.Automation.Models.PSProximityPlacementGroup' is being deprecated without a replacement.
Note :The change is expected to take effect from the version :  'AvailabilitySetsColocationStatus, VirtualMachinesColocationStatus and VirtualMachineScaleSetsColocationStatus properties will be removed when the types of AvailabilitySets, VirtualMachines and VirtualMachineScaleSets are changed from SubResource to SubResourceWithColocationStatus.'



BreakingChangesAttributesCmdLetOutputTypeDeprecated: Microsoft.Azure.Commands.Compute.Automation.Models.PSProximityPlacementGroup




### **New-AzVmssConfig**
The following parameters were affected this release:
#### **AutomaticRepairMaxInstanceRepairsPercent**
 - Cmdlet : 'New-AzVmssConfig'
 - The parameter : 'AutomaticRepairMaxInstanceRepairsPercent' is changing.
	Change description : AutomaticRepairMaxInstanceRepairsPercent is not supported until future.


#### **AssignIdentity**
 - Cmdlet : 'New-AzVmssConfig'
 - The parameter : 'AssignIdentity' is changing.
	Change description : 'IdentityType' parameter with 'SystemAssigned' value will be used instead of 'AssignIdentity'





### **Update-AzVmss**
The following parameters were affected this release:
#### **AutomaticRepairMaxInstanceRepairsPercent**
 - Cmdlet : 'Update-AzVmss'
 - The parameter : 'AutomaticRepairMaxInstanceRepairsPercent' is changing.
	Change description : AutomaticRepairMaxInstanceRepairsPercent is not supported until future.

