---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: EC798838-1850-4E88-B17F-D2F00F2D4EE9
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermpublicipprefix
schema: 2.0.0
---

# Set-AzureRmPublicIpPrefix

## SYNOPSIS
Sets the goal state for a public IP prefix.

## SYNTAX

```
Set-AzureRmPublicIpPrefix -PublicIpPrefix <PSPublicIpPrefix> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmPublicIpPrefix** cmdlet sets the goal state for a public IP prefix.

## EXAMPLES

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -PublicIpPrefix
Specifies a **PublicIpPrefix** object that represents the goal state to which the public IP prefix should be set.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPublicIpPrefix
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSPublicIpPrefix
Parameter 'PublicIpPrefix' accepts value of type 'PSPublicIpPrefix' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPublicIpPrefix

## NOTES

## RELATED LINKS

[Get-AzureRmPublicIpPrefix](./Get-AzureRmPublicIpPrefix.md)

[New-AzureRmPublicIpPrefix](./New-AzureRmPublicIpPrefix.md)

[Remove-AzureRmPublicIpPrefix](./Remove-AzureRmPublicIpPrefix.md)


