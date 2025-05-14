---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonakstrinohivecatalogobject
schema: 2.0.0
---

# New-AzHdInsightOnAksTrinoHiveCatalogObject

## SYNOPSIS
Create an in-memory object for HiveCatalogOption.

## SYNTAX

```
New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName <String> -MetastoreDbConnectionUrl <String>
 -MetastoreWarehouseDir <String> [-MetastoreDbConnectionAuthenticationMode <String>]
 [-MetastoreDbConnectionPasswordSecret <String>] [-MetastoreDbConnectionUserName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HiveCatalogOption.

## EXAMPLES

### Example 1: Create a hive catalog configured as a Trino cluster.
```powershell
$catalogName="{your catalog name}"
$metastoreDbConnectionURL="jdbc:sqlserver://{your sql server url};database={your db name};encrypt=truetrustServerCertificate=true;loginTimeout=30;"
$metastoreDbUserName="{your db user name}"
$metastoreDbPasswordSecret="{secretName}"
$metastoreWarehouseDir="abfs://{your container name}@{your adls gen2 endpoint}/{your path}"

New-AzHdInsightOnAksTrinoHiveCatalogObject -CatalogName $catalogName -MetastoreDbConnectionUrl $metastoreDbConnectionURL -MetastoreDbConnectionUserName $metastoreDbUserName -MetastoreDbConnectionPasswordSecret $metastoreDbPasswordSecret -MetastoreWarehouseDir $metastoreWarehouseDir
```

```output
CatalogName                             : {your catalog name}
MetastoreDbConnectionAuthenticationMode : 
MetastoreDbConnectionPasswordSecret     : {secretName}
MetastoreDbConnectionUrl                : jdbc:sqlserver://{your sql server url};database={your db name};encrypt=truetrustServerCertificate=true;loginTimeout=30;
MetastoreDbConnectionUserName           : {your db user name}
MetastoreWarehouseDir                   : abfs://{your container name}@{your adls gen2 endpoint}/{your path}
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

### -MetastoreDbConnectionAuthenticationMode
The authentication mode to connect to your Hive metastore database.
More details: https://learn.microsoft.com/en-us/azure/azure-sql/database/logins-create-manage?view=azuresql#authentication-and-authorization.

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

### -MetastoreDbConnectionPasswordSecret
Secret reference name from secretsProfile.secrets containing password for database connection.

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
User name for database connection.

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

### -MetastoreWarehouseDir
Metastore root directory URI, format: abfs[s]://\<container\>@\<account_name\>.dfs.core.windows.net/\<path\>.
More details: https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-introduction-abfs-uri.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.HiveCatalogOption

## NOTES

## RELATED LINKS

