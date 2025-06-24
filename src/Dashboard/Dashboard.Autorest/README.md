<!-- region Generated -->
# Az.Dashboard
This directory contains the PowerShell module for the Dashboard service.

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
For information on how to develop for `Az.Dashboard`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 02ed6d4aac29881364f8698b4fdac9c76cd0f538
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/dashboard/resource-manager/Microsoft.Dashboard/stable/2022-08-01/grafana.json

title: Dashboard
module-version: 0.1.0
subject-prefix: Grafana

directive:
  - from: swagger-document 
    where: $.definitions.ResourceSku.properties
    transform: >-
      return {
          "name": {
            "description": "The Sku of the grafana resource.",
            "type": "string"
          }
      }
  - from: swagger-document 
    where: $.definitions.GrafanaIntegrations.properties.azureMonitorWorkspaceIntegrations
    transform: >-
      return {
          "type": "array",
          "x-ms-identifiers": [],
          "description": "The MonitorWorkspaceIntegration of Azure Managed Grafana.",
          "items": {
            "$ref": "#/definitions/AzureMonitorWorkspaceIntegration"
          }
      }
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  - where:
      parameter-name: WorkspaceName
    set:
      parameter-name: Name
      alias: GrafanaName
  - where:
      subject: PrivateEndpointConnection
    remove: true
  - where:
      subject: PrivateLinkResource
    remove: true
  - where:
      verb: New
      subject: Grafana
    hide: true
  - where:
      parameter-name: GrafanaIntegrationAzureMonitorWorkspaceIntegration
    set:
      parameter-name: MonitorWorkspaceIntegration 
  - model-cmdlet:
      - model-name: AzureMonitorWorkspaceIntegration
        cmdlet-name: New-AzGrafanaMonitorWorkspaceIntegrationObject
```
