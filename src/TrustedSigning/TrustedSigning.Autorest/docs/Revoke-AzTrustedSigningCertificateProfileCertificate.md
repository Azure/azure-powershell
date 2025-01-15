---
external help file:
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/revoke-aztrustedsigningcertificateprofilecertificate
schema: 2.0.0
---

# Revoke-AzTrustedSigningCertificateProfileCertificate

## SYNOPSIS
Revoke a certificate under a certificate profile.

## SYNTAX

### RevokeExpanded (Default)
```
Revoke-AzTrustedSigningCertificateProfileCertificate -AccountName <String> -ProfileName <String>
 -ResourceGroupName <String> -EffectiveAt <DateTime> -Reason <String> -SerialNumber <String>
 -Thumbprint <String> [-SubscriptionId <String>] [-Remark <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Revoke
```
Revoke-AzTrustedSigningCertificateProfileCertificate -AccountName <String> -ProfileName <String>
 -ResourceGroupName <String> -Body <IRevokeCertificate> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentity
```
Revoke-AzTrustedSigningCertificateProfileCertificate -InputObject <ITrustedSigningIdentity>
 -Body <IRevokeCertificate> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentityCodeSigningAccount
```
Revoke-AzTrustedSigningCertificateProfileCertificate -CodeSigningAccountInputObject <ITrustedSigningIdentity>
 -ProfileName <String> -Body <IRevokeCertificate> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentityCodeSigningAccountExpanded
```
Revoke-AzTrustedSigningCertificateProfileCertificate -CodeSigningAccountInputObject <ITrustedSigningIdentity>
 -ProfileName <String> -EffectiveAt <DateTime> -Reason <String> -SerialNumber <String> -Thumbprint <String>
 [-Remark <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentityExpanded
```
Revoke-AzTrustedSigningCertificateProfileCertificate -InputObject <ITrustedSigningIdentity>
 -EffectiveAt <DateTime> -Reason <String> -SerialNumber <String> -Thumbprint <String> [-Remark <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaJsonFilePath
```
Revoke-AzTrustedSigningCertificateProfileCertificate -AccountName <String> -ProfileName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaJsonString
```
Revoke-AzTrustedSigningCertificateProfileCertificate -AccountName <String> -ProfileName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Revoke a certificate under a certificate profile.

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

### -AccountName
Trusted Signing account name.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Defines the certificate revocation properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.IRevokeCertificate
Parameter Sets: Revoke, RevokeViaIdentity, RevokeViaIdentityCodeSigningAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CodeSigningAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity
Parameter Sets: RevokeViaIdentityCodeSigningAccount, RevokeViaIdentityCodeSigningAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EffectiveAt
The timestamp when the revocation is effective.

```yaml
Type: System.DateTime
Parameter Sets: RevokeExpanded, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity
Parameter Sets: RevokeViaIdentity, RevokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Revoke operation

```yaml
Type: System.String
Parameter Sets: RevokeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Revoke operation

```yaml
Type: System.String
Parameter Sets: RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Certificate profile name.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaIdentityCodeSigningAccount, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reason
Reason for the revocation.

```yaml
Type: System.String
Parameter Sets: RevokeExpanded, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Remark
Remarks for the revocation.

```yaml
Type: System.String
Parameter Sets: RevokeExpanded, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
Serial number of the certificate.

```yaml
Type: System.String
Parameter Sets: RevokeExpanded, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Revoke, RevokeExpanded, RevokeViaJsonFilePath, RevokeViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Thumbprint
Thumbprint of the certificate.

```yaml
Type: System.String
Parameter Sets: RevokeExpanded, RevokeViaIdentityCodeSigningAccountExpanded, RevokeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.IRevokeCertificate

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ITrustedSigningIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

