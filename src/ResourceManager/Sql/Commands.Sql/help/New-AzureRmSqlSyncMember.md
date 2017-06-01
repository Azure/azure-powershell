---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmSqlSyncMember

## SYNOPSIS
Creates an Azure SQL Database Sync Member.


## SYNTAX

### AzureSql (Default)
```
New-AzureRmSqlSyncMember -SyncMemberName <String> -DatabaseType <String> [-SyncDirection <String>]
 -MemberServerName <String> -MemberDatabaseName <String> -Credential <PSCredential> -SyncGroupName <String>
 [-ServerName] <String> [-DatabaseName] <String> [-ResourceGroupName] <String>
```

### OnPremise
```
New-AzureRmSqlSyncMember -SyncMemberName <String> -DatabaseType <String> [-SyncDirection <String>]
 -SyncAgentResourceGroupName <String> -SyncAgentServerName <String> -SyncAgentName <String>
 -SqlServerDatabaseId <String> -SyncGroupName <String> [-ServerName] <String> [-DatabaseName] <String>
 [-ResourceGroupName] <String>
```

## DESCRIPTION
The **New-AzureRmSqlSyncMember** cmdlet creates an Azure SQL Database Sync Member.

## EXAMPLES

### Example 1: Create a sync member for an Azure SQL database.
```
PS C:\> $credential = Get-Credential
PS C:\> New-AzureRmSqlSyncMember -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -SyncGroupName "SyncGroup01" -SyncMemberName "SyncMember01" -SyncDirection "OneWayMemberToHub"
-DatabaseType "AzureSqlDatabase" -MemberServerName "memberServer01.full.dns.name" -MemberDatabaseName "memberDatabase01" -Credential $credential
ResourceId                  : subscriptions/{subscriptionId}/resourceGroups/{ResourceGroup01}/servers/{Server01}/databases/{Database01}/syncGroups/{SyncGroup01}/syncMembers/{SyncMember01}
ResourceGroupName           : ResourceGroup01
ServerName                  : Server01
DatabaseName                : Database01
SyncGroupName               : SyncGroup01
SyncMemberName              : SyncMember01
SyncDirection               : OneWayMemberToHub
DatabaseType:               : AzureSqlDatabase
SyncAgentId                 : 
SqlServerDatabaseId         : 
MemberServerName            : memberServer01.full.dns.name
MemberDatabaseName          : memberDatabase01
UserName                    : myAccount
Password                    : 
SyncState                   : UnProvisioned 
```

This command creates a sync member for an Azure SQL database.

### Example 2: Create a sync member for an on-premises SQL Server database
```
PS C:\> $credential = Get-Credential
PS C:\> New-AzureRmSqlSyncMember -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01" -SyncGroupName "SyncGroup01" -SyncMemberName "SyncMember01" -SyncDirection "OneWayMemberToHub"
-DatabaseType "SqlServerDatabase" -SqlServerDatabaseId "dbId" -syncAgentResourceGroupName "syncAgentResourceGroupName" -syncAgentServerName "syncAgentServerName" -syncAgentDatabaseName "syncAgentDatabaseName" -syncAgentName "agentName"
ResourceId                  : /subscriptions/{subscriptionId}/resourceGroups/{ResourceGroup01}/servers/{Server01}/databases/{Database01}/syncGroups/{SyncGroup01}/syncMembers/{SyncMember01}
ResourceGroupName           : ResourceGroup01
ServerName                  : Server01
DatabaseName                : Database01
SyncGroupName               : SyncGroup01
SyncMemberName              : SyncMember01
SyncDirection               : OneWayMemberToHub
DatabaseType:               : AzureSqlDatabase
SyncAgentId                 : /subscriptions/{subscriptionId}/resourceGroups/{syncAgentResourceGroupName}/servers/{syncAgentServerName}/syncAgents/{syncAgentId}
SqlServerDatabaseId         : dbId
MemberServerName            : 
MemberDatabaseName          : 
UserName                    : 
Password                    : 
SyncState                   : UnProvisioned 
```

This command creates a sync member for an on-premises SQL database.

## PARAMETERS

### -Credential
The credential (username and password) of the Azure SQL database.

```yaml
Type: PSCredential
Parameter Sets: AzureSql
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the Azure SQL Database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseType
The database type.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: SqlServerDatabase, AzureSqlDatabase

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MemberDatabaseName
The Azure SQL Database name of the member database.

```yaml
Type: String
Parameter Sets: AzureSql
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberServerName
The Azure SQL Server Name of the member database.

```yaml
Type: String
Parameter Sets: AzureSql
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL server.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SqlServerDatabaseId
The id of the SQL server database which is connected by the sync agent.

```yaml
Type: String
Parameter Sets: OnPremise
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncAgentName
The name of the sync agent.

```yaml
Type: String
Parameter Sets: OnPremise
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncAgentResourceGroupName
The name of the resource group where the sync agent is under.

```yaml
Type: String
Parameter Sets: OnPremise
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncAgentServerName
The name of Azure SQL server where the sync agent is under.

```yaml
Type: String
Parameter Sets: OnPremise
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncDirection
The sync direction of this sync member.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Bidirectional, OneWayMemberToHub, OneWayHubToMember

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncGroupName
The sync group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SyncMemberName
The sync member name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

