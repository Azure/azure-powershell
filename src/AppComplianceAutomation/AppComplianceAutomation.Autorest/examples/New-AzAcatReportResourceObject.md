### Example 1: Create a ReportResource object with default values.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"})
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object with default values.

### Example 2: Create a ReportResource object.
```powershell
New-AzAcatReportResourceObject -Resource @(@{resourceId="/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm"; resourceOrigin="Azure"; resourceType="microsoft.compute/virtualmachines"}) -TimeZone "China Standard Time" -TriggerTime "2023-07-19T08:00:00.000Z" -OfferGuid "00000000-0000-0000-0000-000000000001"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a ReportResource object.
