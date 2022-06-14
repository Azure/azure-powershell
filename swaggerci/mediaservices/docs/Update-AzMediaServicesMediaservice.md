---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/update-azmediaservicesmediaservice
schema: 2.0.0
---

# Update-AzMediaServicesMediaservice

## SYNOPSIS
Updates an existing Media Services account

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMediaServicesMediaservice -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AccessControlDefaultAction <DefaultAction>]
 [-AccessControlIPAllowList <String[]>] [-EncryptionType <AccountEncryptionKeyType>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IdentityUseSystemAssignedIdentity]
 [-KeyVaultPropertyKeyIdentifier <String>] [-PropertiesEncryptionIdentityUserAssignedIdentity <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-StorageAccount <IStorageAccount[]>]
 [-StorageAuthentication <StorageAuthentication>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMediaServicesMediaservice -InputObject <IMediaServicesIdentity>
 [-AccessControlDefaultAction <DefaultAction>] [-AccessControlIPAllowList <String[]>]
 [-EncryptionType <AccountEncryptionKeyType>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IdentityUseSystemAssignedIdentity]
 [-KeyVaultPropertyKeyIdentifier <String>] [-PropertiesEncryptionIdentityUserAssignedIdentity <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-StorageAccount <IStorageAccount[]>]
 [-StorageAuthentication <StorageAuthentication>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing Media Services account

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

### -AccessControlDefaultAction
The behavior for IP access control in Key Delivery.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.DefaultAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccessControlIPAllowList
The IP allow list for access control in Key Delivery.
If the default action is set to 'Allow', the IP allow list must be empty.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
The Media Services account name.

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

### -EncryptionType
The type of key used to encrypt the Account Key.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.AccountEncryptionKeyType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

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

### -IdentityUserAssignedIdentity
The user assigned managed identities.

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

### -IdentityUseSystemAssignedIdentity
Indicates whether to use System Assigned Managed Identity.
Mutual exclusive with User Assigned Managed Identity.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyIdentifier
The URL of the Key Vault key used to encrypt the account.
The key may either be versioned (for example https://vault/keys/mykey/version1) or reference a key without a version (for example https://vault/keys/mykey).

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

### -PropertiesEncryptionIdentityUserAssignedIdentity
The user assigned managed identity's ARM ID to use when accessing a resource.

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

### -PublicNetworkAccess
Whether or not public network access is allowed for resources under the Media Services account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the Azure subscription.

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

### -StorageAccount
The storage accounts for this resource.
To construct, see NOTES section for STORAGEACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20210601.IStorageAccount[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAuthentication
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.StorageAuthentication
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.

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
Resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20210601.IMediaService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMediaServicesIdentity>: Identity Parameter
  - `[AccountName <String>]`: The Media Services account name.
  - `[AssetName <String>]`: The Asset name.
  - `[ContentKeyPolicyName <String>]`: The Content Key Policy name.
  - `[FilterName <String>]`: The Account Filter name
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The Job name.
  - `[LiveEventName <String>]`: The name of the live event, maximum length is 32.
  - `[LiveOutputName <String>]`: The name of the live output.
  - `[LocationName <String>]`: The name of the location
  - `[Name <String>]`: 
  - `[OperationId <String>]`: Operation Id.
  - `[ResourceGroupName <String>]`: The name of the resource group within the Azure subscription.
  - `[StreamingEndpointName <String>]`: The name of the streaming endpoint, maximum length is 24.
  - `[StreamingLocatorName <String>]`: The Streaming Locator name.
  - `[StreamingPolicyName <String>]`: The Streaming Policy name.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription.
  - `[TrackName <String>]`: The Asset Track name.
  - `[TransformName <String>]`: The Transform name.

STORAGEACCOUNT <IStorageAccount[]>: The storage accounts for this resource.
  - `Type <StorageAccountType>`: The type of the storage account.
  - `[Id <String>]`: The ID of the storage account resource. Media Services relies on tables and queues as well as blobs, so the primary storage account must be a Standard Storage account (either Microsoft.ClassicStorage or Microsoft.Storage). Blob only storage accounts can be added as secondary storage accounts.
  - `[IdentityUseSystemAssignedIdentity <Boolean?>]`: Indicates whether to use System Assigned Managed Identity. Mutual exclusive with User Assigned Managed Identity.
  - `[IdentityUserAssignedIdentity <String>]`: The user assigned managed identity's ARM ID to use when accessing a resource.

## RELATED LINKS

