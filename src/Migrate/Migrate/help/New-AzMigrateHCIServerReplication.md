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
 [-TargetVMRam <Int64>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByIdPowerUser
```
New-AzMigrateHCIServerReplication -MachineId <String> -TargetStoragePathId <String>
 -TargetResourceGroupId <String> -TargetVMName <String> [-TargetVMCPUCore <Int32>]
 [-IsDynamicMemoryEnabled <String>] [-TargetVMRam <Int64>] [-SubscriptionId <String>]
 -DiskToInclude <AzStackHCIDiskInput[]> -NicToInclude <AzStackHCINicInput[]> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateHCIServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.

## EXAMPLES

### EXAMPLE 1
```
New-AzMigrateHCIServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/testsrc7972site/machines/005-005-005" -OSDiskID "Microsoft:0EC082D5-6827-457A-BAE2-F986E1B94851\83F8638B-8DCA-4152-9EDA-2CA8B33039B4\0\0\L" -TargetStoragePathId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/storagecontainers/testStorageContainer1" -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external" -TargetResourceGroupId "/subscriptions//xxx-xxx-xxx/resourceGroups/target-rg"-TargetVMName "targetVM"
```

### EXAMPLE 2
```
[AzStackHCIDiskInput[]]$DisksToInclude = @()
$OSDisk = New-AzMigrateHCIDiskMappingObject -DiskID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\83F8638B-8DCA-4152-9EDA-2CA8B33039B4\0\0\L" -IsOSDisk true -IsDynamic true -Size 42 -Format VHD
$DataDisk = New-AzMigrateHCIDiskMappingObject -DiskID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\C92FAB89-DA8B-47E9-92F3-364642ECDF39\0\0\L" -IsOSDisk false -IsDynamic true -Size 5 -Format VHD
$DisksToInclude += $OSDisk
$DisksToInclude += $DataDisk
```

\[AzStackHCINicInput\[\]\]$NicsToInclude = @()
$Nic = New-AzMigrateHCINicMappingObject -NicID "Microsoft:C1A34301-3BFF-4EC6-97F1-6C4BD5ADCDE0\99CDFD2E-D60C-4218-AC2E-E7C2D8253EB9" -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external"
$NicsToInclude += $Nic

New-AzMigrateHCIServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/testsrc7972site/machines/005-005-005" -TargetStoragePathId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/storagecontainers/testStorageContainer1" -TargetResourceGroupId "/subscriptions//xxx-xxx-xxx/resourceGroups/target-rg"-TargetVMName "targetVM" -DiskToInclude $DisksToInclude -NicToInclude $NicsToInclude

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: PSObject
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
Type: AzStackHCIDiskInput[]
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
Type: String
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
Type: String
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
Type: AzStackHCINicInput[]
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
Type: String
Parameter Sets: ByIdDefaultUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupId
Specifies the target Resource Group Id where the migrated VM resources will reside.

```yaml
Type: String
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
Type: String
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
Type: String
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
Type: String
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
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMName
Specifies the name of the VM to be created.

```yaml
Type: String
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
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

[https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehciserverreplication](https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehciserverreplication)

