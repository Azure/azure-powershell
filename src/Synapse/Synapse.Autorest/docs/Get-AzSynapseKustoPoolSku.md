---
external help file:
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapsekustopoolsku
schema: 2.0.0
---

# Get-AzSynapseKustoPoolSku

## SYNOPSIS
Lists eligible SKUs for Kusto Pool resource.

## SYNTAX

### List (Default)
```
Get-AzSynapseKustoPoolSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzSynapseKustoPoolSku -KustoPoolName <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists eligible SKUs for Kusto Pool resource.

## EXAMPLES

### Example 1: Lists eligible SKUs
```powershell
Get-AzSynapseKustoPoolSku
```

```output
Location             Name              ResourceType          Size
--------             ----              ------------          ----
{australiacentral}   Compute optimized workspaces/kustoPools Extra small
{australiacentral2}  Compute optimized workspaces/kustoPools Extra small
{australiaeast}      Compute optimized workspaces/kustoPools Extra small
{australiasoutheast} Compute optimized workspaces/kustoPools Extra small
{brazilsouth}        Compute optimized workspaces/kustoPools Extra small
...
```

The above command lists eligible SKUs.

### Example 2: Lists eligible SKUs for specific kusto pool
```powershell
Get-AzSynapseKustoPoolSku -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testnewkustopool
```

```output
ResourceType
------------
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
```

The above command lists eligible SKUs for specific kusto pool.

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

### -KustoPoolName
The name of the Kusto pool.

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

### -WorkspaceName
The name of the workspace

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IAzureResourceSku

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.ISkuDescription

## NOTES

## RELATED LINKS

