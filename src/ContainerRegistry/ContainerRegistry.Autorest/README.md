<!-- region Generated -->
# Az.ContainerRegistry
This directory contains the PowerShell module for the ContainerRegistry service.

---
## Status
[![Az.ContainerRegistry](https://img.shields.io/powershellgallery/v/Az.ContainerRegistry.svg?style=flat-square&label=Az.ContainerRegistry "Az.ContainerRegistry")](https://www.powershellgallery.com/packages/Az.ContainerRegistry/)

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
For information on how to develop for `Az.ContainerRegistry`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 891dd18a70057c2fee388573117683e6d0081bda
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/66174681c09b101de03fd35399080cfbccc93e8f/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/preview/2023-01-01-preview/containerregistry.json
  - https://github.com/Azure/azure-rest-api-specs/blob/66174681c09b101de03fd35399080cfbccc93e8f/specification/containerregistry/resource-manager/Microsoft.ContainerRegistry/preview/2019-06-01-preview/containerregistry_build.json
module-version: 0.1.0
title: ContainerRegistry
subject-prefix: $(service-name)

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

directive:
# Remove cmdlet, Private link related resource should be ignored. 
- where:
    subject: RegistryPrivateLinkResource
  hide: true
# Remove the unexpanded parameter set
- where:
    variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^CreateViaIdentity$|^ImportViaIdentity$|^ImportViaIdentityExpanded$|^CheckViaIdentity$|^CheckViaIdentityExpanded$|^PingViaIdentity$|^Check$|^RegenerateViaIdentity$
  remove: true
- where:
    subject: PrivateEndpointConnection
  hide: true
- where:
    subject: (.*)ConnectedRegistry
  hide: true
- where:
    verb: New
    subject: RegistryCredentials
  hide: true
- where:
    subject: (.*)(Run)
  hide: true
- where:
    verb: update
    subject: Replication 
  hide: true
- where:
    subject: CacheRule
  hide: true
- where:
    subject: (.*)CredentialSet
  hide: true
- where:
    subject: (.*)Task(.*)
  hide: true
- where:
    subject: (.*)UploadUrl
  hide: true
- where:
    verb: Ping
  set: 
    verb: Test
- where:
    verb: New
    subject: RegistryCredential
  set:
    verb: Update
- model-cmdlet:
    - IPRule
- where:
    verb: Get
    subject: RegistryCredentials
  set:
    subject: RegistryCredential
- where:
    parameter-name: AdminUserEnabled
  set:
    parameter-name: EnableAdminUser
- where:
    parameter-name: SkuName
  set:
    parameter-name: Sku

    
- where:
    parameter-name: ServiceUri
  set:
    alias: Uri
- where:
    parameter-name: Tag
  set:
    alias: Tags
- where:
    parameter-name: CustomHeader
  set:
    alias: Header
- where:
    verb: Get
    subject: RegistryCredential|RegistryUsage
    parameter-name: RegistryName
  set:
    alias: Name
- where:
    verb: Get
    subject: Replication
    parameter-name: Name
  set:
    alias: 
    - ResourceName
    - ReplicationName
- where:
    subject: Replication|Webhook|WebhookEvent
    parameter-name: RegistryName
  set:
    alias: ContainerRegistryName
- where:
    subject: Webhook
    parameter-name: Name
  set:
    alias: 
    - WebhookName
    - ResourceName
- where:
    subject: Registry
    parameter-name: Name
  set:
    alias: 
    - RegistryName
    - ResourceName
    - ContainerRegistryName
- where:
    subject: Replication
    parameter-name: Location
  set:
    alias: ReplicationLocation
- where:
    subject: Replication
    parameter-name: Name
  set:
    alias: 
    - ReplicationName
    - ResourceName
- where:
    verb: Update
    subject: RegistryCredential
    parameter-name: Name
  set:
    parameter-name: PasswordName
- where:
    verb: Update
    subject: RegistryCredential
    parameter-name: RegistryName
  set:
    alias: 
    - ContainerRegistryName
    - Name
    - ResourceName
- where:
    verb: Import
    subject: RegistryImage
    parameter-name: CredentialsPassword
  set:
    parameter-name: Password
- where:
    verb: Import
    subject: RegistryImage
    parameter-name: CredentialsUsername
  set:
    parameter-name: Username
- where:
    verb: Import
    subject: RegistryImage
    parameter-name: SourceResourceId
  set:
    alias: SourceRegistryResourceId

#Format
- where:
    model-name: Webhook
  set:
    format-table: 
      properties:
        - Name
        - Location
        - Status
        - Scope
        - Actions
        - ProvisioningState
- where:
    model-name: Event
  set:
    format-table: 
      properties:
        - ID
        - ContentAction
        - ContentTimestamp
        - ResponseMessageStatusCode
- where:
    model-name: ScopeMap
  set:
    format-table: 
      properties:
        - Name
        - Action
        - Type
- where:
    model-name: Registry
  set:
    format-table: 
      properties:
        - Name
        - SkuName
        - LoginServer
        - CreationDate
        - ProvisioningState
        - AdminUserEnabled
- where:
    model-name: Replication
  set:
    format-table: 
      properties:
        - Name
        - Location
        - ProvisioningState
        - Status
        - StatusTimestamp
- where:
    model-name: AgentPool
  set:
    format-table: 
      properties:
        - Name
        - Location
        - OS
        - Count
        - ProvisioningState
- where:
    model-name: Token 
  set:
    format-table: 
      properties:
        - Name
        - Status
        - ProvisioningState
        - Type
        - ResourceGroupName

# custom hide
- where:
    verb: Get
    subject: RegistryCredential|Replication
  hide: true
- where:
    verb: Get
    subject: (.*)WebhookEvent
  hide: true
- where:
    verb: Get
    subject: Webhook
  hide: true
- where:
    verb: New
    subject: Replication|Webhook
  hide: true
- where:
    verb: Test
    subject: Webhook
  hide: true  
- where:
    verb: Update
    subject: RegistryCredential
  hide: true
- where:
    verb: Get
    subject: Registry
  hide: true
# preview cmdlet
- where:
    subject: (.*)AgentPool(.*)|(.*)Pipeline|(.*)ScopeMap|(.*)Token|(.*)WebhookCallbackConfig
  set:
    preview-message: This is a preview version of ContainerRegistry. Let us know if you run into any issues.
