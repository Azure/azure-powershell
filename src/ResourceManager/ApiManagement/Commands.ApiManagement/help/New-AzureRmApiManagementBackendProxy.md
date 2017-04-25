---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmApiManagementBackendProxy

## SYNOPSIS
Creates a new Backend Proxy Object.

## SYNTAX

```
New-AzureRmApiManagementBackendProxy -Url <String> [-UserName <String>] [-Password <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new Backend Proxy Object which can be piped when creating a new Backend entity.

## EXAMPLES

### --------------------------  Example 1  --------------------------
@{paragraph=PS C:\\\>}



```
$proxy= New-AzureRmApiManagementBackendProxy -Url "https://abbc.def.g" -UserName "apim" -Password "password"
```

Creates a Backend Proxy Object

## PARAMETERS

### -Password
Proxy Password used to connect to Backend Proxy.
This parameter is optional.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Url
Url of the Proxy server to be used when forwarding calls to Backend.
This parameter is required.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
Proxy UserName used to connect to Backend Proxy.
This parameter is optional.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

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

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementBackendProxy

## NOTES

## RELATED LINKS

