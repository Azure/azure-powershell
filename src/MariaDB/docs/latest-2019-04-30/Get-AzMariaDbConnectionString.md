---
external help file:
Module Name: Az.MariaDb
online version: https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadbconnectionstring
schema: 2.0.0
---

# Get-AzMariaDbConnectionString

## SYNOPSIS


## SYNTAX

### ServerName (Default)
```
Get-AzMariaDbConnectionString -Client <String> -Name <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ServerObject
```
Get-AzMariaDbConnectionString -Client <String> -InputObject <IServer> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION


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

### -Client


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

### -DefaultProfile


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

### -InputObject
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer
Parameter Sets: ServerObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name


```yaml
Type: System.String
Parameter Sets: ServerName
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName


```yaml
Type: System.String
Parameter Sets: ServerName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer

## OUTPUTS

### System.String

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IServer>: 
  - `Location <String>`: The location the resource resides in.
  - `[Tag <ITrackedResourceTags>]`: Application-specific metadata in the form of key-value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AdministratorLogin <String>]`: The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).
  - `[EarliestRestoreDate <DateTime?>]`: Earliest restore point creation time (ISO8601 format)
  - `[FullyQualifiedDomainName <String>]`: The fully qualified domain name of a server.
  - `[MasterServerId <String>]`: The master server id of a replica server.
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

