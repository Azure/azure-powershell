---
external help file:
Module Name: Az.RedisEnterpriseCache
online version: https://docs.microsoft.com/en-us/powershell/module/az.redisenterprisecache/get-azredisenterprisecache
schema: 2.0.0
---

# Get-AzRedisEnterpriseCache

## SYNOPSIS
Gets information about a RedisEnterprise cluster and its associated database

## SYNTAX

```
Get-AzRedisEnterpriseCache -ResourceGroupName <String> [-Name <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a RedisEnterprise cluster and its associated database

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup" -Name "MyCache"
```

Location Name    Type                            Zone
-------- ----    ----                            ----
East US  MyCache Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

### -------------------------- EXAMPLE 2 --------------------------
```powershell
Get-AzRedisEnterpriseCache -ResourceGroupName "MyGroup"
```

Location Name     Type                            Zone
-------- ----     ----                            ----
East US  MyCache1 Microsoft.Cache/redisEnterprise

ClientProtocol    : Encrypted
ClusteringPolicy  : OSSCluster
EvictionPolicy    : VolatileLRU
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache1/databases/default
Module            :
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

East US  MyCache2 Microsoft.Cache/redisEnterprise {1, 2, 3}

ClientProtocol    : Plaintext
ClusteringPolicy  : EnterpriseCluster
EvictionPolicy    : NoEviction
Id                : /subscriptions/e311648e-a318-4a16-836e-f4a91cc73e9b/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache2/databases/default
Module            : {RedisBloom, RedisTimeSeries, RediSearch}
Name              : default
Port              : 10000
ProvisioningState : Succeeded
ResourceState     : Running
Type              : Microsoft.Cache/redisEnterprise/databases

## PARAMETERS

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

### -Name
The name of the RedisEnterprise cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.ICluster

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabase

## NOTES

ALIASES

## RELATED LINKS

