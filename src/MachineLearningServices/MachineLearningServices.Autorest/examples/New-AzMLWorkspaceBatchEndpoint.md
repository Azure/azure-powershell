### Example 1: Creates a batch inference endpoint (asynchronous)
```powershell
New-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batch-pwsh03 -AuthMode 'Key' -Location 'eastus'
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind ResourceGroupName
-------- ----         -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ---- -----------------
eastus   batch-pwsh03 5/20/2022 7:21:12 AM UserName (Example)  5/20/2022 7:31:17 AM                                                                                        ml-rg-test
```

Creates a batch inference endpoint (asynchronous)
