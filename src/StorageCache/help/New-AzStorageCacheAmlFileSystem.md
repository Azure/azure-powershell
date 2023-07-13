---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecacheamlfilesystem
schema: 2.0.0
---

# New-AzStorageCacheAmlFileSystem

## SYNOPSIS
Create or update an AML file system.

## SYNTAX

```
New-AzStorageCacheAmlFileSystem -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-FilesystemSubnet <String>] [-IdentityType <AmlFilesystemIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-KeyEncryptionKeyUrl <String>]
 [-MaintenanceWindowDayOfWeek <MaintenanceDayOfWeekType>] [-MaintenanceWindowTimeOfDayUtc <String>]
 [-SettingContainer <String>] [-SettingImportPrefix <String>] [-SettingLoggingContainer <String>]
 [-SkuName <String>] [-SourceVaultId <String>] [-StorageCapacityTiB <Single>] [-Tag <Hashtable>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update an AML file system.

## EXAMPLES

### Example 1: Create or update an AML file system.
```powershell
New-AzStorageCacheAmlFileSystem -Name azps-cache-fs -ResourceGroupName azps_test_gp_storagecache -Location eastus -IdentityType 'UserAssigned' -IdentityUserAssignedIdentity @{"/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-management-identity" = @{}} -KeyEncryptionKeyUrl "https://azps-keyvault.vault.azure.net/keys/azps-kv/4cc795e46f114ce2a65b82b312964e0e" -SourceVaultId "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.KeyVault/vaults/azps-keyvault" -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/azps-vnetwork-sub-kv" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1
```

```output
Name          Location ResourceGroupName         HealthState SkuName
----          -------- -----------------         ----------- -------
azps-cache-fs eastus   AZPS_TEST_GP_STORAGECACHE Available   AMLFS-Durable-Premium-250
```

Create or update an AML file system.

### Example 2: Create or update an AML file system and setting HSM.
```powershell
New-AzStorageCacheAmlFileSystem -Name azps-cache-fs-hsm -ResourceGroupName azps_test_gp_storagecache -Location eastus -MaintenanceWindowDayOfWeek 'Saturday' -MaintenanceWindowTimeOfDayUtc "03:00" -FilesystemSubnet "/subscriptions/{subId}/resourcegroups/azps_test_gp_storagecache/providers/Microsoft.Network/virtualNetworks/azps-virtual-network/subnets/default" -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16 -Zone 1 -SettingContainer "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa/blobServices/default/containers/az-blob-login" -SettingImportPrefix "/" -SettingLoggingContainer "/subscriptions/{subId}/resourceGroups/azps_test_gp_storagecache/providers/Microsoft.Storage/storageAccounts/azpssa/blobServices/default/containers/az-blob"
```

```output
Name              Location ResourceGroupName         HealthState SkuName
----              -------- -----------------         ----------- -------
azps-cache-fs-hsm eastus   AZPS_TEST_GP_STORAGECACHE Available   AMLFS-Durable-Premium-250
```

Create or update an AML file system and setting HSM.

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

### -FilesystemSubnet
Subnet used for managing the AML file system and for client-facing operations.
This subnet should have at least a /24 subnet mask within the VNET's address space.

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

### -IdentityType
The type of identity used for the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.AmlFilesystemIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
A dictionary where each key is a user assigned identity resource ID, and each key's value is an empty dictionary.

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

### -Location
The geo-location where the resource lives

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

### -MaintenanceWindowDayOfWeek
Day of the week on which the maintenance window will occur.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Support.MaintenanceDayOfWeekType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceWindowTimeOfDayUtc
The time of day (in UTC) to start the maintenance window.

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

### -Name
Name for the AML file system.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AmlFilesystemName

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SettingContainer
Resource ID of storage container used for hydrating the namespace and archiving from the namespace.
The resource provider must have permission to create SAS tokens on the storage account.

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

### -SettingImportPrefix
Only blobs in the non-logging container that start with this path/prefix get hydrated into the cluster namespace.

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

### -SettingLoggingContainer
Resource ID of storage container used for logging events and errors.
Must be a separate container in the same storage account as the hydration and archive container.
The resource provider must have permission to create SAS tokens on the storage account.

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

### -SkuName
SKU name for this resource.

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

### -StorageCapacityTiB
The size of the AML file system, in TiB.
This might be rounded up.

```yaml
Type: System.Single
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
Parameter Sets: (All)
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

### -Zone
Availability zones for resources.
This field should only contain a single element in the array.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.IAmlFilesystem

## NOTES

ALIASES

## RELATED LINKS

