---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/update-azredisenterprisecache
schema: 2.0.0
---

# Update-AzRedisEnterpriseCache

## SYNOPSIS
Update an existing (overwrite/reupdate  with potential downtime) cache cluster

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRedisEnterpriseCache -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Capacity <Int32>] [-CustomerManagedKeyEncryptionKeyUrl <String>] [-EnableSystemAssignedIdentity <Boolean>]
 [-HighAvailability <String>] [-KeyEncryptionKeyIdentityType <String>]
 [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-MaintenanceConfigurationMaintenanceWindow <IMaintenanceWindow[]>] [-MinimumTlsVersion <String>]
 [-PublicNetworkAccess <String>] [-Sku <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRedisEnterpriseCache -InputObject <IRedisEnterpriseCacheIdentity> [-Capacity <Int32>]
 [-CustomerManagedKeyEncryptionKeyUrl <String>] [-EnableSystemAssignedIdentity <Boolean>]
 [-HighAvailability <String>] [-KeyEncryptionKeyIdentityType <String>]
 [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-MaintenanceConfigurationMaintenanceWindow <IMaintenanceWindow[]>] [-MinimumTlsVersion <String>]
 [-PublicNetworkAccess <String>] [-Sku <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an existing (overwrite/reupdate  with potential downtime) cache cluster

## EXAMPLES

### Example 1: Update Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MinimumTlsVersion "1.2" -Tag @{"tag1" = "value1"}
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}
```

This command updates the minimum TLS version and adds a tag to the Redis Enterprise cache named MyCache.

### Example 2: Update maintenance window on a Redis Enterprise cache
```powershell
Update-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -MaintenanceConfigurationMaintenanceWindow @(@{Type="Weekly"; ScheduleDayOfWeek="Monday"; StartHourUtc=6; Duration="PT10H"}, @{Type="Weekly"; ScheduleDayOfWeek="Thursday"; StartHourUtc=6; Duration="PT10H"})
```

```output
CustomerManagedKeyEncryptionKeyUrl                     :
HighAvailability                                       : Enabled
HostName                                               : MyCache.westus.redis.azure.net
Id                                                     : /subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache
IdentityPrincipalId                                    :
IdentityTenantId                                       :
IdentityType                                           : None
IdentityUserAssignedIdentity                           : {
                                                         }
KeyEncryptionKeyIdentityType                           :
KeyEncryptionKeyIdentityUserAssignedIdentityResourceId :
Kind                                                   : v2
Location                                               : West US
MaintenanceConfigurationMaintenanceWindow              : {{
                                                           "schedule": {
                                                             "dayOfWeek": "Monday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 6
                                                         }, {
                                                           "schedule": {
                                                             "dayOfWeek": "Thursday"
                                                           },
                                                           "type": "Weekly",
                                                           "duration": "PT10H",
                                                           "startHourUtc": 6
                                                         }}
MigratedEndpoint                                       :
MinimumTlsVersion                                      : 1.2
Name                                                   : MyCache
PrivateEndpointConnection                              : {}
ProvisioningState                                      : Succeeded
PublicNetworkAccess                                    : Enabled
RedisVersion                                           :
RedundancyMode                                         : ZR
ResourceGroupName                                      : MyGroup
ResourceState                                          : Running
SkuCapacity                                            :
SkuName                                                : Balanced_B10
SystemDataCreatedAt                                    :
SystemDataCreatedBy                                    :
SystemDataCreatedByType                                :
SystemDataLastModifiedAt                               :
SystemDataLastModifiedBy                               :
SystemDataLastModifiedByType                           :
Tag                                                    : {
                                                         }
Type                                                   : Microsoft.Cache/redisEnterprise
Zone                                                   :
Database                                               :
```

This command updates the maintenance windows on the Redis Enterprise cache named MyCache to Mondays and Thursdays at 6:00 AM UTC for 10 hours.
At least 2 maintenance windows are required.

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

### -Capacity
This property is only used with Enterprise and EnterpriseFlash SKUs.
Determines the size of the cluster.
Valid values are (2, 4, 6, ...) for Enterprise SKUs and (3, 9, 15, ...) for EnterpriseFlash SKUs.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: SkuCapacity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Redis Enterprise cluster.
Name must be 1-60 characters long.
Allowed characters(A-Z, a-z, 0-9) and hyphen(-).
There can be no leading nor trailing nor consecutive hyphens

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerManagedKeyEncryptionKeyUrl
Key encryption key Url, versioned only.
Ex: https://contosovault.vault.azure.net/keys/contosokek/562a4bb76b524a1493a6afe8e536ee78

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

### -HighAvailability
Enabled by default.
If highAvailability is disabled, the data set is not replicated.
This affects the availability SLA, and increases the risk of data loss.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyEncryptionKeyIdentityType
Only userAssignedIdentity is supported in this API version; other types may be supported in the future

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

### -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId
User assigned identity to use for accessing key encryption key Url.
Ex: /subscriptions/\<sub uuid\>/resourceGroups/\<resource group\>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId.

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

### -MaintenanceConfigurationMaintenanceWindow
Custom maintenance windows that apply to the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMaintenanceWindow[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersion
The minimum TLS version for the cluster to support, e.g.
'1.2'.
Newer versions can be added in the future.
Note that TLS 1.0 and TLS 1.1 are now completely obsolete -- you cannot use them.
They are mentioned only for the sake of consistency with old API versions.

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

### -PublicNetworkAccess
Whether or not public network traffic can access the Redis cluster.
Only 'Enabled' or 'Disabled' can be set.
null is returned only for clusters created using an old API version which do not have this property and cannot be set.

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

### -Sku
The level of Redis Enterprise cluster to deploy.
Possible values: ('Balanced_B5', 'MemoryOptimized_M10', 'ComputeOptimized_X5', etc.).
For more information on SKUs see the latest pricing documentation.
Note that additional SKUs may become supported in the future.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SkuName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Zone
The availability zones.

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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.ICluster

## NOTES

## RELATED LINKS
