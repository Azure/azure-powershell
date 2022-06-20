---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbaccount
schema: 2.0.0
---

# New-AzCosmosDBAccount

## SYNOPSIS
Create a new CosmosDB Account.

## SYNTAX

```
New-AzCosmosDBAccount [-EnableAutomaticFailover] [-EnableMultipleWriteLocations] [-EnableVirtualNetwork]
 [-FromPointInTimeBackup] [-ApiKind <String>] [-DisableKeyBasedMetadataWriteAccess] [-EnableFreeTier <Boolean>]
 [-Location <String[]>] [-LocationObject <PSLocation[]>] -ResourceGroupName <String> -Name <String>
 [-DefaultConsistencyLevel <String>] [-IpRule <String[]>] [-MaxStalenessIntervalInSeconds <Int32>]
 [-MaxStalenessPrefix <Int32>] [-Tag <Hashtable>] [-VirtualNetworkRule <String[]>]
 [-VirtualNetworkRuleObject <PSVirtualNetworkRule[]>] [-PublicNetworkAccess <String>]
 [-KeyVaultKeyUri <String>] [-EnableAnalyticalStorage <Boolean>] [-AsJob] [-NetworkAclBypass <String>]
 [-NetworkAclBypassResourceId <String[]>] [-ServerVersion <String>] [-BackupIntervalInMinutes <Int32>]
 [-BackupRetentionIntervalInHours <Int32>] [-BackupStorageRedundancy <String>] [-BackupPolicyType <String>]
 [-AnalyticalStorageSchemaType <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new CosmosDB Account in the given ResourceGroup.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBAccount -ResourceGroupName resourceGroupName -Name databaseAccountName -Location "East US"
```

```output
Kind                          : GlobalDocumentDB
ProvisioningState             : Initializing
DocumentEndpoint              :
DatabaseAccountOfferType      : Standard
IpRangeFilter                 :
IsVirtualNetworkFilterEnabled : False
EnableAutomaticFailover       : False
ConsistencyPolicy             : Microsoft.Azure.Management.CosmosDB.Models.ConsistencyPolicy
Capabilities                  : {}
WriteLocations                : {databaseAccountName-eastus}
ReadLocations                 : {databaseAccountName-eastus}
FailoverPolicies              : {databaseAccountName-eastus}
VirtualNetworkRules           : {}
EnableMultipleWriteLocations  : False
Location                      : East US
Tags                          : {}
Id                            : /subscriptions/{subscriptionid}/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/databaseAccountName
Name                          : databaseAccountName
Type                          : Microsoft.DocumentDB/databaseAccounts
NetworkAclBypass              : None
NetworkAclBypassResourceIds   : {}
```

A new CosmosDB Account with name databaseAccountName is created in the ResourceGroup resourceGroupName.

### Example 2
```powershell
New-AzCosmosDBAccount -ResourceGroupName resourceGroupName -Name restored-account-name -Location "West US" -FromPointInTimeBackup -SourceRestorableDatabaseAccountId "/subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/restorableDatabaseAccounts/{instance-id}" -RestoreTimesampInUtc 2020-07-20T17:19:25+0000
```

```output
Id                                 : /subscriptions/259fbb24-9bcd-4cfc-865c-fc33b22fe38a/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/restored-account-name
Name                               : restored-account-name
InstanceId                         : eeb45f7f-4c05-4b52-9f42-6807d8eb8703
Location                           : West US
Tags                               : {}
EnableCassandraConnector           :
EnableMultipleWriteLocations       : False
VirtualNetworkRules                : {}
FailoverPolicies                   : {restored-account-name-westus}
Locations                          : {restored-account-name-westus}
ReadLocations                      : {restored-account-name-westus}
WriteLocations                     : {restored-account-name-westus}
Capabilities                       : {}
ConsistencyPolicy                  : Microsoft.Azure.Management.CosmosDB.Models.ConsistencyPolicy
EnableAutomaticFailover            : False
IsVirtualNetworkFilterEnabled      : False
IpRules                            : {}
DatabaseAccountOfferType           : Standard
DocumentEndpoint                   : https://restored-account-name.documents.azure.com:443/
ProvisioningState                  : Succeeded
Kind                               : GlobalDocumentDB
ConnectorOffer                     :
DisableKeyBasedMetadataWriteAccess : False
PublicNetworkAccess                : Enabled
KeyVaultKeyUri                     :
PrivateEndpointConnections         :
EnableFreeTier                     : False
ApiProperties                      : Microsoft.Azure.Commands.CosmosDB.Models.PSApiProperties
EnableAnalyticalStorage            : False
BackupPolicy                       : Microsoft.Azure.Commands.CosmosDB.Models.PSBackupPolicy
RestoreParameters                  : Microsoft.Azure.Commands.CosmosDB.Models.PSRestoreParameters
CreateMode                         : Restore
```

A new account with the name restoredDatabaseAccountName is created by restoring the restorable database account of the given Id to the given timestamp.

### Example 3
```powershell
New-AzCosmosDBAccount -ResourceGroupName resourceGroupName -Name restored-account-name -Location "West US" -FromPointInTimeBackup -SourceDatabaseAccountName source-database-account-name -RestoreTimesampInUtc 2020-07-20T17:19:25+0000
```

