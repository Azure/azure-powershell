---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az./new-AzWorkloadsProviderPrometheusOSInstanceObject
schema: 2.0.0
---

# New-AzWorkloadsProviderPrometheusOSInstanceObject

## SYNOPSIS
Create an in-memory object for PrometheusOSProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderPrometheusOSInstanceObject [-PrometheusUrl <String>] [-SapSid <String>]
 [-SslCertificateUri <String>] [-SslPreference <SslPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusOSProviderInstanceProperties.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -PrometheusUrl
URL of the Node Exporter endpoint.

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

### -SapSid
Gets or sets the SAP System Identifier.

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

### -SslCertificateUri
Gets or sets the blob URI to SSL certificate for the prometheus node exporter.

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

### -SslPreference
Gets or sets certificate preference if secure communication is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SslPreference
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.PrometheusOSProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

