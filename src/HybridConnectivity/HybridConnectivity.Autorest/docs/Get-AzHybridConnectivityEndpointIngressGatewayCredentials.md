---
external help file:
Module Name: Az.HybridConnectivity
online version: https://learn.microsoft.com/powershell/module/az.hybridconnectivity/get-azhybridconnectivityendpointingressgatewaycredentials
schema: 2.0.0
---

# Get-AzHybridConnectivityEndpointIngressGatewayCredentials

## SYNOPSIS
Gets the ingress gateway endpoint credentials

## SYNTAX

### ListExpanded (Default)
```
Get-AzHybridConnectivityEndpointIngressGatewayCredentials -EndpointName <String> -ResourceUri <String>
 [-Expiresin <Int64>] [-ServiceName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### List
```
Get-AzHybridConnectivityEndpointIngressGatewayCredentials -EndpointName <String> -ResourceUri <String>
 -ListIngressGatewayCredentialsRequest <IListIngressGatewayCredentialsRequest> [-Expiresin <Int64>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzHybridConnectivityEndpointIngressGatewayCredentials -EndpointName <String> -ResourceUri <String>
 -JsonFilePath <String> [-Expiresin <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzHybridConnectivityEndpointIngressGatewayCredentials -EndpointName <String> -ResourceUri <String>
 -JsonString <String> [-Expiresin <Int64>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the ingress gateway endpoint credentials

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

### -EndpointName
The endpoint name.

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

### -Expiresin
The is how long the endpoint access token is valid (in seconds).

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

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListIngressGatewayCredentialsRequest
Represent ListIngressGatewayCredentials Request object.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IListIngressGatewayCredentialsRequest
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

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

### -ServiceName
The name of the service.
If not provided, the request will by pass the generation of service configuration token.

```yaml
Type: System.String
Parameter Sets: ListExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IListIngressGatewayCredentialsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IIngressGatewayResource

## NOTES

## RELATED LINKS

