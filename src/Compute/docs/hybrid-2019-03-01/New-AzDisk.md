---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/new-azdisk
schema: 2.0.0
---

# New-AzDisk

## SYNOPSIS
Creates or updates a disk.

## SYNTAX

### Create1 (Default)
```
New-AzDisk -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Disk <IDisk>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzDisk -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -CreationDataCreateOption <DiskCreateOption> -DiskEncryptionKeySecretUrl <String> -ImageReferenceId <String>
 -KeyEncryptionKeyUrl <String> -Location <String> [-CreationDataSourceResourceId <String>]
 [-CreationDataSourceUri <String>] [-CreationDataStorageAccountId <String>]
 [-DiskEncryptionKeySourceVaultId <String>] [-DiskSizeGb <Int32>] [-EncryptionSettingEnabled]
 [-ImageReferenceLun <Int32>] [-KeyEncryptionKeySourceVaultId <String>] [-OSType <OperatingSystemTypes>]
 [-SkuName <StorageAccountTypes>] [-Tag <IResourceTags>] [-Zone <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a disk.

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

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreationDataCreateOption
This enumerates the possible sources of a disk's creation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.DiskCreateOption
Parameter Sets: CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreationDataSourceResourceId
If createOption is Copy, this is the ARM id of the source snapshot or disk.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreationDataSourceUri
If createOption is Import, this is the URI of a blob to be imported into a managed disk.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreationDataStorageAccountId
If createOption is Import, the Azure Resource Manager identifier of the storage account containing the blob to import as a disk.
Required only if the blob is in a different subscription

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
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

### -Disk
Disk resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IDisk
Parameter Sets: Create1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -DiskEncryptionKeySecretUrl
Url pointing to a key or secret in KeyVault

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DiskEncryptionKeySourceVaultId
Resource Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DiskSizeGb
If creationData.createOption is Empty, this field is mandatory and it indicates the size of the VHD to create.
If this field is present for updates or creation with other options, it indicates a resize.
Resizes are only allowed if the disk is not attached to a running VM, and can only increase the disk's size.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptionSettingEnabled
Set this flag to true and provide DiskEncryptionKey and optional KeyEncryptionKey to enable encryption.
Set this flag to false and remove DiskEncryptionKey and KeyEncryptionKey to disable encryption.
If EncryptionSettings is null in the request object, the existing settings remain unchanged.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceId
A relative uri containing either a Platform Image Repository or user image reference.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ImageReferenceLun
If the disk is created from an image's data disk, this is an index that indicates which of the data disks in the image to use.
For OS disks, this field is null.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyEncryptionKeySourceVaultId
Resource Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyEncryptionKeyUrl
Url pointing to a key or secret in KeyVault

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed disk that is being created.
The name can't be changed after the disk is created.
Supported characters for the name are a-z, A-Z, 0-9 and _.
The maximum name length is 80 characters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DiskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSType
The Operating System type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.OperatingSystemTypes
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

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
The sku name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountTypes
Parameter Sets: CreateExpanded1
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
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IResourceTags
Parameter Sets: CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Zone
The Logical zone list for Disk.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IDisk

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20170330.IDisk

## ALIASES

## RELATED LINKS

