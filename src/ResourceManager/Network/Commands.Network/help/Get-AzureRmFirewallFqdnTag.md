---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 91D58F60-F22A-454A-B04C-E5AEF33E9D06
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermfirewallfqdntag
schema: 2.0.0
---

# Get-AzureRmFirewallFqdnTag

## SYNOPSIS
Gets available Azure Firewall FQDN Tags.

## SYNTAX

```
Get-AzureRmFirewallFqdnTag [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmFirewallFqdnTag** cmdlet gets all FQDN Tags that can be used on a Firewall configuration.

## EXAMPLES

### 1:  Retrieve all Azure Firewall FQDN Tags
```
Get-AzureRmFirewallFqdnTag
```

This example retrieves all available Azure Firewall FQDN Tags.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
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

[Get-AzureRmFirewall](./Get-AzureRmFirewall.md)

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Set-AzureRmFirewall](./Set-AzureRmFirewall.md)
