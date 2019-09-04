---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/backup-azkeyvaultkey
schema: 2.0.0
---

# Backup-AzKeyVaultKey

## SYNOPSIS
The Key Backup operation exports a key from Azure Key Vault in a protected form.
Note that this operation does NOT return key material in a form that can be used outside the Azure Key Vault system, the returned key material is either protected to a Azure Key Vault HSM or to Azure Key Vault itself.
The intent of this operation is to allow a client to GENERATE a key in one Azure Key Vault instance, BACKUP the key, and then RESTORE it into another Azure Key Vault instance.
The BACKUP operation may be used to export, in protected form, any key type from Azure Key Vault.
Individual versions of a key cannot be backed up.
BACKUP / RESTORE can be performed within geographical boundaries only; meaning that a BACKUP from one geographical area cannot be restored to another geographical area.
For example, a backup from the US geographical area cannot be restored in an EU geographical area.
This operation requires the key/backup permission.

## SYNTAX

### Backup (Default)
```
Backup-AzKeyVaultKey -Name <String> -OutFile <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentity
```
Backup-AzKeyVaultKey -InputObject <IKeyVaultIdentity> -OutFile <String> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Key Backup operation exports a key from Azure Key Vault in a protected form.
Note that this operation does NOT return key material in a form that can be used outside the Azure Key Vault system, the returned key material is either protected to a Azure Key Vault HSM or to Azure Key Vault itself.
The intent of this operation is to allow a client to GENERATE a key in one Azure Key Vault instance, BACKUP the key, and then RESTORE it into another Azure Key Vault instance.
The BACKUP operation may be used to export, in protected form, any key type from Azure Key Vault.
Individual versions of a key cannot be backed up.
BACKUP / RESTORE can be performed within geographical boundaries only; meaning that a BACKUP from one geographical area cannot be restored to another geographical area.
For example, a backup from the US geographical area cannot be restored in an EU geographical area.
This operation requires the key/backup permission.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: BackupViaIdentity
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
The name of the key.

```yaml
Type: System.String
Parameter Sets: Backup
Aliases: KeyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OutFile
Path to write output file to

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

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IKeyVaultIdentity>: Identity Parameter
  - `[CertificateName <String>]`: The name of the certificate.
  - `[CertificateVersion <String>]`: The version of the certificate.
  - `[Id <String>]`: Resource identity path
  - `[IssuerName <String>]`: The name of the issuer.
  - `[KeyName <String>]`: The name for the new key. The system will generate the version name for the new key.
  - `[KeyVersion <String>]`: The version of the key to update.
  - `[Location <String>]`: The location of the deleted vault.
  - `[OperationKind <AccessPolicyUpdateKind?>]`: Name of the operation
  - `[ResourceGroupName <String>]`: The name of the Resource Group to which the server belongs.
  - `[SasDefinitionName <String>]`: The name of the SAS definition.
  - `[SecretName <String>]`: The name of the secret.
  - `[SecretVersion <String>]`: The version of the secret.
  - `[StorageAccountName <String>]`: The name of the storage account.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VaultName <String>]`: Name of the vault

## RELATED LINKS

