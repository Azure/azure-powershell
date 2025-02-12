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
