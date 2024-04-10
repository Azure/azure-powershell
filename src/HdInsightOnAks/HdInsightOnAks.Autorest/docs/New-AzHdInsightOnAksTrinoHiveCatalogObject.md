---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksTrinoHiveCatalogObject
schema: 2.0.0
---

# New-AzHdInsightOnAksTrinoHiveCatalogObject

## SYNOPSIS
Create a hive catalog configured as a Trino cluster.

## SYNTAX

```
New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName <String> -MetastoreDbConnectionPasswordSecret <String>
 -MetastoreDbConnectionUrl <String> -MetastoreDbConnectionUserName <String> [-MetastoreWarehouseDir <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a hive catalog configured as a Trino cluster.

## EXAMPLES

### Example 1: Create a hive catalog configured as a Trino cluster.
```powershell
$catalogName="{your catalog name}"
$metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=truetrustServerCertificate=true;loginTimeout=30;"
$metastoreDbUserName="{your db user name}"
$metastoreDbPasswordSecret="{secretName}"
$metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}"

New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret
```

```output
CatalogName         MetastoreDbConnectionPasswordSecret MetastoreDbConnectionUrl
-----------         ----------------------------------- ------------------------
{your catalog name} {secretName}                        jdbc:sqlserver://{your sql server url};database={your db name};encrypt=truet…
```

Create a hive catalog configured as a Trino cluster.

## PARAMETERS

### -CatalogName
Name of trino catalog which should use specified hive metastore.

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

### -MetastoreDbConnectionPasswordSecret
Password secret for hive metastore database.

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

### -MetastoreDbConnectionUrl
Connection string for hive metastore database.

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

### -MetastoreDbConnectionUserName
User name for hive metastore database.

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

### -MetastoreWarehouseDir
Warehouse directory for hive metastore database.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHiveCatalogOption

## NOTES

## RELATED LINKS

