---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.dll-Help.xml
Module Name: Az.ApiManagement
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.apimanagement/new-azapimanagementsslsetting
=======
online version: https://docs.microsoft.com/powershell/module/az.apimanagement/new-azapimanagementsslsetting
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# New-AzApiManagementSslSetting

## SYNOPSIS
Creates an instance of PsApiManagementSslSetting

## SYNTAX

```
New-AzApiManagementSslSetting [-FrontendProtocol <Hashtable>] [-BackendProtocol <Hashtable>]
 [-CipherSuite <Hashtable>] [-ServerProtocol <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Helper command to create an instance of PsApiManagementSslSetting.
This command is to be used with New-AzApiManagement command.

## EXAMPLES

<<<<<<< HEAD
### Example 1 : Create an SSL Setting to enable TLS 1.0 on both Backend and Frontent
=======
### Example 1: Create an SSL Setting to enable TLS 1.0 on both Backend and Frontend
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```powershell
PS D:\github\azure-powershell\artifacts\Debug\Az.ApiManagement> $enableTls=@{"Tls10" = "True"}
PS D:\github\azure-powershell\artifacts\Debug\Az.ApiManagement> New-AzApiManagementSslSetting -FrontendProtocol $enableTls -BackendProtocol $enableTls

FrontendProtocols BackendProtocols CipherSuites ServerProtocols
----------------- ---------------- ------------ ---------------
{Tls10}           {Tls10}
```

Create an new instance of PsApiManagementSslSetting to Enable TLSv 1.0 in both Frontend (between client and APIM) and Backend (between APIM and Backend) of ApiManagement Gateway.

## PARAMETERS

### -BackendProtocol
Backend Security protocol settings. This parameter is optional.
<<<<<<< HEAD
=======
The valid Protocol Settings are 
`Tls11` - Tls 1.1
`Tls10` - Tls 1.0
`Ssl30` - SSL 3.0
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CipherSuite
Ssl cipher suites settings in the specified order. This parameter is optional.
<<<<<<< HEAD
=======
The valid Settings are 
`TripleDes168` - Enable / Disable Tripe Des 168
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Collections.Hashtable
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

### -FrontendProtocol
Frontend Security protocols settings. This parameter is optional.
<<<<<<< HEAD
=======
The valid Protocol Settings are 
`Tls11` - Tls 1.1
`Tls10` - Tls 1.0
`Ssl30` - SSL 3.0

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerProtocol
Server protocol settings like Http2. This parameter is optional.
<<<<<<< HEAD
=======
The valid Settings are 
`Http2` - Enable Http 2.0
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Collections.Hashtable
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

### Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSslSettings

## NOTES

## RELATED LINKS

[New-AzApiManagement](./New-AzApiManagement.md)

