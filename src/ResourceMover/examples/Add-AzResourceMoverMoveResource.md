### Example 1: Adding a resource to the move collection.
```powershell
PS C:\> $targetResourceSettingsObj = New-Object Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
PS C:\> $targetResourceSettingsObj.ResourceType = "Microsoft.Compute/virtualMachines"
PS C:\> $targetResourceSettingsObj.TargetResourceName = "PSDemoVM"
PS C:\> Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $targetResourceSettingsObj

Output:

DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS
                                    /moveResources/PSDemoVM
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : DependencyComputationPending
MoveStatusErrorsPropertiesDetail  : {}
MoveStatusErrorsPropertiesMessage : The dependency computation is not completed for resource - 
                                    /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM'.
                                        Possible Causes: Dependency computation is pending for resource.
                                        Recommended Action: Validate dependencies to compute the dependencies.
                                        
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : PSDemoVM
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
SourceId                          : /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
TargetId                          : 
Type                              :         

```

Adding a resource to the move collection within the specified subscription.

### Example 2: Adding a resource to the move collection that has existing target resource.
```powershell
PS C:\> Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS"  -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/psdemorm"  -Name "psdemorm"  -ExistingTargetId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/PSDemoRM-target"
Adding a resource to the move collection within the specified subscription.

DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/PSDemoRM-target
Id                                : /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS
                                    /moveResources/psdemorm
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : CommitPending
Name                              : psdemorm
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings
SourceId                          : /subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/psdemorm
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings
TargetId                          : 
Type                              : 

```

Adding a resource to the move collection that has a target resource already created.