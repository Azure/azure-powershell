---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: Az.ApiManagement
online version:
schema: 2.0.0
---

# Get-AzApiManagementApiLoggers

## SYNOPSIS
Get attached loggers of an API.

## SYNTAX

```
Get-AzApiManagementApiLoggers [-Context] <PsApiManagementContext> [-ApiId] <String> [[-DiagnosticId] <String>]
 [[-DefaultProfile] <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApiManagementApiLoggers** cmdlet gets attached logger of an Azure API Management API.
 

## EXAMPLES

### Example 1
```powershell
PS C:\>$context = New-AzApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzApiManagementApiLoggers -Context $context -ApiId "0001" -DiagnosticId "applicationinsights"
```

This example the attached loggers of the API 0001

## PARAMETERS

### -ApiId
API identifier to look for.
If specified will try to get the API by the Id.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Nommé
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
Position: Nommé
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```
### -DiagnosticId
The identifier of the diagnostic.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Nommé
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Nommé
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementLogger

## NOTES

## RELATED LINKS

[Attach-AzApiManagementApiDiagnosticLogger](./Attach-AzApiManagementApiDiagnosticLogger.md)

[Disable-AzApiManagementApiDiagnostic](./Disable-AzApiManagementApiDiagnostic.md)