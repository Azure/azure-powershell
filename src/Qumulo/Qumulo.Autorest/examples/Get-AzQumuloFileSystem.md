### Example 1: List by subscription
```powershell
Get-AzQumuloFileSystem -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   fileSystem01       6/24/2023 5:22:01 AM user@organization.com User                    6/24/2023 5:22:01 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test      
eastus   qumulo-01          6/24/2023 5:27:12 AM user@organization.com User                    6/24/2023 5:27:12 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test      
eastus   qumulo-02          6/24/2023 5:31:50 AM user@organization.com User                    6/24/2023 5:31:50 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test
eastus   fileSystem         5/24/2023 7:10:01 AM user@organization.com User                    5/24/2023 7:19:16 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-02 5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Get list of file system resources by subscription

### Example 2: List by resource group
```powershell
Get-AzQumuloFileSystem -ResourceGroupName ps-joyer-test
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   fileSystem         5/24/2023 7:10:01 AM user@organization.com User                    5/24/2023 7:19:16 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-02 5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test 
```

Get list of file system resources by resource group

### Example 3: Get specific resource with specified resource group
```powershell
Get-AzQumuloFileSystem -ResourceGroupName azpstest-gp -Name fileSystem
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 9:58:45 AM     user@organization.com    User                         ps-joyer-test 
```

Get specific file system resource with specified resource group