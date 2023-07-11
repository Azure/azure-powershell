### Example 1: Get Spring Cloud Service by name
```powershell
Get-AzSpring -ResourceGroupName Springrg -Name spring-portal02
```

```output
Location Name            SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----            -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   spring-portal02 7/21/2022 3:02:40 AM v-diya@microsoft.com User                    7/21/2022 3:02:40 AM     v-diya@microsoft.com     User                         Springrg                                  : Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20190501Preview.Error
```

Get Spring Cloud Service by name.

### Example 2: List all the spring cloud service under the resource group
```powershell
Get-AzSpring -ResourceGroupName spring-cloud-rg
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

List all the spring cloud service under the resource group.

### Example 3: List all the spring cloud service under the subscription
```powershell
Get-AzSpring
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

List all the spring cloud service under the subscription.

### Example 4: Get Spring Cloud Service by pipeline
```powershell
New-AzSpring -ResourceGroupName Springrg -Name spring-pwsh01 -Location eastus | Get-AzSpring
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

Get Spring Cloud Service by pipeline.