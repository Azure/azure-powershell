---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorfrontendbackendpoolssettingsobject
schema: 2.0.0
---

# New-AzFrontDoorBackendPoolsSettingObject

## SYNOPSIS
Create an in-memory object for BackendPoolsSettings.

## SYNTAX

```
New-AzFrontDoorBackendPoolsSettingObject [-EnforceCertificateNameCheck <String>]
 [-SendRecvTimeoutInSeconds <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BackendPoolsSettings.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -EnforceCertificateNameCheck
Whether to enforce certificate name check on HTTPS requests to all backend pools.
No effect on non-HTTPS requests.

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

### -SendRecvTimeoutInSeconds
Send and receive timeout on forwarding request to the backend.
When timeout is reached, the request fails and returns.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.BackendPoolsSettings

## NOTES

## RELATED LINKS

