### Example 1: List bare metal machines by subscription
```powershell
Get-AzNetworkCloudBareMetalMachine -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt      SystemDataLastModifiedBy
--------  ----             -------------------   -------------------  ----------------------- ------------------------      ------------
westus3  rack1compute01    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1compute02    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1compute03    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1control01    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1control02    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>

```

This command lists bare metal machines by subscription.

### Example 2: Get bare metal machine
```powershell
 Get-AzNetworkCloudBareMetalMachine -Name rack1control02 -ResourceGroupName resourceGroupName
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType ResourceGroupName
-------- ----           ------------------- -------------------    ----------------------- ------------------------ ------------------------    ---------------------------- -----------------
eastus   rack1control02 08/12/2023 23:14:00  <identity>            User                     08/17/2023 13:36:42      <identity>                  User                         resourceGroupName
```

This command gets details of a bare metal machine.


### Example 3: List bare metal machines by resource group
```powershell
Get-AzNetworkCloudBareMetalMachine -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name                    SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                         -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  rack1compute01 07/19/2023 15:44:02   <identity>                         User                                          07/19/2023 15:46:45           <identity>
```

This command lists bare metal machines by resource group.
