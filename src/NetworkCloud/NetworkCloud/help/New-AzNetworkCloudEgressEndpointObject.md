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

### Example 1: Create egress endpoint for Azure resource management
```powershell
$endpoint = New-AzNetworkCloudEndpointDependencyObject -DomainName "management.azure.com" -Port 443
New-AzNetworkCloudEgressEndpointObject -Category "azure-resource-management" -Endpoint @($endpoint)
```

```output
Category : azure-resource-management
Endpoint : {Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.EndpointDependency}
```

This example creates an egress endpoint configuration for Azure resource management endpoints.

### Example 2: Create egress endpoint with multiple domain dependencies
```powershell
$endpoint1 = New-AzNetworkCloudEndpointDependencyObject -DomainName "api.github.com" -Port 443
$endpoint2 = New-AzNetworkCloudEndpointDependencyObject -DomainName "github.com" -Port 443
New-AzNetworkCloudEgressEndpointObject -Category "github" -Endpoint @($endpoint1, $endpoint2)
```

```output
Category : github
Endpoint : {Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.EndpointDependency, Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.EndpointDependency}
```

This example creates an egress endpoint configuration for GitHub with multiple domain dependencies.

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
