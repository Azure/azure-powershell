### Example 1: Create or update model container
```powershell
New-AzMLWorkspaceModelContainer -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01 -Description "code container for test."
```

```output
Name                 SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                 ------------------- -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
modelcontainerpwsh01 6/1/2022 4:04:12 PM Lucas Yao (Wicresoft North America) User                    6/1/2022 4:04:12 PM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Create or update model container
