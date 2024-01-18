### Example 1: Create monitoring account destination object
```powershell
New-AzMonitoringAccountDestinationObject -AccountResourceId /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/mac-rg/providers/Microsoft.Monitor/accounts/mac-name1 -Name myMonitoringAccountDest1
```

```output
AccountId AccountResourceId                                                                                                        Name
--------- -----------------                                                                                                        ----
          /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/mac-rg/providers/Microsoft.Monitor/accounts/mac-name1 myMonitoringAccountDest1
```

This command creates a monitoring account destination object.
