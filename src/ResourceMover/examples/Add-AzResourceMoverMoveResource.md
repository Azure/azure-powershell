### Example 1: Add a resource to the Move Collection. (RegionToRegion)
```powershell
$targetResourceSettingsObj = New-Object Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
$targetResourceSettingsObj.ResourceType = "Microsoft.Compute/virtualMachines"
$targetResourceSettingsObj.TargetResourceName = "PSDemoVM"

Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $targetResourceSettingsObj
```

```output
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
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 
```

Add a resource to 'RegionToRegion' type Move Collection.

### Example 2: Add a resource to the Move Collection. (RegionToZone)
```powershell
$targetResourceSettingsObj = New-Object Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
$targetResourceSettingsObj.ResourceType = "Microsoft.Compute/virtualMachines"
$targetResourceSettingsObj.TargetResourceName = "demo-RegionToZone-VM-Target"
$targetResourceSettingsObj.TargetAvailabilityZone = "1"

Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-demo-RegionToZone" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-RegionToZone-RG/providers/Microsoft.Compute/virtualMachines/demo-RegionToZone-VM" -Name "PSDemoVM-RegionToZone" -ResourceSetting $targetResourceSettingsObj
```

```output
DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              :
ErrorsPropertiesDetail            :
ErrorsPropertiesMessage           :
ErrorsPropertiesTarget            :
ExistingTargetId                  :
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollection
                                    s/PS-demo-RegionToZone/moveResources/PSDemoVM-RegionToZone
IsResolveRequired                 : False
JobStatusJobName                  :
JobStatusJobProgress              :
MoveStatusErrorsPropertiesCode    : DependencyComputationPending
MoveStatusErrorsPropertiesDetail  : {Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.MoveResourceErrorBody,
                                    Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.MoveResourceErrorBody}
MoveStatusErrorsPropertiesMessage : The dependency computation is not completed for resource - /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-R
                                    egionToZone-RG/providers/Microsoft.Compute/virtualMachines/demo-RegionToZone-VM'.
                                        Possible Causes: Dependency computation is pending for resource.
                                        Recommended Action: Validate dependencies to compute the dependencies.

MoveStatusErrorsPropertiesTarget  :
MoveStatusMoveState               : MovePending
Name                              : PSDemoVM-RegionToZone
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-RegionToZone-RG/providers/Microsoft.Compute/virtualMachines/
                                    demo-RegionToZone-VM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SystemDataCreatedAt               : 9/5/2023 11:13:46 AM
SystemDataCreatedBy               : xxxxxxx
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 9/5/2023 11:13:46 AM
SystemDataLastModifiedBy          : xxxxxxx
SystemDataLastModifiedByType      : User
TargetId                          :
Type                              :
```

Add a resource to 'RegionToZone' type Move Collection.

### Example 3: Add a resource to the Move Collection that has existing target resource. (RegionToRegion)
```powershell
Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS"  -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm"  -Name "psdemorm"  -ExistingTargetId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM-target"
```

```output
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
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 
```
Add a resource to 'RegionToRegion' type Move Collection that has existing target resource.

### Example 4: Add a resource to the Move Collection that has existing target resource. (RegionToZone)
```powershell
Add-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS"  -MoveCollectionName "PS-demo-RegionToZone" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PS-demo-RegionToZone-RG/providers/Microsoft.Network/networkinterfaces/nic_demo-RegionToZone-VM"  -Name "PSDemoNIC-RegionToZone"  -ExistingTargetId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PS-demo-Existing/providers/Microsoft.Network/networkinterfaces/nic-demo-existing-target"
```

```output
DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              :
ErrorsPropertiesDetail            :
ErrorsPropertiesMessage           :
ErrorsPropertiesTarget            :
ExistingTargetId                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PS-demo-Existing/providers/Microsoft.Network/networkinterfaces/nic-demo-existing-target
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/moveResources/PSDemoNIC-RegionToZone
IsResolveRequired                 : False
JobStatusJobName                  :
JobStatusJobProgress              :
MoveStatusErrorsPropertiesCode    :
MoveStatusErrorsPropertiesDetail  :
MoveStatusErrorsPropertiesMessage :
MoveStatusErrorsPropertiesTarget  :
MoveStatusMoveState               : CommitPending
Name                              : PSDemoNIC-RegionToZone
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PS-demo-RegionToZone-RG/providers/Microsoft.Network/networkinterfaces/nic_demo-RegionToZone-VM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.ResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          :
Type                              :
```

Add a resource to 'RegionToZone' type Move Collection that has existing target resource.

### Example 5: Update target resource settings after the Move Resource has been added.(RegionToRegion)
```powershell
$moveResourceObj = Get-AzResourceMoverMoveResource -MoveCollectionName "PS-centralus-westcentralus-demoRMS1" -ResourceGroupName "RG-MoveCollection-demoRMS" -Name "PSDemoVM"
$TargetResourceSettingObj = $moveResourceObj.ResourceSetting
$TargetResourceSettingObj.TargetResourceName="PSDemoVM-target"

Update-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $TargetResourceSettingObj
```

```output
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
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
TargetId                          : 
Type                              : 
```

Update target resource settings after the Move Resource has been added to 'RegionToRegion' type Move Collection.

### Example 6: Update target resource settings after the Move Resource has been added. (RegionToZone)
```powershell
$moveResourceObj = Get-AzResourceMoverMoveResource -MoveCollectionName "PS-demo-RegionToZone" -ResourceGroupName "RG-MoveCollection-demoRMS" -Name "PSDemoVM-RegionToZone"
$TargetResourceSettingObj = $moveResourceObj.ResourceSetting
$TargetResourceSettingObj.TargetVMSize = "Standard_D4s_v3"

Update-AzResourceMoverMoveResource -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM" -Name "PSDemoVM" -ResourceSetting $TargetResourceSettingObj
```

```output
DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              :
ErrorsPropertiesDetail            :
ErrorsPropertiesMessage           :
ErrorsPropertiesTarget            :
ExistingTargetId                  :
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/moveResources/PSDemoVM-RegionToZone
IsResolveRequired                 : False
JobStatusJobName                  :
JobStatusJobProgress              :
MoveStatusErrorsPropertiesCode    : DependencyComputationPending
MoveStatusErrorsPropertiesDetail  : {Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.MoveResourceErrorBody,
                                    Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.MoveResourceErrorBody}
MoveStatusErrorsPropertiesMessage : The dependency computation is not completed for resource - /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-RegionToZone-RG/providers/Microsoft.Compute/virtualMachines/demo-RegionToZone-VM'.
Possible Causes: Dependency computation is pending for resource.
Recommended Action: Validate dependencies to compute the dependencies.

MoveStatusErrorsPropertiesTarget  :
MoveStatusMoveState               : MovePending
Name                              : PSDemoVM-RegionToZone
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PS-demo-RegionToZone-RG/providers/Microsoft.Compute/virtualMachines/
                                    demo-RegionToZone-VM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.VirtualMachineResourceSettings
SystemDataCreatedAt               : 9/5/2023 11:13:46 AM
SystemDataCreatedBy               : xxxxxxx
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 9/5/2023 11:13:46 AM
SystemDataLastModifiedBy          : xxxxxxx
SystemDataLastModifiedByType      : User
TargetId                          :
Type                              :
```

Update target resource settings after the Move Resource has been added to 'RegionToZone' type Move Collection.