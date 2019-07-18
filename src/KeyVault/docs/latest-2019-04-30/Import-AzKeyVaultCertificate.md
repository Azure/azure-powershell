---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/import-azkeyvaultcertificate
schema: 2.0.0
---

# Import-AzKeyVaultCertificate

## SYNOPSIS
Imports an existing valid certificate, containing a private key, into Azure Key Vault.
The certificate to be imported can be in either PFX or PEM format.
If the certificate is in PEM format the PEM file must contain the key as well as x509 certificates.
This operation requires the certificates/import permission.

## SYNTAX

### Import (Default)
```
Import-AzKeyVaultCertificate -Name <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-Parameter <ICertificateImportParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ImportExpanded
```
Import-AzKeyVaultCertificate -Name <String> -CertificateString <String> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-Enabled] [-Expire <DateTime>] [-NotBefore <DateTime>] [-Password <String>]
 [-Policy <ICertificatePolicy>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzKeyVaultCertificate -InputObject <IKeyVaultIdentity> -CertificateString <String>
 [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-Enabled] [-Expire <DateTime>] [-NotBefore <DateTime>]
 [-Password <String>] [-Policy <ICertificatePolicy>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzKeyVaultCertificate -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-Parameter <ICertificateImportParameters>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Imports an existing valid certificate, containing a private key, into Azure Key Vault.
The certificate to be imported can be in either PFX or PEM format.
If the certificate is in PEM format the PEM file must contain the key as well as x509 certificates.
This operation requires the certificates/import permission.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CertificateString
Base64 encoded representation of the certificate object to import.
This certificate needs to contain the private key.

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Enabled
Determines whether the object is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Expire
Expiry date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: ImportViaIdentityExpanded, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultDnsSuffix
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the certificate.

```yaml
Type: System.String
Parameter Sets: Import, ImportExpanded
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NotBefore
Not before date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The certificate import parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateImportParameters
Parameter Sets: Import, ImportViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Password
If the private key in base64EncodedCertificate is encrypted, the password used for encryption.

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Policy
The management policy for the certificate.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificatePolicy
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Application specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultName
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateImportParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateBundle

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <ICertificateImportParameters>: The certificate import parameters.
  - `Base64EncodedCertificate <String>`: Base64 encoded representation of the certificate object to import. This certificate needs to contain the private key.
  - `[AttributeEnabled <Boolean?>]`: Determines whether the object is enabled.
  - `[AttributeExpire <DateTime?>]`: Expiry date in UTC.
  - `[AttributeNotBefore <DateTime?>]`: Not before date in UTC.
  - `[Password <String>]`: If the private key in base64EncodedCertificate is encrypted, the password used for encryption.
  - `[Policy <ICertificatePolicy>]`: The management policy for the certificate.
    - `[AttributeEnabled <Boolean?>]`: Determines whether the object is enabled.
    - `[AttributeExpire <DateTime?>]`: Expiry date in UTC.
    - `[AttributeNotBefore <DateTime?>]`: Not before date in UTC.
    - `[IssuerCertificateType <String>]`: Type of certificate to be requested from the issuer provider.
    - `[IssuerName <String>]`: Name of the referenced issuer object or reserved names; for example, 'Self' or 'Unknown'.
    - `[KeyPropExportable <Boolean?>]`: Indicates if the private key can be exported.
    - `[KeyPropKeySize <Int32?>]`: The key size in bits. For example: 2048, 3072, or 4096 for RSA.
    - `[KeyPropKeyType <String>]`: The key type.
    - `[KeyPropReuseKey <Boolean?>]`: Indicates if the same key pair will be used on certificate renewal.
    - `[LifetimeAction <ILifetimeAction[]>]`: Actions that will be performed by Key Vault over the lifetime of a certificate.
      - `[ActionType <ActionType?>]`: The type of the action.
      - `[TriggerDaysBeforeExpiry <Int32?>]`: Days before expiry to attempt renewal. Value should be between 1 and validity_in_months multiplied by 27. If validity_in_months is 36, then value should be between 1 and 972 (36 * 27).
      - `[TriggerLifetimePercentage <Int32?>]`: Percentage of lifetime at which to trigger. Value should be between 1 and 99.
    - `[SanDnsName <String[]>]`: Domain names.
    - `[SanEmail <String[]>]`: Email addresses.
    - `[SanUpn <String[]>]`: User principal names.
    - `[SecretPropContentType <String>]`: The media type (MIME type).
    - `[X509PropEku <String[]>]`: The enhanced key usage.
    - `[X509PropKeyUsage <KeyUsageType[]>]`: List of key usages.
    - `[X509PropSubject <String>]`: The subject name. Should be a valid X509 distinguished Name.
    - `[X509PropValidityInMonth <Int32?>]`: The duration that the certificate is valid in months.
  - `[Tag <ICertificateImportParametersTags>]`: Application specific metadata in the form of key-value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### POLICY <ICertificatePolicy>: The management policy for the certificate.
  - `[AttributeEnabled <Boolean?>]`: Determines whether the object is enabled.
  - `[AttributeExpire <DateTime?>]`: Expiry date in UTC.
  - `[AttributeNotBefore <DateTime?>]`: Not before date in UTC.
  - `[IssuerCertificateType <String>]`: Type of certificate to be requested from the issuer provider.
  - `[IssuerName <String>]`: Name of the referenced issuer object or reserved names; for example, 'Self' or 'Unknown'.
  - `[KeyPropExportable <Boolean?>]`: Indicates if the private key can be exported.
  - `[KeyPropKeySize <Int32?>]`: The key size in bits. For example: 2048, 3072, or 4096 for RSA.
  - `[KeyPropKeyType <String>]`: The key type.
  - `[KeyPropReuseKey <Boolean?>]`: Indicates if the same key pair will be used on certificate renewal.
  - `[LifetimeAction <ILifetimeAction[]>]`: Actions that will be performed by Key Vault over the lifetime of a certificate.
    - `[ActionType <ActionType?>]`: The type of the action.
    - `[TriggerDaysBeforeExpiry <Int32?>]`: Days before expiry to attempt renewal. Value should be between 1 and validity_in_months multiplied by 27. If validity_in_months is 36, then value should be between 1 and 972 (36 * 27).
    - `[TriggerLifetimePercentage <Int32?>]`: Percentage of lifetime at which to trigger. Value should be between 1 and 99.
  - `[SanDnsName <String[]>]`: Domain names.
  - `[SanEmail <String[]>]`: Email addresses.
  - `[SanUpn <String[]>]`: User principal names.
  - `[SecretPropContentType <String>]`: The media type (MIME type).
  - `[X509PropEku <String[]>]`: The enhanced key usage.
  - `[X509PropKeyUsage <KeyUsageType[]>]`: List of key usages.
  - `[X509PropSubject <String>]`: The subject name. Should be a valid X509 distinguished Name.
  - `[X509PropValidityInMonth <Int32?>]`: The duration that the certificate is valid in months.

## RELATED LINKS

