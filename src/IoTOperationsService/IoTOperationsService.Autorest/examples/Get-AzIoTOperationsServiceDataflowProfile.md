### Example 1: List DataflowProfiles
```powershell
Get-AzIoTOperationsServiceDataflowProfile -InstanceName  "aio-3lrx4" -ResourceGroupName "aio-validation-117026523"
```

```output
Name               SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----               ------------------- -------------------                  ----------------------- ------------------------ ------------------------
default            3/5/2025 5:07:34 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:29:52 PM      319f651f-7ddb-4fc6-9857-7ae…
dataflowdeployment 3/5/2025 5:28:56 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:30:03 PM      319f651f-7ddb-4fc6-9857-7ae…
quickstart-profile 3/5/2025 5:30:44 PM 739f5293-922a-4616-b106-3662530ef99f Application             3/5/2025 5:31:30 PM      319f651f-7ddb-4fc6-9857-7ae…

```

This command list dataflow profiles
