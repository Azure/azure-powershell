---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: Az.ApiManagement
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.apimanagement/new-azapimanagementhttpmessagediagnostic
=======
online version: https://docs.microsoft.com/powershell/module/az.apimanagement/new-azapimanagementhttpmessagediagnostic
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# New-AzApiManagementHttpMessageDiagnostic

## SYNOPSIS
Creates an instance of **PsApiManagementHttpMessageDiagnostic** which is an Http Message diagnostic setting of the Diagnostic

## SYNTAX

```
New-AzApiManagementHttpMessageDiagnostic [-HeadersToLog <String[]>] [-BodyBytesToLog <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The cmdlet **New-AzApiManagementHttpMessageDiagnostic** creates the Http Message diagnostic setting.

## EXAMPLES

<<<<<<< HEAD
### Example 1 : Create a Basic Http Message diagnostic Setting
=======
### Example 1: Create a Basic Http Message diagnostic Setting
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```powershell
PS C:\>  New-AzApiManagementHttpMessageDiagnostic -Headers 'Content-Type', 'UserAgent' -BodyBytes 100

Headers                   Body
-------                   ----
{Content-Type, UserAgent} Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementBodyDiagnosticSetting
```

<<<<<<< HEAD
Create a http message diagnostic setting to log `Content-Type` and `User-Agent` headers along with 100 byts of `body`
=======
Create a http message diagnostic setting to log `Content-Type` and `User-Agent` headers along with 100 bytes of `body`
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -BodyBytesToLog
Number of request body bytes to log. This parameter is optional.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeadersToLog
The array of headers to log. This parameter is optional.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementHttpMessageDiagnostic

## NOTES

## RELATED LINKS

[New-AzApiManagementDiagnostic](./New-AzApiManagementDiagnostic.md)

[New-AzApiManagementSamplingSetting](./New-AzApiManagementHttpMessageDiagnostic.md)