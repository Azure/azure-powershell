---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsprovidersqlserverinstanceobject
schema: 2.0.0
---

# New-AzWorkloadsProviderSqlServerInstanceObject

## SYNOPSIS
Create an in-memory object for MsSqlServerProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderSqlServerInstanceObject [-Hostname <String>] [-Password <String>]
 [-PasswordUri <String>] [-Port <String>] [-SapSid <String>] [-SslCertificateUri <String>]
 [-SslPreference <SslPreference>] [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MsSqlServerProviderInstanceProperties.

## EXAMPLES

### Example 1: Create Microsoft SQL server provider
```powershell
New-AzWorkloadsProviderSqlServerInstanceObject -Password 'Password@123' -Port 1433 -Username ams -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled
```

```output
ProviderType DbPassword   DbPasswordUri DbPort DbUsername Hostname  SapSid SslCertificateUri SslPreference
------------ ----------   ------------- ------ ---------- --------  ------ ----------------- -------------
MsSqlServer  Password@123               1433   ams        10.1.14.5 X00                      Disabled
```

Create Microsoft SQL server provider for an AMS instance

## PARAMETERS

### -Hostname
Gets or sets the SQL server host name.

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

### -Password
Gets or sets the database password.

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

### -PasswordUri
Gets or sets the key vault URI to secret with the database password.

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

### -Port
Gets or sets the database sql port.

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
Gets or sets the blob URI to SSL certificate for the SQL Database.

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

### -Username
Gets or sets the database user name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.MSSqlServerProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

