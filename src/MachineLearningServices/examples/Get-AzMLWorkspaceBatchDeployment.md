### Example 1: Lists all batch inference deployment under a batch endpoint
```powershell
Get-AzMLWorkspaceBatchDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName batch-cli02
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation Kind ResourceGroupName
-------- ----        ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ------------------- ---- -----------------
eastus   nonmlflowdp 6/1/2022 6:19:16 AM Lucas Yao (Wicresoft North America)                         6/1/2022 6:19:16 AM                                                                                     ml-rg-test
```

Lists all batch inference deployment under a batch endpoint

### Example 2: Gets a batch inference deployment by Name
```powershell
Get-AzMLWorkspaceBatchDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName batch-cli02 -Name nonmlflowdp
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation Kind ResourceGroupName
-------- ----        ------------------- -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ------------------- ---- -----------------
eastus   nonmlflowdp 6/1/2022 6:19:16 AM Lucas Yao (Wicresoft North America)                         6/1/2022 6:19:16 AM                                                                                     ml-rg-test
```

Gets a batch inference deployment by Name

