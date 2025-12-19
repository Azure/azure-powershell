---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorcacheconfigurationobject
schema: 2.0.0
---

# New-AzFrontDoorCacheConfigurationObject

## SYNOPSIS
Create an in-memory object for CacheConfiguration.

## SYNTAX

```
New-AzFrontDoorCacheConfigurationObject [-CacheDuration <TimeSpan>] [-DynamicCompression <String>]
 [-QueryParameter <String>] [-QueryParameterStripDirective <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CacheConfiguration.

## EXAMPLES

### Example 1: Create a cache configuration object
```powershell
New-AzFrontDoorCacheConfigurationObject -CacheDuration "0.12:00:00" -DynamicCompression "Enabled" -QueryParameterStripDirective "StripAllExcept"
```

```output
CacheDuration DynamicCompression QueryParameter QueryParameterStripDirective
------------- ------------------ -------------- ----------------------------
12:00:00      Enabled                           StripAllExcept
```

Create a cache configuration object.

## PARAMETERS

### -CacheDuration
The duration for which the content needs to be cached.
Allowed format is in ISO 8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).
HTTP requires the value to be no more than a year.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicCompression
Whether to use dynamic compression for cached content.

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

### -QueryParameter
query parameters to include or exclude (comma separated).

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

### -QueryParameterStripDirective
Treatment of URL query terms when forming the cache key.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.CacheConfiguration

## NOTES

## RELATED LINKS
