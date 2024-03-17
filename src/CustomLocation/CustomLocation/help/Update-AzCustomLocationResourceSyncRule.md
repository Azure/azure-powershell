---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/update-azcustomlocationresourcesyncrule
schema: 2.0.0
---

# Update-AzCustomLocationResourceSyncRule

## SYNOPSIS
Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzCustomLocationResourceSyncRule -CustomLocationName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityCustomlocationExpanded
```
Update-AzCustomLocationResourceSyncRule -Name <String> -CustomlocationInputObject <ICustomLocationIdentity>
 [-Priority <Int32>] [-SelectorMatchExpression <IMatchExpressionsProperties[]>]
 [-SelectorMatchLabel <Hashtable>] [-Tag <Hashtable>] [-TargetResourceGroup <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCustomLocationResourceSyncRule -InputObject <ICustomLocationIdentity> [-Priority <Int32>]
 [-SelectorMatchExpression <IMatchExpressionsProperties[]>] [-SelectorMatchLabel <Hashtable>]
 [-Tag <Hashtable>] [-TargetResourceGroup <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.

## EXAMPLES

### Example 1: Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.
```powershell
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
Update-AzCustomLocationResourceSyncRule -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster" -Tag @{"abc"="123"}
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.

### Example 2: Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.
```powershell
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
$obj = Get-AzCustomLocationResourceSyncRule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Name azps-resourcesyncrule
Update-AzCustomLocationResourceSyncRule -InputObject $obj -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster" -Tag @{"abc"="123"}
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.

### Example 3: Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.
```powershell
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Update-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name azps-resourcesyncrule -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster" -Tag @{"abc"="123"}
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Updates a Resource Sync Rule with the specified Resource Sync Rule name in the specified Resource Group, Subscription and Custom Location name.

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
Parameter Sets: UpdateViaIdentityCustomlocationExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
PathofJsonfilesuppliedtotheUpdateoperation

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
JsonstringsuppliedtotheUpdateoperation

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

### -Name
ResourceSyncRulename.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityCustomlocationExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityCustomlocationExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityCustomlocationExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityCustomlocationExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resourcetags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityCustomlocationExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityCustomlocationExpanded, UpdateViaIdentityExpanded
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
