### Example 1: Update linker
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14/resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test
$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name username -SecretValue password 
Update-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group  -TargetService $target -AuthInfo $authInfo -ClientType 'none' -Name postgres_connection
```

```output
Name
----
postgres_connection
```

Update linker

