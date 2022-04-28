### Example 1: Create target service object of Azure resource
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test

$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name testUser -SecretValue ***  

New-AzServiceLinkerForWebapp -TargetService $target -AuthInfo $auth -ClientType dotnet -LinkerName testLinker -Webapp servicelinker-portal-e2e -ResourceGroupName servicelinker-test-linux-group


```

```output
Name
----
testLinker
```

Create target service object of Azure resource

