### Example 1: Gets code version
```powershell
Get-AzMLWorkspaceCodeVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name 'codepwsh01' -Version 1
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/24/2022 7:14:05 AM Lucas Yao (Wicresoft North America) User                    5/24/2022 7:14:05 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Gets code version.

