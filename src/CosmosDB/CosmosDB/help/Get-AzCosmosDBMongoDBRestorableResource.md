---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version:
schema: 2.0.0
---

# Get-AzCosmosDBMongoDBRestorableResource

## SYNOPSIS
Lists all the restorable Azure Cosmos DB MongoDB resources available for a specific database account at a given time and location.

## SYNTAX

```
Get-AzCosmosDBMongoDBRestorableResource -LocationName <String> -DatabaseAccountInstanceId <String>
 -RestoreTimestampInUtc <DateTimeOffset> -RestoreLocation <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all the restorable Azure Cosmos DB MongoDB resources available for a specific database account at a given time and location.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzCosmosDBMongoDBRestorableResource -LocationName {locationName} -DatabaseAccountInstanceId {DatabaseInstanceId} -RestoreLocation {Database} -RestoreTimestampInUtc {RestoreTimestamp}

DatabaseName CollectionNames
------------ ---------------
{DBName}     {Collection names}
```

Returns the list of all restorable Azure Cosmos DB MongoDB resources available for a specific database account at a given time and location.

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.
(This is returned as a part of database account properties).

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationName
Name of the Location in string.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreLocation
The location of the source account from which restore is triggered.
This will also be the write region of the restored account

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreTimestampInUtc
The timestamp to which the source account has to be restored to.

```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseToRestore

## NOTES

## RELATED LINKS
