---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstoragefileshare
schema: 2.0.0
---

# New-AzStorageFileShare

## SYNOPSIS
Creates a new share under the specified account as described by request body.
The share resource includes metadata and properties for that share.
It does not include a list of the files contained by the share.

## SYNTAX

```
New-AzStorageFileShare -AccountName <String> -ResourceGroupName <String> -ShareName <String>
 [-SubscriptionId <String>] [-Expand <String>] [-FileSharePropertyAccessTier <ShareAccessTier>]
 [-FileSharePropertyEnabledProtocol <EnabledProtocols>] [-FileSharePropertyMetadata <Hashtable>]
 [-FileSharePropertyRootSquash <RootSquashType>] [-FileSharePropertyShareQuota <Int32>]
 [-FileSharePropertySignedIdentifier <ISignedIdentifier[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new share under the specified account as described by request body.
The share resource includes metadata and properties for that share.
It does not include a list of the files contained by the share.

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
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

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

### -Expand
Optional, used to expand the properties within share's properties.
Valid values are: snapshots.
Should be passed as a string with delimiter ','

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

### -FileSharePropertyAccessTier
Access tier for specific share.
GpV2 account can choose between TransactionOptimized (default), Hot, and Cool.
FileStorage account can choose Premium.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.ShareAccessTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSharePropertyEnabledProtocol
The authentication protocol that is used for the file share.
Can only be specified when creating a share.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.EnabledProtocols
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSharePropertyMetadata
A name-value pair to associate with the share as metadata.

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

### -FileSharePropertyRootSquash
The property is for NFS share only.
The default is NoRootSquash.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.RootSquashType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSharePropertyShareQuota
The maximum size of the share, in gigabytes.
Must be greater than 0, and less than or equal to 5TB (5120).
For Large File Shares, the maximum size is 102400.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSharePropertySignedIdentifier
List of stored access policies specified on the share.
To construct, see NOTES section for FILESHAREPROPERTYSIGNEDIDENTIFIER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210901.ISignedIdentifier[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

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

### -ShareName
The name of the file share within the specified storage account.
File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.

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
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210901.IFileShare

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FILESHAREPROPERTYSIGNEDIDENTIFIER <ISignedIdentifier[]>: List of stored access policies specified on the share.
  - `[AccessPolicyExpiryTime <DateTime?>]`: Expiry time of the access policy
  - `[AccessPolicyPermission <String>]`: List of abbreviated permissions.
  - `[AccessPolicyStartTime <DateTime?>]`: Start time of the access policy
  - `[Id <String>]`: An unique identifier of the stored access policy.

## RELATED LINKS

