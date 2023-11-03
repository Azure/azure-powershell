### Example 1: Create data product resource.

```powershell
 New-AzNetworkAnalyticsDataProduct -Name "pwshdp01" -Product "MCC" -MajorVersion "2.0.0" -Publisher "Microsoft" -Location "southcentralus" -ResourceGroupName "ResourceGroupName"
```

```output
Location       Name     SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----     -------------------    -------------------    ----------------------- ------------------------ -------------
southcentralus pwshdp01 10/13/2023 11:22:54 AM user1@microsoft.com User                    10/13/2023 11:22:54 AM   user1@microsoft.com
```

Create data product resource.