---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudendpointdependencyobject
schema: 2.0.0
---

# New-AzNetworkCloudEndpointDependencyObject

## SYNOPSIS
Create an in-memory object for EndpointDependency.

## SYNTAX

```
New-AzNetworkCloudEndpointDependencyObject -DomainName <String> [-Port <Int64>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EndpointDependency.

## EXAMPLES

### Example 1: Create endpoint dependency for API server
```powershell
New-AzNetworkCloudEndpointDependencyObject -DomainName "api.example.com" -Port 443
```

```output
DomainName : api.example.com
Port       : 443
```

This example creates an endpoint dependency object for an API server at the specified domain and port.

### Example 2: Create endpoint dependency without port specification
```powershell
New-AzNetworkCloudEndpointDependencyObject -DomainName "registry.example.com"
```

```output
DomainName : registry.example.com
Port       : 
```

This example creates an endpoint dependency object without specifying a port, which will use the default.

## PARAMETERS

### -DomainName
The domain name of the dependency.

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

### -Port
The port of this endpoint.

```yaml
Type: System.Int64
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.EndpointDependency

## NOTES

## RELATED LINKS
