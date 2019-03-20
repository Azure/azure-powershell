---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: Az.ApiManagement
online version:
schema: 2.0.0
---

# Disable-AzApiManagementApiDiagnostic

## SYNOPSIS
Disable an API Diagnostic of an API

## SYNTAX

```
Disable-AzApiManagementApiDiagnostic [-Context] <PsApiManagementContext> [-ApiId] <String>
 [-DiagnosticId] <String> [-PassThru] [[-DefaultProfile] <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzApiManagementApiDiagnostic** cmdlet disable an API Diagnostic of an Azure API Management API.

## EXAMPLES

### Example 1
```powershell
PS C:\>$context = New-AzApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Disable-AzApiManagementApiDiagnostic -Context $context -ApiId "0001" -DiagnosticId "applicationinsights"
```

This example disables an Application Insights diagnostic of an Azure API Management API.

## PARAMETERS

### -ApiId
Identifier of existing Api.
This parameter is required.

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

### -DiagnosticId
Identifier of the diagnostic.
This parameter is required.

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

### -PassThru
If specified then instance of Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementLogger type  representing the logger will be written to output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Nommé
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext

### System.String

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementLogger

## NOTES

## RELATED LINKS

[Attach-AzApiManagementApiDiagnosticLogger](./Attach-AzApiManagementApiDiagnosticLogger.md)

[Get-AzApiManagementApiLoggers](./Get-AzApiManagementApiLoggers.md)
