---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azrmstoragecontainerimmutabilitypolicy
schema: 2.0.0
---

# New-AzRmStorageContainerImmutabilityPolicy

## SYNOPSIS
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

## SYNTAX

### Create (Default)
```
New-AzRmStorageContainerImmutabilityPolicy -AccountName <String> -ContainerName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-Parameter <IImmutabilityPolicy>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzRmStorageContainerImmutabilityPolicy -AccountName <String> -ContainerName <String>
 -ResourceGroupName <String> -SubscriptionId <String> -ImmutabilityPeriodSinceCreationInDay <Int32>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzRmStorageContainerImmutabilityPolicy -InputObject <IStorageIdentity>
 -ImmutabilityPeriodSinceCreationInDay <Int32> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzRmStorageContainerImmutabilityPolicy -InputObject <IStorageIdentity> [-Parameter <IImmutabilityPolicy>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

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

### -Parameter
The ImmutabilityPolicy property of a blob container, including Id, resource name, resource type, Etag.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy

## ALIASES

## RELATED LINKS

