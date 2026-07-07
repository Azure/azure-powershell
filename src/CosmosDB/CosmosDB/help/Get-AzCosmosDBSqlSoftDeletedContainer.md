---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbsqlsoftdeletedcontainer
schema: 2.0.0
---

# Get-AzCosmosDBSqlSoftDeletedContainer

## SYNOPSIS
Gets soft-deleted SQL containers in a CosmosDB SQL database.

## SYNTAX

```
Get-AzCosmosDBSqlSoftDeletedContainer -ResourceGroupName <String> -AccountName <String> -Location <String>
 -DatabaseName <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBSqlSoftDeletedContainer** cmdlet lists all soft-deleted SQL containers in the specified CosmosDB SQL database, or gets a specific soft-deleted container by name.

## EXAMPLES

### Example 1: List all soft-deleted SQL containers
```powershell
Get-AzCosmosDBSqlSoftDeletedContainer -ResourceGroupName "myResourceGroup" -AccountName "myCosmosAccount" -Location "West US 2" -DatabaseName "myDatabase"
```

Lists all soft-deleted SQL containers in the specified database.

### Example 2: Get a specific soft-deleted SQL container
```powershell
Get-AzCosmosDBSqlSoftDeletedContainer -ResourceGroupName "myResourceGroup" -AccountName "myCosmosAccount" -Location "West US 2" -DatabaseName "myDatabase" -Name "myDeletedContainer"
```

Gets the soft-deleted SQL container with the specified name.

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -DatabaseName
Database name.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the soft-deleted Cosmos DB database account.

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

### -Name
Name of the soft-deleted SQL container.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSSoftDeletedSqlContainerGetResult

## NOTES

## RELATED LINKS
