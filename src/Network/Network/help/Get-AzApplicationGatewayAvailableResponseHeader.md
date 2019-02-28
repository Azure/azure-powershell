---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailableresponseheader
schema: 2.0.0
---

# Get-AzApplicationGatewayAvailableResponseHeader

## SYNOPSIS
Gets all available response headers for application gateway.

## SYNTAX

```
Get-AzApplicationGatewayAvailableResponseHeader [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayAvailableResponseHeader** cmdlet gets all available response headers for application gateway.

## EXAMPLES

### Example 1
```
PS C:\> $availableResponseHeaders = Get-AzApplicationGatewayAvailableResponseHeader
```

This command returns all the available response headers.

## PARAMETERS

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

### System.String

## NOTES
**List-AzApplicationGatewayAvailableResponseHeader** is an alias for the **Get-AzApplicationGatewayAvailableResponseHeader** cmdlet.

## RELATED LINKS
