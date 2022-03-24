---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-azoperationalinsightstable
schema: 2.0.0
---

# Get-AzOperationalInsightsTable

## SYNOPSIS
Gets a Log Analytics workspace table.

## SYNTAX

### List (Default)
```
Get-AzOperationalInsightsTable -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOperationalInsightsTable -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOperationalInsightsTable -InputObject <IOperationalInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Log Analytics workspace table.

## EXAMPLES

### Example 1: List tables for a given workspace name
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName {RG-Name} -WorkspaceName {WS-Name}


Name                                         Id                                                                                                                                                                                                      RetentionInDays
----                                         --                                                                                                                                                                                                      ---------------
DatabricksTables                             /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/DatabricksTables                                          30
BlockchainProxyLog                           /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/BlockchainProxyLog                                        30
BlockchainApplicationLog                     /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/BlockchainApplicationLog                                  30
AADDomainServicesAccountLogon                /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/AADDomainServicesAccountLogon                             30
AADDomainServicesAccountManagement           /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/AADDomainServicesAccountManagement                        30

```

Get all tables for a given workspace name

### Example 2: Get a table by name
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName {RG-Name} -WorkspaceName {WS-Name} -TableName {Table-Name}

Name  Id                                                                                                                                                               RetentionInDays
----  --                                                                                                                                                               ---------------
{Table-Name} /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/{Table-Name}              90
```

Get a specific table by name for a given workspace

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the table.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TableName

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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.ITable

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IOperationalInsightsIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TableName <String>]`: The name of the table.
  - `[WorkspaceName <String>]`: The name of the workspace.

## RELATED LINKS

