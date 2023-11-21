### Example 1: Get data product resource by data product name.

```powershell
Get-AzNetworkAnalyticsDataProduct -DataProductName "pwshdp01" -ResourceGroupName "ResourceGroupName"
```

```output
Location       Name     SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----     -------------------    -------------------    ----------------------- ------------------------ -------------
southcentralus pwshdp01 10/13/2023 11:22:54 AM user1@microsoft.com User                    10/13/2023 11:22:54 AM   user1@microsoft.com
```

Get data product resource by data product name.


### Example 2: List all data product resource for a resoure group.

```powershell
$GetDataProductsForRG = Get-AzNetworkAnalyticsDataProduct -ResourceGroupName "ResourceGroupName"

$GetDataProductsForRG | select Name,ResourceGroupName,Location,ProvisioningState,Product,MajorVersion,Publisher | Format-Table
```

```output
Name         ResourceGroupName Location    ProvisioningState Product MajorVersion Publisher SystemDataCreatedBy
----         ----------------- --------    ----------------- ------- ------------ --------- -------------------
dpinstance1  powershell-test    eastus      Succeeded         MCC     2.0.0        Microsoft user1@microsoft.com
dpinstance2  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user1@microsoft.com
dpinstance3  powershell-test    westus      Succeeded         MCC     2.0.0        Microsoft user2@microsoft.com
dpinstance4  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user3@microsoft.com
```

List all data product resource for a resoure group.


### Example 3: List all data product resource for a subscription.

```powershell
$GetDataProductsForSub = Get-AzNetworkAnalyticsDataProduct

$GetDataProductsForRG | select Name,ResourceGroupName,Location,ProvisioningState,Product,MajorVersion,Publisher | Format-Table
```

```output
Name         ResourceGroupName Location    ProvisioningState Product MajorVersion Publisher SystemDataCreatedBy
----         ----------------- --------    ----------------- ------- ------------ --------- -------------------
dpinstance1  powershell-test    eastus      Succeeded         MCC     1.0.0        Microsoft user1@microsoft.com
dpinstance2  powershell-test    uksouth     Succeeded         MCC     1.0.0        Microsoft user1@microsoft.com
dpinstance3  powershell-test    westus      Succeeded         MCC     2.0.0        Microsoft user2@microsoft.com
dpinstance4  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user3@microsoft.com
```

List all data product resource for a subscription.
