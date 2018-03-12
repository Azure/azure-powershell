---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: AzureRM.ApiManagement
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.apimanagement/get-azurermapimanagementapiversionset
schema: 2.0.0
---

# Get-AzureRmApiManagementApiVersionSet

## SYNOPSIS
Get the details of the API Version Sets

## SYNTAX

### GetAllApiVersionSets (Default)
```
Get-AzureRmApiManagementApiVersionSet -Context <PsApiManagementContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetVersionSetbyId
```
Get-AzureRmApiManagementApiVersionSet -Context <PsApiManagementContext> -ApiVersionSetId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementApiVersionSet** cmdlet gets the details of the API Version Sets configured in an API Management context.

## EXAMPLES

### Example 1

### Example 1: Get all API Version Sets
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzureRmApiManagementApiVersionSet -Context $ApiMgmtContext
```

This command gets all of the API Version sets for the specified context.

### Example 2: Get a API Version Set by ID
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzureRmApiManagementApiVersionSet -Context $ApiMgmtContext -ApiId $ApiId
```

This command gets the API Version Set with the specified ID.

## PARAMETERS

### -ApiVersionSetId
API identifier to look for.
If specified will try to get the API by the Id.

```yaml
Type: String
Parameter Sets: GetVersionSetbyId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Context
Instance of PsApiManagementContext.
This parameter is required.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext
System.String

## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiVersionSet, Microsoft.Azure.Commands.ApiManagement.ServiceManagement, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiVersionSet

## NOTES

## RELATED LINKS

[New-AzureRmApiManagementApiVersionSet](./New-AzureRmApiManagementApiVersionSet.md)

[Remove-AzureRmApiManagementApiSet](./Remove-AzureRmApiManagementApiVersionSet.md)

[Set-AzureRmApiManagementApiVersionSet](./Set-AzureRmApiManagementApiSet.md)
