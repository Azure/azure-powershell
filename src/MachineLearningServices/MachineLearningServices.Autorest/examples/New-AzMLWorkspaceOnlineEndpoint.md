### Example 1: Create or update Online Endpoint (asynchronous)
```powershell
New-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-cli01 -Location eastus -AuthMode 'Key' -IdentityType 'SystemAssigned'
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   online-cli01 5/19/2022 2:47:34 AM UserName (Example)                  5/19/2022 2:48:26 AM                                                                                   Managed ml-rg-test
```

Create or update Online Endpoint (asynchronous)
