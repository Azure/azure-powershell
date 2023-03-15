---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbtablerestorabletable
schema: 2.0.0
---

# Get-AzCosmosDBTableRestorableTable

## SYNOPSIS
Lists all the restorable Azure Cosmos DB Tables available for a specific database.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBTableRestorableTable -Location <String> -DatabaseAccountInstanceId <String> [-StartTime <String>]
 [-EndTime <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBTableRestorableTable -InputObject <PSRestorableTableGetResult>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Lists all the restorable Azure Cosmos DB Tables available for a specific database account.
The list would have entries corresponding to create, replace and delete events of all live and deleted tables under a specific database account.
This list is useful to identify the restore timestamp based on the changes in the collection.
For example, if user wants to restore the database account to a timestamp when a specific table is deleted, the user can find corresponding table delete event from this list, and choose a timestamp before the delete event for restore.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBTableRestorableTable -Location "location" -DatabaseAccountInstanceId "DatabaseAccountInstanceId" -StartTime "StartTime" -EndTime "EndTime"
```

```output
Id              : /subscriptions/23587e98-b6ac-4328-a753-03bcd3c8e744/providers/Microsoft.DocumentDB/locations/East%20US2%20EUAP/restorableDatabaseAccounts/45221949-3b3b-457a-b23c-2562858de5a8/restorab
                  leTables/768c880d-082a-4414-9095-33eb612de58e
Name            : 768c880d-082a-4414-9095-33eb612de58e
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableTables
_rid            : QEE+IAAAAA==
OperationType   : Create
EventTimestamp  : 01/27/2022 02:08:02
OwnerId         : table1
OwnerResourceId : F45qAKUxkWc=

Id              : /subscriptions/23587e98-b6ac-4328-a753-03bcd3c8e744/providers/Microsoft.DocumentDB/locations/East%20US2%20EUAP/restorableDatabaseAccounts/45221949-3b3b-457a-b23c-2562858de5a8/restorab
                  leTables/6af230dc-dd95-4a36-97b9-5c7071d40fef
Name            : 6af230dc-dd95-4a36-97b9-5c7071d40fef
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableTables
_rid            : s74kawAAAA==
OperationType   : Create
EventTimestamp  : 01/27/2022 02:08:34
OwnerId         : table2
OwnerResourceId : F45qAJxEhOM=
```

The resource object contains the properties of the table resource.

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.
(This is returned as a part of database account properties).

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
Restorable Tables event feed end time.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
CosmosDB Restorable Table object.

```yaml
Type: Microsoft.Azure.Management.CosmosDB.Models.PSRestorableTableGetResult
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the Location in string.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Restorable Tables event feed start time.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableTableGetResult

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableTableGetResult

## NOTES

## RELATED LINKS
