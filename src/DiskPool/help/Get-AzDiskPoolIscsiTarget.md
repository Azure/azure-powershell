---
external help file:
Module Name: Az.DiskPool
online version: https://docs.microsoft.com/powershell/module/az.diskpool/get-azdiskpooliscsitarget
schema: 2.0.0
---

# Get-AzDiskPoolIscsiTarget

## SYNOPSIS
Get an iSCSI Target.

## SYNTAX

### List (Default)
```
Get-AzDiskPoolIscsiTarget -DiskPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDiskPoolIscsiTarget -DiskPoolName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiskPoolIscsiTarget -InputObject <IDiskPoolIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an iSCSI Target.

## EXAMPLES

### Example 1: List iSCSI targets in a Disk Pool
```powershell
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5'
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command lists all iSCSI targets in a Disk Pool.

### Example 2: Get an iSCSI target
```powershell
Get-AzDiskPoolIscsiTarget -ResourceGroupName 'storagepool-rg-test' -DiskPoolName 'disk-pool-5' -Name 'target0'
```

```output
Name               Type
----               ----
target0 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target.

### Example 3: Get an iSCSI target by object
```powershell
New-AzDiskPoolIscsiTarget -DiskPoolName 'disk-pool-5' -Name 'target1' -ResourceGroupName 'storagepool-rg-test' -AclMode 'Dynamic' | Get-AzDiskPoolIscsiTarget
```

```output
Name               Type
----               ----
target1 Microsoft.StoragePool/diskPools/iscsiTargets
```

This command gets an iSCSI target by object.

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

### -DiskPoolName
The name of the Disk Pool.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the iSCSI Target.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: IscsiTargetName

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210801.IIscsiTarget

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IDiskPoolIdentity>`: Identity Parameter
  - `[DiskPoolName <String>]`: The name of the Disk Pool.
  - `[Id <String>]`: Resource identity path
  - `[IscsiTargetName <String>]`: The name of the iSCSI Target.
  - `[Location <String>]`: The location of the resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

