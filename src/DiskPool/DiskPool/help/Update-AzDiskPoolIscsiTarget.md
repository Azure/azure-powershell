---
external help file: Az.DiskPool-help.xml
Module Name: Az.DiskPool
online version: https://learn.microsoft.com/powershell/module/az.diskpool/update-azdiskpooliscsitarget
schema: 2.0.0
---

# Update-AzDiskPoolIscsiTarget

## SYNOPSIS
update an iSCSI Target.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDiskPoolIscsiTarget -DiskPoolName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Lun <IIscsiLun[]>] [-ManagedBy <String>] [-ManagedByExtended <String[]>]
 [-StaticAcl <IAcl[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDiskPoolIscsiTarget -DiskPoolName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDiskPoolIscsiTarget -DiskPoolName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityDiskPoolExpanded
```
Update-AzDiskPoolIscsiTarget -Name <String> -DiskPoolInputObject <IDiskPoolIdentity> [-Lun <IIscsiLun[]>]
 [-ManagedBy <String>] [-ManagedByExtended <String[]>] [-StaticAcl <IAcl[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDiskPoolIscsiTarget -InputObject <IDiskPoolIdentity> [-Lun <IIscsiLun[]>] [-ManagedBy <String>]
 [-ManagedByExtended <String[]>] [-StaticAcl <IAcl[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update an iSCSI Target.

## EXAMPLES

### Example 1: Update an iSCSI target
```powershell
$lun0 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Compute/disks/disk1" -Name "lun0"
Update-AzDiskPoolIscsiTarget -Name 'target0' -DiskPoolName 'disk-pool-5' -ResourceGroupName 'storagepool-rg-test' -Lun @($lun0)
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command updates an iSCSI target.

### Example 2: Update an iSCSI target by object
```powershell
$lun0 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Compute/disks/disk1" -Name "lun0"
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0' | Update-AzDiskPoolIscsiTarget -Lun @($lun0)
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command updates an iSCSI target by object.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DiskPoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
Parameter Sets: UpdateViaIdentityDiskPoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DiskPoolName
The name of the Disk Pool.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lun
List of LUNs to be exposed through iSCSI Target.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IIscsiLun[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityDiskPoolExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedBy
Azure resource id.
Indicates if this resource is managed by another Azure resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityDiskPoolExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedByExtended
List of Azure resource ids that manage this resource.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityDiskPoolExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the iSCSI Target.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityDiskPoolExpanded
Aliases: IscsiTargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticAcl
Access Control List (ACL) for an iSCSI Target; defines LUN masking policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IAcl[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityDiskPoolExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IIscsiTarget

## NOTES

## RELATED LINKS
