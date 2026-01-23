#### New-AzDurableTaskScheduler

#### SYNOPSIS
Create a Scheduler

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-IPAllowlist <String[]>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaJsonFilePath
```powershell
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaJsonString
```powershell
New-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new Durable Task scheduler with basic settings
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuCapacity 3 -SkuName "Dedicated" -IPAllowlist @("10.0.0.0/8") -Tag @{department="research"; development="true"}
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a new Durable Task scheduler with Dedicated SKU, IP allowlist, and tags.
Output shows all returned properties.

+ Example 2: Create a scheduler with JSON file
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -JsonFilePath "./scheduler.json"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a Durable Task scheduler using a JSON configuration file.
Output shows full resource details.

+ Example 3: Create a scheduler with capacity configuration
```powershell
New-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Location "northcentralus" -SkuName "Dedicated" -SkuCapacity 1
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {0.0.0.0/0}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 1
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Creates a Durable Task scheduler with a specific SKU capacity and shows the full returned object.


#### Get-AzDurableTaskScheduler

#### SYNOPSIS
Get a Scheduler

#### SYNTAX

+ List (Default)
```powershell
Get-AzDurableTaskScheduler [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzDurableTaskScheduler -InputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzDurableTaskScheduler -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all schedulers in a subscription
```powershell
Get-AzDurableTaskScheduler
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Lists all Durable Task schedulers in the current subscription.

+ Example 2: Get a specific scheduler by name
```powershell
Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Gets the details of a specific Durable Task scheduler by name and resource group.

+ Example 3: List schedulers in a resource group
```powershell
Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi"
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Lists all Durable Task schedulers in a specific resource group.

+ Example 4: Get a scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Get-AzDurableTaskScheduler
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                 "department": "research",
                                 "development": "true"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Gets a scheduler using an input object via pipeline (GetViaIdentity parameter set).


#### Remove-AzDurableTaskScheduler

#### SYNOPSIS
Delete a Scheduler

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzDurableTaskScheduler -InputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a scheduler by name
```powershell
Remove-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi"
```

Removes a Durable Task scheduler by name and resource group.

+ Example 2: Remove a scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Remove-AzDurableTaskScheduler
```

Removes a Durable Task scheduler using pipeline input (DeleteViaIdentity parameter set).

+ Example 3: Remove a scheduler with PassThru parameter
```powershell
Remove-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -PassThru
```

```output
True
```

Removes a scheduler and returns a boolean value indicating success.


#### Update-AzDurableTaskScheduler

#### SYNOPSIS
Update a Scheduler

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IPAllowlist <String[]>] [-SkuCapacity <Int32>] [-SkuName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzDurableTaskScheduler -InputObject <IDurableTaskIdentity> [-IPAllowlist <String[]>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaJsonFilePath
```powershell
Update-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaJsonString
```powershell
Update-AzDurableTaskScheduler -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update scheduler tags and IP allowlist
```powershell
Update-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -Tag @{hello="world"} -IPAllowlist @("10.0.0.0/8")
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                  "hello": "world"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates the tags and IP allowlist for an existing Durable Task scheduler.
Output shows all returned properties, with Tag reflecting the update.

+ Example 2: Update scheduler SKU capacity
```powershell
Update-AzDurableTaskScheduler -Name "testscheduler" -ResourceGroupName "rgopenapi" -SkuName "Dedicated" -SkuCapacity 3
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates the SKU capacity of an existing scheduler.
Output shows all returned properties, with SkuName and SkuCapacity reflecting the update.

+ Example 3: Update scheduler using pipeline input
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
$scheduler | Update-AzDurableTaskScheduler -Tag @{hello="world"}
```

```output
Endpoint                     : https://test.northcentralus.1.durabletask.io
IPAllowlist                  : {10.0.0.0/8}
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler
Location                     : North Central US
Name                         : testscheduler
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SkuCapacity                  : 3
SkuName                      : Dedicated
SkuRedundancyState           : Zone
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Tag                          : {
                                  "hello": "world"
                               }
Type                         : Microsoft.DurableTask/schedulers
```

Updates a scheduler using pipeline input (UpdateViaIdentityExpanded parameter set).
Output shows all returned properties, with Tag reflecting the update.


#### New-AzDurableTaskHub

#### SYNOPSIS
Create a Task Hub

#### SYNTAX

+ CreateExpanded (Default)
```powershell
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaIdentitySchedulerExpanded
```powershell
New-AzDurableTaskHub -Name <String> -SchedulerInputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CreateViaJsonFilePath
```powershell
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ CreateViaJsonString
```powershell
New-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new task hub
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub in a Durable Task scheduler.

+ Example 2: Create a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
New-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub using a scheduler input object (CreateViaIdentitySchedulerExpanded parameter set).

+ Example 3: Create a task hub from JSON file
```powershell
New-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler" -JsonFilePath "./taskhub.json"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Creates a new task hub using a JSON configuration file.


#### Get-AzDurableTaskHub

#### SYNOPSIS
Get a Task Hub

#### SYNTAX

+ List (Default)
```powershell
Get-AzDurableTaskHub -ResourceGroupName <String> -SchedulerName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzDurableTaskHub -InputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentityScheduler
```powershell
Get-AzDurableTaskHub -Name <String> -SchedulerInputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all task hubs for a scheduler
```powershell
Get-AzDurableTaskHub -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Lists all task hubs for a specific Durable Task scheduler.

+ Example 2: Get a specific task hub by name
```powershell
Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets the details of a specific task hub by name.

+ Example 3: Get a task hub using pipeline input
```powershell
$taskHub = Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
$taskHub | Get-AzDurableTaskHub
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets a task hub using pipeline input (GetViaIdentity parameter set).

+ Example 4: Get a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
Get-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

```output
DashboardUrl                 : https://test-db.northcentralus.1.durabletask.io/taskhubs/testtaskhub
Id                           : /subscriptions/EE9BD735-67CE-4A90-89C4-439D3F6A4C93/resourceGroups/rgopenapi/providers/Microsoft.DurableTask/schedulers/testscheduler/taskHubs/testtaskhub
Name                         : testtaskhub
ProvisioningState            : Succeeded
ResourceGroupName            : rgopenapi
SystemDataCreatedAt          : 4/17/2024 3:34:17 PM
SystemDataCreatedBy          : tenmbevaunjzikxowqexrsx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/17/2024 3:34:17 PM
SystemDataLastModifiedBy     : xfvdcegtj
SystemDataLastModifiedByType : User
Type                         : Microsoft.DurableTask/schedulers/taskHubs
```

Gets a task hub using a scheduler input object (GetViaIdentityScheduler parameter set).


#### Remove-AzDurableTaskHub

#### SYNOPSIS
Delete a Task Hub

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzDurableTaskHub -Name <String> -ResourceGroupName <String> -SchedulerName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzDurableTaskHub -InputObject <IDurableTaskIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentityScheduler
```powershell
Remove-AzDurableTaskHub -Name <String> -SchedulerInputObject <IDurableTaskIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a task hub by name
```powershell
Remove-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
```

Removes a task hub from a Durable Task scheduler.

+ Example 2: Remove a task hub using pipeline input
```powershell
$taskHub = Get-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler"
$taskHub | Remove-AzDurableTaskHub
```

Removes a task hub using pipeline input (DeleteViaIdentity parameter set).

+ Example 3: Remove a task hub with scheduler input object
```powershell
$scheduler = Get-AzDurableTaskScheduler -ResourceGroupName "rgopenapi" -Name "testscheduler"
Remove-AzDurableTaskHub -Name "testtaskhub" -SchedulerInputObject $scheduler
```

Removes a task hub using a scheduler input object (DeleteViaIdentityScheduler parameter set).

+ Example 4: Remove a task hub with PassThru parameter
```powershell
Remove-AzDurableTaskHub -Name "testtaskhub" -ResourceGroupName "rgopenapi" -SchedulerName "testscheduler" -PassThru
```

```output
True
```

Removes a task hub and returns a boolean value indicating success.


