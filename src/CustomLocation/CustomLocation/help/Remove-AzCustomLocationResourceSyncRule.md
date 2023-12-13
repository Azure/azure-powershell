---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/remove-azcustomlocationresourcesyncrule
schema: 2.0.0
---

# Remove-AzCustomLocationResourceSyncRule

## SYNOPSIS
Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.

## SYNTAX

### Delete (Default)
```
Remove-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityCustomlocation
```
Remove-AzCustomLocationResourceSyncRule -Name <String> -CustomlocationInputObject <ICustomLocationIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzCustomLocationResourceSyncRule -InputObject <ICustomLocationIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.

## EXAMPLES

### EXAMPLE 1
```
Remove-AzCustomLocationResourceSyncRule -CustomLocationName azps-customlocation -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster
```

### EXAMPLE 2
```
$obj = Get-AzCustomLocationResourceSyncRule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Name azps-resourcesyncrule
Remove-AzCustomLocationResourceSyncRule -InputObject $obj
```

### EXAMPLE 3
```
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Remove-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name azps-resourcesyncrule
```

## PARAMETERS

### -CustomlocationInputObject
Identity Parameter
To construct, see NOTES section for CUSTOMLOCATIONINPUTOBJECT properties and create a hash table.

```yaml
Type: ICustomLocationIdentity
Parameter Sets: DeleteViaIdentityCustomlocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomLocationName
Custom Locations name.

```yaml
Type: String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: ICustomLocationIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Resource Sync Rule name.

```yaml
Type: String
Parameter Sets: Delete, DeleteViaIdentityCustomlocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: Delete
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
Type: String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
## OUTPUTS

### System.Boolean
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

CUSTOMLOCATIONINPUTOBJECT \<ICustomLocationIdentity\>: Identity Parameter
  \[ChildResourceName \<String\>\]: Resource Sync Rule name.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceName \<String\>\]: Custom Locations name.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

INPUTOBJECT \<ICustomLocationIdentity\>: Identity Parameter
  \[ChildResourceName \<String\>\]: Resource Sync Rule name.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceName \<String\>\]: Custom Locations name.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.customlocation/remove-azcustomlocationresourcesyncrule](https://learn.microsoft.com/powershell/module/az.customlocation/remove-azcustomlocationresourcesyncrule)

