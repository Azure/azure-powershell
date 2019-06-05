---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azrmstoragecontainer
schema: 2.0.0
---

# New-AzRmStorageContainer

## SYNOPSIS
Creates a new container under the specified account as described by request body.
The container resource includes metadata and properties for that container.
It does not include a list of the blobs contained by the container.

## SYNTAX

### Create (Default)
```
New-AzRmStorageContainer -AccountName <String> -ContainerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-BlobContainer <IBlobContainer>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzRmStorageContainer -AccountName <String> -ContainerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ImmutabilityPeriodSinceCreationInDay <Int32> [-LegalHoldTag <ITagProperty[]>]
 [-Metadata <IContainerPropertiesMetadata>] [-PublicAccess <PublicAccess>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzRmStorageContainer -InputObject <IStorageIdentity> -ImmutabilityPeriodSinceCreationInDay <Int32>
 [-LegalHoldTag <ITagProperty[]>] [-Metadata <IContainerPropertiesMetadata>] [-PublicAccess <PublicAccess>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzRmStorageContainer -InputObject <IStorageIdentity> [-BlobContainer <IBlobContainer>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new container under the specified account as described by request body.
The container resource includes metadata and properties for that container.
It does not include a list of the blobs contained by the container.

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

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BlobContainer
Properties of the blob container, including Id, resource name, resource type, Etag.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IBlobContainer
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ContainerName
The name of the blob container within the specified storage account.
Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### -ImmutabilityPeriodSinceCreationInDay
The immutability period for the blobs in the container since the policy creation, in days.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -LegalHoldTag
The list of LegalHold tags of a blob container.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.ITagProperty[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metadata
A name-value pair to associate with the container as metadata.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IContainerPropertiesMetadata
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublicAccess
Specifies whether data in the container may be accessed publicly and the level of access.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.PublicAccess
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IBlobContainer

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IBlobContainer

## ALIASES

## RELATED LINKS

