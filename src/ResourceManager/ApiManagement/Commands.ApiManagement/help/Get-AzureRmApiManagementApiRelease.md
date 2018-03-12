---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: AzureRM.ApiManagement
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.apimanagement/get-azurermapimanagementapirelease
schema: 2.0.0
---

# Get-AzureRmApiManagementApiRelease

## SYNOPSIS
Get the API Release.

## SYNTAX

### GetAllApis (Default)
```
Get-AzureRmApiManagementApiRelease -Context <PsApiManagementContext> -ApiId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByApiId
```
Get-AzureRmApiManagementApiRelease -Context <PsApiManagementContext> -ApiId <String> -ReleaseId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementApiRelease** cmdlet gets one or more releases of the Azure API Management API.

## EXAMPLES

### Example 1: Get all releases of the API
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzureRmApiManagementApiRelease -Context $ApiMgmtContext -ApiId "echo-api"
```

This command gets all of the releases of the `echo-api` API for the specified context.

### Example 2: Get the release information of the particular API release
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzureRmApiManagementApiRelease -Context $ApiMgmtContext -ApiId "echo-api" -ReleaseId "version2-release"
```

This command gets the releases information of a particular API with the specified releaseId.

## PARAMETERS

### -ApiId
API identifier to look for.
If specified will try to get the API by the Id.

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

### -ReleaseId
The identifier of the Release.

```yaml
Type: String
Parameter Sets: GetByApiId
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

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext
System.String

## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease, Microsoft.Azure.Commands.ApiManagement.ServiceManagement, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease

## NOTES

## RELATED LINKS

[New-AzureRmApiManagementApiRelease](./Get-AzureRmApiManagementApiRelease.md)

[Remove-AzureRmApiManagementApiRelease](./Remove-AzureRmApiManagementApiRelease.md)

[Set-AzureRmApiManagementApiRelease](./Set-AzureRmApiManagementApiRelease.md)