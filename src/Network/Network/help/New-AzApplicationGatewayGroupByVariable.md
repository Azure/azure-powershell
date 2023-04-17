---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewaygroupbyvariable
schema: 2.0.0
---

# New-AzApplicationGatewayGroupByVariable

## SYNOPSIS
Creates a new GroupByVariable for the application gateway GroupByUserSession.

## SYNTAX

```
New-AzApplicationGatewayGroupByVariable -VariableName<String> 
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayGroupByVariable** creates a new GroupByVariable for the application gateway GroupByUserSession.

## EXAMPLES

### Example 1
```powershell
New-AzApplicationGatewayGroupByVariable -VariableName ClientAddr
```

The command creates a new GroupByVariable, with the VariableName ClientAddr

## PARAMETERS

### -VariableName
User Session clause variable.

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRule

## NOTES

## RELATED LINKS
