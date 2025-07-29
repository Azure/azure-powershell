---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/get-azbatchaccountoutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzBatchAccountOutboundNetworkDependencyEndpoint

## SYNOPSIS
Lists the endpoints that a Batch Compute Node under this Batch Account may call as part of Batch service administration.
If you are deploying a Pool inside of a virtual network that you specify, you must make sure your network allows outbound access to these endpoints.
Failure to allow access to these endpoints may cause Batch to mark the affected nodes as unusable.
For more information about creating a pool inside of a virtual network, see https://learn.microsoft.com/azure/batch/batch-virtual-network.

## SYNTAX

```
Get-AzBatchAccountOutboundNetworkDependencyEndpoint -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the endpoints that a Batch Compute Node under this Batch Account may call as part of Batch service administration.
If you are deploying a Pool inside of a virtual network that you specify, you must make sure your network allows outbound access to these endpoints.
Failure to allow access to these endpoints may cause Batch to mark the affected nodes as unusable.
For more information about creating a pool inside of a virtual network, see https://learn.microsoft.com/azure/batch/batch-virtual-network.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the Batch account.

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

### -ResourceGroupName
The name of the resource group that contains the Batch account.

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
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IOutboundEnvironmentEndpoint

## NOTES

## RELATED LINKS

