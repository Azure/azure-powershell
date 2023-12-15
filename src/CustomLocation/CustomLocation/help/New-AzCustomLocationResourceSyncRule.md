---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/new-azcustomlocationresourcesyncrule
schema: 2.0.0
---

# New-AzCustomLocationResourceSyncRule

## SYNOPSIS
Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group

## SYNTAX

### CreateExpanded (Default)
```
New-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-Priority <Int32>]
 [-SelectorMatchExpression <IMatchExpressionsProperties[]>] [-SelectorMatchLabel <Hashtable>]
 [-Tag <Hashtable>] [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityCustomlocationExpanded
```
New-AzCustomLocationResourceSyncRule -Name <String> -CustomlocationInputObject <ICustomLocationIdentity>
 -Location <String> [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzCustomLocationResourceSyncRule -InputObject <ICustomLocationIdentity> -Location <String>
 [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group

## EXAMPLES

### EXAMPLE 1
```
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
New-AzCustomLocationResourceSyncRule -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Location eastus -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster"
```

## PARAMETERS

### -AsJob
Run the command as a job

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

### -CustomlocationInputObject
Identity Parameter
To construct, see NOTES section for CUSTOMLOCATIONINPUTOBJECT properties and create a hash table.

```yaml
Type: ICustomLocationIdentity
Parameter Sets: CreateViaIdentityCustomlocationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource Sync Rule name.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityCustomlocationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Priority
Priority represents a priority of the Resource Sync Rule

```yaml
Type: Int32
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectorMatchExpression
MatchExpressions is a list of resource selector requirements.
Valid operators include In, NotIn, Exists, and DoesNotExist.
The values set must be non-empty in the case of In and NotIn.
The values set must be empty in the case of Exists and DoesNotExist.
To construct, see NOTES section for SELECTORMATCHEXPRESSION properties and create a hash table.

```yaml
Type: IMatchExpressionsProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectorMatchLabel
MatchLabels is a map of {key,value} pairs.
A single {key,value} in the matchLabels map is equivalent to an element of matchExpressions, whose key field is 'key', the operator is 'In', and the values array contains only 'value'.

```yaml
Type: Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
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
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroup
For an unmapped custom resource, its labels will be used to find matching resource sync rules.
If this resource sync rule is one of the matching rules with highest priority, then the unmapped custom resource will be projected to the target resource group associated with this resource sync rule.
The user creating this resource sync rule should have write permissions on the target resource group and this write permission will be validated when creating the resource sync rule.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.IResourceSyncRule
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

SELECTORMATCHEXPRESSION \<IMatchExpressionsProperties\[\]\>: MatchExpressions is a list of resource selector requirements.
Valid operators include In, NotIn, Exists, and DoesNotExist.
The values set must be non-empty in the case of In and NotIn.
The values set must be empty in the case of Exists and DoesNotExist.
  \[Key \<String\>\]: Key is the label key that the selector applies to.
  \[Operator \<String\>\]: The Operator field represents a key's relationship to a set of values.
Valid operators are In, NotIn, Exists and DoesNotExist.
  \[Value \<List\<String\>\>\]: The label value

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.customlocation/new-azcustomlocationresourcesyncrule](https://learn.microsoft.com/powershell/module/az.customlocation/new-azcustomlocationresourcesyncrule)

