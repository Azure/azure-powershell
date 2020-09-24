### Example 1: List (Default)
```powershell
PS C:\> Get-AzMigrateMachine  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite

Name                                                                                  Type
----                                                                                  ----
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_500994c6-c0d1-312c-06dd-ab2a925b6a48 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50093d34-6ee0-4345-5c9c-5ea3970fad1f Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098f99-f949-22ca-642b-724ec6595210 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009c2ce-ced0-f761-317a-f3ae764596f8 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_500975f3-de2f-b09f-3afe-6217ef7bb6ae Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5008290d-9ce8-5c05-9ba0-e7c8274dd33b Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009959a-3ae5-03f5-b412-145bdc93ff96 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_502b221c-7ba0-55dc-ea4d-27816b5e809f Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009ac6d-c410-2762-d4d3-927d3e3343ef Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50094477-e603-d4d3-4512-4289fc502423 Microsoft.OffAzure/VMwareSites/machines
```

List machines in a site.

### Example 2: Get
```powershell
PS C:\> Get-AzMigrateMachine  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite -Name 10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9

Name                                                                                  Type
----                                                                                  ----
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9 Microsoft.OffAzure/VMwareSites/machines
```

Get machine by name.

