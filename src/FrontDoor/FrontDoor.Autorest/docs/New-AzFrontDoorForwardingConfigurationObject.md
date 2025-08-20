---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorforwardingconfigurationobject
schema: 2.0.0
---

# New-AzFrontDoorForwardingConfigurationObject

## SYNOPSIS
Create an in-memory object for ForwardingConfiguration.

## SYNTAX

```
New-AzFrontDoorForwardingConfigurationObject [-BackendPoolId <String>]
 [-CacheConfiguration <ICacheConfiguration>] [-CustomForwardingPath <String>] [-ForwardingProtocol <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ForwardingConfiguration.

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

### -BackendPoolId
Resource ID.

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

### -CacheConfiguration
The caching configuration associated with this rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICacheConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomForwardingPath
A custom path used to rewrite resource paths matched by this rule.
Leave empty to use incoming path.

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

### -ForwardingProtocol
Protocol this rule will use when forwarding traffic to backends.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ForwardingConfiguration

## NOTES

## RELATED LINKS

