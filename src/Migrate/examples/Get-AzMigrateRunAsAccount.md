### Example 1: List (Default)
```powershell
PS C:\> Get-AzMigrateRunAsAccount  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite

Name                                 Type
----                                 ----
b090bef3-b733-5e34-bc8f-eb6f2701432a Microsoft.OffAzure/VMwareSites/runasaccounts
```

List all run as accounts in a site.

### Example 2: Get
```powershell
PS C:\> Get-AzMigrateRunAsAccount  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite -AccountName b090bef3-b733-5e34-bc8f-eb6f2701432a

Name                                 Type
----                                 ----
b090bef3-b733-5e34-bc8f-eb6f2701432a Microsoft.OffAzure/VMwareSites/runasaccounts
```

Get Run as account by name.
