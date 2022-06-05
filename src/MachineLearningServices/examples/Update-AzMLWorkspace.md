### Example 1: Updates a machine learning workspace with the specified parameters
```powershell
Update-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01 -Tag @{'key1' = 'value2'}
```

```output
Name              SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----              -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-pwsh01 5/18/2022 6:33:49 AM v-diya@microsoft.com User                    5/18/2022 6:33:49 AM     v-diya@microsoft.com     User                         eastus   ml-rg-test
```

Updates a machine learning workspace with the specified parameters

### Example 2: Updates a machine learning workspace with the specified parameters by pipeline
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01 | Update-AzMLWorkspace -Tag @{'key1' = 'value2'}
```

```output
Name              SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----              -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-pwsh01 5/18/2022 6:33:49 AM v-diya@microsoft.com User                    5/18/2022 6:33:49 AM     v-diya@microsoft.com     User                         eastus   ml-rg-test
```

Updates a machine learning workspace with the specified parameters by pipeline

