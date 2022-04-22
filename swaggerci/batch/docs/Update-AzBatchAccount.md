---
external help file:
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/update-azbatchaccount
schema: 2.0.0
---

# Update-AzBatchAccount

## SYNOPSIS
Updates the properties of an existing Batch account.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzBatchAccount -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AllowedAuthenticationMode <AuthenticationMode[]>] [-AutoStorageAccountId <String>]
 [-AutoStorageAuthenticationMode <AutoStorageAuthenticationMode>] [-EncryptionKeySource <KeySource>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-KeyVaultPropertyKeyIdentifier <String>] [-NodeIdentityReferenceResourceId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzBatchAccount -InputObject <IBatchIdentity> [-AllowedAuthenticationMode <AuthenticationMode[]>]
 [-AutoStorageAccountId <String>] [-AutoStorageAuthenticationMode <AutoStorageAuthenticationMode>]
 [-EncryptionKeySource <KeySource>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyVaultPropertyKeyIdentifier <String>]
 [-NodeIdentityReferenceResourceId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing Batch account.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the Batch account.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowedAuthenticationMode
List of allowed authentication modes for the Batch account that can be used to authenticate with the data plane.
This does not affect authentication with the control plane.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.AuthenticationMode[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoStorageAccountId
The resource ID of the storage account to be used for auto-storage account.

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

### -AutoStorageAuthenticationMode
The authentication mode which the Batch service will use to manage the auto-storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.AutoStorageAuthenticationMode
Parameter Sets: (All)
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

### -EncryptionKeySource
Type of the key source.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.KeySource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the Batch account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the Batch account.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyIdentifier
Full path to the versioned secret.
Example https://mykeyvault.vault.azure.net/keys/testkey/6e34a81fef704045975661e297a4c053.
To be usable the following prerequisites must be met: The Batch Account has a System Assigned identity The account identity has been granted Key/Get, Key/Unwrap and Key/Wrap permissions The KeyVault has soft-delete and purge protection enabled

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

### -NodeIdentityReferenceResourceId
The ARM resource id of the user assigned identity.

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

### -ResourceGroupName
The name of the resource group that contains the Batch account.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The user-specified tags associated with the account.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IBatchAccount

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IBatchIdentity>: Identity Parameter
  - `[AccountName <String>]`: A name for the Batch account which must be unique within the region. Batch account names must be between 3 and 24 characters in length and must use only numbers and lowercase letters. This name is used as part of the DNS name that is used to access the Batch service in the region in which the account is created. For example: http://accountname.region.batch.azure.com/.
  - `[ApplicationName <String>]`: The name of the application. This must be unique within the account.
  - `[CertificateName <String>]`: The identifier for the certificate. This must be made up of algorithm and thumbprint separated by a dash, and must match the certificate data in the request. For example SHA1-a3d1c5.
  - `[DetectorId <String>]`: The name of the detector.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The region for which to retrieve Batch service quotas.
  - `[PoolName <String>]`: The pool name. This must be unique within the account.
  - `[PrivateEndpointConnectionName <String>]`: The private endpoint connection name. This must be unique within the account.
  - `[PrivateLinkResourceName <String>]`: The private link resource name. This must be unique within the account.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the Batch account.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
  - `[VersionName <String>]`: The version of the application.

## RELATED LINKS

