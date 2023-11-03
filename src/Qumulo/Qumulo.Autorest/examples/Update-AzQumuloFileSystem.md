### Example 1: Update tags with specific name and group
```powershell
Update-AzQumuloFileSystem -ResourceGroupName ps-joyer-test -Name qumulo-resource-01 -Tag @{"123"="abc"}
```

```output
Location Name               SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGrou
                                                                                                                                                                             pName
-------- ----               ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ------------
eastus   qumulo-resource-01 6/8/2023 9:49:18 AM user@organization.com User                    6/21/2023 6:27:53 AM     user@organization.com    User                         ps-joyer-te…
```

Update tags with specific name and group