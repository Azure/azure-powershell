---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmSqlSyncAgentKey

## SYNOPSIS
Creates an Azure SQL Sync Agent Key.

## SYNTAX

```
New-AzureRmSqlSyncAgentKey [-ServerName] <String> -SyncAgentName <String> [-ResourceGroupName] <String>
```

## DESCRIPTION
The **New-AzureRmSqlSyncAgentKey** cmdlet creates an Azure SQL Sync Agent key.

## EXAMPLES

### Example 1: Create a sync agent key for an Azure SQL sync agent.
```
PS C:\> New-AzureRmSqlSyncAgentKey -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -SyncAgentName "SyncAgent01"
SyncAgentKey                  : "Key"
```

This command creates a sync agent key for an Azure SQL Sync Agent.

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

