### Example 1: Lists all batch inference endpoint under workspace
```powershell
Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ---- -----------------
eastus   batch-pwsh03 5/20/2022 7:21:12 AM UserName (Example)                  5/20/2022 7:31:17 AM                                                                                        ml-rg-test
eastus   batch-pwsh02 5/20/2022 7:17:33 AM UserName (Example)                  5/20/2022 7:20:02 AM                                                                                        ml-rg-test
eastus   batch-cli01  5/20/2022 7:11:11 AM UserName (Example)                  5/20/2022 7:11:32 AM                                                                                        ml-rg-test
```

Lists all batch inference endpoint under workspace

### Example 2: Gets a batch inference endpoint by name
```powershell
Get-AzMLWorkspaceBatchEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name batch-pwsh03
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ---- -----------------
eastus   batch-pwsh03 5/20/2022 7:21:12 AM UserName (Example)                  5/20/2022 7:31:17 AM                                                                                        ml-rg-test
```

Gets a batch inference endpoint by name
