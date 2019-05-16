---
external help file: Az.KeyVault-help.xml
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/merge-azkeyvaultcertificate
schema: 2.0.0
---

# Merge-AzKeyVaultCertificate

## SYNOPSIS
The MergeCertificate operation performs the merging of a certificate or certificate chain with a key pair currently available in the service.
This operation requires the certificates/create permission.

## SYNTAX

### Merge (Default)
```
Merge-AzKeyVaultCertificate -Name <String> [-Parameter <ICertificateMergeParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MergeExpanded
```
Merge-AzKeyVaultCertificate -Name <String> [-AttributesEnabled <Boolean>] [-AttributesExpire <DateTime>]
 [-AttributesNotBefore <DateTime>] [-AttributesRecoveryLevel <DeletionRecoveryLevel>]
 [-Tag <ICertificateMergeParametersTags>] -X509Certificates <Byte[][]> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### MergeViaIdentityExpanded
```
Merge-AzKeyVaultCertificate -InputObject <IKeyVaultIdentity> [-AttributesEnabled <Boolean>]
 [-AttributesExpire <DateTime>] [-AttributesNotBefore <DateTime>]
 [-AttributesRecoveryLevel <DeletionRecoveryLevel>] [-Tag <ICertificateMergeParametersTags>]
 -X509Certificates <Byte[][]> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MergeViaIdentity
```
Merge-AzKeyVaultCertificate -InputObject <IKeyVaultIdentity> [-Parameter <ICertificateMergeParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The MergeCertificate operation performs the merging of a certificate or certificate chain with a key pair currently available in the service.
This operation requires the certificates/create permission.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AttributesEnabled
Determines whether the object is enabled.

```yaml
Type: System.Boolean
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributesExpire
Expiry date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributesNotBefore
Not before date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributesRecoveryLevel
Reflects the deletion recovery level currently in effect for certificates in the current vault.
If it contains 'Purgeable', the certificate can be permanently deleted by a privileged user; otherwise, only the system can purge the certificate, at the end of the retention interval.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.DeletionRecoveryLevel
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: MergeViaIdentityExpanded, MergeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the certificate.

```yaml
Type: System.String
Parameter Sets: Merge, MergeExpanded
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The certificate merge parameters

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateMergeParameters
Parameter Sets: Merge, MergeViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Tag
Application specific metadata in the form of key-value pairs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateMergeParametersTags
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -X509Certificates
The certificate or the certificate chain to merge.

```yaml
Type: System.Byte[][]
Parameter Sets: MergeExpanded, MergeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateBundle
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.keyvault/merge-azkeyvaultcertificate](https://docs.microsoft.com/en-us/powershell/module/az.keyvault/merge-azkeyvaultcertificate)

