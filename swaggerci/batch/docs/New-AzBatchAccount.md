---
external help file:
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/new-azbatchaccount
schema: 2.0.0
---

# New-AzBatchAccount

## SYNOPSIS
Creates a new Batch account with the specified parameters.
Existing accounts cannot be updated with this API and should instead be updated with the Update Batch Account API.

## SYNTAX

```
New-AzBatchAccount -AccountName <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AllowedAuthenticationMode <AuthenticationMode[]>]
 [-AutoStorageAccountId <String>] [-AutoStorageAuthenticationMode <AutoStorageAuthenticationMode>]
 [-EncryptionKeySource <KeySource>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyVaultPropertyKeyIdentifier <String>]
 [-KeyVaultReferenceId <String>] [-KeyVaultReferenceUrl <String>] [-NodeIdentityReferenceResourceId <String>]
 [-PoolAllocationMode <PoolAllocationMode>] [-PublicNetworkAccess <PublicNetworkAccessType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Batch account with the specified parameters.
Existing accounts cannot be updated with this API and should instead be updated with the Update Batch Account API.

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
A name for the Batch account which must be unique within the region.
Batch account names must be between 3 and 24 characters in length and must use only numbers and lowercase letters.
This name is used as part of the DNS name that is used to access the Batch service in the region in which the account is created.
For example: http://accountname.region.batch.azure.com/.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -AsJob
Run the command as a job

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

### -KeyVaultReferenceId
The resource ID of the Azure key vault associated with the Batch account.

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

### -KeyVaultReferenceUrl
The URL of the Azure key vault associated with the Batch account.

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

### -Location
The region in which to create the account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -NoWait
Run the command asynchronously

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

### -PoolAllocationMode
The pool allocation mode also affects how clients may authenticate to the Batch Service API.
If the mode is BatchService, clients may authenticate using access keys or Azure Active Directory.
If the mode is UserSubscription, clients must use Azure Active Directory.
The default is BatchService.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.PoolAllocationMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
If not specified, the default value is 'enabled'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.PublicNetworkAccessType
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IBatchAccount

## NOTES

ALIASES

## RELATED LINKS

