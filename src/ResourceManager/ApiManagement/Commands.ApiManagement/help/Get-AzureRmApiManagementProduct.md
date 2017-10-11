---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
ms.assetid: B64E9C13-97A6-4E8B-92DB-EFAF8A48C5B8
online version: 
schema: 2.0.0
---

# Get-AzureRmApiManagementProduct

## SYNOPSIS
Gets a list or a particular product.

## SYNTAX

### Get all producst (Default)
```
Get-AzureRmApiManagementProduct -Context <PsApiManagementContext> [<CommonParameters>]
```

### Get by Id
```
Get-AzureRmApiManagementProduct -Context <PsApiManagementContext> -ProductId <String> [<CommonParameters>]
```

### Get by Title
```
Get-AzureRmApiManagementProduct -Context <PsApiManagementContext> [-Title <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementProduct** cmdlet gets a list or a particular product.

## EXAMPLES

### Example 1: Get all products
```
PS C:\>Get-AzureRmApiManagementProduct -Context $APImContext
```

This command get all API Management products.

### Example 2: Get a product by ID
```
PS C:\>Get-AzureRmApiManagementProduct -Context $APImContext -ProductId "0123456789"
```

This command get an API Management product by ID.

## PARAMETERS

### -Context
Specifies an instance of a **PsApiManagementContext** object.

```yaml
Type: PsApiManagementContext
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProductId
Specifies the identifier of the product to search for.

```yaml
Type: String
Parameter Sets: Get by Id
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Title
Specifies the title of the product to look for.
If specified, the cmdlet attempts to get the product by title.

```yaml
Type: String
Parameter Sets: Get by Title
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### IList<Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementProduct>

## NOTES

## RELATED LINKS

[New-AzureRmApiManagementProduct](./New-AzureRmApiManagementProduct.md)

[Remove-AzureRmApiManagementProduct](./Remove-AzureRmApiManagementProduct.md)

[Set-AzureRmApiManagementProduct](./Set-AzureRmApiManagementProduct.md)


