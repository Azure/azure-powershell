---
external help file: Microsoft.Azure.Commands.DataFactoryV2.dll-Help.xml
Module Name: AzureRM.DataFactoryV2
online version: 
schema: 2.0.0
---

# Get-AzureRmDataFactoryV2

## SYNOPSIS
Gets information about Data Factory.

## SYNTAX

```
Get-AzureRmDataFactoryV2 [-ResourceGroupName] <String> [[-Name] <String>]
```

## DESCRIPTION
The Get-AzureRmDataFactoryV2 cmdlet gets information about data factories in an Azure resource group.
If you specify the name of a data factory, this cmdlet gets information about that data factory.
If you do not specify a name, this cmdlet gets information about all of the data factories in an Azure resource group.


## EXAMPLES

### Example 1: Get all data factories
```
PS C:\> Get-AzureRmDataFactoryV2 -ResourceGroupName "ADF"
          DataFactoryName   : WikiADF
          ResourceGroupName : ADF
          Location          : WestUS
          Tags              : {}
          Properties        : Microsoft.WindowsAzure.Commands.Utilities.PSDataFactoryConfiguration

          DataFactoryName   : WikiADF2
          ResourceGroupName : ADF
          Location          : westus
          Tags              : {}
          Properties        : Microsoft.WindowsAzure.Commands.Utilities.PSDataFactoryConfiguration
```

Displays information about all data factories in the Azure subscription.

### Example 2: Get a specific data factory
```
PS C:\> $DataFactory = Get-AzureRmDataFactoryV2 -ResourceGroupName "ADF" -Name "WikiADF"
          DataFactoryName   : WikiADF
          ResourceGroupName : ADF
          Location          : westus
          Tags              : {}
          Properties        : Microsoft.WindowsAzure.Commands.Utilities.PSDataFactoryConfiguration
```

This command displays information about the data factory named WikiADF in the subscription for the resource group named ADF, and then stores it in the $DataFactory variable.
Specify the DataFactory parameter in subsequent cmdlets to use the data factory stored in $DataFactory.

## PARAMETERS

### -Name
Specifies the name of the data factory about which to get information.

```yaml
Type: String
Parameter Sets: (All)
Aliases: DataFactoryName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of an Azure resource group.
This cmdlet gets information about data factories that belong to the group that this parameter specifies.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory, Microsoft.Azure.Commands.DataFactoryV2, Version=0.1.9.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory


## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS
[New-AzureRmDataFactoryV2]()

[Remove-AzureRmDataFactoryV2]()

