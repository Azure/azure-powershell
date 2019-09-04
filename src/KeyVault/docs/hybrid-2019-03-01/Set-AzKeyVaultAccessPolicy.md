---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/set-azkeyvaultaccesspolicy
schema: 2.0.0
---

# Set-AzKeyVaultAccessPolicy

## SYNOPSIS
Update access policies in a key vault in the specified subscription.

## SYNTAX

### Update (Default)
```
Set-AzKeyVaultAccessPolicy -OperationKind <AccessPolicyUpdateKind> -ResourceGroupName <String>
 -VaultName <String> -Parameter <IVaultAccessPolicyParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzKeyVaultAccessPolicy -OperationKind <AccessPolicyUpdateKind> -ResourceGroupName <String>
 -VaultName <String> -AccessPolicy <IAccessPolicyEntry[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update access policies in a key vault in the specified subscription.

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
Parameter Sets: UpdateExpanded
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

### -OperationKind
Name of the operation

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.AccessPolicyUpdateKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Parameters for updating the access policy in a vault
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultAccessPolicyParameters
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the Resource Group to which the vault belongs.

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultName
Name of the vault

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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultAccessPolicyParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultAccessPolicyParameters

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

#### PARAMETER <IVaultAccessPolicyParameters>: Parameters for updating the access policy in a vault
  - `AccessPolicy <IAccessPolicyEntry[]>`: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.
    - `ObjectId <String>`: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
    - `TenantId <String>`: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
    - `[ApplicationId <String>]`:  Application ID of the client making request on behalf of a principal
    - `[PermissionCertificate <CertificatePermissions[]>]`: Permissions to certificates
    - `[PermissionKey <KeyPermissions[]>]`: Permissions to keys
    - `[PermissionSecret <SecretPermissions[]>]`: Permissions to secrets
    - `[PermissionStorage <StoragePermissions[]>]`: Permissions to storage accounts

## RELATED LINKS

