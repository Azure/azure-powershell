---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
ms.assetid: 6CD1C2B8-0416-4FF3-81B0-0C9E59AE6CF9
online version: 
schema: 2.0.0
---

# Set-AzureRmApiManagementPolicy

## SYNOPSIS
Sets the specified scope policy for API Management.

## SYNTAX

### Tenant level (Default)
```
Set-AzureRmApiManagementPolicy -Context <PsApiManagementContext> [-Format <String>] [-Policy <String>]
 [-PolicyFilePath <String>] [-PassThru] [<CommonParameters>]
```

### Product level
```
Set-AzureRmApiManagementPolicy -Context <PsApiManagementContext> [-Format <String>] -ProductId <String>
 [-Policy <String>] [-PolicyFilePath <String>] [-PassThru] [<CommonParameters>]
```

### API level
```
Set-AzureRmApiManagementPolicy -Context <PsApiManagementContext> [-Format <String>] -ApiId <String>
 [-Policy <String>] [-PolicyFilePath <String>] [-PassThru] [<CommonParameters>]
```

### Operation level
```
Set-AzureRmApiManagementPolicy -Context <PsApiManagementContext> [-Format <String>] -ApiId <String>
 -OperationId <String> [-Policy <String>] [-PolicyFilePath <String>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmApiManagementPolicy** cmdlet sets the specified scope policy for API Management.

## EXAMPLES

### Example 1: Set the tenant level policy
```
PS C:\>Set-AzureRmApiManagementPolicy -Context $APImContext -PolicyFilePath "C:\contoso\policies\tenantpolicy.xml"
```

This command sets the tenant level policy from a file named tenantpolicy.xml.

### Example 2: Set a product-scope policy
```
PS C:\>Set-AzureRmApiManagementPolicy -Context $APImContext -ProductId "0123456789" -Policy $PolicyString
```

This command sets the product-scope policy for API Management.

### Example 3: Set API-scope policy
```
PS C:\>Get-AzureRmApiManagementPolicy -Context $APImContext -ApiId "9876543210" -Policy $PolicyString
```

This command sets API-scope policy for API Management.

### Example 4: Set operation-scope policy
```
PS C:\>Set-AzureRmApiManagementPolicy -Context $APImContext -ApiId "9876543210" -OperationId "777" -Policy $PolicyString
```

This command sets operation-scope policy for API Management.

## PARAMETERS

### -ApiId
Specifies the identifier of the existing API.
If you specify this parameter, the cmdlet sets the API-scope policy.

```yaml
Type: String
Parameter Sets: API level, Operation level
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Context
Specifies the instance of **PsApiManagementContext**.

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

### -Format
Specifies the format of the policy.
The default value is "application/vnd.ms-azure-apim.policy+xml".

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OperationId
Specifies the identifier of the existing operation.
If specified with ApiId will set operation-scope policy.
This parameters is required.

```yaml
Type: String
Parameter Sets: Operation level
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
passthru

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Policy
Specifies the policy document as a string.
This parameter is required if the -*PolicyFilePath* is not specified.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyFilePath
Specifies the policy document file path.
This parameter is required if the *Policy* parameter is not specified.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProductId
Specifies the identifier of the existing product.
If this parameter is specified, the cmdlet sets the product-scope policy.

```yaml
Type: String
Parameter Sets: Product level
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### bool

## NOTES

## RELATED LINKS

[Get-AzureRmApiManagementPolicy](./Get-AzureRmApiManagementPolicy.md)

[Remove-AzureRmApiManagementPolicy](./Remove-AzureRmApiManagementPolicy.md)


