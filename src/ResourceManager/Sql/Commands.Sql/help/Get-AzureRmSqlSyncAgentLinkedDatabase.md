---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSqlSyncAgentLinkedDatabase

## SYNOPSIS
Returns information about SQL Server databases linked by a sync agent.

## SYNTAX

```
Get-AzureRmSqlSyncAgentLinkedDatabase [-ServerName] <String> [-SyncAgentName] <String>
 [-ResourceGroupName] <String>
```

## DESCRIPTION
The **Get-AzureRmSqlSyncAgentLinkedDatabases** cmdlet returns information about SQL Server databases linked by a sync agent.

## EXAMPLES

### Example 1: Get the linked SQL Server databases for an Azure SQL sync agent.
```
PS C:\> Get-AzureRmSqlSyncAgentLinkedDatabases -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -SyncAgentName "SyncAgent01" | Format-List
SeverName                 : sever01
DatabaseId                : databaseId
DatabaseName              : database01
DatabaseType              : SQLServerDatabase
Description               : 
UserName                  : myAccount
```

This command returns the linked SQL Server databases linked by an Azure SQL sync agent.


## PARAMETERS

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
The name of the Azure SQL Server the sync agent is in.

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

### -SyncAgentName
The sync agent name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```


## INPUTS

## OUTPUTS

###  Microsoft.Azure.Commands.Sql.DataSync.Model.AzureSqlSyncAgentLinkedDatabaseModel

## NOTES

## RELATED LINKS

