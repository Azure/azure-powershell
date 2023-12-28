---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsproviderhanadbinstanceobject
schema: 2.0.0
---

# New-AzWorkloadsProviderHanaDbInstanceObject

## SYNOPSIS
Create an in-memory object for HanaDbProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderHanaDbInstanceObject [-Hostname <String>] [-InstanceNumber <String>] [-Name <String>]
 [-Password <String>] [-PasswordUri <String>] [-SapSid <String>] [-SqlPort <String>]
 [-SslCertificateUri <String>] [-SslHostNameInCertificate <String>] [-SslPreference <SslPreference>]
 [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HanaDbProviderInstanceProperties.

## EXAMPLES

### Example 1: Create SAP HANA provider 
```powershell
New-AzWorkloadsProviderHanaDbInstanceObject -Name SYSTEMDB -Password ''  -Username SYSTEM -Hostname 10.0.81.4 -InstanceNumber 00 -SapSid X00 -SqlPort 1433 -SslPreference Disabled
```

```output
ProviderType DbName   DbPassword DbPasswordUri DbUsername Hostname  InstanceNumber SapSid SqlPort SslCertificateUri SslHostNameInCer
                                                                                                                    tificate
------------ ------   ---------- ------------- ---------- --------  -------------- ------ ------- ----------------- ----------------
SapHana      SYSTEMDB                          SYSTEM     10.0.81.4 00             X00    1433
```

Create SAP HANA provider for an AMS instance

## PARAMETERS

### -Hostname
Gets or sets the target virtual machine size.

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

### -InstanceNumber
Gets or sets the database instance number.

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

### -Name
Gets or sets the hana database name.

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

### -SqlPort
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

### -SslCertificateUri
Gets or sets the blob URI to SSL certificate for the DB.

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

### -SslHostNameInCertificate
Gets or sets the hostname(s) in the SSL certificate.

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.HanaDbProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

