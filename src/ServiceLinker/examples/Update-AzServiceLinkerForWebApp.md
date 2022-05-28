### Example 1: Update linker
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14/resourceGroups/servicelinker-test-linux-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test
$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name username -SecretValue password 
Update-AzServiceLinkerForWebApp -ResourceGroupName servicelinker-test-linux-group -WebApp servicelinker-app -TargetService $target -AuthInfo $authInfo -ClientType 'none' -Name postgres_connection
```

```output
Name
----
postgres_connection
```

Update linker

