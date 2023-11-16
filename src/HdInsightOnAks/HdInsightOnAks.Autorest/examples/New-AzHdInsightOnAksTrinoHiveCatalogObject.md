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
