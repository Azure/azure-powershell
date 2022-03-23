---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightsdeletedworkspace
schema: 2.0.0
---

# Get-AzOperationalInsightsDeletedWorkspace

## SYNOPSIS
Gets recently deleted workspaces in a subscription, available for recovery.

## SYNTAX

### List (Default)
```
Get-AzOperationalInsightsDeletedWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets recently deleted workspaces in a subscription, available for recovery.

## EXAMPLES

### Example 1: List all deleted workspaces for a given resource group
```powershell
Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName {RG-Name}

Name                            : {WS-Name1}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name1}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures

Name                            : {WS-Name2}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name2}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures
```

Get all deleted workspaces for a given resource group

### Example 2: Get a deleted workspace by resource group and name
```powershell
Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName {RG-Name} -Name {WS-Name1}

Name                            : {WS-Name1}
ResourceId                      : /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/microsoft.operationalinsights/workspaces/{WS-Name1}
ResourceGroupName               : {RG-Name}
Location                        : eastus2euap
Tags                            : {}
Sku                             : pergb2018
CapacityReservationLevel        :
LastSkuUpdate                   : Tue, 12 Jan 2021 11:25:15 GMT
retentionInDays                 : 30
CustomerId                      : 43eda0ea-004a-48e8-9c40-1219418083de
ProvisioningState               : Succeeded
PublicNetworkAccessForIngestion : Enabled
PublicNetworkAccessForQuery     : Enabled
PrivateLinkScopedResources      :
WorkspaceCapping                : Microsoft.Azure.Management.OperationalInsights.Models.WorkspaceCapping
CreatedDate                     : Tue, 12 Jan 2021 11:25:15 GMT
ModifiedDate                    : Wed, 19 Jan 2022 20:50:32 GMT
ForceCmkForQuery                :
WorkspaceFeatures               : Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspaceFeatures
```

Get a specific deleted workspace  by resource group and name

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.IWorkspace

## NOTES

ALIASES

## RELATED LINKS

