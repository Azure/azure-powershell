<!-- region Generated -->
# Az.Workloads
This directory contains the PowerShell module for the Workloads service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Workloads`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: 202321f386ea5b0c103b46902d43b3d3c50e029c
tag: package-preview-2023-10
# tag: package-2023-04
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/workloads/resource-manager/readme.md

try-require: 
  - $(repo)/specification/workloads/resource-manager/readme.powershell.md

resourcegroup-append: true
identity-correction-for-post: true
nested-object-to-string: true
inlining-threshold: 100

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
# Monitor
- where:
    verb: New
    subject: ^Monitor$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: Update
    subject: ^Monitor$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    subject: ^Monitor$
    parameter-name: IdentityUserAssignedIdentity
  set:
    parameter-name: UserAssignedIdentity

- where:
    subject: ^Monitor$
    parameter-name: ManagedResourceGroupConfigurationName
  set:
    parameter-name: ManagedResourceGroupName

# ProviderInstance
- where:
    verb: New
    subject: ^ProviderInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

# SapApplicationServerInstance
- where:
    verb: New
    subject: ^SapApplicationServerInstance$
  remove: true

- where:
    verb: Stop
    subject: ^SapApplicationServerInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapApplicationServerInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapApplicationServerInstance$
  remove: true

- where:
    subject: SapApplicationServerInstance
  set:
    subject: SapApplicationInstance

- where:
    subject: SapApplicationInstance
    parameter-name: ApplicationInstanceName
  set:
    parameter-name: Name

# SapCentralInstance
- where:
    verb: New
    subject: ^SapCentralInstance$
  remove: true
- where:
    verb: Stop
    subject: ^SapCentralInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapCentralInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapCentralInstance$
  remove: true

- where:
    subject: SapCentralInstance
    parameter-name: CentralInstanceName
  set:
    parameter-name: Name

# SapDatabaseInstance
- where:
    verb: New
    subject: ^SapDatabaseInstance$
  remove: true

- where:
    verb: Stop
    subject: ^SapDatabaseInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapDatabaseInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    verb: Remove
    subject: ^SapDatabaseInstance$
  remove: true

- where:
    subject: SapDatabaseInstance
    parameter-name: DatabaseInstanceName
  set:
    parameter-name: Name

# SapLandscapeMonitor
- where:
    verb: New
    subject: ^SapLandscapeMonitor$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: Get
    subject: ^SapLandscapeMonitor$
    variant: ^List$
  remove: true
- where:
    verb: Update
    subject: ^SapLandscapeMonitor$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

# SapVirtualInstance
- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^CreateExpanded$
  hide: true

- where:
    verb: Stop
    subject: ^SapVirtualInstance$
    variant: ^Stop$|^StopViaIdentity$
  remove: true

- where:
    verb: Update
    subject: ^SapVirtualInstance$
    variant: ^Update$|^UpdateViaIdentity$
  remove: true

- where:
    subject: ^SapVirtualInstance$
    parameter-name: IdentityUserAssignedIdentity
  set:
    parameter-name: UserAssignedIdentity

- where:
    subject: ^SapVirtualInstance$
    parameter-name: ManagedResourceGroupConfigurationName
  set:
    parameter-name: ManagedResourceGroupName

# SapAvailabilityZoneDetail
- where:
    verb: Invoke
    subject: ^SapAvailabilityZoneDetail$
  remove: true

# SapDiskConfiguration
- where:
    verb: Invoke
    subject: ^SapDiskConfiguration$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

# SapSizingRecommendation
- where:
    verb: Invoke
    subject: ^SapSizingRecommendation$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

# SapSupportedSku
- where:
    verb: Invoke
    subject: ^SapSupportedSku$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

# Module Table Formatting
- where:
    model-name: Monitor
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ManagedResourceGroupConfigurationName
        - Location
        - ProvisioningState

- where:
    model-name: ProviderInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - ProviderSettingProviderType
        - IdentityType

- where:
    model-name: SapVirtualInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - Environment
        - ProvisioningState
        - SapProduct
        - State
        - Status
        - Location

- where:
    model-name: SapCentralServerInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - EnqueueServerPropertyHostname
        - ProvisioningState
        - Status
        - Location

- where:
    model-name: SapApplicationServerInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - Health
        - ProvisioningState
        - Status
        - Hostname
        - Location

- where:
    model-name: SapDatabaseInstance
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - Location        
        - Status
        - IPAddress        
        - DatabaseSid

- where:
    model-name: SapLandscapeMonitor
  set:
    format-table:
      properties:
        - Name
        - ResourceGroupName
        - ProvisioningState
        - GroupingLandscape        
        - GroupingSapApplication

- no-inline:  # choose ONE of these models to disable inlining
  - ProviderSpecificProperties
  - SAPConfiguration
  - ErrorInnerError
- model-cmdlet:
  - SapLandscapeMonitorSidMapping
  - SapLandscapeMonitorMetricThresholds
## Need custom below cmdlets.
#   - HanaDbProviderInstanceProperties
#   - SapNetWeaverProviderInstanceProperties
#   - PrometheusOSProviderInstanceProperties
#   - DB2ProviderInstanceProperties
#   - PrometheusHaClusterProviderInstanceProperties
#   - MsSqlServerProviderInstanceProperties

- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Workloads/sapVirtualInstances/{sapVirtualInstanceName}"].delete.responses
  transform: >-
    return { "200": { "description": "OK" }, "202": { "description": "Accepted", "headers": { "Location": { "description": "The URL of the resource used to check the status of the asynchronous operation.", "type": "string" }, "Retry-After": { "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.", "type": "integer",	"format": "int32" }, "Azure-AsyncOperation": { "description": "The URI to poll for completion status.", "type": "string" } } }, "204": { "description": "No Content" }, "default": { "description": "Error response describing why the operation failed.", "schema": { "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/202321f386ea5b0c103b46902d43b3d3c50e029c/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse" } } }
 	  
# Result shoule be in SingleServerRecommendationResult and ThreeTierRecommendationResult
- from: source-file-csharp
  where: $
  transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapSizingRecommendationResult Property', 'public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapSizingRecommendationResult Property');

# remove System Data in module Monitor, ProviderInstance, SapApplicationServerInstance, SapCentralServerInstance, SapDatabaseInstance, SapLandscapeMonitor, SapVirtualInstance
- from: Monitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: ProviderInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapApplicationServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapCentralServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapDatabaseInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapLandscapeMonitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
- from: SapVirtualInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.ISystemData SystemData');
```
