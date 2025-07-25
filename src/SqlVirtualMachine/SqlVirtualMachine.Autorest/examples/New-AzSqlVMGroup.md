### Example
```powershell
# $accessKey is a valid access key for the storage account
$storageAccountPrimaryKey = ConvertTo-SecureString -String $accessKey -AsPlainText -Force
New-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01' -Location 'eastus' -Offer 'SQL2022-WS2022' -Sku 'Developer' -DomainFqdn 'yourdomain.com' -ClusterOperatorAccount 'operatoruser@yourdomain.com' -ClusterBootstrapAccount 'bootstrapuser@yourdomain.com' -StorageAccountUrl 'https://yourstorageaccount.blob.core.windows.net/' -StorageAccountPrimaryKey $storageAccountPrimaryKey -SqlServiceAccount 'sqladmin@yourdomain.com' -ClusterSubnetType 'SingleSubnet'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
```

Creates a Azure SQL virtual machine group "sqlvmgroup01" in the resource group "ResourceGroup01".

