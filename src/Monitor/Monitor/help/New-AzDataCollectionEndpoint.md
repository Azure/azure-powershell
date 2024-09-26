---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azdatacollectionendpoint
schema: 2.0.0
---

# New-AzDataCollectionEndpoint

## SYNOPSIS
Create a data collection endpoint.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataCollectionEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-Description <String>] [-IdentityType <String>] [-ImmutableId <String>] [-Kind <String>]
 [-NetworkAclsPublicNetworkAccess <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDataCollectionEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDataCollectionEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a data collection endpoint.

## EXAMPLES

### Example 1: Create endpoint
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint -ResourceGroupName AMCS-TEST -Location eastus -NetworkAclsPublicNetworkAccess Enabled
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint-bthd.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "b9029ae7-0000-0100-0000-65016d2a0000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint  
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-014e59a439e04f44af4b97b16b7614df
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint-bthd.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint-bthd.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/13/2023 8:04:55 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/13/2023 8:04:55 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command creates the endpiont with given values.

### Example 2: Create enpoint with json file
```powershell
New-AzDataCollectionEndpoint -Name myCollectionEndpoint2 -ResourceGroupName AMCS-TEST -JsonFilePath .\test\jsonfile\endpointTest1.json
# Note: content of .\test\jsonfile\endpointTest1.json
#{
#     "location": "eastus",
#     "properties": {
#         "networkAcls": {
#             "publicNetworkAccess": "Enabled"
#             }
#         }
# }
```

```output
ConfigurationAccessEndpoint         : https://mycollectionendpoint2-0e77.eastus-1.handler.control.monitor.azure.com
Description                         : 
Etag                                : "ba021b4b-0000-0100-0000-650170c20000"
FailoverConfigurationActiveLocation : 
FailoverConfigurationLocation       : 
Id                                  : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionEndpoints/myCollectionEndpoint2
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : 
IdentityUserAssignedIdentity        : {
                                      }
ImmutableId                         : dce-ab8aec1ea24a41c0a175a5692c173b76
Kind                                : 
Location                            : eastus
LogIngestionEndpoint                : https://mycollectionendpoint2-0e77.eastus-1.ingest.monitor.azure.com
MetadataProvisionedBy               : 
MetadataProvisionedByResourceId     : 
MetricIngestionEndpoint             : https://mycollectionendpoint2-0e77.eastus-1.metrics.ingest.monitor.azure.com
Name                                : myCollectionEndpoint2
NetworkAclsPublicNetworkAccess      : Enabled
PrivateLinkScopedResource           : 
ProvisioningState                   : Succeeded
ResourceGroupName                   : AMCS-TEST
SystemDataCreatedAt                 : 9/13/2023 8:20:16 AM
SystemDataCreatedBy                 : v-jiaji@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 9/13/2023 8:20:16 AM
SystemDataLastModifiedBy            : v-jiaji@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : Microsoft.Insights/dataCollectionEndpoints
```

This command creates enpoint with given json file path.

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

### -Description
Description of the data collection endpoint.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

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

### -ImmutableId
The immutable ID of this data collection endpoint resource.
This property is READ-ONLY.

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

### -Kind
The kind of the resource.

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

### -Location
The geo-location where the resource lives.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the data collection endpoint.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataCollectionEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsPublicNetworkAccess
The configuration to set whether network access from public internet to the endpoints are allowed.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionEndpointResource

## NOTES

## RELATED LINKS
