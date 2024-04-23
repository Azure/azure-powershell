---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azdatacollectionruleassociation
schema: 2.0.0
---

# Get-AzDataCollectionRuleAssociation

## SYNOPSIS
Returns the specified association.

## SYNTAX

### List (Default)
```
Get-AzDataCollectionRuleAssociation -ResourceUri <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataCollectionRuleAssociation -AssociationName <String> -ResourceUri <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataCollectionRuleAssociation -InputObject <IDataCollectionRuleIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzDataCollectionRuleAssociation -DataCollectionRuleName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### List2
```
Get-AzDataCollectionRuleAssociation -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -DataCollectionEndpointName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the specified association.

## EXAMPLES

### Example 1: List data collection rule associations with specified resource URI
```powershell
Get-AzDataCollectionRuleAssociation -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01
```

```output
Etag                                   Name                           ResourceGroupName
----                                   ----                           -----------------
"d500d29e-0000-0100-0000-650d68490000" myCollectionRule1-association  amcs-test
"20017ecf-0000-0100-0000-651147350000" myCollectionRule2-association1 amcs-test
```

This command gets list of specific data collection rule associations with specified resource URI.

### Example 2: Get specific data collection rule association with specified resource URI and association name
```powershell
Get-AzDataCollectionRuleAssociation -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -AssociationName myCollectionRule2-association1
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

This command gets specific data collection rule association with specified resource URI.

### Example 3: Get specific data collection rule association with specified resource group
```powershell
Get-AzDataCollectionRuleAssociation -DataCollectionRuleName myCollectionRule1 -ResourceGroupName AMCS-Test
```

```output
DataCollectionEndpointId        : 
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.insights/datacollectionrules/mycollectionrule1
Description                     : 
Etag                            : 
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/microsof 
                                  t.insights/datacollectionruleassociations/mycollectionrule1-association
MetadataProvisionedBy           : 
MetadataProvisionedByResourceId : 
Name                            : mycollectionrule1-association
ProvisioningState               : 
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```

This command gets list of data collection rule association with specified data collection rule.

### Example 4: List data collection endpoint associations with specified data collection endpoint
```powershell
Get-AzDataCollectionRuleAssociation -DataCollectionEndpointName myCollectionEndpoint -ResourceGroupName AMCS-Test
```

```output
Etag                                   Name                        ResourceGroupName
----                                   ----                        -----------------
"21017484-0000-0100-0000-6511505c0000" configurationAccessEndpoint amcs-test
"210182a5-0000-0100-0000-6511520c0000" configurationAccessEndpoint azsecpack-rg
```

This command gets list of specific data collection rule associations with specified data collection endpoint.

## PARAMETERS

### -AssociationName
The name of the association.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionEndpointName
The name of the data collection endpoint.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List2
Aliases: EndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionRuleName
The name of the data collection rule.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1
Aliases: RuleName

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases: TargetResourceId

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
Parameter Sets: List1, List2
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleAssociationProxyOnlyResource

## NOTES

## RELATED LINKS
