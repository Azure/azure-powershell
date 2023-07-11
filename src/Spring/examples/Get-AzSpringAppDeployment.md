### Example 1: Get Spring Cloud App Deploymeng by name
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         Springrg
```

Get Spring Cloud App Deploymeng by name.

### Example 2: List all the deployment under a given spring cloud app
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         Springrg
```

List all the deployment under a given spring cloud app.

### Example 3: List all the deployment under a given subscription
```powershell
Get-AzSpringAppDeployment -ResourceGroupName 'Springrg' -ServiceName 'standardspring-demo'
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         Springrg
```

List all the deployment under a given subscription.
