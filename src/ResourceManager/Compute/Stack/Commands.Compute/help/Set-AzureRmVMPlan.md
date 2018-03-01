---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
ms.assetid: A1EA7D34-A8B4-4FA0-BD8C-3E846715AFBA
online version: 
schema: 2.0.0
---

# Set-AzureRmVMPlan

## SYNOPSIS
Sets the Marketplace plan information on a virtual machine.

## SYNTAX

```
Set-AzureRmVMPlan [-VM] <PSVirtualMachine> [-Name] <String> [[-Product] <String>] [[-PromotionCode] <String>]
 [[-Publisher] <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmVMPlan** cmdlet sets the Azure Marketplace plan information for a virtual machine.

Before being able to deploy a Marketplace image through the command-line, programmatic access must be enabled or the virtual machine must be deployed by using the Azure portal.

## EXAMPLES

## PARAMETERS

### -Name
Specifies the name of the image from the Marketplace.
This is the same value that is returned by the Get-AzureRmVMImageSku cmdlet.
For more information about how to find image information, see [Navigating and Selecting Azure Virtual Machine images with PowerShell and the Azure CLI](https://azure.microsoft.com/documentation/articles/resource-groups-vm-searching/) in the Microsoft Azure documentation.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Product
Specifies the product of the image from the Marketplace.
This is the same information as the **Offer** value of the **imageReference** element.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PromotionCode
Specifies a promotion code.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Publisher
Specifies the publisher of the image.
You can find this information by using the Get-AzureRmVMImagePublisher cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VM
Specifies the virtual machine object for which to set a Marketplace plan.
You can use the Get-AzureRmVM cmdlet to obtain a virtual machine object.
You can use the New-AzureRmVMConfig cmdlet to create a virtual machine object.

```yaml
Type: PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

[Get-AzureRmVM](./Get-AzureRmVM.md)

[Get-AzureRmVMImagePublisher](./Get-AzureRmVMImagePublisher.md)

[Get-AzureRmVMImageSku](./Get-AzureRmVMImageSku.md)

[New-AzureRmVMConfig](./New-AzureRmVMConfig.md)
