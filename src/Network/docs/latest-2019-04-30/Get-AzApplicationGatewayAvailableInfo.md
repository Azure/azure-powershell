---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailableinfo
schema: 2.0.0
---

# Get-AzApplicationGatewayAvailableInfo

## SYNOPSIS
Lists all available request headers, response headers, or server variables.

## SYNTAX

```
Get-AzApplicationGatewayAvailableInfo [-IncludeRequestHeaders] [-IncludeResponseHeaders]
 [-IncludeServerVariables] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all available request headers, response headers, or server variables.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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
Dynamic: False
```

### -IncludeRequestHeaders
Includes the available request headers from the application gateway

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: RequestHeader

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeResponseHeaders
Includes the available response headers from the application gateway

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: ResponseHeader

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeServerVariables
Includes the available server variables from the application gateway

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: ServerVariable

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.ApplicationGatewayAvailableInfo

## ALIASES

### Get-AzApplicationGatewayAvailableServerVariableAndHeader

## NOTES

## RELATED LINKS

