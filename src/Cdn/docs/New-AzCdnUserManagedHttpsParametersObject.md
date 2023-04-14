---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnUserManagedHttpsParametersObject
schema: 2.0.0
---

# New-AzCdnUserManagedHttpsParametersObject

## SYNOPSIS
Create an in-memory object for UserManagedHttpsParameters.

## SYNTAX

```
New-AzCdnUserManagedHttpsParametersObject -CertificateSource <CertificateSource>
 -CertificateSourceParameterResourceGroupName <String> -CertificateSourceParameterSecretName <String>
 -CertificateSourceParameterSubscriptionId <String> -CertificateSourceParameterVaultName <String>
 -ProtocolType <ProtocolType> [-CertificateSourceParameterSecretVersion <String>]
 [-MinimumTlsVersion <MinimumTlsVersion>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UserManagedHttpsParameters.

## EXAMPLES

### Example 1: Create an in-memory object for UserManagedHttpsParameters
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSource certSource -CertificateSourceParameterResourceGroupName rgName -CertificateSourceParameterSecretName secretName -CertificateSourceParameterSubscriptionId subId -CertificateSourceParameterVaultName kvName -ProtocolType typeTest
```

```output
CertificateSource MinimumTlsVersion ProtocolType
----------------- ----------------- ------------
certSource                          typeTest
```

Create an in-memory object for UserManagedHttpsParameters

## PARAMETERS

### -CertificateSource
Defines the source of the SSL certificate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.CertificateSource
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateSourceParameterResourceGroupName
Resource group of the user's Key Vault containing the SSL certificate.

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

### -CertificateSourceParameterSecretName
The name of Key Vault Secret (representing the full certificate PFX) in Key Vault.

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

### -CertificateSourceParameterSecretVersion
The version(GUID) of Key Vault Secret in Key Vault.

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

### -CertificateSourceParameterSubscriptionId
Subscription Id of the user's Key Vault containing the SSL certificate.

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

### -CertificateSourceParameterVaultName
The name of the user's Key Vault containing the SSL certificate.

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

### -MinimumTlsVersion
TLS protocol version that will be used for Https.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MinimumTlsVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtocolType
Defines the TLS extension protocol that is used for secure delivery.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProtocolType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.UserManagedHttpsParameters

## NOTES

ALIASES

## RELATED LINKS

