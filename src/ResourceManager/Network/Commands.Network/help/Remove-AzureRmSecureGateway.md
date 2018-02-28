---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 9DBD5ADF-C30E-4D1A-A4CB-4D70C21088F3
online version:
schema: 2.0.0
---

# Remove-AzureRmSecureGateway

## SYNOPSIS
Remove a secure gateway

## SYNTAX

```
Remove-AzureRmSecureGateway -ResourceGroupName <String> -Name <String>
```

## DESCRIPTION
The **Remove-AzureRmSecureGateway** cmdlet removes an Azure secure gateway.

## EXAMPLES

### 1: Create and delete a secure gateway
```
New-AzureRmSecureGateway -Name "secGw" -ResourceGroupName "rgName" -Location centralus

Remove-AzureRmSecureGateway -Name "secGw" -ResourceGroupName "rgName"
```

This example creates a secure gateway in a resource group and then immediately deletes it. To suppress the prompt when deleting the secure gateway, use the -Force flag.

## PARAMETERS

### -Name
Specifies the name of the virtual network that this cmdlet removes.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the virtual network that this cmdlet removes.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmSecureGateway](./Get-AzureRmSecureGateway.md)

[New-AzureRmSecureGateway](./New-AzureRmSecureGateway.md)

[Set-AzureRmSecureGateway](./Set-AzureRmSecureGateway.md)
