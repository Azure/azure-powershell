### Example 1: Create a purview account
```powershell
New-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg -Location eastus -IdentityType SystemAssigned -SkuCapacity 4 -SkuName Standard
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name    SystemDataCreatedAt  SystemDataCreatedBy    
-------------------                  ----------------                     ------------   -------- ----    -------------------  ----------- 
xxxxxxxx-9e08-4873-8b0d-1442be9e5b14 54826b22-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus  test-pa 8/17/2021 7:47:10 AM xxx.xxx…
```

Create a purview account named 'test-pa'.

