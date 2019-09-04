---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/update-azkeyvault
schema: 2.0.0
---

# Update-AzKeyVault

## SYNOPSIS
Update a key vault in the specified subscription.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzKeyVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AccessPolicy <IAccessPolicyEntry[]>] [-CreateMode <CreateMode>] [-EnabledForDeployment]
 [-EnabledForDiskEncryption] [-EnabledForTemplateDeployment] [-EnablePurgeProtection] [-EnableSoftDelete]
 [-SkuName <SkuName>] [-Tag <Hashtable>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update1
```
Update-AzKeyVault -Name <String> -ResourceGroupName <String> -Parameter <IVaultPatchParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity1
```
Update-AzKeyVault -InputObject <IKeyVaultIdentity> -Parameter <IVaultPatchParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzKeyVault -InputObject <IKeyVaultIdentity> [-AccessPolicy <IAccessPolicyEntry[]>]
 [-CreateMode <CreateMode>] [-EnabledForDeployment] [-EnabledForDiskEncryption]
 [-EnabledForTemplateDeployment] [-EnablePurgeProtection] [-EnableSoftDelete] [-SkuName <SkuName>]
 [-Tag <Hashtable>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a key vault in the specified subscription.

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
To construct, see NOTES section for ACCESSPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IAccessPolicyEntry[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnablePurgeProtection
Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is also enabled.
Once activated, the property may no longer be reset to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableSoftDelete
Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault.
The property may not be set to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateViaIdentity1, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the vault

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultPatchParameters
Parameter Sets: Update1, UpdateViaIdentity1
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
Parameter Sets: Update1, UpdateExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
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
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
The tags that will be assigned to the key vault.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultPatchParameters

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVault

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ACCESSPOLICY <IAccessPolicyEntry[]>: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.
  - `ObjectId <String>`: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
  - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
  - `[ApplicationId <String>]`:  Application ID of the client making request on behalf of a principal
  - `[PermissionCertificate <CertificatePermissions[]>]`: Permissions to certificates
  - `[PermissionKey <KeyPermissions[]>]`: Permissions to keys
  - `[PermissionSecret <SecretPermissions[]>]`: Permissions to secrets
  - `[PermissionStorage <StoragePermissions[]>]`: Permissions to storage accounts

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

#### PARAMETER <IVaultPatchParameters>: Parameters for creating or updating a vault
  - `SkuName <SkuName>`: SKU name to specify whether the key vault is a standard vault or a premium vault.
  - `[AccessPolicy <IAccessPolicyEntry[]>]`: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.
    - `ObjectId <String>`: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
    - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
    - `[ApplicationId <String>]`:  Application ID of the client making request on behalf of a principal
    - `[PermissionCertificate <CertificatePermissions[]>]`: Permissions to certificates
    - `[PermissionKey <KeyPermissions[]>]`: Permissions to keys
    - `[PermissionSecret <SecretPermissions[]>]`: Permissions to secrets
    - `[PermissionStorage <StoragePermissions[]>]`: Permissions to storage accounts
  - `[CreateMode <CreateMode?>]`: The vault's create mode to indicate whether the vault need to be recovered or not.
  - `[EnablePurgeProtection <Boolean?>]`: Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is also enabled. Once activated, the property may no longer be reset to false.
  - `[EnableSoftDelete <Boolean?>]`: Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be set to false.
  - `[EnabledForDeployment <Boolean?>]`: Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.
  - `[EnabledForDiskEncryption <Boolean?>]`: Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
  - `[EnabledForTemplateDeployment <Boolean?>]`: Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
  - `[Tag <IVaultPatchParametersTags>]`: The tags that will be assigned to the key vault. 
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[TenantId <String>]`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.

## RELATED LINKS

