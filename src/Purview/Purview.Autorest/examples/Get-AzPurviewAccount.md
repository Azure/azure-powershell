### Example 1: List All Purview Accounts
```powershell
Get-AzPurviewAccount
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name          SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType 
-------------------                  ----------------                     ------------   -------- ----          -------------------  -------------------      -------- 
xxxxxxxx-a087-43aa-8a7f-c17a4bbd4d36 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   pvac          8/4/2021 8:34:28 AM  xxx@microsoft.com        User     
xxxxxxxx-bbe7-4506-a9c4-4d602d8e4e1c xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   purview-test  8/9/2021 9:38:47 AM  xxxxxxxxx@microsoft.com  User     
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa       8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User 
```

List all purview accounts.

### Example 2: Get Purview Account by Resource Group Name and Name
```powershell
Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 
```

Get the purview account name test-rg in resource group test-pa

### Example 3: List Purview Accounts in a Specified Resource Group 
```powershell
Get-AzPurviewAccount -ResourceGroupName test-rg
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 
```

List the purview accounts in resource group test-pa

### Example 4: Get Purview Account by InputObject
```powershell
$got = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
Get-AzADDomainService -InputObject $got
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 
```

Get the purview account by InputObject
