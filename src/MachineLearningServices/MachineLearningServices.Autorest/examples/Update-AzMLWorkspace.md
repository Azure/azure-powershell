### Example 1: Updates a machine learning workspace with the specified parameters
```powershell
Update-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlwork01 -Tag @{'key1' = 'value2'}
```

```output
Name     SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    Location ResourceGroupName     
----     ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----    -------- -----------------     
mlwork01 6/6/2024 9:40:20 AM user@example.com      User                    6/7/2024 3:57:23 AM      user@example.com         User                         Default eastus   ml-rg-test
```

This command updates a machine learning workspace with the specified parameters.

### Example 2: Updates a machine learning workspace with the specified parameters by pipeline
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlwork01 | Update-AzMLWorkspace -Tag @{'key1' = 'value2'}
```

```output
Name     SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    Location ResourceGroupName     
----     ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----    -------- -----------------     
mlwork01 6/6/2024 9:40:20 AM user@example.com      User                    6/7/2024 3:57:23 AM      user@example.com         User                         Default eastus   ml-rg-test
```

These commands update a machine learning workspace with the specified parameters by pipeline.

