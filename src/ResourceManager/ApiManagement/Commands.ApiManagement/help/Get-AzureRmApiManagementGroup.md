---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
ms.assetid: EEB52CCA-F5D6-4ACB-A6C9-D07C510A5878
online version: 
schema: 2.0.0
---

# Get-AzureRmApiManagementGroup

## SYNOPSIS
Gets all or specific API management groups.

## SYNTAX

### Get all groups (Default)
```
Get-AzureRmApiManagementGroup -Context <PsApiManagementContext> [-Name <String>] [<CommonParameters>]
```

### Get by group ID
```
Get-AzureRmApiManagementGroup -Context <PsApiManagementContext> [-GroupId <String>] [-Name <String>]
 [<CommonParameters>]
```

### Find groups by user
```
Get-AzureRmApiManagementGroup -Context <PsApiManagementContext> [-Name <String>] [-UserId <String>]
 [<CommonParameters>]
```

### Find groups by product
```
Get-AzureRmApiManagementGroup -Context <PsApiManagementContext> [-Name <String>] [-ProductId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementGroup** cmdlet gets all or specific API management groups.

## EXAMPLES

### Example 1: Get all groups
```
PS C:\>Get-AzureRmApiManagementGroup -Context $APImContext
```

This command gets all groups.

### Example 2: Get a group by ID
```
PS C:\>Get-AzureRmApiManagementGroup -Context $APImContext -GroupId "0123456789"
```

This command gets  the group ID named 0123456789.

### Example 3: Get a group by name
```
PS C:\>Get-AzureRmApiManagementGroup -Context $APImContext -Name "Group0002"
```

This command gets the group named Group0002.

### Example 4: Get all user groups
```
PS C:\>Get-AzureRmApiManagementGroup -Context $APImContext -UserId "0123456789"
```

This command gets all user groups with the user ID named 0123456789.

## PARAMETERS

### -Context
Specifies an instance of PsApiManagementContext.

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

### -GroupId
Specifies the group ID.
If specified, the cmdlet attempts to find the group by the identifier.

```yaml
Type: String
Parameter Sets: Get by group ID
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the management group.

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
Identifier of existing product.
If specified will return all groups the product assigned to.
This parameter is optional.

```yaml
Type: String
Parameter Sets: Find groups by product
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserId
Specifies the identifier of existing product.
If specified the cmdlet will return all groups the product assigned to.

```yaml
Type: String
Parameter Sets: Find groups by user
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

### IList<Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementGroup>

## NOTES

## RELATED LINKS

[New-AzureRmApiManagementGroup](./New-AzureRmApiManagementGroup.md)

[Remove-AzureRmApiManagementGroup](./Remove-AzureRmApiManagementGroup.md)

[Set-AzureRmApiManagementGroup](./Set-AzureRmApiManagementGroup.md)


