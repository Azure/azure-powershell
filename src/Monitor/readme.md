<!-- region Generated -->
# Az.Monitor
This directory contains the PowerShell module for the Monitor service.

---
## Status
[![Az.Monitor](https://img.shields.io/powershellgallery/v/Az.Monitor.svg?style=flat-square&label=Az.Monitor "Az.Monitor")](https://www.powershellgallery.com/packages/Az.Monitor/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Monitor`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/monitor/resource-manager/readme.md
  - $(repo)/specification/monitor/data-plane/readme.md

subject-prefix: ''
module-version: 4.0.2
title: Monitor

directive:
  # Set correct variants for PUT and PATCH verbs
  - where:
      verb: New
      variant: ^CreateViaIdentityExpanded\d?$|^CreateViaIdentity\d?$|^Create\d?$
    remove: true
  - where:
      verb: Set
      variant: ^Update\d?$|^UpdateViaIdentity\d?$
    remove: true
  - where:
      verb: Update
      variant: ^Update\d?$|^UpdateViaIdentity\d?$
    remove: true
  # Renaming fix
  - where:
      enum-name: ComparisonOperationType|^Operator$
      enum-value-name: Equals
    set:
      enum-value-name: Equal
  - where:
      model-name: ActivityLogAlertLeafCondition
      property-name: Equals
    set:
      property-name: Equal
  # Pluralization fix
  - where:
      subject: MetricAlertsStatus
    set:
      subject: MetricAlertStatus
  # ActivityLogAlert
  - where:
      subject: ActivityLogAlert
      parameter-name: ConditionAllOf
    set:
      parameter-name: Condition
  - where:
      verb: Update
      subject: ActivityLogAlert
    hide: true
  # Log
  - where:
      verb: Get
      subject: ^ActivityLog$
    set:
      alias: Get-AzLog
  # MetricAlert
  - where:
      verb: Get
      subject: MetricAlert
    set:
      alias: Get-AzMetricAlertRuleV2
  - where:
      verb: New
      subject: MetricAlert
    set:
      alias: Add-AzMetricAlertRuleV2
  - where:
      verb: Remove
      subject: MetricAlert
    set:
      alias: Remove-AzMetricAlertRuleV2
  - where:
      verb: Set
      subject: MetricAlert
    hide: true
  - where:
      subject: MetricAlert
      parameter-name: RuleName
    set:
      parameter-name: Name
  - where:
      verb: New|Update
      subject: MetricAlert
    hide: true
  # AlertRule
  - where:
      verb: New
      subject: ^AlertRule$
    set:
      alias: Add-AzMetricAlertRule
  - where:
      subject: AlertRule
      parameter-name: Name
    set:
      parameter-name: PropertiesName
  - where:
      subject: AlertRule
      parameter-name: RuleName
    set:
      parameter-name: Name
  - where:
      subject: AlertRuleIncident
      parameter-name: RuleName
    set:
      parameter-name: Name
  - where:
      subject: AlertRule
      parameter-name: IsEnabled
    set:
      parameter-name: Enabled
  - where:
      verb: New|Update
      subject: AlertRule
    hide: true
  - where:
      verb: Set
      subject: AlertRule
    hide: true
  # LogProfile
  - where:
      verb: New
      subject: ^LogProfile$
    set:
      alias: Add-AzLogProfile
  - where:
      subject: LogProfile
      parameter-name: RetentionPolicyDay
    set:
      parameter-name: RetentionPolicyInDays
  - where:
      verb: Set|New
      subject: LogProfile
    hide: true
  # Autoscale
  - where:
      verb: Set
      subject: ^AutoscaleSetting$
    set:
      alias: Add-AzAutoscaleSetting
  - where:
      subject: AutoscaleSetting
      parameter-name: Profile
    set:
      alias: AutoscaleProfile
  - where:
      subject: AutoscaleSetting
      parameter-name: TargetResourceUri
    set:
      parameter-name: TargetResourceId
  # Fix Help Generation Bug
  - where:
      verb: Update
      subject: ^AutoscaleSetting$
      parameter-name: ^Name$
    clear-alias: true
  # ActivityLog
  - where:
      verb: Get
      subject: ^ActivityLog$
    hide: true
  - where:
      verb: Get
      subject: TenantActivityLog
    hide: true
  # ActionGroup
  - where:
      subject: ActionGroup
      parameter-name: GroupShortName
    set:
      parameter-name: ShortName
  - where:
      verb: Enable
      subject: ActionGroupReceiver
    remove: true
  - where:
      verb: Update
      subject: ActionGroup
    remove: true
  # Metric
  - where:
      subject: Metric
      parameter-name: Interval
    set:
      alias: TimeGrain
  - where:
      subject: Metric.*
      parameter-name: ResourceUri
    set:
      parameter-name: ResourceId
  - where:
      verb: New
      subject: Metric
    remove: true
  - where:
      verb: Get
      subject: MetricDefinition
    hide: true
  # ScheduledQuery
  - where:
      subject: ScheduledQueryRule
      parameter-name: RuleName
    set:
      parameter-name: Name
  - where:
      verb: New|Set|Update
      subject: ScheduledQueryRule
    hide: true
  # DiagnosticSetting
  - where:
      subject: ^DiagnosticSettings(.*)
    set:
      subject: DiagnosticSetting$1
  - where:
      subject: ^DiagnosticSetting(Category)?$
      parameter-name: ResourceUri
    set:
      parameter-name: ResourceId
  # Removing
  - where:
      verb: Get
      subject: Baseline
    remove: true
# Fix the name of the module in the nuspec
  - from: Az.Monitor.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Monitor service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on Monitor, please visit the following$1 https://docs.microsoft.com/azure/monitoring-and-diagnostics/');
# Add release notes
  - from: Az.Monitor.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Monitor cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Make the nuget package a preview
  - from: Az.Monitor.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Monitor cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Monitor service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Monitor, please visit the following$1 https://docs.microsoft.com/azure/monitoring-and-diagnostics/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Monitor cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```

``` yaml
declare-directive:
  no-inline: >-
    (() => {
      return {
       from: "code-model-v3", 
       where: (Array.isArray($) ? $ : [$]).map( each => `$.schemas[?(/^${each}$/i.exec(@.details.default.name))]`),
       transform: "$.details.default['skip-inline'] = true;"
      };
    })()
```

``` yaml
directive:
  no-inline:  # the name of the model schema in the swagger file
    - Action
    - RuleCondition
```
