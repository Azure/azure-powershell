### Example 1: Regenerate key of an app configuration store
```powershell
$keys = Get-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp
New-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp -Id $keys[0].id
```

```output
ConnectionString                                                                                                                      LastModified           Name    ReadOnly ResourceGroupName Value
----------------                                                                                                                      ------------           ----    -------- ----------------- -----
Endpoint=https://azpstest-appstore.azconfig.io;Id=m6TW-l0-s0:g302jTPLEpvmI0AahitF;Secret=vt5aKm6ezq2iVKNjQo+dQpA8QyuH1UhH9Jv8N3jfZdE= 2022-08-24 AM 06:13:21 Primary False                      vt5aKm6ezq2iV…
```

This command regenerate key of an app configuration store.