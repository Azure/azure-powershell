### Example 1: Get a specified pipeline
```powershell
$pipeline01 = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01 -Name Pipeline01
```

```output
Connection                         : {}
DisabledFlowType                   : 
DisplayName                        : 
FlowType                           : {Complex, Mission, Messaging, API}
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/Pipelines/Pipeline01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
Location                           : eastus
Name                               : Pipeline01
Policy                             : 
ProvisioningState                  : Succeeded
QuarantineDownloadStorageAccount   : 
QuarantineDownloadStorageContainer : 
RemoteCloud                        : Pipeline01
ResourceGroupName                  : ResourceGroup01
Status                             : 
Subscriber                         : 
SystemDataCreatedAt                : 5/23/2099 8:24:10 PM
SystemDataCreatedBy                : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType            : Application
SystemDataLastModifiedAt           : 6/10/2099 4:59:58 PM
SystemDataLastModifiedBy           : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType       : Application
Tag                                : {}
Type                               : microsoft.azuredatatransfer/pipelines
```

This example retrieves a specific pipeline named `Pipeline01` within the resource group `ResourceGroup01`.

### Example 2: Get a list of pipelines in a resource group
```powershell
$pipelinesInResourceGroup = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01
```

```output
Connection                         : {}
DisabledFlowType                   : 
DisplayName                        : 
FlowType                           : {Complex, Mission, Messaging, API}
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/Pipelines/Pipeline01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
Location                           : eastus
Name                               : Pipeline01
Policy                             : 
ProvisioningState                  : Succeeded
QuarantineDownloadStorageAccount   : 
QuarantineDownloadStorageContainer : 
RemoteCloud                        : Pipeline01
ResourceGroupName                  : ResourceGroup01
Status                             : 
Subscriber                         : 
SystemDataCreatedAt                : 5/23/2099 8:24:10 PM
SystemDataCreatedBy                : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType            : Application
SystemDataLastModifiedAt           : 6/10/2099 4:59:58 PM
SystemDataLastModifiedBy           : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType       : Application
Tag                                : {}
Type                               : microsoft.azuredatatransfer/pipelines
```

This example retrieves all pipelines in the resource group `ResourceGroup01`.

### Example 3: Get a list of pipelines in a subscription
```powershell
$pipelinesInSubscription = Get-AzDataTransferPipeline -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Connection                         : {}
DisabledFlowType                   : 
DisplayName                        : 
FlowType                           : {Complex, Mission, Messaging, API}
Id                                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/Pipelines/Pipeline01
IdentityPrincipalId                : 
IdentityTenantId                   : 
IdentityType                       : None
IdentityUserAssignedIdentity       : {}
Location                           : eastus
Name                               : Pipeline01
Policy                             : 
ProvisioningState                  : Succeeded
QuarantineDownloadStorageAccount   : 
QuarantineDownloadStorageContainer : 
RemoteCloud                        : Pipeline01
ResourceGroupName                  : ResourceGroup01
Status                             : 
Subscriber                         : 
SystemDataCreatedAt                : 5/23/2099 8:24:10 PM
SystemDataCreatedBy                : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType            : Application
SystemDataLastModifiedAt           : 6/10/2099 4:59:58 PM
SystemDataLastModifiedBy           : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType       : Application
Tag                                : {}
Type                               : microsoft.azuredatatransfer/pipelines
```

This example retrieves all pipelines in the subscription with the ID `00000000-0000-0000-0000-000000000000`.
