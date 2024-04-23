---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azdatacollectionendpoint
schema: 2.0.0
---

# Get-AzDataCollectionEndpoint

## SYNOPSIS
Returns the specified data collection endpoint.

## SYNTAX

### List1 (Default)
```
Get-AzDataCollectionEndpoint [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataCollectionEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzDataCollectionEndpoint -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataCollectionEndpoint -InputObject <IDataCollectionRuleIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Returns the specified data collection endpoint.

## EXAMPLES

### Example 1: Get data collection endpoints by subscription ID
```powershell
Get-AzDataCollectionEndpoint
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

This command lists all the data collection endpoints for the current subscription.

### Example 2: Get data collection endpoints for the given resource group
```powershell
Get-AzDataCollectionEndpoint -ResourceGroupName AMCS-TEST
```

```output
Etag                                   Kind Location Name                  ResourceGroupName
----                                   ---- -------- ----                  -----------------
"b9029ae7-0000-0100-0000-65016d2a0000"      eastus   myCollectionEndpoint  AMCS-TEST
"ba021b4b-0000-0100-0000-650170c20000"      eastus   myCollectionEndpoint2 AMCS-TEST
```

This command lists data collection endpoints for the given resource group.

### Example 3: Get a data collection endpoint
```powershell
Get-AzDataCollectionEndpoint -ResourceGroupName AMCS-TEST -Name myCollection
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

This command lists one (a list with a single element) data collection endpoint.

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

### -Name
The name of the data collection endpoint.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DataCollectionEndpointName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionEndpointResource

## NOTES

## RELATED LINKS
