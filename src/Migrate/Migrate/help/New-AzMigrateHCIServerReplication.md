---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehciserverreplication
schema: 2.0.0
---

# New-AzMigrateHCIServerReplication

## SYNOPSIS
Starts replication for the specified server.

## SYNTAX

### ByIdDefaultUser (Default)
```
New-AzMigrateHCIServerReplication -MachineId <String> -TargetStoragePathId <String>
 -TargetResourceGroupId <String> -TargetVMName <String> -TargetVirtualSwitchId <String> -OSDiskID <String>
 [-TargetVMCPUCore <Int32>] [-TargetTestVirtualSwitchId <String>] [-IsDynamicMemoryEnabled <String>]
 [-TargetVMRam <Int64>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByIdPowerUser
```
New-AzMigrateHCIServerReplication -MachineId <String> -TargetStoragePathId <String>
 -TargetResourceGroupId <String> -TargetVMName <String> [-TargetVMCPUCore <Int32>]
 [-IsDynamicMemoryEnabled <String>] [-TargetVMRam <Int64>] [-SubscriptionId <String>]
 -DiskToInclude <AzStackHCIDiskInput[]> -NicToInclude <AzStackHCINicInput[]> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateHCIServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.

## EXAMPLES

### Example 1: When there is only OS disk to migrate
```powershell
New-AzMigrateHCIServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/testsrc7972site/machines/005-005-005" -OSDiskID "Microsoft:0EC082D5-6827-457A-BAE2-F986E1B94851\83F8638B-8DCA-4152-9EDA-2CA8B33039B4\0\0\L" -TargetStoragePathId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/storagecontainers/testStorageContainer1" -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external" -TargetResourceGroupId "/subscriptions//xxx-xxx-xxx/resourceGroups/target-rg"-TargetVMName "targetVM"
```

```output
ActivityId                         : ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Create or update protected item
EndTime                            : 1/1/1900 8:54:47 PM
Error                              : {}
Id                                 : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/jobs/f2d3430a-2977-419f-abd5-11d171e17f5e
Name                               : f2d3430a-2977-419f-abd5-11d171e17f5e
ObjectId                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94555     
ObjectInternalId                   : a8b5ee68-102c-5aae-9499-c57a475a8fd4
ObjectInternalName                 : test_vm
ObjectName                         : 0ec082d5-6827-457a-bae2-f986e1b94555
ObjectType                         : ProtectedItem
ReplicationProviderId              : xxx-xxx-xxx
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 1/1/1900 8:49:27 PM
State                              : Succeeded
SystemDataCreatedAt                : 
SystemDataCreatedBy                : 
SystemDataCreatedByType            : 
SystemDataLastModifiedAt           : 
SystemDataLastModifiedBy           : 
SystemDataLastModifiedByType       : 
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Creating or updating the protected item, Initializing Protection, Enabling Protection, Starting Replication}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

This is for the scenario, when there is only one single disk that has to be protected.

### Example 2: When there are multiple disks or NICs to migrate
```powershell
[AzStackHCIDiskInput[]]$DisksToInclude = @()
$OSDisk = New-AzMigrateHCIDiskMappingObject -DiskID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\83F8638B-8DCA-4152-9EDA-2CA8B33039B4\0\0\L" -IsOSDisk true -IsDynamic true -Size 42 -Format VHD
$DataDisk = New-AzMigrateHCIDiskMappingObject -DiskID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\C92FAB89-DA8B-47E9-92F3-364642ECDF39\0\0\L" -IsOSDisk false -IsDynamic true -Size 5 -Format VHD
$DisksToInclude += $OSDisk
$DisksToInclude += $DataDisk

[AzStackHCINicInput[]]$NicsToInclude = @()
$Nic = New-AzMigrateHCINicMappingObject -NicID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\99CDFD2E-D60C-4218-AC2E-E7C2D8253EB9" -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external"
$NicsToInclude += $Nic

New-AzMigrateHCIServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/testsrc7972site/machines/005-005-005" -TargetStoragePathId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/storagecontainers/testStorageContainer1" -TargetResourceGroupId "/subscriptions//xxx-xxx-xxx/resourceGroups/target-rg"-TargetVMName "targetVM" -DiskToInclude $DisksToInclude -NicToInclude $NicsToInclude
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Create or update protected item
EndTime                            : 1/1/1900 2:27:14 PM
Error                              : {}
Id                                 : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/jobs/f855305c-5bed-4bc6-996e-d273115ab833
Name                               : f855305c-5bed-4bc6-996e-d273115ab833
ObjectId                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/c1a34301-3bff-4ec6-97f1-6c4bd5adcde0     
ObjectInternalId                   : a40ecd8e-6413-574d-b1f8-2ef925e087fc
ObjectInternalName                 : test_vm
ObjectName                         : c1a34301-3bff-4ec6-97f1-6c4bd5adcde0
ObjectType                         : ProtectedItem
ReplicationProviderId              : 4de0fddc-bdfe-40d9-b60e-678bdce89630
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 1/1/1900 2:21:50 PM
State                              : Succeeded
SystemDataCreatedAt                : 
SystemDataCreatedBy                : 
SystemDataCreatedByType            : 
SystemDataLastModifiedAt           : 
SystemDataLastModifiedBy           : 
SystemDataLastModifiedByType       : 
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Creating or updating the protected item, Initializing Protection, Enabling Protection, Starting Replication}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

This is for the scenario, when there are multiple disks that has to be protected.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskToInclude
Specifies the disks on the source server to be included for replication.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCIDiskInput[]
Parameter Sets: ByIdPowerUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDynamicMemoryEnabled
Specifies if RAM is dynamic or not.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineId
Specifies the machine ARM ID of the discovered server to be migrated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicToInclude
Specifies the NICs on the source server to be included for replication.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput[]
Parameter Sets: ByIdPowerUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskID
Specifies the Operating System disk for the source server to be migrated.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupId
Specifies the target Resource Group Id where the migrated VM resources will reside.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetStoragePathId
Specifies the storage path ARM ID where the VMs will be stored.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTestVirtualSwitchId
Specifies the test logical network ARM ID that the VMs will use.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVirtualSwitchId
Specifies the logical network ARM ID that the VMs will use.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMCPUCore
Specifies the number of CPU cores.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMName
Specifies the name of the VM to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMRam
Specifies the target RAM size in MB.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IWorkflowModel

## NOTES

## RELATED LINKS
