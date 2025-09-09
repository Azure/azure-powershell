---
external help file: Az.StorageCache-help.xml
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/update-azstoragecachecach
schema: 2.0.0
---

# Update-AzStorageCacheCach

## SYNOPSIS
Update a cache.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageCacheCach -EName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DirectoryServicesSetting <ICacheDirectorySettings>] [-EnableSystemAssignedIdentity <Boolean>]
 [-EncryptionSettingRotationToLatestKeyVersionEnabled] [-KeyEncryptionKeyUrl <String>]
 [-NetworkSettingDnsSearchDomain <String>] [-NetworkSettingDnsServer <String[]>] [-NetworkSettingMtu <Int32>]
 [-NetworkSettingNtpServer <String>] [-SecuritySettingAccessPolicy <INfsAccessPolicy[]>]
 [-SourceVaultId <String>] [-Tag <Hashtable>] [-UpgradeSettingScheduledTime <DateTime>]
 [-UpgradeSettingUpgradeScheduleEnabled] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageCacheCach -InputObject <IStorageCacheIdentity>
 [-DirectoryServicesSetting <ICacheDirectorySettings>] [-EnableSystemAssignedIdentity <Boolean>]
 [-EncryptionSettingRotationToLatestKeyVersionEnabled] [-KeyEncryptionKeyUrl <String>]
 [-NetworkSettingDnsSearchDomain <String>] [-NetworkSettingDnsServer <String[]>] [-NetworkSettingMtu <Int32>]
 [-NetworkSettingNtpServer <String>] [-SecuritySettingAccessPolicy <INfsAccessPolicy[]>]
 [-SourceVaultId <String>] [-Tag <Hashtable>] [-UpgradeSettingScheduledTime <DateTime>]
 [-UpgradeSettingUpgradeScheduleEnabled] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a cache.

## EXAMPLES

### Example 1: Update cache configuration
```powershell
Update-AzStorageCacheCach -CacheName "myCache" -ResourceGroupName "myResourceGroup" -Tag @{"Environment"="Test"}
```

The HPC Cache service is being deprecated.

## PARAMETERS

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DirectoryServicesSetting
Specifies Directory Services settings of the cache.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.ICacheDirectorySettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EName
Name of cache.
Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: CacheName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionSettingRotationToLatestKeyVersionEnabled
Specifies whether the service will automatically rotate to the newest version of the key in the key vault.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
The URL referencing a key encryption key in key vault.

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

### -NetworkSettingDnsSearchDomain
DNS search domain

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

### -NetworkSettingDnsServer
DNS servers for the cache to use.
It will be set from the network configuration if no value is provided.

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

### -NetworkSettingMtu
The IPv4 maximum transmission unit configured for the subnet.

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

### -NetworkSettingNtpServer
NTP server IP Address or FQDN for the cache to use.
The default is time.windows.com.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SecuritySettingAccessPolicy
NFS access policies defined for this cache.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.INfsAccessPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceVaultId
Resource Id.

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

### -SubscriptionId
The ID of the target subscription.

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

### -UpgradeSettingScheduledTime
When upgradeScheduleEnabled is true, this field holds the user-chosen upgrade time.
At the user-chosen time, the firmware update will automatically be installed on the cache.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeSettingUpgradeScheduleEnabled
True if the user chooses to select an installation time between now and firmwareUpdateDeadline.
Else the firmware will automatically be installed after firmwareUpdateDeadline if not triggered earlier via the upgrade operation.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.ICache

## NOTES

## RELATED LINKS
