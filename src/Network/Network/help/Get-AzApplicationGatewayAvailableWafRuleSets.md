---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailablewafrulesets
schema: 2.0.0
---

# Get-AzApplicationGatewayAvailableWafRuleSets

## SYNOPSIS
Gets all available web application firewall rule sets.

## SYNTAX

```
Get-AzApplicationGatewayAvailableWafRuleSets [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayAvailableWafRuleSets** cmdlet gets all available web application firewall rule sets.

## EXAMPLES

### Example 1
```
PS C:\>$availableRuleSets = Get-AzApplicationGatewayAvailableWafRuleSets
```

This commands returns all the available web application firewall rule sets.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAvailableWafRuleSetsResult

## NOTES
**List-AzApplicationGatewayAvailableWafRuleSets** is an alias for the **Get-AzApplicationGatewayAvailableWafRuleSets** cmdlet.

## RELATED LINKS
