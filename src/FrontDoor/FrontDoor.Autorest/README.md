<!-- region Generated -->
# Az.FrontDoor
This directory contains the PowerShell module for the FrontDoor service.

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
For information on how to develop for `Az.FrontDoor`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: cf9f241708ed82f2dad218fed3c09ca5fd191311
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
input-file:
# You need to specify your swagger files here.
  # - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2024-09-01/afdx.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/webapplicationfirewall.json
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2019-11-01/networkexperiment.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2024-03-01/network.json
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2021-06-01/frontdoor.json

try-require: 
  - $(repo)/specification/xxx/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: FrontDoor
subject-prefix: $(service-name)

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - no-inline:  # choose ONE of these models to disable inlining
    - NetworkInterfaceIPConfiguration
    #- NetworkInterfaceIPConfigurationPropertiesFormat
    - PublicIPAddress
    #- PublicIPAddressPropertiesFormat
    - IPConfiguration
    #- IPConfigurationPropertiesFormat
    - BackendPoolsSettings

  - from: swagger-document
    where: $.definitions.RouteUpdatePropertiesParameters.properties.supportedProtocols
    transform: delete $.default
  - from: swagger-document
    where: $.definitions.PolicySettings.properties.logScrubbing
    transform: $['x-ms-client-flatten'] = false;

  # For New object model cmdlet
  - model-cmdlet:
    # - model-name: Backend
    #   cmdlet-name: New-AzFrontDoorFrontendBackendObject
    # # New-AzFrontDoorFrontendBackendObject
    # - where:
    #     model-name: Backend
    #     property-name: HostHeader
    #   set:
    #     property-name: BackendHostHeader
    # - model-name: BackendPool
    #   cmdlet-name: New-AzFrontDoorFrontendBackendPoolObject
    # - model-name: BackendPoolsSettings
    #   cmdlet-name: New-AzFrontDoorFrontendBackendPoolsSettingsObject
    # - model-name: FrontendEndpoint
    #   cmdlet-name: New-AzFrontDoorFrontendEndpointObject
    - model-name: HeaderAction
      cmdlet-name: New-AzFrontDoorHeaderActionObject
    - model-name: HealthProbeSettingsModel
      cmdlet-name: New-AzFrontDoorHealthProbeSettingObject
    - model-name: LoadBalancingSettingsModel
      cmdlet-name: New-AzFrontDoorLoadBalancingSettingObject
    # - model-name: RoutingRule
    #   cmdlet-name: New-AzFrontDoorRoutingRuleObject
    - model-name: RulesEngineAction
      cmdlet-name: New-AzFrontDoorRulesEngineActionObject
    - model-name: RulesEngineMatchCondition
      cmdlet-name: New-AzFrontDoorRulesEngineMatchConditionObject
    - model-name: RulesEngineRule
      cmdlet-name: New-AzFrontDoorRulesEngineRuleObject
    - model-name: CustomRule
      cmdlet-name: New-AzFrontDoorCustomRuleObject
    - model-name: ManagedRuleOverride
      cmdlet-name: New-AzFrontDoorWafManagedRuleOverrideObject
    - model-name: MatchCondition
      cmdlet-name: New-AzFrontDoorWafMatchConditionObject
    - model-name: ManagedRuleGroupOverride
      cmdlet-name: New-AzFrontDoorWafRuleGroupOverrideObject 
    - model-name: GroupByVariable
      cmdlet-name: New-AzFrontDoorWafCustomRuleGroupByVariableObject
    - model-name: ExclusionManagedRule
      cmdlet-name: New-AzFrontDoorWafCustomRuleExclusionManagedRuleObject
    - model-name: PolicySettingsLogScrubbing
      cmdlet-name: New-AzFrontDoorWafLogScrubbingSettingObject 
    - model-name: WebApplicationFirewallScrubbingRules
      cmdlet-name: New-AzFrontDoorWafLogScrubbingRuleObject 
    - model-name: WebApplicationFirewallCustomRule
      cmdlet-name: New-AzFrontDoorWafCustomRuleObject 
  # Rename
  - where: 
      subject: WebApplicationFirewallPolicy
    set:
      subject: WafPolicy

  # Enable-AzFrontDoorFrontendEndpointHttps
  - where:
      verb: Enable
      subject: FrontendEndpointHttps
      parameter-name: KeyVaultCertificateSourceParameterSecretName
    set:
      parameter-name: SecretName
  - where:
      verb: Enable
      subject: FrontendEndpointHttps
      parameter-name: KeyVaultCertificateSourceParameterSecretVersion
    set:
      parameter-name: SecretVersion
  - where:
      verb: Enable
      subject: FrontendEndpointHttps
      parameter-name: FrontDoorCertificateSourceParameterCertificateType
    set:
      parameter-name: CertificateType

  # Breaking change avoid rename
  # New-AzFrontDoorHeaderActionObject
  - where:
      model-name: HeaderAction
      property-name: Type
    set:
      property-name: HeaderActionType

  # New-AzFrontDoorHealthProbeSettingObject
  - where:
      model-name: HealthProbeSettingsModel
      property-name: IntervalInSecond
    set:
      property-name: IntervalInSeconds

  # New-AzFrontDoorLoadBalancingSettingsObject
  - where:
      model-name: LoadBalancingSettingsModel
      property-name: AdditionalLatencyInMillisecond
    set:
      property-name: AdditionalLatencyInMilliseconds 

```
