---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailableservervariable
schema: 2.0.0
---

# Get-AzApplicationGatewayAvailableServerVariable

## SYNOPSIS
Gets all available server variables for application gateway.

## SYNTAX

```
Get-AzApplicationGatewayAvailableServerVariable [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayAvailableServerVariable** cmdlet gets all available server variables for application gateway.

## EXAMPLES

### Example 1
```
PS C:\> $availableServerVariables = Get-AzApplicationGatewayAvailableServerVariable
```

This command returns all the available server variables.

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
**List-AzApplicationGatewayAvailableServerVariable** is an alias for the **Get-AzApplicationGatewayAvailableServerVariable** cmdlet.

## RELATED LINKS
