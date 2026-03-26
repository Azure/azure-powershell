---
external help file: Az.NetworkCloud-help.xml
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

### Example 1: Create an in-memory object for EgressEndpointObject.
```powershell
$endpointDependency=New-AzNetworkCloudEndpointDependencyObject -DomainName domainName -Port 1234

New-AzNetworkCloudEgressEndpointObject -Category "azure-resource-management" -Endpoint ($endpointDependency)
```

```output
Category
--------
azure-resource-management
```

Create an in-memory object for EgressEndpoint.

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
