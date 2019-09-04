---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/new-azkeyvaultkey
schema: 2.0.0
---

# New-AzKeyVaultKey

## SYNOPSIS
The create key operation can be used to create any key type in Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
It requires the keys/create permission.

## SYNTAX

### CreateExpanded (Default)
```
New-AzKeyVaultKey -Name <String> -Kty <JsonWebKeyType> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-Crv <JsonWebKeyCurveName>] [-Enabled] [-Expire <DateTime>] [-KeyOp <JsonWebKeyOperation[]>]
 [-KeySize <Int32>] [-NotBefore <DateTime>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzKeyVaultKey -Name <String> -Parameter <IKeyCreateParameters> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzKeyVaultKey -InputObject <IKeyVaultIdentity> -Parameter <IKeyCreateParameters>
 [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzKeyVaultKey -InputObject <IKeyVaultIdentity> -Kty <JsonWebKeyType> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-Crv <JsonWebKeyCurveName>] [-Enabled] [-Expire <DateTime>]
 [-KeyOp <JsonWebKeyOperation[]>] [-KeySize <Int32>] [-NotBefore <DateTime>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The create key operation can be used to create any key type in Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
It requires the keys/create permission.

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

### -Crv
Elliptic curve name.
For valid values, see JsonWebKeyCurveName.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyCurveName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -Enabled
Determines whether the object is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Expire
Expiry date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyOp
HELP MESSAGE MISSING

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyOperation[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeySize
The key size in bits.
For example: 2048, 3072, or 4096 for RSA.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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

### -Kty
The type of key to create.
For valid values, see JsonWebKeyType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name for the new key.
The system will generate the version name for the new key.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: KeyName

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The key create parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyCreateParameters
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Application specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyCreateParameters

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyBundle

## ALIASES

### Add-AzKeyVaultKey

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

#### PARAMETER <IKeyCreateParameters>: The key create parameters.
  - `Kty <JsonWebKeyType>`: The type of key to create. For valid values, see JsonWebKeyType.
  - `[AttributeEnabled <Boolean?>]`: Determines whether the object is enabled.
  - `[AttributeExpire <DateTime?>]`: Expiry date in UTC.
  - `[AttributeNotBefore <DateTime?>]`: Not before date in UTC.
  - `[Crv <JsonWebKeyCurveName?>]`: Elliptic curve name. For valid values, see JsonWebKeyCurveName.
  - `[KeyOp <JsonWebKeyOperation[]>]`: 
  - `[KeySize <Int32?>]`: The key size in bits. For example: 2048, 3072, or 4096 for RSA.
  - `[Tag <IKeyCreateParametersTags>]`: Application specific metadata in the form of key-value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

