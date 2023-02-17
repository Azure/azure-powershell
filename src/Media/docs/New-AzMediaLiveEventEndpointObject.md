---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaLiveEventEndpointObject
schema: 2.0.0
---

# New-AzMediaLiveEventEndpointObject

## SYNOPSIS
Create an in-memory object for LiveEventEndpoint.

## SYNTAX

```
New-AzMediaLiveEventEndpointObject [-Protocol <String>] [-Url <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LiveEventEndpoint.

## EXAMPLES

### Example 1: Create an in-memory object for LiveEventEndpoint.
```powershell
New-AzMediaLiveEventEndpointObject -Protocol "RTMP"
```

```output
Protocol Url
-------- ---
RTMP
```

Create an in-memory object for LiveEventEndpoint.

## PARAMETERS

### -Protocol
The endpoint protocol.

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

### -Url
The endpoint URL.

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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.LiveEventEndpoint

## NOTES

ALIASES

## RELATED LINKS

