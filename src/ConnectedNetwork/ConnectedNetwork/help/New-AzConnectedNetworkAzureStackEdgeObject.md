---
external help file: Az.ConnectedNetwork-help.xml
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedNetwork/new-azconnectednetworkazurestackedgeobject
schema: 2.0.0
---

# New-AzConnectedNetworkAzureStackEdgeObject

## SYNOPSIS
Create an in-memory object for AzureStackEdgeFormat.

## SYNTAX

```
New-AzConnectedNetworkAzureStackEdgeObject [-AzureStackEdgeId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureStackEdgeFormat.

## EXAMPLES

### Example 1: Create a in-memory stored AzureStackEdgeFormat object for creating the device
```powershell
New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId "/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse1"
```

```output
DeviceType     ProvisioningState Status
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.AzureStackEdgeFormat

## NOTES

## RELATED LINKS
