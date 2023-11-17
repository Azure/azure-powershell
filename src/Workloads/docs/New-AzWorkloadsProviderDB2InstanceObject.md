---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsproviderdb2instanceobject
schema: 2.0.0
---

# New-AzWorkloadsProviderDB2InstanceObject

## SYNOPSIS
Create an in-memory object for DB2ProviderInstanceProperties.

## SYNTAX

```
New-AzWorkloadsProviderDB2InstanceObject [-Hostname <String>] [-Name <String>] [-Password <String>]
 [-PasswordUri <String>] [-Port <String>] [-SapSid <String>] [-SslCertificateUri <String>]
 [-SslPreference <SslPreference>] [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DB2ProviderInstanceProperties.

## EXAMPLES

### Example 1: Create an IBM Db2 Provider
```powershell
New-AzWorkloadsProviderDB2InstanceObject -Name Sample -Password '' -Port 25000 -Username db2admin -Hostname 10.1.21.4 -SapSid OPA -SslPreference Disabled
```

```output
ProviderType DbName DbPassword DbPasswordUri DbPort DbUsername Hostname  SapSid SslCertificateUri SslPreference
------------ ------ ---------- ------------- ------ ---------- --------  ------ ----------------- -------------
Db2          Sample                          25000  db2admin   10.1.21.4 OPA                      Disabled
```

Create an IBM Db2 provider for an AMS Instance

## PARAMETERS

### -Hostname
Gets or sets the target virtual machine name.

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
Gets or sets the db2 database name.

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
Gets or sets the db2 database password.

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
Gets or sets the db2 database sql port.

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
Gets or sets the blob URI to SSL certificate for the DB2 Database.

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
Gets or sets the db2 database user name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.Db2ProviderInstanceProperties

## NOTES

ALIASES

## RELATED LINKS