```output
Id                                 : /subscriptions/259fbb24-9bcd-4cfc-865c-fc33b22fe38a/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/restored-account-name
Name                               : restored-account-name
InstanceId                         : eeb45f7f-4c05-4b52-9f42-6807d8eb8703
Location                           : West US
Tags                               : {}
EnableCassandraConnector           :
EnableMultipleWriteLocations       : False
VirtualNetworkRules                : {}
FailoverPolicies                   : {restored-account-name-westus}
Locations                          : {restored-account-name-westus}
ReadLocations                      : {restored-account-name-westus}
WriteLocations                     : {restored-account-name-westus}
Capabilities                       : {}
ConsistencyPolicy                  : Microsoft.Azure.Management.CosmosDB.Models.ConsistencyPolicy
EnableAutomaticFailover            : False
IsVirtualNetworkFilterEnabled      : False
IpRules                            : {}
DatabaseAccountOfferType           : Standard
DocumentEndpoint                   : https://restored-account-name.documents.azure.com:443/
ProvisioningState                  : Succeeded
Kind                               : GlobalDocumentDB
ConnectorOffer                     :
DisableKeyBasedMetadataWriteAccess : False
PublicNetworkAccess                : Enabled
KeyVaultKeyUri                     :
PrivateEndpointConnections         :
EnableFreeTier                     : False
ApiProperties                      : Microsoft.Azure.Commands.CosmosDB.Models.PSApiProperties
EnableAnalyticalStorage            : False
BackupPolicy                       : Microsoft.Azure.Commands.CosmosDB.Models.PSBackupPolicy
RestoreParameters                  : Microsoft.Azure.Commands.CosmosDB.Models.PSRestoreParameters
CreateMode                         : Restore
```

A new account with the name restoredDatabaseAccountName is created by restoring the restorable database account of the given Id to the given timestamp.

## PARAMETERS

### -AnalyticalStorageSchemaType
The schema type for analytical storage. Valid values include: 'WellDefined' and 'FullFidelity'.

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

### -ApiKind
The type of Cosmos DB database account to create.
Accepted values: GlobalDocumentDB, MongoDB, Gremlin, Table, Cassandra.
Default value: GlobalDocumentDB

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

### -AsJob
Run cmdlet in the background

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

### -BackupIntervalInMinutes
The interval(in minutes) with which backup are taken (only for accounts with periodic mode backups)

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupPolicyType
The type of backups on the Cosmos DB account. Accepted values: Periodic, Continuous

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

### -BackupRetentionIntervalInHours
The time(in hours) for which each backup is retained (only for accounts with periodic mode backups)

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupStorageRedundancy
The redundancy type of the backup Storage account

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

### -DefaultConsistencyLevel
Default consistency level of the Cosmos DB database account.
Accepted values: BoundedStaleness, ConsistentPrefix, Eventual, Session, Strong

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableKeyBasedMetadataWriteAccess
Disable write operations on metadata resources (databases, containers, throughput) via account keys

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

### -EnableAnalyticalStorage
Bool to indicate if AnalyticalStorage is enabled on the account.

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

### -EnableAutomaticFailover
Enables automatic failover of the write region in the rare event that the region is unavailable due to an outage.
Automatic failover will result in a new write region for the account and is chosen based on the failover priorities configured for the account.
Accepted values: false, true

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

### -EnableFreeTier
Bool to indicate if FreeTier is enabled on the account.

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

### -EnableMultipleWriteLocations
Enable Multiple Write Locations.
Accepted values: false, true

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

### -EnableVirtualNetwork
Enables virtual network on the Cosmos DB database account.
Accepted values: false, true

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

### -FromPointInTimeBackup
Indicates that the new Cosmos DB account request is a restore request.

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

### -IpRule
Firewall support. Specifies the set of IP addresses or IP address ranges in CIDR form to be included as the allowed list of client IPs for a given database account.

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

### -KeyVaultKeyUri
URI of the KeyVault

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
Add a location to the Cosmos DB database account.
Array of strings, ordered by failover priority.

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

### -LocationObject
Add a location to the Cosmos DB database account. Array of PSLocation objects.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSLocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxStalenessIntervalInSeconds
When used with Bounded Staleness consistency, this value represents the time amount of staleness (in timespan) tolerated.
Accepted range for this value is 5-86400.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxStalenessPrefix
When used with Bounded Staleness consistency, this value represents the number of stale requests tolerated.
Accepted range for this value is 1 - 2,147,483,647.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Cosmos DB database account.

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

### -NetworkAclBypass
Whether or not Network Acl Bypass is enabled for this account for Synapse Link. Possible values include: 'None', 'AzureServices'.

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

### -NetworkAclBypassResourceId
List of Resource Ids to allow Network Acl Bypass for Synapse Link.

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

### -PublicNetworkAccess
Whether or not public endpoint access is allowed for this server. Possible values include: 'Enabled', 'Disabled'

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
Name of resource group.

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

### -ServerVersion
ServerVersion, valid only in case of MongoDB Accounts.

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

### -Tag
Hashtable of tags as key-value pairs.
Use empty string to clear existing tag.

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

### -VirtualNetworkRule
Array of string values of ACL's for virtual network.

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

### -VirtualNetworkRuleObject
Array of PSVirtualNetworkRuleObjects for virtual network.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSVirtualNetworkRule[]
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSCorsRule[]

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccount

## NOTES

## RELATED LINKS
