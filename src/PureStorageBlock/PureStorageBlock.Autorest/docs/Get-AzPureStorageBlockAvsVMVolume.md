---
external help file:
Module Name: Az.PureStorageBlock
online version: https://learn.microsoft.com/powershell/module/az.purestorageblock/get-azpurestorageblockavsvmvolume
schema: 2.0.0
---

# Get-AzPureStorageBlockAvsVMVolume

## SYNOPSIS
Get a volume in an AVS VM

## SYNTAX

### List (Default)
```
Get-AzPureStorageBlockAvsVMVolume -AvsVMId <String> -ResourceGroupName <String> -StoragePoolName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPureStorageBlockAvsVMVolume -AvsVMId <String> -ResourceGroupName <String> -StoragePoolName <String>
 -VolumeId <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPureStorageBlockAvsVMVolume -InputObject <IPureStorageBlockIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAvsVM
```
Get-AzPureStorageBlockAvsVMVolume -AvsVMInputObject <IPureStorageBlockIdentity> -VolumeId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityStoragePool
```
Get-AzPureStorageBlockAvsVMVolume -AvsVMId <String> -StoragePoolInputObject <IPureStorageBlockIdentity>
 -VolumeId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a volume in an AVS VM

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AvsVMId
ID of the AVS VM

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityStoragePool, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvsVMInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: GetViaIdentityAvsVM
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -StoragePoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: GetViaIdentityStoragePool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StoragePoolName
Name of the storage pool

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
The value must be an UUID.

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

### -VolumeId
ID of the volume in the AVS VM

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAvsVM, GetViaIdentityStoragePool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IAvsVMVolume

## NOTES

## RELATED LINKS

