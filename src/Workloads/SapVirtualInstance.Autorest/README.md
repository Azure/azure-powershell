<!-- region Generated -->
# Az.SapVirtualInstance
This directory contains the PowerShell module for the SapVirtualInstance service.

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
For information on how to develop for `Az.SapVirtualInstance`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
commit: 724933f1dfe3bc7831d74b6f1d0a189790fca5e0
tag: package-2024-09

require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/workloads/resource-manager/Microsoft.Workloads/SAPVirtualInstance/readme.md

try-require:
  - $(repo)/specification/workloads/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
root-module-name: $(prefix).Workloads
# Normally, title is the service name
title: SapVirtualInstance
subject-prefix: Workloads
namespace: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance
inlining-threshold: 100

flatten-userassignedidentity: false
disable-transform-identity-type: true

directive:
- where:
    variant: ^(Stop|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
  remove: true

- where:
    verb: New|Remove
    subject: ^SapApplicationServerInstance$|^SapCentralServerInstance$|^SapDatabaseInstance$
  remove: true

#SapApplicationInstance
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
    subject: SapCentralServerInstance
    parameter-name: CentralInstanceName
  set:
    parameter-name: Name

- where:
    verb: Get|Start|Stop|Update
    subject: ^SapCentralServerInstance$
  set:
    subject: SapCentralInstance

# SapDatabaseInstance
- where:
    subject: SapDatabaseInstance
    parameter-name: DatabaseInstanceName
  set:
    parameter-name: Name

# SapVirtualInstance
- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^(Create)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
  remove: true

- where:
    verb: New
    subject: ^SapVirtualInstance$
    variant: ^CreateExpanded$
  hide: true

- where:
    subject: ^SapVirtualInstance$
    parameter-name: ManagedResourceGroupConfigurationName
  set:
    parameter-name: ManagedResourceGroupName

- where:
    verb: Update
    subject: ^SapVirtualInstance$
  hide: true

# SapAvailabilityZoneDetail
- where:
    verb: Invoke
    subject: ^InvokeSapVirtualInstanceAvailabilityZoneDetail$
  remove: true

# SapDiskConfiguration
- where:
    verb: Invoke
    subject: ^InvokeSapVirtualInstanceDiskConfiguration$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

- where:
    verb: Invoke
    subject:  ^InvokeSapVirtualInstanceDiskConfiguration$
  set:
    subject:  SapDiskConfiguration

# SapSizingRecommendation
- where:
    verb: Invoke
    subject: ^InvokeSapVirtualInstanceSizingRecommendation$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

- where:
    verb: Invoke
    subject:  ^InvokeSapVirtualInstanceSizingRecommendation$
  set:
    subject:  SapSizingRecommendation

# SapSupportedSku
- where:
    verb: Invoke
    subject: ^InvokeSapVirtualInstanceSapSupportedSku$
    variant: ^Sap$|^SapViaIdentity$
  remove: true

- where:
    verb: Invoke
    subject:  ^InvokeSapVirtualInstanceSapSupportedSku$
  set:
    subject:  SapSupportedSku

#Aliasing
- where:
    verb: New
    subject: ^SapVirtualInstance$
  set:
    alias: New-AzVIS

- where:
    verb: Get
    subject:  ^SapVirtualInstance$
  set:
    alias: Get-AzVIS

- where:
    verb: Remove
    subject:  ^SapVirtualInstance$
  set:
    alias: Remove-AzVIS

- where:
    verb: Update
    subject:  ^SapVirtualInstance$
  set:
    alias: Update-AzVIS

- where:
    verb: Start
    subject:  ^SapVirtualInstance$
  set:
    alias: Start-AzVIS

- where:
    verb: Stop
    subject:  ^SapVirtualInstance$
  set:
    alias: Stop-AzVIS

- where:
    verb: Get
    subject:  ^SapApplicationInstance$
  set:
    alias: Get-AzVISApplicationInstance

- where:
    verb: Start
    subject:  ^SapApplicationInstance$
  set:
    alias: Start-AzVISApplicationInstance

- where:
    verb: Stop
    subject:  ^SapApplicationInstance$
  set:
    alias: Stop-AzVISApplicationInstance

- where:
    verb: Update
    subject:  ^SapApplicationInstance$
  set:
    alias: Update-AzVISApplicationInstance

- where:
    verb: Get
    subject:  ^SapCentralInstance$
  set:
    alias: Get-AzVISCentralInstance

- where:
    verb: Start
    subject:  ^SapCentralInstance$
  set:
    alias: Start-AzVISCentralInstance

- where:
    verb: Stop
    subject:  ^SapCentralInstance$
  set:
    alias: Stop-AzVISCentralInstance

- where:
    verb: Update
    subject:  ^SapCentralInstance$
  set:
    alias: Update-AzVISCentralInstance

- where:
    verb: Get
    subject:  ^SapDatabaseInstance$
  set:
    alias: Get-AzVISDatabaseInstance

- where:
    verb: Start
    subject:  ^SapDatabaseInstance$
  set:
    alias: Start-AzVISDatabaseInstance

- where:
    verb: Stop
    subject:  ^SapDatabaseInstance$
  set:
    alias: Stop-AzVISDatabaseInstance

- where:
    verb: Update
    subject:  ^SapDatabaseInstance$
  set:
    alias: Update-AzVISDatabaseInstance

- where:
    verb: Invoke
    subject:  ^SapDiskConfiguration$
  set:
    alias: Invoke-AzVISDiskConfiguration

- where:
    verb: Invoke
    subject:  ^SapSizingRecommendation$
  set:
    alias: Invoke-AzVISSizingRecommendation

- where:
    verb: Invoke
    subject:  ^SapSupportedSku$
  set:
    alias: Invoke-AzVISSupportedSku

# Module Table Formatting
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

- no-inline:  # choose ONE of these models to disable inlining
  - ProviderSpecificProperties
  - SAPConfiguration
  - ErrorInnerError

- from: swagger-document
  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Workloads/sapVirtualInstances/{sapVirtualInstanceName}"].delete.responses

  transform: >-
    return { "200": { "description": "OK" }, "202": { "description": "Accepted", "headers": { "Location": { "description": "The URL of the resource used to check the status of the asynchronous operation.", "type": "string" }, "Retry-After": { "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.", "type": "integer",	"format": "int32" }, "Azure-AsyncOperation": { "description": "The URI to poll for completion status.", "type": "string" } } }, "204": { "description": "No Content" }, "default": { "description": "Error response describing why the operation failed.", "schema": { "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/724933f1dfe3bc7831d74b6f1d0a189790fca5e0/specification/common-types/resource-management/v5/types.json#/definitions/ErrorResponse" } } }

# Result shoule be in SingleServerRecommendationResult and ThreeTierRecommendationResult
- from: source-file-csharp
  where: $
  transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISapSizingRecommendationResult Property', 'public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISapSizingRecommendationResult Property');

# remove System Data in module Monitor, ProviderInstance, SapApplicationServerInstance, SapCentralServerInstance, SapDatabaseInstance, SapLandscapeMonitor, SapVirtualInstance
- from: SapApplicationServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData');
- from: SapCentralServerInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData');
- from: SapDatabaseInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData');
- from: SapLandscapeMonitor.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData');
- from: SapVirtualInstance.cs
  where: $
  transform: $ = $.replace('public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData', 'internal Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.ISystemData SystemData');
```
