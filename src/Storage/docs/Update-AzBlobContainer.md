---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azblobcontainer
schema: 2.0.0
---

# Update-AzBlobContainer

## SYNOPSIS
Updates container properties as specified in request body.
Properties not mentioned in the request will be unchanged.
Update fails if the specified container doesn't already exist.

## SYNTAX

### Update (Default)
```
Update-AzBlobContainer -AccountName <String> -ContainerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-BlobContainer <IBlobContainer>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzBlobContainer -AccountName <String> -ContainerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ImmutabilityPeriodSinceCreationInDay <Int32> [-LegalHoldTag <ITagProperty[]>]
 [-Metadata <IContainerPropertiesMetadata>] [-PublicAccess <PublicAccess>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzBlobContainer -InputObject <IStorageIdentity> -ImmutabilityPeriodSinceCreationInDay <Int32>
 [-LegalHoldTag <ITagProperty[]>] [-Metadata <IContainerPropertiesMetadata>] [-PublicAccess <PublicAccess>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzBlobContainer -InputObject <IStorageIdentity> [-BlobContainer <IBlobContainer>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates container properties as specified in request body.
Properties not mentioned in the request will be unchanged.
Update fails if the specified container doesn't already exist.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobContainer
Properties of the blob container, including Id, resource name, resource type, Etag.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IBlobContainer
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ContainerName
The name of the blob container within the specified storage account.
Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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

### -ImmutabilityPeriodSinceCreationInDay
The immutability period for the blobs in the container since the policy creation, in days.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LegalHoldTag
The list of LegalHold tags of a blob container.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.ITagProperty[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
A name-value pair to associate with the container as metadata.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IContainerPropertiesMetadata
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicAccess
Specifies whether data in the container may be accessed publicly and the level of access.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.PublicAccess
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IBlobContainer
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azblobcontainer](https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azblobcontainer)

