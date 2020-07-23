---
external help file:
Module Name: Az.MySql
online version: https://docs.microsoft.com/en-us/powershell/module/az.mysql/get-azmysqlconnectionstring
schema: 2.0.0
---

# Get-AzMySqlConnectionString

## SYNOPSIS
Get the connection string according to client connection provider.

## SYNTAX

### Get (Default)
```
Get-AzMySqlConnectionString -Client <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMySqlConnectionString -Client <String> -InputObject <IServer> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the connection string according to client connection provider.

## EXAMPLES

### Example 1: Get MySql server connection string by resource group and server name
```powershell
PS C:\> Get-AzMySqlConnectionString -Client ADO.NET -Name mysql-test -ResourceGroupName PowershellMySqlTest

Server=mysql-test.mysql.database.azure.com; Port=3306; Database={your_database}; Uid=mysql_test@mysql-test; Pwd={your_password};
```

This cmdlet gets MySql server connection string by resource group and server name.

### Example 2: Get MySql server connection string by identity
```powershell
PS C:\> Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -ServerName mysql-test | Get-AzMySqlConnectionString -Client PHP

$con=mysqli_init(); mysqli_real_connect($con, "mysql-test.mysql.database.azure.com", "mysql_test@mysql-test", {your_password}, {your_database}, 3306);
```

This cmdlet gets MySql server connection string by identity.

## PARAMETERS

### -Client
Client connection provider.

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

### -InputObject
The source server object to create replica from.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the server.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IServer>: The source server object to create replica from.
  - `Location <String>`: The location the resource resides in.
  - `[Tag <ITrackedResourceTags>]`: Application-specific metadata in the form of key-value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AdministratorLogin <String>]`: The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).
  - `[EarliestRestoreDate <DateTime?>]`: Earliest restore point creation time (ISO8601 format)
  - `[FullyQualifiedDomainName <String>]`: The fully qualified domain name of a server.
  - `[IdentityType <IdentityType?>]`: The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.
  - `[InfrastructureEncryption <InfrastructureEncryption?>]`: Status showing whether the server enabled infrastructure encryption.
  - `[MasterServerId <String>]`: The master server id of a replica server.
  - `[MinimalTlsVersion <MinimalTlsVersionEnum?>]`: Enforce a minimal Tls version for the server.
  - `[PublicNetworkAccess <PublicNetworkAccessEnum?>]`: Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'
  - `[ReplicaCapacity <Int32?>]`: The maximum number of replicas that a master server can have.
  - `[ReplicationRole <String>]`: The replication role of the server.
  - `[SkuCapacity <Int32?>]`: The scale up/out capacity, representing server's compute units.
  - `[SkuFamily <String>]`: The family of hardware.
  - `[SkuName <String>]`: The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
  - `[SkuSize <String>]`: The size code, to be interpreted by resource as appropriate.
  - `[SkuTier <SkuTier?>]`: The tier of the particular SKU, e.g. Basic.
  - `[SslEnforcement <SslEnforcementEnum?>]`: Enable ssl enforcement or not when connect to server.
  - `[StorageProfileBackupRetentionDay <Int32?>]`: Backup retention days for the server.
  - `[StorageProfileGeoRedundantBackup <GeoRedundantBackup?>]`: Enable Geo-redundant or not for server backup.
  - `[StorageProfileStorageAutogrow <StorageAutogrow?>]`: Enable Storage Auto Grow.
  - `[StorageProfileStorageMb <Int32?>]`: Max storage allowed for a server.
  - `[UserVisibleState <ServerState?>]`: A state of a server that is visible to user.
  - `[Version <ServerVersion?>]`: Server version.

## RELATED LINKS

