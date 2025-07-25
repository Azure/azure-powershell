### Example 1: Create service linker between container app and postgresql
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test

$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name testUser -SecretValue ***  

New-AzServiceLinkerForContainerApp -TargetService $target -AuthInfo $auth -ClientType dotnet -LinkerName testLinker -ContainerApp servicelinker-app -ResourceGroupName servicelinker-test-linux-group -Scope 'simple-hello-world-container'
```

```output
Name
----
testLinker
```

Create service linker between Container AppName and postgresql

