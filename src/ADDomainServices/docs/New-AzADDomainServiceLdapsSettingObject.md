---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesLdapsSettingsObject
schema: 2.0.0
---

# New-AzADDomainServiceLdapsSettingObject

## SYNOPSIS
Create a in-memory object for LdapsSettings

## SYNTAX

```
New-AzADDomainServiceLdapsSettingObject [-ExternalAccess <String>] [-Ldaps <String>]
 [-PfxCertificatePassword <SecureString>] [-PfxCertificatePath <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for LdapsSettings

## EXAMPLES

### Example 1: Create LdapsSetting for AzADDomain
```powershell
PS C:\> $secstr = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
New-AzADDomainServiceLdapsSettingObject -ExternalAccess Enabled -Ldaps Enabled -PfxCertificatePath sahg -PfxCertificatePassword $secstr

CertificateNotAfter CertificateThumbprint ExternalAccess Ldaps    PfxCertificate PfxCertificatePassword PublicCertificate
------------------- --------------------- -------------- ----    -------------- ---------------------- -----------------
                                          Enabled        Enabled                Password
```

Create LdapsSetting for AzADDomain

## PARAMETERS

### -ExternalAccess
A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.

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

### -Ldaps
A flag to determine whether or not Secure LDAP is enabled or disabled.

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

### -PfxCertificatePassword
The password to decrypt the provided Secure LDAP certificate pfx file.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PfxCertificatePath
The path of certificate required to configure Secure LDAP.

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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings

## NOTES

ALIASES

## RELATED LINKS

