---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/find-azcustomlocationtargetresourcegroup
schema: 2.0.0
---

# Find-AzCustomLocationTargetResourceGroup

## SYNOPSIS
Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.

## SYNTAX

### FindExpanded (Default)
```
Find-AzCustomLocationTargetResourceGroup -CustomLocationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Label <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FindViaJsonString
```
Find-AzCustomLocationTargetResourceGroup -CustomLocationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FindViaJsonFilePath
```
Find-AzCustomLocationTargetResourceGroup -CustomLocationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### FindViaIdentityExpanded
```
Find-AzCustomLocationTargetResourceGroup -InputObject <ICustomLocationIdentity> [-Label <Hashtable>]
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.

## EXAMPLES

### EXAMPLE 1
```
Find-AzCustomLocationTargetResourceGroup -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Label @{"Key1"="Value1"} -PassThru
```

### EXAMPLE 2
```
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Find-AzCustomLocationTargetResourceGroup -InputObject $obj -Label @{"Key1"="Value1"} -PassThru
```

## PARAMETERS

### -CustomLocationName
Custom Locations name.

```yaml
Type: String
Parameter Sets: FindExpanded, FindViaJsonString, FindViaJsonFilePath
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
Parameter Sets: FindViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Find operation

```yaml
Type: String
Parameter Sets: FindViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Find operation

```yaml
Type: String
Parameter Sets: FindViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
Labels of the custom resource, this is a map of {key,value} pairs.

```yaml
Type: Hashtable
Parameter Sets: FindExpanded, FindViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: FindExpanded, FindViaJsonString, FindViaJsonFilePath
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
Parameter Sets: FindExpanded, FindViaJsonString, FindViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationFindTargetResourceGroupResult
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<ICustomLocationIdentity\>: Identity Parameter
  \[ChildResourceName \<String\>\]: Resource Sync Rule name.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceName \<String\>\]: Custom Locations name.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.customlocation/find-azcustomlocationtargetresourcegroup](https://learn.microsoft.com/powershell/module/az.customlocation/find-azcustomlocationtargetresourcegroup)

