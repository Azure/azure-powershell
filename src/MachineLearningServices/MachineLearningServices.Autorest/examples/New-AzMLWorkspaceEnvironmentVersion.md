### Example 1: Creates or updates an EnvironmentVersion.
```powershell
New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv -Version 1 -Image "library/python:latest"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/31/2022 8:28:35 AM UserName (Example)                  User                    5/31/2022 8:28:35 AM     UserName (Example)                  User                         ml-rg-test
```

Creates or updates an EnvironmentVersion.

