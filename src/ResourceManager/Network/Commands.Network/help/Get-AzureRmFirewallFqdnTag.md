---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 98CB62E1-0A18-4207-81FA-07CC60310896
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermfirewallfqdntag
schema: 2.0.0
---

# Get-AzureRmFirewallFqdnTag

## SYNOPSIS
Gets the available Azure Firewall Fqdn Tags.

## SYNTAX

```
Get-AzureRmFirewallFqdnTag [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmFirewallFqdnTag** cmdlet gets the list of FQDN Tags which can be used for Azure Firewall Application Rules

## EXAMPLES

### 1:  Retrieve all available FQDN Tags
```
Get-AzureRmFirewallFqdnTag
```

This example retrieves all available FQDN Tags.

### 2:  Use first available FQDN Tag in an Application Rule
```
$fqdnTags = Get-AzureRmFirewallFqdnTag
New-AzureRmFirewallApplicationRule -Name AR -SourceAddress * -FqdnTag $fqdnTags[0].FqdnTagName
```

This example creates a Firewall Application Rule using the first available FQDN Tag

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

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
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallFqdnTag

## NOTES

## RELATED LINKS

[New-AzureRmFirewallApplicationRule](./New-AzureRmFirewallApplicationRule.md)

[New-AzureRmFirewall](./New-AzureRmFirewall.md)
