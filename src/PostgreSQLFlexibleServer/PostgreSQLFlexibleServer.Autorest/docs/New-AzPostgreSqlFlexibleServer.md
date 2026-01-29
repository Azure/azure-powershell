---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/new-azpostgresqlflexibleserver
schema: 2.0.0
---

# New-AzPostgreSqlFlexibleServer

## SYNOPSIS
Create a new server.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AdministratorLogin <String>] [-AdministratorLoginPassword <SecureString>]
 [-AuthConfigActiveDirectoryAuth <String>] [-AuthConfigPasswordAuth <String>] [-AuthConfigTenantId <String>]
 [-AvailabilityZone <String>] [-BackupGeoRedundantBackup <String>] [-BackupRetentionDay <Int32>]
 [-ClusterDefaultDatabaseName <String>] [-ClusterSize <Int32>] [-CreateMode <String>]
 [-DataEncryptionGeoBackupKeyUri <String>] [-DataEncryptionGeoBackupUserAssignedIdentityId <String>]
 [-DataEncryptionPrimaryKeyUri <String>] [-DataEncryptionPrimaryUserAssignedIdentityId <String>]
 [-DataEncryptionType <String>] [-EnableSystemAssignedIdentity] [-HighAvailabilityMode <String>]
 [-HighAvailabilityStandbyAvailabilityZone <String>] [-IdentityPrincipalId <String>]
 [-NetworkDelegatedSubnetResourceId <String>] [-NetworkPrivateDnsZoneArmResourceId <String>]
 [-NetworkPublicNetworkAccess <String>] [-PointInTimeUtc <DateTime>] [-ReplicationRole <String>]
 [-SkuName <String>] [-SkuTier <String>] [-SourceServerResourceId <String>] [-StorageAutoGrow <String>]
 [-StorageIop <Int32>] [-StorageSizeGb <Int32>] [-StorageThroughput <Int32>] [-StorageTier <String>]
 [-StorageType <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new server.

## EXAMPLES

### Example 1: Create a PostgreSQL Flexible Server with basic configuration
```powershell
New-AzPostgreSqlFlexibleServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -Location "East US" -AdministratorLogin "pgadmin" -AdministratorLoginPassword (ConvertTo-SecureString "MySecurePassword123!" -AsPlainText -Force) -Sku "Standard_B1ms" -StorageSizeGb 32 -Version "13"
```

```output
Name               : myPostgreSqlServer
ResourceGroupName  : myResourceGroup
Location           : East US
SkuName            : Standard_B1ms
SkuTier            : Burstable
StorageSizeGb      : 32
Version            : 13
State              : Ready
AdministratorLogin : pgadmin
FullyQualifiedDomainName: mypostgresqlserver.postgres.database.azure.com
```

Creates a new PostgreSQL Flexible Server with basic configuration using a Burstable SKU.

### Example 2: Create a PostgreSQL Flexible Server with high availability
```powershell
New-AzPostgreSqlFlexibleServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -Location "East US" -AdministratorLogin "pgadmin" -AdministratorLoginPassword (ConvertTo-SecureString "SecurePassword123!" -AsPlainText -Force) -Sku "Standard_D2s_v3" -StorageSizeGb 128 -Version "14" -HaEnabled "ZoneRedundant" -AvailabilityZone "1" -StandbyAvailabilityZone "2"
```

```output
Name               : prod-postgresql-01
ResourceGroupName  : production-rg
Location           : East US
SkuName            : Standard_D2s_v3
SkuTier            : GeneralPurpose
StorageSizeGb      : 128
Version            : 14
State              : Ready
AdministratorLogin : pgadmin
HaEnabled          : ZoneRedundant
AvailabilityZone   : 1
StandbyAvailabilityZone: 2
```

Creates a PostgreSQL Flexible Server with zone-redundant high availability for production workloads.

## PARAMETERS

### -AdministratorLogin
Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL.
Must be specified the first time that you enable password based authentication on a server.
Once set to a given value, it cannot be changed for the rest of the life of a server.
If you disable password based authentication on a server which had it enabled, this password based role isn't deleted.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdministratorLoginPassword
Password assigned to the administrator login.
As long as password authentication is enabled, this password can be changed at any time.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AuthConfigActiveDirectoryAuth
Indicates if the server supports Microsoft Entra authentication.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthConfigPasswordAuth
Indicates if the server supports password based authentication.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthConfigTenantId
Identifier of the tenant of the delegated resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Availability zone of a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupGeoRedundantBackup
Indicates if the server is configured to create geographically redundant backups.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRetentionDay
Backup retention days for the server.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterDefaultDatabaseName
Default database name for the elastic cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterSize
Number of nodes assigned to the elastic cluster.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateMode
Creation mode of a new server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionGeoBackupKeyUri
Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionGeoBackupUserAssignedIdentityId
Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryKeyUri
URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryUserAssignedIdentityId
Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the primary storage associated to a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionType
Data encryption type used by a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HighAvailabilityMode
High availability mode for a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HighAvailabilityStandbyAvailabilityZone
Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityPrincipalId
Identifier of the object of the service principal associated to the user assigned managed identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the server.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkDelegatedSubnetResourceId
Resource identifier of the delegated subnet.
Required during creation of a new server, in case you want the server to be integrated into your own virtual network.
For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkPrivateDnsZoneArmResourceId
Identifier of the private DNS zone.
Required during creation of a new server, in case you want the server to be integrated into your own virtual network.
For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkPublicNetworkAccess
Indicates if public network access is enabled or not.
This is only supported for servers that are not integrated into a virtual network which is owned and provided by customer when server is deployed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -PointInTimeUtc
Creation time (in ISO8601 format) of the backup which you want to restore in the new server.
It's required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationRole
Role of the server in a replication set.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -SkuName
Name by which is known a given compute size assigned to a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the compute assigned to a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceServerResourceId
Identifier of the server to be used as the source of the new server.
Required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', 'Replica', or 'ReviveDropped'.
This property is returned only when the target server is a read replica.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAutoGrow
Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions allow for automatically growing storage size.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageIop
Maximum IOPS supported for storage.
Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSizeGb
Size of storage assigned to a server.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageThroughput
Maximum throughput supported for storage.
Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageTier
Storage tier of a server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageType
Type of storage assigned to a server.
Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS.
If not specified, it defaults to Premium_LRS.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Major version of PostgreSQL database engine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer

## NOTES

## RELATED LINKS

