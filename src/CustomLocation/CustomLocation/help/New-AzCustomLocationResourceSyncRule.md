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
 [-Tag <Hashtable>] [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityCustomlocationExpanded
```
New-AzCustomLocationResourceSyncRule -Name <String> -CustomlocationInputObject <ICustomLocationIdentity>
 -Location <String> [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzCustomLocationResourceSyncRule -InputObject <ICustomLocationIdentity> -Location <String>
 [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group

## EXAMPLES

### Example 1: Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group.
```powershell
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
New-AzCustomLocationResourceSyncRule -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Location eastus -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group.

## PARAMETERS

### -AsJob
Runthecommandasajob

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

### -CustomlocationInputObject
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
Parameter Sets: CreateViaIdentityCustomlocationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomLocationName
CustomLocationsname.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
PathofJsonfilesuppliedtotheCreateoperation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
JsonstringsuppliedtotheCreateoperation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Thegeo-locationwheretheresourcelives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ResourceSyncRulename.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityCustomlocationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Runthecommandasynchronously

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

### -Priority
PriorityrepresentsapriorityoftheResourceSyncRule

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectorMatchExpression
MatchExpressionsisalistofresourceselectorrequirements.ValidoperatorsincludeIn,NotIn,Exists,andDoesNotExist.Thevaluessetmustbenon-emptyinthecaseofInandNotIn.ThevaluessetmustbeemptyinthecaseofExistsandDoesNotExist.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.IMatchExpressionsProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectorMatchLabel
MatchLabelsisamapof{key,value}pairs.Asingle{key,value}inthematchLabelsmapisequivalenttoanelementofmatchExpressions,whosekeyfieldis'key',theoperatoris'In',andthevaluesarraycontainsonly'value'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
TheIDofthetargetsubscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resourcetags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityCustomlocationExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroup
Foranunmappedcustomresource,itslabelswillbeusedtofindmatchingresourcesyncrules.Ifthisresourcesyncruleisoneofthematchingruleswithhighestpriority,thentheunmappedcustomresourcewillbeprojectedtothetargetresourcegroupassociatedwiththisresourcesyncrule.Theusercreatingthisresourcesyncruleshouldhavewritepermissionsonthetargetresourcegroupandthiswritepermissionwillbevalidatedwhencreatingtheresourcesyncrule.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.IResourceSyncRule

## NOTES

## RELATED LINKS
