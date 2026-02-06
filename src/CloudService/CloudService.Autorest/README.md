<!-- region Generated -->
# Az.CloudService
This directory contains the PowerShell module for the CloudService service.

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
For information on how to develop for `Az.CloudService`, see [how-to.md](how-to.md).
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
commit: afc91d411dc6f5b8f6c6e6d5abbc46da096729e0
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04/cloudService.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2021-03-01/cloudServiceNetworkInterface.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2021-03-01/cloudServicePublicIpAddress.json

title: CloudService
module-version: 0.1.0

directive:
  - where:
      subject: ^CloudServiceOperatingSystemOSFamily$
    set:
      subject: CloudServiceOSFamily
  - where:
      subject: ^CloudServiceOperatingSystemOSVersion$
    set:
      subject: CloudServiceOSVersion
  - where:
      variant: ^Rebuild$|^RebuildViaIdentity$|^RebuildViaJsonFilePathViaJsonFilePath$|^RebuildViaJsonStringViaJsonString$
      subject: RebuildCloudService
    remove: true
  - where:
      subject: ^RebuildCloudService$
    set:
      subject: Rebuild
  - where:
      subject: Rebuild
    hide: true
  - where:
      variant: ^Restart$|^RestartViaIdentity$|^Reimage$|^ReimageViaIdentity$
      subject: ^CloudService$
    remove: true
  - where:
      variant: ^RebuildViaIdentityRoleInstance$
      subject: ^RebuildCloudServiceRoleInstance$
    remove: true

  - where:
      subject: ^CloudService$
      variant: ^ReimageExpanded$|^ReimageViaIdentityExpanded$
    set:
      subject: CloudServiceReimage
      verb: Invoke
  - where:
      subject: ^CloudServiceRoleInstance$
      variant: ^Reimage$|^ReimageViaIdentity$
    set:
      subject: CloudServiceRoleInstanceReimage
      verb: Invoke

  - where:
      subject: ^RebuildCloudServiceRoleInstance$
      variant: ^Rebuild$|^RebuildViaIdentity$
    set:
      subject: RoleInstanceRebuild

  - where:
      subject: ^CloudServicesUpdateDomain$
      verb: Get|Update
    remove: true
  - where:
      subject: ^WalkCloudServicesUpdateDomain$
      variant: ^Walk$|^WalkViaIdentity$|^WalkViaIdentityCloudService$|^WalkViaIdentityCloudServiceExpanded$|^WalkViaIdentityExpanded$|^WalkViaJsonFilePathViaJsonFilePath$|^WalkViaJsonStringViaJsonString$
    remove: true
  - where:
      subject: ^WalkCloudServicesUpdateDomain$
    set:
      subject: UpdateDomain
      verb: Set

  - where:
      subject: ^CloudServiceRole$
      verb: Get
    remove: true
  - where:
      subject: ^CloudServiceRoleInstance$
      verb: Remove|Update
    remove: true
  - where:
      variant: ^Delete$|^DeleteViaIdentity$
      subject: CloudServiceInstance
      verb: Remove
    remove: true
  - where:
      subject: ^CloudServiceInstance$
      verb: Remove
    set:
      subject: CloudServiceRoleInstance

  - where:
      subject: ^CloudService$
      verb: Update|Set
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$
      verb: New
    remove: true

  - where:
      variant: ^CreateViaIdentity$
      verb: New
    set:
      verb: Update

  - where:
      variant: ^GetViaIdentity$
      subject: ^CloudServiceRoleInstanceRemoteDesktopFile$|^CloudServiceInstanceView$|^CloudServiceRoleInstanceView$
      verb: Get
    remove: true

  - where:
      subject: ^CloudService$
      parameter-name: Name
    set:
      parameter-name: Name
      alias-name: CloudServiceName

  - where:
      subject: ^LoadBalancerProbe$|^LoadBalancerNetworkInterface$|^LoadBalancerOutboundRule$|^LoadBalancerLoadBalancingRule$|^LoadBalancerInboundNatRule$|^LoadBalancerFrontendIPConfiguration$|^LoadBalancerBackendAddressPool$|^InboundNatRule$|^LoadBalancer$|^LoadBalancerTag$
    remove: true
  - no-inline:  # choose ONE of these models to disable inlining
    - PublicIPAddressPropertiesFormat
    - IPConfiguration
    - IPConfigurationPropertiesFormat
    - PublicIPAddress
    - CloudServiceRoleProfile
    - CloudServiceOsProfile
    - CloudServiceNetworkProfile
    - CloudServiceExtensionProfile
  - where:
      subject: ^LoadBalancerPublicIPAddress$
      verb: Switch
    hide: true

  # 1. Fix the issue of naming in cloudServiceNetworkInterface.json
  # 2. Merge the operation of roleInstances and cloudServices into one cmdlet
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces"].get.operationId
    transform: >-
      return "NetworkInterfaces_ListByCloudServiceRoleInstance"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/networkInterfaces"].get.operationId
    transform: >-
      return "NetworkInterfaces_ListByCloudService"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces/{networkInterfaceName}"].get.operationId
    transform: >-
      return "NetworkInterfaces_GetByCloudService"
  
  # 1. Fix the issue of naming in cloudServicePublicIpAddress.json
  # 2. Merge the operation of roleInstances and cloudServices into one cmdlet
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/publicipaddresses"].get.operationId
    transform: >-
      return "PublicIPAddresses_ListByCloudService"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses"].get.operationId
    transform: >-
      return "PublicIPAddresses_ListByCloudServiceRoleInstance"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses/{publicIpAddressName}"].get.operationId
    transform: >-
      return "PublicIPAddresses_GetByCloudService"

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('{_frontendIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray>("frontendIPConfigurations"), out var __jsonFrontendIPConfigurations) ? If( __jsonFrontendIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ILoadBalancerFrontendIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ILoadBalancerFrontendIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerFrontendIPConfiguration.FromJson(__u) )) ))() :' + ' null' + ' :' + ' FrontendIPConfiguration;}', 'var frontendIpConfigurationJsonArray = json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray>("frontendIpConfigurations") as Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray;\n\t\t\t_frontendIPConfiguration = global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(frontendIpConfigurationJsonArray, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ILoadBalancerFrontendIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerFrontendIPConfiguration.FromJson(__u) )));');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('if ((first == \'{\' && last == \'}\') || (first == \'<\' && last == \'>\') || (first == \'[\' && last == \']\') || (first == \'"\' && last == \'"\'))\n            {','')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('            }\n\n            // base64 for everyone else\n            return new JsonString(System.Convert.ToBase64String(content));','')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('if (content.EndsWith("=="))','if (!(content.Contains("{") || content.Contains("[")))')
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.SecurityRuleProtocol = @"*";', 'public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.SecurityRuleProtocol All = @"*";')

  # - from: source-file-csharp
  #   where: 
  #   transform: return new JsonString(System.Text.Encoding.UTF8.GetString(content));
            
  - where:
      model-name: CloudService
    set:
      format-table:
        properties:
          - ResourceGroupName
          - Name
          - Location
          - ProvisioningState
  - where:
      model-name: Extension
    set:
      format-table:
        properties:
          - Name
          - Publisher
          - Type
          - TypeHandlerVersion
          - ProvisioningState
  - where:
      model-name: CloudServiceRoleProfileProperties
    set:
      format-table:
        properties:
          - Name
          - SkuName
          - SkuTier
          - SkuCapacity
  - where:
      model-name: LoadBalancerConfiguration
    set:
      format-table:
        properties:
          - Name
          - FrontendIPConfiguration

  - where:
      model-name: RoleInstanceView
    set:
      format-table:
        properties:
          - Statuses
          - PlatformFaultDomain
          - PlatformUpdateDomain

  - where:
      model-name: RoleInstance
    set:
      format-table:
        properties:
          - Name
          - Location
          - SkuName
          - SkuTier
  - where:
      model-name: OSVersion
    set:
      format-table:
        properties:
          - Name
          - Label
          - IsDefault
          - IsActive
          - Family
          - FamilyLabel
  - where:
      model-name: OSFamily
    set:
      format-table:
        properties:
          - Name
          - Label

  - where:
      model-name: CloudServiceInstanceView
    set:
      format-table:
        properties:
          - Statuses
          - RoleInstanceStatusesSummary

  # CloudService change the type to object to fix some issues in C# SDK.
  # But they are still passed as string in HTTP request. So we keep them string.
  - from: swagger-document
    where: $.definitions.CloudServiceExtensionProperties.properties.settings.type
    transform: >-
      return "string"
  - from: swagger-document
    where: $.definitions.CloudServiceExtensionProperties.properties.protectedSettings.type
    transform: >-
      return "string"

  - model-cmdlet:
      - model-name: Extension
        cmdlet-name: New-AzCloudServiceExtensionObject
      - model-name: LoadBalancerConfiguration
        cmdlet-name: New-AzCloudServiceLoadBalancerConfigurationObject
      # - model-name: LoadBalancerFrontendIPConfiguration
      #   cmdlet-name: New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject
      - model-name: CloudServiceRoleProfileProperties
        cmdlet-name: New-AzCloudServiceRoleProfilePropertiesObject
      # - model-name: CloudServiceVaultSecretGroup
      #   cmdlet-name: New-AzCloudServiceVaultSecretGroupObject
```
