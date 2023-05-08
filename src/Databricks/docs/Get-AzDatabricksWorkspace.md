---
external help file:
Module Name: Az.Databricks
online version: https://learn.microsoft.com/powershell/module/az.databricks/get-azdatabricksworkspace
schema: 2.0.0
---

# Get-AzDatabricksWorkspace

## SYNOPSIS
Gets the workspace.

## SYNTAX

### List1 (Default)
```
Get-AzDatabricksWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDatabricksWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDatabricksWorkspace -InputObject <IDatabricksIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDatabricksWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the workspace.

## EXAMPLES

### Example 1: Get a Databricks workspace with name
```powershell
Get-AzDatabricksWorkspace -Name databricks-test -ResourceGroupName databricks-rg-rqb2yo
```

```output
Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command gets a Databricks workspace in a resource group.

### Example 2: List all Databricks workspaces in a subscription
```powershell
Get-AzDatabricksWorkspace
```

```output
Name                ResourceGroupName    Location       Managed Resource Group ID
----                -----------------    --------       -------------------------
workspace1xfmkv     databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace1xfmkv-s41tghmif7cle
workspace-pwsh01    databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace-pwsh01-sdenr3zv5tyh9
workspacewqpya1     databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspacewqpya1-mhsacdo0pb15e
workspace2b8i61     databricks-rg-1jxsia eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace2b8i61-xmkef5d6j7483
workspace2rzshd     databricks-rg-1jxsia eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace2rzshd-oql04khm89rx3
```

This command lists all Databricks workspaces in a subscription.

### Example 3: List all Databricks workspaces in a resource group
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo
```

```output
Name            ResourceGroupName    Location       Managed Resource Group ID
----            -----------------    --------       -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
workspacefnw9gd databricks-rg-rqb2yo eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspacefnw9gd-ik7n2yfmzhuxq
workspace3o1d60 databricks-rg-rqb2yo East US 2 EUAP /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3o1d60-gancyx6kjmw71
```

This command lists all Databricks workspaces in a resource group.

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
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

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

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20230201.IWorkspace

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

