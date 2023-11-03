### Example 1: Updates properties of a compute
```powershell
Update-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name aml02 -MaxNodeCount 8
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation Location ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ------------------- -------- -----------------
cpu-cluster                                                                                                                                                                    eastus   ml-rg-test
```

Updates properties of a compute

### Example 2: Updates properties of a compute by pipeline
```powershell
Get-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name aml02 | Update-AzMLWorkspaceCompute -MaxNodeCount 8
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType AzureAsyncOperation Location ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ------------------- -------- -----------------
cpu-cluster                                                                                                                                                                    eastus   ml-rg-test
```

Updates properties of a compute by pipeline
