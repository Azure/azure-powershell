---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Invoke-AzureRmSqlSyncSchemaRefresh

## SYNOPSIS
Invoke the sync schema refresh for a sync member database or a sync hub database.

## SYNTAX

```
Invoke-AzureRmSqlSyncSchemaRefresh -SyncGroupName <String> [-SyncMemberName <String>] [-ServerName] <String>
 [-DatabaseName] <String> [-ResourceGroupName] <String>
```

## DESCRIPTION
The **Invoke-AzureRmSqlSyncSchemaRefresh** cmdlet invokes the sync schema refresh for a sync member database or a sync hub database.

## EXAMPLES

### Example 1: Invoke the sync schema refresh for a hub database
```
PS C:\>Invoke-AzureRmSqlSyncSchemaRefresh -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "database01" -SyncGroupName "syncGroup01"
```

This command invokes the sync schema refresh for the hub database in the sync group syncGroup01


### Example 2: Invoke the sync schema refresh for a member database
```
PS C:\>Invoke-AzureRmSqlSyncSchemaRefresh -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "database01" -SyncGroupName "syncGroup01" -SyncMemberName "syncMember01"
```

This command invokes the sync schema refresh for the member database in the sync member syncMember01

## PARAMETERS

### -DatabaseName
SQL Database name.

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
SQL Database server name.

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

Required: False
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

