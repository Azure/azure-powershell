### Example 1: Add a resource to the Move Collection.
```powershell
PS C:\> Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $targetResourceSettingsObj

DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/moveResources/PSDemoVM
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : DependencyComputationPending
MoveStatusErrorsPropertiesDetail  : {}
MoveStatusErrorsPropertiesMessage : The dependency computation is not completed for resource - /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM. Possible Causes: Dependency computation is pending for resource. Recommended Action: Validate dependencies to compute the dependencies.
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : PSDemoVM
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.VirtualMachineResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 

PS C:\> $targetResourceSettingsObj = New-Object Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.VirtualMachineResourceSettings
PS C:\> $targetResourceSettingsObj.ResourceType = "Microsoft.Compute/virtualMachines"
$targetResourceSettingsObj.TargetResourceName = "PSDemoVM"

```

Add a resource to the Move Collection.

### Example 2: Add a resource to the Move Collection that has existing target resource.
```powershell
PS C:\> Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS"  -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm"  -Name "psdemorm"  -ExistingTargetId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM-target"

DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM-target
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/moveResources/psdemorm
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
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.ResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.ResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 

```

Add a resource to the Move Collection that has existing target resource.

### Example 3: Update target resource settings after the Move Resource has been added.
```powershell
PS C:\> Update-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $TargetResourceSettingObj


DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Network/networkInterfaces/psdemov
                                    m111, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/moveResources/PSDemoVM
IsResolveRequired                 : True
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : PSDemoVM
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20210801.VirtualMachineResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 

PS C:\> $moveResourceObj = Get-AzResourceMoverMoveResource -MoveCollectionName "PS-centralus-westcentralus-demoRMS1" -ResourceGroupName "RG-MoveCollection-demoRMS" -Name "PSDemoVM"
PS C:\> $TargetResourceSettingObj = $moveResourceObj.ResourceSetting
$TargetResourceSettingObj.TargetResourceName="PSDemoVM-target"

```

Update target resource settings after the Move Resource has been added.