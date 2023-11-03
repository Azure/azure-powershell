---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsproviderprometheusosinstanceobject
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

### Example 1: Create Linux OS Provider
```powershell
New-AzWorkloadsProviderPrometheusOSInstanceObject -PrometheusUrl "http://10.1.0.4:9100/metrics" -SapSid X00 -SslPreference Disabled
```

```output
ProviderType PrometheusUrl                SapSid SslCertificateUri SslPreference
------------ -------------                ------ ----------------- -------------
PrometheusOS http://10.1.0.4:9100/metrics X00                      Disabled
```

Create Linux Operating System provider for an AMS instance

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

