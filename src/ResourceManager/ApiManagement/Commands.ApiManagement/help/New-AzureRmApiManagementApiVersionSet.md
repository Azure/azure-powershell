---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: AzureRM.ApiManagement
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.apimanagement/new-azurermapimanagementapiversionset
schema: 2.0.0
---

# New-AzureRmApiManagementApiVersionSet

## SYNOPSIS
Creates an API Version Set.

## SYNTAX

```
New-AzureRmApiManagementApiVersionSet -Context <PsApiManagementContext> [-ApiVersionSetId <String>]
 -Name <String> -Scheme <PsApiManagementVersioningScheme> [-HeaderName <String>] [-QueryName <String>]
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmApiManagementApiVersionSet** cmdlet creates an API Version set entity in the Azure API Management context.

## EXAMPLES

### Example 1
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>New-AzureRmApiManagementApiVersionSet -Context $ApiMgmtContext -Name "Query VersionSet" -Scheme Query -QueryName "api-version" -Description "Azure version query string"
```

This command creates an API Version Set which versioning scheme `Query` and Query parameter `api-version`.

## PARAMETERS

### -ApiVersionSetId
Identifier for new API Version Set.
This parameter is optional.
If not specified an identifier will be generated.

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
Accept pipeline input: True (ByValue)
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

### -Description
Description of the Api Version set.

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

### -HeaderName
The Header value which will contain the versioning information.
If versioning Scheme HEADER is choosen, then this value must be specified.

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

### -Name
The name of the ApiVersion Set.
This parameter is required.

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

### -QueryName
The Query value which will contain the versioning information.
If versioning Scheme Query is choosen, then this value must be specified.

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

### -Scheme
Versioning Scheme to select for the Api Versioning Set.
This parameter is required.

```yaml
Type: PsApiManagementVersioningScheme
Parameter Sets: (All)
Aliases:
Accepted values: Segment, Query, Header

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementVersioningScheme

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiVersionSet

## NOTES

## RELATED LINKS

[Get-AzureRmApiManagementApiVersionSet](./Get-AzureRmApiManagementApiVersionSet.md)

[Remove-AzureRmApiManagementApiVersionSet](./Remove-AzureRmApiManagementApiVersionSet.md)

[Set-AzureRmApiManagementApiVersionSet](./Set-AzureRmApiManagementApiVersionSet.md)