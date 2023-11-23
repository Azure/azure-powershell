---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsproviderprometheushaclusterinstanceobject
schema: 2.0.0
---

# New-AzWorkloadsProviderPrometheusHaClusterInstanceObject

## SYNOPSIS
Create an in-memory object for PrometheusHaClusterProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderPrometheusHaClusterInstanceObject [-ClusterName <String>] [-Hostname <String>]
 [-PrometheusUrl <String>] [-Sid <String>] [-SslCertificateUri <String>] [-SslPreference <SslPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusHaClusterProviderInstanceProperties.

## EXAMPLES

### Example 1: Create High Availability Pacemaker cluster provider
```powershell
New-AzWorkloadsProviderPrometheusHaClusterInstanceObject -ClusterName hacluster -Hostname h20dbvm0 -PrometheusUrl "http://10.0.92.5:964/metrics" -Sid X00 -SslPreference Disabled
```

```output
ProviderType        ClusterName Hostname PrometheusUrl                Sid SslCertificateUri SslPreference
------------        ----------- -------- -------------                --- ----------------- -------------
PrometheusHaCluster hacluster   h20dbvm0 http://10.0.92.5:964/metrics X00                   Disabled
```

Create High Availability Pacemaker cluster for an AMS instance

## PARAMETERS

### -ClusterName
Gets or sets the clusterName.

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

### -Hostname
Gets or sets the target machine name.

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

### -Sid
Gets or sets the cluster sid.

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
Gets or sets the blob URI to SSL certificate for the HA cluster exporter.

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.PrometheusHaClusterProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

