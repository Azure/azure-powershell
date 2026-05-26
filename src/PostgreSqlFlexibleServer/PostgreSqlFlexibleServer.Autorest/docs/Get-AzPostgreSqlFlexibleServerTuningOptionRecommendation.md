---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservertuningoptionrecommendation
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation

## SYNOPSIS
Lists available object recommendations.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName <String> -ServerName <String>
 -TuningOption <String> [-SubscriptionId <String[]>] [-RecommendationType <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists available object recommendations.

## EXAMPLES

### Example 1: List all index recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption index
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
CreateIndex_postgres_public_l_partkey_l… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_partkey_l_shipinstruct_idx" ON… Column "lineitem"."l_partkey" appear in Join On clause(s) i…
CreateIndex_postgres_public_l_partkey_l… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_partkey_l_quantity_idx" ON "pu… Column "lineitem"."l_partkey" appear in Join On clause(s) i…
CreateIndex_postgres_public_o_orderdate… postgres             public               orders               CREATE INDEX CONCURRENTLY "o_orderdate_idx" ON "public"."or… Column "orders"."o_orderdate" appear in Non-Equal Predicate…
CreateIndex_postgres_public_l_orderkey_… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_orderkey_idx" ON "public"."lin… Column "lineitem"."l_orderkey" appear in Join On clause(s) …
CreateIndex_postgres_public_l_shipdate_… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_shipdate_l_quantity_idx" ON "p… Column "lineitem"."l_shipdate" appear in Non-Equal Predicat…
CreateIndex_tpch_public_l_receiptdate_i… tpch                 public               lineitem             CREATE INDEX CONCURRENTLY "l_receiptdate_idx" ON "public"."… Column "lineitem"."l_receiptdate" appear in Non-Equal Predi…
CreateIndex_tpch_public_o_orderkey_idx   tpch                 public               orders               CREATE INDEX CONCURRENTLY "o_orderkey_idx" ON "public"."ord… Column "orders"."o_orderkey" appear in Join On clause(s) in…
CreateIndex_tpch_public_ps_suppkey_idx   tpch                 public               partsupp             CREATE INDEX CONCURRENTLY "ps_suppkey_idx" ON "public"."par… Column "partsupp"."ps_suppkey" appear in Join On clause(s) …
CreateIndex_tpch_public_c_nationkey_c_m… tpch                 public               customer             CREATE INDEX CONCURRENTLY "c_nationkey_c_mktsegment_idx" ON… Column "customer"."c_nationkey" appear in Equal Predicate c…
DropIndex_duplicateIndexes_testdup_idx_… duplicateIndexes     testdup              address              DROP INDEX CONCURRENTLY "testdup"."idx_test_1_duplicate";    Duplicate of "address_pkey". The equivalent index "address_…
DropIndex_duplicateIndexes_testdup_idx_… duplicateIndexes     testdup              address              DROP INDEX CONCURRENTLY "testdup"."idx_test_2_duplicate";    Duplicate of "uc_address_country_id". The equivalent index …
DropIndex_duplicateIndexes_testdup2_dup… duplicateIndexes     testdup2             address              ALTER TABLE "testdup2"."address" DROP CONSTRAINT "duplicate… Duplicate of "address_pkey". The equivalent index "address_…
DropIndex_duplicateIndexes_testdup2_idx… duplicateIndexes     testdup2             address              DROP INDEX CONCURRENTLY "testdup2"."idx_test_2_address_dupl… Duplicate of "idx_test_2_address_duplicate_1". The equivale…
DropIndex_duplicateIndexes_invalididxte… duplicateIndexes     invalididxtests      table1               DROP INDEX CONCURRENTLY "invalididxtests"."idx_test_invalid… Duplicate of "idx_test_invalid_idx2". The equivalent index …
ReIndex_duplicateIndexes_invalididxtest… duplicateIndexes     invalididxtests      table1               REINDEX INDEX CONCURRENTLY "invalididxtests"."idx_test_inva… The index is invalid and the recommended recovery method is…
ReIndex_duplicateIndexes_invalididxtest… duplicateIndexes     invalididxtests      table1               REINDEX INDEX CONCURRENTLY "invalididxtests"."idx_test_inva… The index is invalid and the recommended recovery method is…
```

Lists all index recommendations in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.
It includes any existing recommendations of CreateIndex, DropIndex or ReIndex.

### Example 2: List all CreateIndex index recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption index -RecommendationType CreateIndex
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
CreateIndex_postgres_public_l_partkey_l… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_partkey_l_shipinstruct_idx" ON… Column "lineitem"."l_partkey" appear in Join On clause(s) i…
CreateIndex_postgres_public_l_partkey_l… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_partkey_l_quantity_idx" ON "pu… Column "lineitem"."l_partkey" appear in Join On clause(s) i…
CreateIndex_postgres_public_o_orderdate… postgres             public               orders               CREATE INDEX CONCURRENTLY "o_orderdate_idx" ON "public"."or… Column "orders"."o_orderdate" appear in Non-Equal Predicate…
CreateIndex_postgres_public_l_orderkey_… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_orderkey_idx" ON "public"."lin… Column "lineitem"."l_orderkey" appear in Join On clause(s) …
CreateIndex_postgres_public_l_shipdate_… postgres             public               lineitem             CREATE INDEX CONCURRENTLY "l_shipdate_l_quantity_idx" ON "p… Column "lineitem"."l_shipdate" appear in Non-Equal Predicat…
CreateIndex_tpch_public_l_receiptdate_i… tpch                 public               lineitem             CREATE INDEX CONCURRENTLY "l_receiptdate_idx" ON "public"."… Column "lineitem"."l_receiptdate" appear in Non-Equal Predi…
CreateIndex_tpch_public_o_orderkey_idx   tpch                 public               orders               CREATE INDEX CONCURRENTLY "o_orderkey_idx" ON "public"."ord… Column "orders"."o_orderkey" appear in Join On clause(s) in…
CreateIndex_tpch_public_ps_suppkey_idx   tpch                 public               partsupp             CREATE INDEX CONCURRENTLY "ps_suppkey_idx" ON "public"."par… Column "partsupp"."ps_suppkey" appear in Join On clause(s) …
CreateIndex_tpch_public_c_nationkey_c_m… tpch                 public               customer             CREATE INDEX CONCURRENTLY "c_nationkey_c_mktsegment_idx" ON… Column "customer"."c_nationkey" appear in Equal Predicate c…
```

Lists all index recommendations of CreateIndex type in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 3: List all DropIndex index recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption index -RecommendationType DropIndex
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
DropIndex_duplicateIndexes_testdup_idx_… duplicateIndexes     testdup              address              DROP INDEX CONCURRENTLY "testdup"."idx_test_1_duplicate";    Duplicate of "address_pkey". The equivalent index "address_…
DropIndex_duplicateIndexes_testdup_idx_… duplicateIndexes     testdup              address              DROP INDEX CONCURRENTLY "testdup"."idx_test_2_duplicate";    Duplicate of "uc_address_country_id". The equivalent index …
DropIndex_duplicateIndexes_testdup2_dup… duplicateIndexes     testdup2             address              ALTER TABLE "testdup2"."address" DROP CONSTRAINT "duplicate… Duplicate of "address_pkey". The equivalent index "address_…
DropIndex_duplicateIndexes_testdup2_idx… duplicateIndexes     testdup2             address              DROP INDEX CONCURRENTLY "testdup2"."idx_test_2_address_dupl… Duplicate of "idx_test_2_address_duplicate_1". The equivale…
DropIndex_duplicateIndexes_invalididxte… duplicateIndexes     invalididxtests      table1               DROP INDEX CONCURRENTLY "invalididxtests"."idx_test_invalid… Duplicate of "idx_test_invalid_idx2". The equivalent index …
```

Lists all index recommendations of DropIndex type in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 4: List all ReIndex index recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption index -RecommendationType ReIndex
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
ReIndex_duplicateIndexes_invalididxtest… duplicateIndexes     invalididxtests      table1               REINDEX INDEX CONCURRENTLY "invalididxtests"."idx_test_inva… The index is invalid and the recommended recovery method is…
ReIndex_duplicateIndexes_invalididxtest… duplicateIndexes     invalididxtests      table1               REINDEX INDEX CONCURRENTLY "invalididxtests"."idx_test_inva… The index is invalid and the recommended recovery method is…
```

Lists all index recommendations of DropIndex type in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 5: List all table recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption table
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
```

Lists all table recommendations in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.
It includes any existing recommendations of AnalyzeTable, or VacuumTable.

### Example 6: List all AnalyzeTable table recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption table -RecommendationType AnalyzeTable
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
```

Lists all table recommendations of AnalyzeTable type in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 7: List all VacuumTable table recommendations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -TuningOption table -RecommendationType VacuumTable
```

```output
Name                                     DetailDatabaseName   DetailSchema         DetailTable          ImplementationDetailScript                                   RecommendationReason
----                                     ------------------   ------------         -----------          --------------------------                                   --------------------
```

Lists all table recommendations of VacuumTable type in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecommendationType
Recommendations list filter.
Retrieves recommendations based on type.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TuningOption
The name of the tuning option.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendation

## NOTES

## RELATED LINKS

