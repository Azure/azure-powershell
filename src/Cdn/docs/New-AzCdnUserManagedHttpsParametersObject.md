---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdnusermanagedhttpsparametersobject
schema: 2.0.0
---

# New-AzCdnUserManagedHttpsParametersObject

## SYNOPSIS
Create an in-memory object for UserManagedHttpsParameters.

## SYNTAX

```
New-AzCdnUserManagedHttpsParametersObject -CertificateSourceParameterResourceGroupName <String>
 -CertificateSourceParameterSecretName <String> -CertificateSourceParameterSubscriptionId <String>
 -CertificateSourceParameterVaultName <String> -ProtocolType <String>
 [-CertificateSourceParameterSecretVersion <String>] [-MinimumTlsVersion <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UserManagedHttpsParameters.

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
Type: System.String
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
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.UserManagedHttpsParameters

## NOTES

ALIASES

## RELATED LINKS

