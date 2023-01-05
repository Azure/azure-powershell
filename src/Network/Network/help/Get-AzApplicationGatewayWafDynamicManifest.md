---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azapplicationgatewaywafdynamicmanifest
schema: 2.0.0
---

# Get-AzApplicationGatewayWafDynamicManifest

## SYNOPSIS
Gets the web application firewall manifest and all the supported rule sets.

## SYNTAX

```
Get-AzApplicationGatewayWafDynamicManifest -Location <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayWafDynamicManifest** cmdlet gets athe web application firewall manifest and all the supported rule sets .

## EXAMPLES

### Example 1
```powershell
$wafManifest = Get-AzApplicationGatewayWafDynamicManifest -Location westcentralus
```

This commands returns the web application firewall manifest and all the supported rule sets.

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

### -Location
The location where resource usage is queried.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSUsage

## NOTES

## RELATED LINKS
