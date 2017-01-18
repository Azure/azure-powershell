---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 8B0116E5-0AED-4050-BF11-1BFE65DB9436
---

# Get-AzureRmApiManagementAuthorizationServer

## SYNOPSIS
Gets an API Management authorization server.

## SYNTAX

### Get all authorization server (Default)
```
Get-AzureRmApiManagementAuthorizationServer -Context <PsApiManagementContext>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### Get by Id
```
Get-AzureRmApiManagementAuthorizationServer -Context <PsApiManagementContext> [-ServerId <String>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementAuthorizationServer** cmdlet gets all Azure API Management authorization servers or specified authorization servers.

## EXAMPLES

### Example 1: Get all authorization servers
```
PS C:\>Get-AzureRmApiManagementAuthrizarionServer -Context $ApiMgmtContext
```

This command gets all API Management authorization servers.

### Example 2: Get a specified authorization server
```
PS C:\>Get-AzureRmApiManagementCertificate -Context $ApiMgmtContext -ServerId "0123456789"
```

This command gets the specified authorization server.

## PARAMETERS

### -Context

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

### -ServerId

```yaml
Type: String
Parameter Sets: Get by Id
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### IList<Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementOAuth2AuthrozationServer>

## NOTES

## RELATED LINKS

[New-AzureRmApiManagementAuthorizationServer](./New-AzureRmApiManagementAuthorizationServer.md)

[Remove-AzureRmApiManagementAuthorizationServer](./Remove-AzureRmApiManagementAuthorizationServer.md)

[Set-AzureRmApiManagementAuthorizationServer](./Set-AzureRmApiManagementAuthorizationServer.md)


