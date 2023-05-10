### Example 1: List all store keys of an app configuration store
```powershell
Get-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
ConnectionString                                                                                                                      LastModified           Name                ReadOnly ResourceGroupName Value
----------------                                                                                                                      ------------           ----                -------- ----------------- ---
Endpoint=https://azpstest-appstore.azconfig.io;Id=SXvQ-l0-s0:1EG/TDfXP30kHZoLxGxb;Secret=GknYAPIAFixLJw5wfGOGt0dgwj0hr2eGoRnusIgkNdc= 2022-08-24 AM 06:11:51 Secondary           False                       Gk…
Endpoint=https://azpstest-appstore.azconfig.io;Id=WCoZ-l0-s0:OY71pf8vbFCZTtDpuIfE;Secret=06+woMjMn4iQNhpvmpCuLQys0qjGXbal3UFgQxAipas= 2022-08-24 AM 06:11:51 Primary Read Only   True                        06…
Endpoint=https://azpstest-appstore.azconfig.io;Id=7sDt-l0-s0:1tEtn3TApcmgJjk0PlqM;Secret=jZDAxcgFtEhj5ug2VYjUvdImaHybGwRSvkq45dvnVFk= 2022-08-24 AM 06:11:51 Secondary Read Only True                        jZ…
Endpoint=https://azpstest-appstore.azconfig.io;Id=m6TW-l0-s0:g302jTPLEpvmI0AahitF;Secret=vt5aKm6ezq2iVKNjQo+dQpA8QyuH1UhH9Jv8N3jfZdE= 2022-08-24 AM 06:13:21 Primary             False                       vt…
```

This command lists all store keys of an app configuration store.