---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudegressendpointobject
schema: 2.0.0
---

# New-AzNetworkCloudEgressEndpointObject

## SYNOPSIS
Create an in-memory object for EgressEndpoint.

## SYNTAX

```
New-AzNetworkCloudEgressEndpointObject -Category <String> -Endpoint <IEndpointDependency[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EgressEndpoint.

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

### -Category
The descriptive category name of endpoints accessible by the AKS agent node.
For example, azure-resource-management, API server, etc.
The platform egress endpoints provided by default will use the category 'default'.

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

### -Endpoint
The list of endpoint dependencies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IEndpointDependency[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.EgressEndpoint

## NOTES

## RELATED LINKS

