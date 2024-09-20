---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azdatacollectionruleassociation
schema: 2.0.0
---

# New-AzDataCollectionRuleAssociation

## SYNOPSIS
Create an association.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataCollectionRuleAssociation -AssociationName <String> -ResourceUri <String>
 [-DataCollectionEndpointId <String>] [-DataCollectionRuleId <String>] [-Description <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDataCollectionRuleAssociation -AssociationName <String> -ResourceUri <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDataCollectionRuleAssociation -AssociationName <String> -ResourceUri <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an association.

## EXAMPLES

### Example 1: Create data collection rule association with specified data collection rule
```powershell
New-AzDataCollectionRuleAssociation -AssociationName myCollectionRule2-association1 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -DataCollectionRuleId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
Description                     : 
Etag                            : "20017ecf-0000-0100-0000-651147350000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/myCollectionRule2-association1
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : myCollectionRule2-association1
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 8:39:15 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 8:39:15 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates data collection rule association with specified data collection rule.

### Example 2: Create data collection endpoint association with specified data collection endpoint
```powershell
New-AzDataCollectionRuleAssociation -AssociationName configurationAccessEndpoint -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -DataCollectionEndpointId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint
```

```output
DataCollectionEndpointId        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint      
DataCollectionRuleId            : 
Description                     : 
Etag                            : "21017484-0000-0100-0000-6511505c0000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/configurationAccessEndpoint
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : configurationAccessEndpoint
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:18:20 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:18:20 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command creates specific data collection endpoint association with specified data collection endpoint.

## PARAMETERS

### -AssociationName
The name of the association.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionEndpointId
The resource ID of the data collection endpoint that is to be associated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionRuleId
The resource ID of the data collection rule that is to be associated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: RuleId

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

### -Description
Description of the association.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

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
Json string supplied to the Create operation

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

### -ResourceUri
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TargetResourceId

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleAssociationProxyOnlyResource

## NOTES

## RELATED LINKS
