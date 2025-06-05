### Example 1: Upload storage file to domain list
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Upload" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

```output
Location Name                     Type                                  Etag
-------- ----                     ----                                  ----
westus2  exampleDomainListName    Microsoft.Network/dnsResolverPolicies "00008cd5-0000-0800-0000-604016c90000"
```

This command runs the POST on the domain list to upload the domains from a storage url with sas token.

### Example 2: Download domain list domains to storage file
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Download" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

```output
Location Name                     Type                                  Etag
-------- ----                     ----                                  ----
westus2  exampleDomainListName    Microsoft.Network/dnsResolverPolicies "00008cd5-0000-0800-0000-604016c90000"
```

This command runs the POST on the domain list to download the domains to a storage url with sas token. 

