### Example 1: List Broker Listeners
```powershell
Get-AzIoTOperationsServiceBrokerListener -BrokerName "default" -InstanceName "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
Name          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMod
                                                                                                                        ifiedBy
----          ------------------- -------------------                  ----------------------- ------------------------ -----------------
default       3/5/2025 5:08:41 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:29:55 PM      319f651f-7ddb-4f…
test-listener 3/5/2025 5:17:15 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:29:55 PM      319f651f-7ddb-4f…

```

This command gets a list of broker listeners
