<!-- region Generated -->
# Az.ServiceBus
This directory contains the PowerShell module for the ServiceBus service.

---
## Status
[![Az.ServiceBus](https://img.shields.io/powershellgallery/v/Az.ServiceBus.svg?style=flat-square&label=Az.ServiceBus "Az.ServiceBus")](https://www.powershellgallery.com/packages/Az.ServiceBus/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ServiceBus`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/servicebus/resource-manager/readme.md

module-version: 0.0.1

directive:
# Internal
  - where:
      subject: AuthorizationRule$|Key$|NameAvailability$
    hide: true
# AuthorizationRule
  - where:
      parameter-name: AuthorizationRuleName
    set:
      alias: AuthorizationRule
  - where:
      subject: AuthorizationRule$
      parameter-name: AuthorizationRuleName
    set:
      alias: AuthorizationRuleName
      parameter-name: Name
  - where:
      subject: AuthorizationRule$
      parameter-name: Right
    set:
      alias:
        - Right
        - Rights
      parameter-name: AccessRight
# DisasterRecovery
  - where:
      subject: (.*)DisasterRecoveryConfig(.*)
    set:
      subject: $1DisasterRecoveryConfiguration$2
  - where:
      subject: (.*)DisasterRecoveryConfiguration(.*)
      parameter-name: Alias
    set:
      alias:
        - Alias
        - AliasName
        - DisasterRecoveryConfiguration
      parameter-name: DisasterRecoveryConfigurationName
  - where:
      subject: FailDisasterRecoveryConfigurationOver
    set:
      subject: DisasterRecoveryFailOver
  - where:
      subject: BreakDisasterRecoveryConfigurationPairing
    set:
      verb: Disable
      subject: DisasterRecoveryPairing
  - where:
      subject: DisasterRecoveryConfiguration$|DisasterRecoveryFailOver|DisasterRecoveryPairing
      parameter-name: DisasterRecoveryConfigurationName
    set:
      alias: DisasterRecoveryConfigurationName
      parameter-name: Name
  - where:
      verb: Get
      subject: DisasterRecoveryConfiguration
    set:
      alias: Get-AzServiceBusGeoDRConfiguration
  - where:
      verb: New
      subject: DisasterRecoveryConfiguration
    set:
      alias: New-AzServiceBusGeoDRConfiguration
  - where:
      verb: Remove
      subject: DisasterRecoveryConfiguration
    set:
      alias: Remove-AzServiceBusGeoDRConfiguration
  - where:
      verb: Invoke
      subject: DisasterRecoveryFailOver
    set:
      alias: Set-AzServiceBusGeoDRConfigurationFailOver
  - where:
      verb: Disable
      subject: DisasterRecoveryPairing
    set:
      alias: Set-AzServiceBusGeoDRConfigurationBreakPair
# MigrationConfiguration
  - where:
      subject: (.*)MigrationConfig(.*)
    set:
      subject: $1Migration$2
  - where:
      subject: MigrationMigration
    set:
      subject: Migration
  - where:
      subject: MigrationAndStartMigration
    set:
      verb: Start
      subject: Migration
  - where:
      subject: RevertMigration
    set:
      verb: Stop
      subject: Migration
  - where:
      subject: Migration$
      parameter-name: NamespaceName
    set:
      alias: Name
# NameAvailability
  - where:
      subject: DisasterRecoveryConfigurationNameAvailability
      parameter-name: Name
    set:
      alias:
        - Alias
        - AliasName
        - DisasterRecoveryConfiguration
      parameter-name: DisasterRecoveryConfigurationName
  - where:
      subject: NamespaceNameAvailability
      parameter-name: Name
    set:
      parameter-name: NamespaceName
# General Parameters
  - where:
      parameter-name: NamespaceName
    set:
      alias: Namespace
  - where:
      parameter-name: TopicName
    set:
      alias: Topic
  - where:
      parameter-name: QueueName
    set:
      alias: Queue
  - where:
      subject: Key$
      parameter-name: AuthorizationRuleName
    set:
      alias: Name
# Remove Non-expanded
  # - where:
  #     verb: Move
  #     subject: ^Namespace$
  #     variant: ^Migrate$|^MigrateViaIdentity$
  #   remove: true
  # - where:
  #     verb: New|Set
  #     subject: DisasterRecoveryConfiguration|^Namespace$|NamespaceAuthorizationRule|NamespaceIPFilterRule|NamespaceNetworkRuleSet|NamespaceVirtualNetworkRule|^Queue$|QueueAuthorizationRule|^Rule$|^Subscription$|^Topic$|TopicAuthorizationRule
  #     variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
  #   remove: true
  # - where:
  #     verb: New
  #     subject: ^NamespaceKey$|^QueueKey$|^TopicKey$
  #     variant: ^Regenerate$|^RegenerateViaIdentity$
  #   remove: true
  # - where:
  #     verb: Start
  #     subject: ^Migration$
  #     variant: ^Create$|^CreateViaIdentity$
  #   remove: true
  # - where:
  #     verb: Test
  #     subject: DisasterRecoveryConfigurationNameAvailability|NamespaceNameAvailability
  #     variant: ^Check$|^CheckViaIdentity$
  #   remove: true

  - where:
      verb: Move
      subject: ^Namespace$
      variant: ^Migrate$
    hide: true
  - where:
      verb: ^New$|^Set$
      subject: DisasterRecoveryConfiguration|^Namespace$|NamespaceAuthorizationRule|NamespaceIPFilterRule|NamespaceNetworkRuleSet|NamespaceVirtualNetworkRule|^Queue$|QueueAuthorizationRule|^Rule$|^Subscription$|^Topic$|TopicAuthorizationRule
      variant: ^Create$|^Update$
    hide: true
  - where:
      verb: New
      subject: ^NamespaceKey$|^QueueKey$|^TopicKey$
      variant: ^Regenerate$
    hide: true
  - where:
      verb: Start
      subject: ^Migration$
      variant: ^Create$
    hide: true
  - where:
      verb: Test
      subject: DisasterRecoveryConfigurationNameAvailability|NamespaceNameAvailability
      variant: ^Check$
    hide: true
```
