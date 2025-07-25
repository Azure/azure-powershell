### Example 1: Update a batch inference endpoint (asynchronous)
```powershell
Update-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batchpwsh01-key -Tag @{'key'='value'}
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ---- -----------------
eastus   batch-pwsh03 5/20/2022 7:21:12 AM UserName (Example)                  5/20/2022 7:31:17 AM                                                                                        ml-rg-test
```

Update a batch inference endpoint (asynchronous)

### Example 2: Update a batch inference endpoint (asynchronous) by pipeline
```powershell
Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batchpwsh01-key | Update-AzMLWorkspaceBatchEndpoint -Tag @{'key'='value'}
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ---- -----------------
eastus   batch-pwsh03 5/20/2022 7:21:12 AM UserName (Example)                  5/20/2022 7:31:17 AM                                                                                        ml-rg-test
```

Update a batch inference endpoint (asynchronous) by pipeline

