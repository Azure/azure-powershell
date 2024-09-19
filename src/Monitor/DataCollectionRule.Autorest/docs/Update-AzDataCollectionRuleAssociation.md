---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azdatacollectionruleassociation
schema: 2.0.0
---

# Update-AzDataCollectionRuleAssociation

## SYNOPSIS
Update an association.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataCollectionRuleAssociation -AssociationName <String> -ResourceUri <String>
 [-DataCollectionEndpointId <String>] [-DataCollectionRuleId <String>] [-Description <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataCollectionRuleAssociation -InputObject <IDataCollectionRuleIdentity>
 [-DataCollectionEndpointId <String>] [-DataCollectionRuleId <String>] [-Description <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an association.

## EXAMPLES

### Example 1: Update specific data collection endpoint association with specified name and resource URI
```powershell
Update-AzDataCollectionRuleAssociation -AssociationName configurationAccessEndpoint -DataCollectionEndpointId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01 -Description "monitor test VM endpoint association"
```

```output
DataCollectionEndpointId        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint      
DataCollectionRuleId            : 
Description                     : monitor test VM endpoint association
Etag                            : "2101c8f4-0000-0100-0000-6511563b0000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01/providers/Microsof 
                                  t.Insights/dataCollectionRuleAssociations/configurationAccessEndpoint
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : configurationAccessEndpoint
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:43:23 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:43:23 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command updates specific data collection endpoint association with specified data collection association name and resource URI

### Example 2: Update specific data collection rule association with specified data collection association name and resource URI
```powershell
Update-AzDataCollectionRuleAssociation -AssociationName myCollectionRule1-association -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01 -Description "new"
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1
Description                     : new
Etag                            : "2201bb11-0000-0100-0000-651157920000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/Microsoft.Compute/virtualMachines/MonitorTestVM01/providers/Microsoft.Insights/dataCollectionRuleAssociations/myCollectionRule1-association 
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : myCollectionRule1-association
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 9:49:06 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 9:49:06 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command updates specific data collection rule association with specified name and resource URI.

## PARAMETERS

### -AssociationName
The name of the association.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceUri
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleAssociationProxyOnlyResource

## NOTES

## RELATED LINKS

