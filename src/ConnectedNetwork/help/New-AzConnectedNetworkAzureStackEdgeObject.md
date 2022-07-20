---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://docs.microsoft.com/powershell/module/az.ConnectedNetwork/new-AzConnectedNetworkAzureStackEdgeObject
schema: 2.0.0
---

# New-AzConnectedNetworkAzureStackEdgeObject

## SYNOPSIS
Create a in-memory object for AzureStackEdgeFormat

## SYNTAX

```
New-AzConnectedNetworkAzureStackEdgeObject [-AzureStackEdgeId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for AzureStackEdgeFormat

## EXAMPLES

### Example 1: Create a in-memory stored AzureStackEdgeFormat object for creating the device
```powershell
New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId "/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse1"
```

```output
eviceType     ProvisioningState Status
----------     ----------------- ------
AzureStackEdge
```

Create a in-memory stored AzureStackEdgeFormat object for creating the device

## PARAMETERS

### -AzureStackEdgeId
Resource ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.AzureStackEdgeFormat

## NOTES

ALIASES

## RELATED LINKS

