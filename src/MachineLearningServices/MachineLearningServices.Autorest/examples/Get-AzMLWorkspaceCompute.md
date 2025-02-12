### Example 1: Lists all computes under a workspace
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----          ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
cpu-cluster                                                                                                                                                  eastus   ml-rg-test
gpu-cluster                                                                                                                                                  eastus   ml-rg-test
batch-cluster                                                                                                                                                eastus   ml-rg-test
```

Lists all computes under a workspace

### Example 2: Gets a compute by name
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name cpu-cluster
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
cpu-cluster                                                                                                                                                eastus   ml-rg-test
```

Gets a compute by name

