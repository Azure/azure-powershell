---
external help file:
Module Name: Az.Databricks
online version: https://learn.microsoft.com/powershell/module/az.databricks/get-azdatabricksaccessconnector
schema: 2.0.0
---

# Get-AzDatabricksAccessConnector

## SYNOPSIS
Gets an azure databricks accessConnector.

## SYNTAX

### List1 (Default)
```
Get-AzDatabricksAccessConnector [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDatabricksAccessConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDatabricksAccessConnector -InputObject <IDatabricksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzDatabricksAccessConnector -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an azure databricks accessConnector.

## EXAMPLES

### Example 1: List all access connectors under a subscription
```powershell
Get-AzDatabricksAccessConnector
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command lists all access connectors under a subscription.

### Example 2: List all access connectors under a resource group
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command lists all access connectors under a resource group.

### Example 3: Get a access connectors by name
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command gets a access connectors by name.

### Example 4: Get a access connectors by pipeline
```powershell
New-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac -Location eastus | Get-AzDatabricksAccessConnector
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command gets a access connectors by pipeline.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the azure databricks accessConnector.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20221001Preview.IAccessConnector

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDatabricksIdentity>`: Identity Parameter
  - `[ConnectorName <String>]`: The name of the azure databricks accessConnector.
  - `[GroupId <String>]`: The name of the private link resource
  - `[Id <String>]`: Resource identity path
  - `[PeeringName <String>]`: The name of the workspace vNet peering.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WorkspaceName <String>]`: The name of the workspace.

## RELATED LINKS

