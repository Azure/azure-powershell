---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbsqldatabaseperpartitionthroughput
schema: 2.0.0
---

# Update-AzCosmosDBSqlDatabasePerPartitionThroughput

## SYNOPSIS
Updates the throughput of selected partitions in a CosmosDB Sql database.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDBSqlDatabasePerPartitionThroughput -ResourceGroupName <String> -DatabaseName <String>
 [-SourcePhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>]
 [-TargetPhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>] [-EqualDistributionPolicy]
 [-DefaultProfile <IAzureContextContainer>] -AccountName <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBSqlDatabasePerPartitionThroughput -InputObject <PSSqlDatabaseGetResults>
 [-SourcePhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>]
 [-TargetPhysicalPartitionThroughputObject <PSPhysicalPartitionThroughputInfo[]>] [-EqualDistributionPolicy]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to redistribute the throughput across partitions in a CosmosDB Sql database.

## EXAMPLES

### Example 1
```powershell
$partitions = Get-AzCosmosDBSqlDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -AllPartitions
      $sources = @()
      $targets = @()
      $oldPartitions = @()
      for($i = 0; $i -lt $partitions.Count; $i++)
      {
          if($i -lt 2)
          {
            $throughput = $partitions[$i].Throughput - 100
            $sources += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partitions[$i].Id -Throughput $throughput
          }
          else
          {
              $throughput = $partitions[$i].Throughput + 100
              $targets += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partitions[$i].Id -Throughput $throughput
          }
          $oldPartitions += $partitions[$i]
      }
      
      $newPartitions = Update-AzCosmosDBSqlDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -SourcePhysicalPartitionThroughputObject $sources -TargetPhysicalPartitionThroughputObject $targets

      $resetPartitions = Update-AzCosmosDBSqlDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -EqualDistributionPolicy

      $somePartitions = Get-AzCosmosDBSqlDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -PhysicalPartitionIds ($oldPartitions[0].Id, $oldPartitions[1].Id)
```

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -DatabaseName
Database name.

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

### -EqualDistributionPolicy
Set this switch to reset the throughput layout for all partitions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Sql Database object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

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

### -SourcePhysicalPartitionThroughputObject
Source physical partitions

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetPhysicalPartitionThroughputObject
Target physical partitions

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSPhysicalPartitionThroughputInfo

## NOTES

## RELATED LINKS
