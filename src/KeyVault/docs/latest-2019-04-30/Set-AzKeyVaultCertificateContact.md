---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/set-azkeyvaultcertificatecontact
schema: 2.0.0
---

# Set-AzKeyVaultCertificateContact

## SYNOPSIS
Sets the certificate contacts for the specified key vault.
This operation requires the certificates/managecontacts permission.

## SYNTAX

### SetExpanded (Default)
```
Set-AzKeyVaultCertificateContact [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-ContactList <IContact[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Set-AzKeyVaultCertificateContact -Contact <IContacts> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets the certificate contacts for the specified key vault.
This operation requires the certificates/managecontacts permission.

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

### -Contact
The contacts for the vault certificates.
To construct, see NOTES section for CONTACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IContacts
Parameter Sets: Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ContactList
The contact list for the vault certificates.
To construct, see NOTES section for CONTACTLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IContact[]
Parameter Sets: SetExpanded
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IContacts

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IContacts

## ALIASES

### Add-AzKeyVaultCertificateContact

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONTACT <IContacts>: The contacts for the vault certificates.
  - `[ContactList <IContact[]>]`: The contact list for the vault certificates.
    - `[EmailAddress <String>]`: Email address.
    - `[Name <String>]`: Name.
    - `[Phone <String>]`: Phone number.

#### CONTACTLIST <IContact[]>: The contact list for the vault certificates.
  - `[EmailAddress <String>]`: Email address.
  - `[Name <String>]`: Name.
  - `[Phone <String>]`: Phone number.

## RELATED LINKS

