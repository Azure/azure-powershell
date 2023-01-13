### Example 1: Create service linker between spring cloud app and postgresql
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test

$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name testUser -SecretValue ***  

New-AzServiceLinkerForSpringCloud -TargetService $target -AuthInfo $auth -ClientType dotnet -LinkerName testLinker -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group 


```

```output
Name
----
testLinker
```

Create service linker between spring cloud app and postgresql

