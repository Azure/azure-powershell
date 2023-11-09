<!-- region Generated -->
# Az.DataCollectionRule
This directory contains the PowerShell module for the DataCollectionRule service.

---
## Status
[![Az.DataCollectionRule](https://img.shields.io/powershellgallery/v/Az.DataCollectionRule.svg?style=flat-square&label=Az.DataCollectionRule "Az.DataCollectionRule")](https://www.powershellgallery.com/packages/Az.DataCollectionRule/)

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
branch: 4f4044394791773e6e7e82a9bd90d3935caaca1b

input-file:
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionEndpoints_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRuleAssociations_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-06-01/dataCollectionRules_API.json

root-module-name: $(prefix).Monitor
title: DataCollectionRule
module-version: 0.1.0
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection
subject-prefix: ''
resourcegroup-append: true
nested-object-to-string: true

use-extension:
  "@autorest/powershell": "4.x"

directive:
  - remove-operation: DataCollectionRules_Update
#   # Following is two common directive which are normally required in all the RPs
#   # 1. Remove the unexpanded parameter set
#   # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
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
  - from: dataCollectionRules_API.json
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
```
