### Example 1: create action group logic app receiver
```powershell
New-AzActionGroupLogicAppReceiverObject -CallbackUrl "https://prod-27.northcentralus.logic.azure.com/workflows/68e572e818e5457ba898763b7db90877/triggers/manual/paths/invoke/azns/test?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Abpsb72UYJxPPvmDo937uzofupO5r_vIeWEx7KVHo7w" -Name "sample logic app" -ResourceId "/subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/LogicApp/providers/Microsoft.Logic/workflows/testLogicApp"
```

```output
CallbackUrl                                                                                                                                                                                                                                  Name             ResourceId
-----------                                                                                                                                                                                                                                  ----             ----------
https://prod-27.northcentralus.logic.azure.com/workflows/68e572e818e5457ba898763b7db90877/triggers/manual/paths/invoke/azns/test?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Abpsb72UYJxPPvmDo937uzofupO5r_vIeWEx7KVHo7w sample logic app /subscriptions/187f412d-1758-44d9-b052-169e2564721d/resourceGroups/LogicApp/provid…
```

This command creates action group logic app receiver object.

