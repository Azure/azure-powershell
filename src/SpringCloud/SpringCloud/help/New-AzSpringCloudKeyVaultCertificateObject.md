---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudKeyVaultCertificateObject
schema: 2.0.0
---

# New-AzSpringCloudKeyVaultCertificateObject

## SYNOPSIS
Create an in-memory object for KeyVaultCertificateProperties.

## SYNTAX

```
New-AzSpringCloudKeyVaultCertificateObject -Name <String> -VaultUri <String> [-Version <String>]
 [-ExcludePrivateKey <Boolean>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeyVaultCertificateProperties.

## EXAMPLES

### Example 1: Create an in-memory object for KeyVaultCertificateProperties
```powershell
New-AzSpringCloudKeyVaultCertificateObject -VaultUri "keyvaluturi" -Name 'keycert'
```

```output
ActivateDate DnsName ExpirationDate IssuedDate Issuer SubjectName Thumbprint CertVersion ExcludePrivateKey KeyVaultCertName VaultUri
------------ ------- -------------- ---------- ------ ----------- ---------- ----------- ----------------- ---------------- --------
                                                                                                           keycert          keyvaluturi
```

Create an in-memory object for KeyVaultCertificateProperties

## PARAMETERS

### -ExcludePrivateKey
Optional.
If set to true, it will not import private key from key vault.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The certificate name of key vault.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultUri
The vault uri of user key vault.

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

### -Version
The certificate version of key vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.KeyVaultCertificateProperties

## NOTES

## RELATED LINKS
