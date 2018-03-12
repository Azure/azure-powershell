---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: AzureRM.ApiManagement
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.apimanagement/set-azurermapimanagementapirevision
schema: 2.0.0
---

# Set-AzureRmApiManagementApiRevision

## SYNOPSIS
Modifies an API Revision

## SYNTAX

### ExpandedParameter (Default)
```
Set-AzureRmApiManagementApiRevision -ApiRevision <String> -Context <PsApiManagementContext> -ApiId <String>
 -Name <String> [-Description <String>] -ServiceUrl <String> [-Path <String>]
 -Protocols <PsApiManagementSchema[]> [-AuthorizationServerId <String>] [-AuthorizationScope <String>]
 [-SubscriptionKeyHeaderName <String>] [-SubscriptionKeyQueryParamName <String>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByValue
```
Set-AzureRmApiManagementApiRevision -Context <PsApiManagementContext> -ApiObject <PsApiManagementApi>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmApiManagementApiRevision** cmdlet modifies an Azure API Management API Revision.

## EXAMPLES

### Example 1 Modify an API Revision
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Set-AzureRmApiManagementApiRevision -Context $ApiMgmtContext -ApiId "echo-api" -ApiRevision "2" -Name "EchoApi" -ServiceUrl "https://contoso.com/apis/echo" -Protocols @('https') -Description "Responds with what was sent" -Path "echo"
```

The cmdlet updates the `2` revision of the API `echo-api` with a new description, protocol and path.

## PARAMETERS

### -ApiId
Identifier of existing API.
This parameter is required.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ApiObject
Instance of PsApiManagementApi.
This parameter is required.

```yaml
Type: PsApiManagementApi
Parameter Sets: ByValue
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApiRevision
Identifier of existing API Revision. This parameter is required.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuthorizationScope
OAuth operations scope.
This parameter is optional.
Default value is $null.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuthorizationServerId
OAuth authorization server identifier.
This parameter is optional.
Default value is $null.
Must be specified if AuthorizationScope specified.

```yaml
Type: String
Parameter Sets: ExpandedParameter
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

### -Description
Web API description.
This parameter is optional.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Web API name.
Public name of the API as it would appear on the developer and admin portals.
This parameter is required.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
If specified then instance of Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApi type representing the set API.

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

### -Path
Web API Path.
Last part of the API's public URL.
This URL will be used by API consumers for sending requests to the web service.
Must be 1 to 400 characters long.
This parameter is optional.
Default value is $null.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Protocols
Web API protocols (http, https).
Protocols over which API is made available.
This parameter is required.
Default value is $null.

```yaml
Type: PsApiManagementSchema[]
Parameter Sets: ExpandedParameter
Aliases:
Accepted values: Http, Https

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceUrl
A URL of the web service exposing the API.
This URL will be used by Azure API Management only, and will not be made public.
Must be 1 to 2000 characters long.
This parameter is required.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionKeyHeaderName
Subscription key header name.
This parameter is optional.
Default value is $null.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionKeyQueryParamName
Subscription key query string parameter name.
This parameter is optional.
Default value is $null.

```yaml
Type: String
Parameter Sets: ExpandedParameter
Aliases:

Required: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### System.String
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementSchema[]
Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApi

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApi

## NOTES

## RELATED LINKS

[Get-AzureRmApiManagementApiRevision](./Get-AzureRmApiManagementApiRevision.md)

[New-AzureRmApiManagementApiRevision](./New-AzureRmApiManagementApiRevision.md)

[Remove-AzureRmApiManagementApiRevision](./Remove-AzureRmApiManagementApiRevision.md)