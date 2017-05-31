---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSqlSyncSchema

## SYNOPSIS
Returns information about the sync schema of a member database or a hub database.

## SYNTAX

```
Get-AzureRmSqlSyncSchema -SyncGroupName <String> [-SyncMemberName <String>] [-ServerName] <String>
 [-DatabaseName] <String> [-ResourceGroupName] <String>
```

## DESCRIPTION
The **Get-AzureRmSqlSyncSchema** cmdlet returns information about the sync schema of a member database or a hub database.

## EXAMPLES

### Example 1: Get the sync schema for a hub database
```
PS C:\>Get-AzureRmSqlSyncSchema -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "database01" -SyncGroupName "syncGroup01"
LastUpdateTime       : 2016-06-01T09:08:36.164217Z
Tables {
[{  ErrorId          : 
    HasError         : false
    Name             : table1
    QuotedName       : [dbo].[table1]
    Columns          : 
    {[{  DataSize    : 100
         DataType    : String
         ErrorId     ： 
         HasError    ： false
         IsPrimaryKey： true
         Name        : column1
         QuotedName  : [dbo].[column1]
    }]},
}]
```

This command gets the sync schema for the hub database in the sync group syncGroup01.


### Example 2: Get the sync schema for a member database
```
PS C:\>Get-AzureRmSqlSyncSchema -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "database01" -SyncGroupName "syncGroup01" -SyncMemberName "syncMember01"
The schema payload is the same as Example 1.
```
This command gets the sync schema for the member database in the sync member syncMember01.


## PARAMETERS

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

