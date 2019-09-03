---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/set-azkeyvault
schema: 2.0.0
---

# Set-AzKeyVault

## SYNOPSIS
Create or update a key vault in the specified subscription.

## SYNTAX

### UpdateExpanded1 (Default)
```
Set-AzKeyVault -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 -SkuName <SkuName> -TenantId <String> [-AccessPolicy <IAccessPolicyEntry[]>] [-CreateMode <CreateMode>]
 [-EnabledForDeployment] [-EnabledForDiskEncryption] [-EnabledForTemplateDeployment] [-EnablePurgeProtection]
 [-EnableSoftDelete] [-Tag <Hashtable>] [-VaultUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update1
```
Set-AzKeyVault -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Parameter <IVaultCreateOrUpdateParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update a key vault in the specified subscription.

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

### -AccessPolicy
An array of 0 to 16 identities that have access to the key vault.
All identities in the array must use the same tenant ID as the key vault's tenant ID.
When `createMode` is set to `recover`, access policies are not required.
Otherwise, access policies are required.
To construct, see NOTES section for ACCESSPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IAccessPolicyEntry[]
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreateMode
The vault's create mode to indicate whether the vault need to be recovered or not.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.CreateMode
Parameter Sets: UpdateExpanded1
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

### -EnabledForDeployment
Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnabledForDiskEncryption
Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnabledForTemplateDeployment
Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnablePurgeProtection
Property specifying whether protection against purge is enabled for this vault.
Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion.
The setting is effective only if soft delete is also enabled.
Enabling this functionality is irreversible - that is, the property does not accept false as its value.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableSoftDelete
Property specifying whether recoverable deletion is enabled for this key vault.
Setting this property to true activates the soft delete feature, whereby vaults or vault entities can be recovered after deletion.
Enabling this functionality is irreversible - that is, the property does not accept false as its value.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
The supported Azure location where the key vault should be created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VaultName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Parameters for creating or updating a vault
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultCreateOrUpdateParameters
Parameter Sets: Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the Resource Group to which the server belongs.

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

### -SkuName
SKU name to specify whether the key vault is a standard vault or a premium vault.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -Tag
The tags that will be assigned to the key vault.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TenantId
The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultUri
The URI of the vault for performing operations on keys and secrets.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultCreateOrUpdateParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVault

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ACCESSPOLICY <IAccessPolicyEntry[]>: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access policies are required.
  - `ObjectId <String>`: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
  - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
  - `[ApplicationId <String>]`:  Application ID of the client making request on behalf of a principal
  - `[PermissionCertificate <CertificatePermissions[]>]`: Permissions to certificates
  - `[PermissionKey <KeyPermissions[]>]`: Permissions to keys
  - `[PermissionSecret <SecretPermissions[]>]`: Permissions to secrets
  - `[PermissionStorage <StoragePermissions[]>]`: Permissions to storage accounts

#### PARAMETER <IVaultCreateOrUpdateParameters>: Parameters for creating or updating a vault
  - `Location <String>`: The supported Azure location where the key vault should be created.
  - `SkuName <SkuName>`: SKU name to specify whether the key vault is a standard vault or a premium vault.
  - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
  - `[AccessPolicy <IAccessPolicyEntry[]>]`: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access policies are required.
    - `ObjectId <String>`: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
    - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
    - `[ApplicationId <String>]`:  Application ID of the client making request on behalf of a principal
    - `[PermissionCertificate <CertificatePermissions[]>]`: Permissions to certificates
    - `[PermissionKey <KeyPermissions[]>]`: Permissions to keys
    - `[PermissionSecret <SecretPermissions[]>]`: Permissions to secrets
    - `[PermissionStorage <StoragePermissions[]>]`: Permissions to storage accounts
  - `[CreateMode <CreateMode?>]`: The vault's create mode to indicate whether the vault need to be recovered or not.
  - `[EnablePurgeProtection <Boolean?>]`: Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value.
  - `[EnableSoftDelete <Boolean?>]`: Property specifying whether recoverable deletion is enabled for this key vault. Setting this property to true activates the soft delete feature, whereby vaults or vault entities can be recovered after deletion. Enabling this functionality is irreversible - that is, the property does not accept false as its value.
  - `[EnabledForDeployment <Boolean?>]`: Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.
  - `[EnabledForDiskEncryption <Boolean?>]`: Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
  - `[EnabledForTemplateDeployment <Boolean?>]`: Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
  - `[Tag <IVaultCreateOrUpdateParametersTags>]`: The tags that will be assigned to the key vault.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[VaultUri <String>]`: The URI of the vault for performing operations on keys and secrets.

## RELATED LINKS

