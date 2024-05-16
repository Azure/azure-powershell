---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azdatacollectionendpoint
schema: 2.0.0
---

# Update-AzDataCollectionEndpoint

## SYNOPSIS
Updates part of a data collection endpoint.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataCollectionEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityType <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataCollectionEndpoint -InputObject <IDataCollectionRuleIdentity> [-IdentityType <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates part of a data collection endpoint.

## EXAMPLES

### Example 1: Update tag for data collection endpoint
```powershell
Update-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Tag @{"123"="abc"}
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint-yz4d.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "22014545-0000-0100-0000-65115a540000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint  
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-8011fcc7985844938c3809e497420638
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint-yz4d.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint-yz4d.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/18/2023 2:37:19 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/25/2023 10:00:51 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "123": "abc"
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command updates data collection endpoint.

## PARAMETERS

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

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

### -Name
The name of the data collection endpoint.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DataCollectionEndpointName

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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionEndpointResource

## NOTES

## RELATED LINKS

