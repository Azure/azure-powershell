---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorredirectconfigurationobject
schema: 2.0.0
---

# New-AzFrontDoorRedirectConfigurationObject

## SYNOPSIS
Create an in-memory object for RedirectConfiguration.

## SYNTAX

```
New-AzFrontDoorRedirectConfigurationObject [-CustomFragment <String>] [-CustomHost <String>]
 [-CustomPath <String>] [-CustomQueryString <String>] [-RedirectProtocol <String>] [-RedirectType <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RedirectConfiguration.

## EXAMPLES

### Example 1: Create a redirect configuration object with all parameters
```powershell
New-AzFrontDoorRedirectConfigurationObject -RedirectType "PermanentRedirect" -RedirectProtocol "HttpsOnly" -CustomHost "www.example.com" -CustomPath "/newpath" -CustomQueryString "source=frontdoor&campaign=redirect" -CustomFragment "section1"
```

```output
CustomFragment    : section1
CustomHost        : www.example.com
CustomPath        : /newpath
CustomQueryString : source=frontdoor&campaign=redirect
OdataType         : #Microsoft.Azure.FrontDoor.Models.FrontdoorRedirectConfiguration
RedirectProtocol  : HttpsOnly
RedirectType      : PermanentRedirect
```

Create a comprehensive redirect configuration object that permanently redirects requests to HTTPS protocol with custom host, path, query string, and fragment.

## PARAMETERS

### -CustomFragment
Fragment to add to the redirect URL.
Fragment is the part of the URL that comes after #.
Do not include the #.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHost
Host to redirect.
Leave empty to use the incoming host as the destination host.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomPath
The full path to redirect.
Path cannot be empty and must start with /.
Leave empty to use the incoming path as destination path.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomQueryString
The set of query strings to be placed in the redirect URL.
Setting this value would replace any existing query string; leave empty to preserve the incoming query string.
Query string must be in \<key\>=\<value\> format.
The first ? and & will be added automatically so do not include them in the front, but do separate multiple query strings with &.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectProtocol
The protocol of the destination to where the traffic is redirected.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectType
The redirect type the rule will use when redirecting traffic.

```yaml
Type: System.String
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RedirectConfiguration

## NOTES

## RELATED LINKS
