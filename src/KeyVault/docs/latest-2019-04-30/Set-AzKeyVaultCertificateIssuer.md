---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/set-azkeyvaultcertificateissuer
schema: 2.0.0
---

# Set-AzKeyVaultCertificateIssuer

## SYNOPSIS
The SetCertificateIssuer operation adds or updates the specified certificate issuer.
This operation requires the certificates/setissuers permission.

## SYNTAX

### SetExpanded (Default)
```
Set-AzKeyVaultCertificateIssuer -IssuerName <String> -Provider <String> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-CredentialsAccountId <String>] [-CredentialsPassword <String>] [-Enabled]
 [-OrgDetailAdminDetail <IAdministratorDetails[]>] [-OrgDetailId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Set-AzKeyVaultCertificateIssuer -IssuerName <String> -Parameter <ICertificateIssuerSetParameters>
 [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The SetCertificateIssuer operation adds or updates the specified certificate issuer.
This operation requires the certificates/setissuers permission.

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

### -CredentialsAccountId
The user name/account name/account id.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: AccountId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CredentialsPassword
The password/secret/account key.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: ApiKey

Required: False
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
Determines whether the issuer is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IssuerName
The name of the issuer.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -OrgDetailAdminDetail
Details of the organization administrator.
To construct, see NOTES section for ORGDETAILADMINDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IAdministratorDetails[]
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OrgDetailId
Id of the organization.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The certificate issuer set parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateIssuerSetParameters
Parameter Sets: Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Provider
The issuer provider.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: IssuerProvider

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateIssuerSetParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IIssuerBundle

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ORGDETAILADMINDETAIL <IAdministratorDetails[]>: Details of the organization administrator.
  - `[EmailAddress <String>]`: Email address.
  - `[FirstName <String>]`: First name.
  - `[LastName <String>]`: Last name.
  - `[Phone <String>]`: Phone number.

#### PARAMETER <ICertificateIssuerSetParameters>: The certificate issuer set parameters.
  - `Provider <String>`: The issuer provider.
  - `[AttributeEnabled <Boolean?>]`: Determines whether the issuer is enabled.
  - `[CredentialsAccountId <String>]`: The user name/account name/account id.
  - `[CredentialsPassword <String>]`: The password/secret/account key.
  - `[OrgDetailAdminDetail <IAdministratorDetails[]>]`: Details of the organization administrator.
    - `[EmailAddress <String>]`: Email address.
    - `[FirstName <String>]`: First name.
    - `[LastName <String>]`: Last name.
    - `[Phone <String>]`: Phone number.
  - `[OrgDetailId <String>]`: Id of the organization.

## RELATED LINKS

