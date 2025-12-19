### Example 1: Check if Datadog creation is supported
```powershell
Get-AzDatadogCreationSupported -DatadogOrganizationId 11111111-2222-3333-aaaa-3e9a21a119f9
```

```output
CreationSupported Name
----------------- ----
True abc111cd-efhg-1111-bbbb-0e3eb56bef5c
```

Informs if the current subscription is being already monitored for selected Datadog organization.