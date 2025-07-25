### Example 1: Lists all online deployments under a online endpoint
```powershell
Get-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01
```

```output
Location Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   blue 5/19/2022 2:52:06 AM UserName (Example)                  5/19/2022 2:52:06 AM                                                                                   Managed ml-rg-test
```

Lists all online deployments under a online endpoint

### Example 2: Gets online deployment by name
```powershell
Get-AzMLWorkspaceOnlineDeployment -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -EndpointName online-cli01 -Name blue
```

```output
Location Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   blue 5/19/2022 2:52:06 AM UserName (Example)                  5/19/2022 2:52:06 AM                                                                                   Managed ml-rg-test
```

Gets online deployment by name

