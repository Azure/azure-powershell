### Example 1: Bulk upload domains to a domain list from a storage blob
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Upload" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

This cmdlet bulk uploads domains from a storage blob to a DNS resolver domain list. The storage URL must include a valid SAS token with read permissions.

### Example 2: Bulk download domains from a domain list to a storage blob
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Download" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=w&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

This cmdlet bulk downloads domains from a DNS resolver domain list to a storage blob. The storage URL must include a valid SAS token with write permissions. This action is only supported for storage-based domain lists.
