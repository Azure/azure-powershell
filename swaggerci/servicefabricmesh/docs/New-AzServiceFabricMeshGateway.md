---
external help file:
Module Name: Az.ServiceFabricMesh
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicefabricmesh/new-azservicefabricmeshgateway
schema: 2.0.0
---

# New-AzServiceFabricMeshGateway

## SYNOPSIS
Creates a gateway resource with the specified name, description and properties.
If a gateway resource with the same name exists, then it is updated with the specified description and properties.
Use gateway resources to create a gateway for public connectivity for services within your application.

## SYNTAX

```
New-AzServiceFabricMeshGateway -ResourceGroupName <String> -ResourceName <String> -Location <String>
 [-SubscriptionId <String>] [-Description <String>] [-DestinationNetworkEndpointRef <IEndpointRef[]>]
 [-DestinationNetworkName <String>] [-Http <IHttpConfig[]>] [-SourceNetworkEndpointRef <IEndpointRef[]>]
 [-SourceNetworkName <String>] [-Tag <Hashtable>] [-Tcp <ITcpConfig[]>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a gateway resource with the specified name, description and properties.
If a gateway resource with the same name exists, then it is updated with the specified description and properties.
Use gateway resources to create a gateway for public connectivity for services within your application.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Description
User readable description of the gateway.

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

### -DestinationNetworkEndpointRef
A list of endpoints that are exposed on this network.
To construct, see NOTES section for DESTINATIONNETWORKENDPOINTREF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IEndpointRef[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationNetworkName
Name of the network

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

### -Http
Configuration for http connectivity for this gateway.
To construct, see NOTES section for HTTP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IHttpConfig[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Azure resource group name

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

### -ResourceName
The identity of the gateway.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GatewayResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceNetworkEndpointRef
A list of endpoints that are exposed on this network.
To construct, see NOTES section for SOURCENETWORKENDPOINTREF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IEndpointRef[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceNetworkName
Name of the network

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

### -SubscriptionId
The customer subscription identifier

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tcp
Configuration for tcp connectivity for this gateway.
To construct, see NOTES section for TCP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.ITcpConfig[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IGatewayResourceDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DESTINATIONNETWORKENDPOINTREF <IEndpointRef[]>: A list of endpoints that are exposed on this network.
  - `[Name <String>]`: Name of the endpoint.

HTTP <IHttpConfig[]>: Configuration for http connectivity for this gateway.
  - `Host <IHttpHostConfig[]>`: description for routing.
    - `Name <String>`: http hostname config name.
    - `Route <IHttpRouteConfig[]>`: Route information to use for routing. Routes are processed in the order they are specified. Specify routes that are more specific before routes that can handle general cases.
      - `DestinationApplicationName <String>`: Name of the service fabric Mesh application.
      - `DestinationEndpointName <String>`: name of the endpoint in the service.
      - `DestinationServiceName <String>`: service that contains the endpoint.
      - `Name <String>`: http route name.
      - `PathValue <String>`: Uri path to match for request.
      - `[MatchHeader <IHttpRouteMatchHeader[]>]`: headers and their values to match in request.
        - `Name <String>`: Name of header to match in request.
        - `[Type <HeaderMatchType?>]`: how to match header value
        - `[Value <String>]`: Value of header to match in request.
      - `[PathRewrite <String>]`: replacement string for matched part of the Uri.
  - `Name <String>`: http gateway config name.
  - `Port <Int32>`: Specifies the port at which the service endpoint below needs to be exposed.

SOURCENETWORKENDPOINTREF <IEndpointRef[]>: A list of endpoints that are exposed on this network.
  - `[Name <String>]`: Name of the endpoint.

TCP <ITcpConfig[]>: Configuration for tcp connectivity for this gateway.
  - `DestinationApplicationName <String>`: Name of the service fabric Mesh application.
  - `DestinationEndpointName <String>`: name of the endpoint in the service.
  - `DestinationServiceName <String>`: service that contains the endpoint.
  - `Name <String>`: tcp gateway config name.
  - `Port <Int32>`: Specifies the port at which the service endpoint below needs to be exposed.

## RELATED LINKS

