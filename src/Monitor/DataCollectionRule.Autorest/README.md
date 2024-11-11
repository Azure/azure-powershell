<!-- region Generated -->
# Az.DataCollectionRule
This directory contains the PowerShell module for the DataCollectionRule service.

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
For information on how to develop for `Az.DataCollectionRule`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
commit: 4f4044394791773e6e7e82a9bd90d3935caaca1b

input-file:
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionEndpoints_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRuleAssociations_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRules_API.json

root-module-name: $(prefix).Monitor
title: DataCollectionRule
module-version: 0.1.0
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection
subject-prefix: ''
disable-transform-identity-type: true
flatten-userassignedidentity: false

directive:
  # custom required body
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dataCollectionRuleName}"].put.parameters
    transform: >-
      return [
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "$ref": "#/parameters/DataCollectionRuleNameParameter"
          },
          {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          },
          {
            "in": "body",
            "name": "body",
            "description": "The payload",
            "required": true,
            "schema": {
              "$ref": "#/definitions/DataCollectionRuleResource"
            }
          }
        ]
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionEndpoints/{dataCollectionEndpointName}"].put.parameters
    transform: >-
      return [
        {
          "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/SubscriptionIdParameter"
        },
        {
          "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/ResourceGroupNameParameter"
        },
        {
          "$ref": "#/parameters/DataCollectionEndpointNameParameter"
        },
        {
          "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/4f4044394791773e6e7e82a9bd90d3935caaca1b/specification/common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
        },
        {
          "in": "body",
          "name": "body",
          "description": "The payload",
          "required": true,
          "schema": {
            "$ref": "#/definitions/DataCollectionEndpointResource"
          }
        }
      ]
  # remove tag patch, add resource put by autorest
  - remove-operation: DataCollectionRules_Update
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^UpdateViaJsonFilePath$|^UpdateViaJsonString$
    remove: true
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      verb: Update
      subject: DataCollectionRule
    set:
      command-description: 'Update a data collection rule.'
  # fix breaking change
  - where:
      subject: DataCollectionRule
      parameter-name: Name
    set:
      alias: RuleName
  - where:
      subject: DataCollectionRuleAssociation
      parameter-name: ResourceUri
    set:
      alias: TargetResourceId
  - where:
      subject: DataCollectionRuleAssociation
      parameter-name: DataCollectionRuleId
    set:
      alias: RuleId
  - where:
      subject: DataCollectionRuleAssociation
      parameter-name: AssociationName
    set:
      alias: Name
  - where:
      subject: DataCollectionRuleAssociation
      parameter-name: DataCollectionRuleName
    set:
      alias: RuleName
  - where:
      subject: DataCollectionRuleAssociation
      parameter-name: DataCollectionEndpointName
    set:
      alias: EndpointName
  # model cmdlet
  - from: swagger-document
    where: $.definitions.ExtensionDataSource.properties.extensionSettings
    transform: >-
      return {
          "description": "The extension settings. The format is specific for particular extension.",
          "additionalProperties": true,
          "type": "object"
      }
  - model-cmdlet:
    # string BuiltInTransform, List<string> Destination, string OutputStream, List<string> Stream, string TransformKql
    - model-name: DataFlow
    # string EventHubResourceId, string Name
    - model-name: EventHubDestination
    - model-name: EventHubDirectDestination
    # custom string ExtensionName, IExtensionDataSourceExtensionSettings ExtensionSetting -> hashtable, List<string> InputDataSource, string Name, List<string> Stream
    # - model-name: ExtensionDataSource
    # List<string> LogDirectory, string Name, List<string> Stream
    - model-name: IisLogsDataSource
    # string Name, string WorkspaceId, string WorkspaceResourceId
    - model-name: LogAnalyticsDestination
    # List<string> FilePattern, string Format, string Name, ILogFilesDataSourceSettings Setting, ILogFileSettingsText SettingText, string SettingTextRecordStartTimestampFormat, List<string> Stream
    - model-name: LogFilesDataSource
    # string AccountId, string AccountResourceId, string Name
    - model-name: MonitoringAccountDestination
    # List<string> CounterSpecifier, string Name, int? SamplingFrequencyInSecond, List<string> Stream
    - model-name: PerfCounterDataSource
    # string Name, List<string> Stream
    - model-name: PlatformTelemetryDataSource
    # custom IPrometheusForwarderDataSourceLabelIncludeFilter LabelIncludeFilter -> HashTable, string Name, List<string> Stream
    #- model-name: PrometheusForwarderDataSource
    # string Name, List<string> Stream
    - model-name: WindowsFirewallLogsDataSource
    # List<string> FacilityName, List<string> LogLevel, string Name, List<string> Stream
    - model-name: SyslogDataSource
    # string Namev, List<string> Stream, List<string> XPathQuery
    - model-name: WindowsEventLogDataSource
    # string Name, List<string> Stream
    - model-name: WindowsFirewallLogsDataSource
    # string ContainerName, string Name, string StorageAccountResourceId
    - model-name: StorageBlobDestination
    # string Name, string StorageAccountResourceId, string TableName
    - model-name: StorageTableDestination

##### announce upcoming MI-related breaking changes
  - where:
      parameter-name: IdentityType
    set:
      breaking-change:
        change-description: IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.0.0
        change-effective-date: 2024/11/19
  - where:
      parameter-name: UserAssignedIdentity
    set:
      breaking-change:
        old-parameter-type: Hashtable
        new-parameter-type: string[]
        change-description: UserAssignedIdentity's type will be simplified as string array.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 13.0.0
        change-effective-date: 2024/11/19
```
