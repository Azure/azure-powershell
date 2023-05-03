---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/test-azcdnprobe
schema: 2.0.0
---

# Test-AzCdnProbe

## SYNOPSIS
Check if the probe path is a valid path and the file can be accessed.
Probe path is the path to a file hosted on the origin server to help accelerate the delivery of dynamic content via the CDN endpoint.
This path is relative to the origin path specified in the endpoint configuration.

## SYNTAX

```
Test-AzCdnProbe -ProbeUrl <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check if the probe path is a valid path and the file can be accessed.
Probe path is the path to a file hosted on the origin server to help accelerate the delivery of dynamic content via the CDN endpoint.
This path is relative to the origin path specified in the endpoint configuration.

## EXAMPLES

### Example 1: Check if the probe path is a valid path and the file can be accessed
```powershell
Test-AzCdnProbe -ProbeUrl "https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt"
```

```output
ErrorCode IsValid Message
--------- ------- -------
None      True
```

Check if the probe path is a valid path and the file can be accessed

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeUrl
The probe URL to validate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IValidateProbeOutput

## NOTES

ALIASES

## RELATED LINKS

