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
commit: 03253947022beee13bf4782c4ebef93a0afa237b
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2025-10-01/webapplicationfirewall.json
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2025-10-01/network.json
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2025-10-01/frontdoor.json

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

  - where:
      variant: ^EnableViaIdentityFrontDoorExpanded$
    remove: true
  - where:
      variant: ^EnableViaIdentityExpanded$
    remove: true
  - no-inline:  # choose ONE of these models to disable inlining
    - BackendPoolsSettings
    - RouteConfiguration
    - PolicySettingsLogScrubbing
    - CacheConfiguration
    - RulesEngineAction
    - PolicySettings

  - from: swagger-document
    where: $.definitions.RouteUpdatePropertiesParameters.properties.supportedProtocols
    transform: delete $.default
  - from: swagger-document
    where: $.definitions.PolicySettings.properties.logScrubbing
    transform: $['x-ms-client-flatten'] = false;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsConfiguration
    transform: >- 
      return {
        "description": "The configuration specifying how to enable HTTPS",
        "$ref": "#/definitions/CustomHttpsConfiguration"
      }

  # For New object model cmdlet
  - model-cmdlet:
    # - model-name: Backend
    #   cmdlet-name: New-AzFrontDoorBackendObject
    # - model-name: BackendPool
    #   cmdlet-name: New-AzFrontDoorBackendPoolObject
    # - model-name: BackendPoolsSettings
    #   cmdlet-name: New-AzFrontDoorBackendPoolsSettingsObject
    # - model-name: FrontendEndpoint
    #   cmdlet-name: New-AzFrontDoorFrontendEndpointObject
    - model-name: HeaderAction
      cmdlet-name: New-AzFrontDoorHeaderActionObject
    # - model-name: HealthProbeSettingsModel
    #   cmdlet-name: New-AzFrontDoorHealthProbeSettingObject
    # - model-name: LoadBalancingSettingsModel
    #   cmdlet-name: New-AzFrontDoorLoadBalancingSettingObject
    # - model-name: RoutingRule
    #   cmdlet-name: New-AzFrontDoorRoutingRuleObject
    # - model-name: RulesEngineAction
    #   cmdlet-name: New-AzFrontDoorRulesEngineActionObject
    # - model-name: RulesEngineMatchCondition
    #   cmdlet-name: New-AzFrontDoorRulesEngineMatchConditionObject
    # - model-name: RulesEngineRule
    #   cmdlet-name: New-AzFrontDoorRulesEngineRuleObject
    # - model-name: CustomRule
    #   cmdlet-name: New-AzFrontDoorWafCustomRuleObject
    # - model-name: ManagedRuleOverride
    #   cmdlet-name: New-AzFrontDoorWafManagedRuleOverrideObject
    - model-name: MatchCondition
      cmdlet-name: New-AzFrontDoorWafMatchConditionObject
    - model-name: ManagedRuleGroupOverride
      cmdlet-name: New-AzFrontDoorWafRuleGroupOverrideObject 
    - model-name: GroupByVariable
      cmdlet-name: New-AzFrontDoorWafCustomRuleGroupByVariableObject
    - model-name: ManagedRuleExclusion
      cmdlet-name: New-AzFrontDoorWafManagedRuleExclusionObject
    # - model-name: ManagedRuleSet
    #   cmdlet-name: New-AzFrontDoorWafManagedRuleObject
    - model-name: PolicySettingsLogScrubbing
      cmdlet-name: New-AzFrontDoorWafLogScrubbingSettingObject
    - model-name: WebApplicationFirewallScrubbingRules
      cmdlet-name: New-AzFrontDoorWafLogScrubbingRuleObject
    - model-name: ForwardingConfiguration
      cmdlet-name: New-AzFrontDoorForwardingConfigurationObject
    - model-name: RedirectConfiguration
      cmdlet-name: New-AzFrontDoorRedirectConfigurationObject
    - model-name: CacheConfiguration
      cmdlet-name: New-AzFrontDoorCacheConfigurationObject
    # - model-name: RouteConfiguration
    #   cmdlet-name: New-AzFrontDoorRouteConfigurationObject
    - model-name: PolicySettings
      cmdlet-name: New-AzFrontDoorPolicySettingsObject

  # Rename
  - where: 
      subject: Policy
    set:
      subject: WafPolicy
  - where:
      verb: Get
      subject: ManagedRuleSet
    set:
      verb: Get
      subject: WafManagedRuleSetDefinition
  - where:
      verb: Set 
      subject: WafPolicy
    hide: true
  # Hide Waf
  - where:
      verb: New
      subject: WafPolicy
    hide: true
  # Hide for customization
  - where:
      verb: Update
      subject: WafPolicy
    hide: true
  - remove-operation: Policies_Update
  # Hide unused
  - where:
      verb: Test
    hide: true
  - where:
      verb: Set
      subject: FrontDoor
    hide: true
    
  - where:
      verb: Get
      subject: FrontendEndpoint
    hide: true

  - where:
      subject: FrontendEndpointHttps
    set:
      subject: CustomDomainHttps
  - where:
      verb: Enable
      subject: CustomDomainHttps
      parameter-name: KeyVaultCertificateSourceParameterSecretName
    set:
      parameter-name: SecretName
  - where:
      verb: Enable
      subject: CustomDomainHttps
      parameter-name: KeyVaultCertificateSourceParameterSecretVersion
    set:
      parameter-name: SecretVersion
  - where:
      verb: Enable
      subject: CustomDomainHttps
      parameter-name: FrontDoorCertificateSourceParameterCertificateType
    set:
      parameter-name: CertificateType
  - where:
      verb: Enable
      subject: CustomDomainHttps
      parameter-name: MinimumTlsVersion
    set:
      default:
        script: '1.2'
  - where:
      verb: Enable
      subject: CustomDomainHttps
    hide: true

  # AzFrontDoor
  - where:
      subject: FrontDoor
      parameter-name: Location
    hide: true
    set:
      default:
        script: '"global"'
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: EnabledState
    set:
      default:
        script: '"Enabled"'
  # Customize
  - where:
      verb: New
      subject: FrontDoor
    hide: true
  - where:
      verb: Update
      subject: FrontDoor
    hide: true
  # AzFrontDoorWafPolicy
  - where:
      subject: WafPolicy
      parameter-name: Location
    hide: true
    set:
      default:
        script: '"global"'
  - where:
      subject: WafPolicy
      parameter-name: CustomRule
    set:
      parameter-name: Customrule

  # Clear-AzFrontDoorEndpointContent rename to Remove-AzFrontDoorContent
  - where:
      verb: Clear
      subject: EndpointContent
    set:
      verb: Remove
      subject: Content

  - where:
      verb: Remove 
      subject: Content
      parameter-name: FrontDoorName
    set:
      parameter-name: Name

  # Update Rules Engine rename, and hide set
  - where:
      verb: Set
      subject: RulesEngine
    hide: true
  - where:
      verb: Update
      subject: RulesEngine
    set:
      verb: Set

  # Breaking change avoid rename
  # New-AzFrontDoorHeaderActionObject
  - where:
      model-name: HeaderAction
      property-name: Type
    set:
      property-name: HeaderActionType

  - where:
      model-name: Backend
      property-name: HostHeader
    set:
      property-name: BackendHostHeader      

  - where:
      model-name: BackendPoolsSettings
      property-name: SendRecvTimeoutSecond
    set:
      property-name: SendRecvTimeoutInSeconds
      
  - where:
      model-name: FrontendEndpoint
      property-name: CustomHttpsConfigurationCertificateSource
    set:
      property-name: CertificateSource
  - where:
      model-name: FrontendEndpoint
      property-name: CustomHttpsConfigurationMinimumTlsVersion
    set:
      property-name: MinimumTlsVersion
  - where:
      model-name: FrontendEndpoint
      property-name: FrontDoorCertificateSourceParameterCertificateType
    set:
      property-name: CertificateType
  - where:
      model-name: FrontendEndpoint
      property-name: KeyVaultCertificateSourceParameterSecretName
    set:
      property-name: SecretName
  - where:
      model-name: FrontendEndpoint
      property-name: KeyVaultCertificateSourceParameterSecretVersion
    set:
      property-name: SecretVersion
  - where:
      model-name: FrontendEndpoint
      property-name: SessionAffinityTtlSecond
    set:
      property-name: SessionAffinityTtlInSeconds
  - where:
      model-name: FrontendEndpoint
      property-name: VaultId
    set:
      property-name: Vault     
  - where:
      model-name: FrontendEndpoint
      property-name: CustomHttpsConfigurationProtocolType
    set:
      property-name: ProtocolType          

  - where:
      model-name: HealthProbeSettingsModel
      property-name: IntervalInSecond
    set:
      property-name: IntervalInSeconds

  - where:
      model-name: LoadBalancingSettingsModel
      property-name: AdditionalLatencyMillisecond
    set:
      property-name: AdditionalLatencyInMilliseconds
    
  - where:
      model-name: CustomRule
      property-name: RateLimitDurationInMinute
    set:
      property-name: RateLimitDurationInMinutes

  - where:
      model-name: WebApplicationFirewallPolicy
      property-name: CustomRule
    set:
      property-name: CustomRuleList
  - where:
      model-name: WebApplicationFirewallPolicy
      property-name: CustomRuleRules
    set:
      property-name: Customrule

  - where:
      model-name: ManagedRuleExclusion
      property-name: MatchVariable
    set:
      property-name: Variable 
  - where:
      model-name: ManagedRuleExclusion
      property-name: SelectorMatchOperator
    set:
      property-name: Operator 

  - where:
      model-name: ManagedRuleSet
      property-name: RuleSetType
    set:
      property-name: Type 
  - where:
      model-name: ManagedRuleSet
      property-name: RuleSetVersion
    set:
      property-name: Version 

  - where:
      model-name: ManagedRuleGroupOverride
      property-name: Rule
    set:
      property-name: ManagedRuleOverride 

  - where:
      model-name: MatchCondition
      property-name: Operator
    set:
      property-name: OperatorProperty

  - where:
      model-name: RulesEngineMatchCondition
      property-name: RulesEngineMatchValue
    set:
      property-name: MatchValue
  - where:
      model-name: RulesEngineMatchCondition
      property-name: RulesEngineMatchVariable
    set:
      property-name: MatchVariable
  - where:
      model-name: RulesEngineMatchCondition
      property-name: RulesEngineOperator
    set:
      property-name: Operator
  - where:
      model-name: PolicySettings
      property-name: JavascriptChallengeExpirationInMinute
    set:
      property-name: JavascriptChallengeExpirationInMinutes
  - where:
      model-name: PolicySettings
      property-name: CaptchaExpirationInMinute
    set:
      property-name: CaptchaExpirationInMinutes
  - where:
      model-name: PolicySettings
      property-name: LogScrubbing
    set:
      property-name: LogScrubbingSetting
  - where:
      model-name: CustomRule
      property-name: GroupBy
    set:
      property-name: GroupByCustomRule
  - where: 
      model-name: RulesEngine
      property-name: Rule
    set:
      property: RulesEngineRule

```
