In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml

commit: f11631f1c1057d8363f9e3f9597c73b90f8924c8
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2025-03-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2025-03-01/webapplicationfirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2021-06-01/frontdoor.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)//specification/frontdoor/resource-manager/Microsoft.Network/stable/2019-11-01/networkexperiment.json

# csharp: true
isSdkGenerator: true
powershell: true
clear-output-folder: true
openapi-type: arm
azure-arm: true
output-folder: Generated
namespace: Microsoft.Azure.Management.FrontDoor
title: FrontDoor

directive:
  - from: swagger-document
    where: $.definitions.RouteUpdatePropertiesParameters.properties.supportedProtocols
    transform: delete $.default
  - from: swagger-document
    where: $.definitions.PolicySettings.properties.logScrubbing
    transform: $['x-ms-client-flatten'] = false;
  - where:
      model-name: FrontDoor
    set:
      model-name: FrontDoorModel


  - where:
      verb: Disable
      subjectPrefix: FrontDoor
      subject: CustomDomainHttps
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        replacement-cmdlet-output-type: System.Boolean
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Enable
      subjectPrefix: FrontDoor
      subject: CustomDomainHttps
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        replacement-cmdlet-output-type: System.Boolean
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subject: FrontDoor
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoor
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: FrontendEndpoint
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: RulesEngine
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngine
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngine
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngine'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafManagedRuleSetDefinition
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleSetDefinition
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSetDefinition
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleSetDefinition'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafPolicy
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSPolicy
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallPolicy
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSPolicy'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: BackendObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackend
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.Backend
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackend'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: BackendPoolObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.BackendPool
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: BackendPoolsSettingObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.BackendPoolsSettings
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: FrontendEndpointObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.FrontendEndpoint
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: HeaderActionObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.HeaderAction
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: HealthProbeSettingObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.HealthProbeSettingsModel
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: LoadBalancingSettingObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.LoadBalancingSettingsModel
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: RoutingRuleObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RoutingRule
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: RulesEngineActionObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineAction
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: RulesEngineMatchConditionObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchCondition
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineMatchCondition
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchCondition'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: RulesEngineRuleObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineRule
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafCustomRuleObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.CustomRule
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafLogScrubbingSettingObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.PolicySettingsLogScrubbing
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafManagedRuleObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRule
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleSet
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafManagedRuleOverrideObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRuleOverride
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleOverride
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRuleOverride'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafRuleGroupOverrideObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleGroupOverride
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: WafRuleGroupOverrideObject
    set:
      breaking-change:
        deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride
        replacement-cmdlet-output-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleGroupOverride
        change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  # - where:
  #     verb: Remove
  #     subject: FrontDoor
  #   set:
  #     breaking-change:
  #       deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor
  #       replacement-cmdlet-output-type: System.Boolean
  #       change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor'.
  #       deprecated-by-version: 5.0.0
  #       deprecated-by-azversion: 14.0.0
  #       change-effective-date: 2025/5/19
  # - where:
  #     verb: Remove
  #     subjectPrefix: FrontDoor
  #     subject: Content
  #   set:
  #     breaking-change:
  #       deprecated-cmdlet-output-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor
  #       replacement-cmdlet-output-type: System.Boolean
  #       change-description: no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor'.
  #       deprecated-by-version: 5.0.0
  #       deprecated-by-azversion: 14.0.0
  #       change-effective-date: 2025/5/19
  - where:
      subjectPrefix: FrontDoor
      subject: FrontendEndpoint
      parameter-name: FrontDoorObject
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoor' for parameter 'FrontDoorObject'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: RoutingRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule[]
        change-description: The element type for parameter 'RoutingRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: BackendPool
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool[]
        change-description: The element type for parameter 'BackendPool' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: FrontendEndpoint
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint[]
        change-description: The element type for parameter 'FrontendEndpoint' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: LoadBalancingSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel[]
        change-description: The element type for parameter 'LoadBalancingSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: HealthProbeSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel[]
        change-description: The element type for parameter 'HealthProbeSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subject: FrontDoor
      parameter-name: BackendPoolsSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPoolsSettings
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting' for parameter 'BackendPoolsSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: BackendObject
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: DoorBackendPoolObject
      parameter-name: Backend
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackend
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackend[]
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackend' for parameter 'Backend'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: BackendPoolsSettingObject
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: FrontendEndpointObject
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: HeaderActionObject
      parameter-name: HeaderActionType
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderActionType
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderActionType' for parameter 'HeaderActionType'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: HealthProbeSettingObject
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: HealthProbeSettingObject
      parameter-name: Protocol
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSProtocol
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSProtocol' for parameter 'Protocol'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RoutingRuleObject
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RoutingRuleObject
      parameter-name: DynamicCompression
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'DynamicCompression'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RoutingRuleObject
      parameter-name: AcceptedProtocol
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSProtocol
        new-parameter-type: System.String[]
        change-description: The element type for parameter 'AcceptedProtocol' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSProtocol' to 'System.String'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngine
      parameter-name: Rule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineRule[]
        change-description: The element type for parameter 'Rule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineActionObject
      parameter-name: RequestHeaderAction
    set:
      breaking-change:
        old-parameter-type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]
        change-description: no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]' for parameter 'RequestHeaderAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineActionObject
      parameter-name: ResponseHeaderAction
    set:
      breaking-change:
        old-parameter-type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]
        change-description: no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]' for parameter 'ResponseHeaderAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineActionObject
      parameter-name: ResponseHeaderAction
    set:
      breaking-change:
        old-parameter-type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]
        change-description: no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]' for parameter 'ResponseHeaderAction'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineActionObject
      parameter-name: DynamicCompression
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'DynamicCompression'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineMatchConditionObject
      parameter-name: MatchVariable
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchVariable
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchVariable' for parameter 'MatchVariable'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineMatchConditionObject
      parameter-name: Operator
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineOperator
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineOperator' for parameter 'Operator'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineMatchConditionObject
      parameter-name: Transform
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSTransform
        new-parameter-type: System.String[]
        change-description: The element type for parameter 'Transform' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSTransform' to 'System.String'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: EngineRuleObject
      parameter-name: Action
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction
        new-parameter-type: System.String
        change-description: The type for parameter 'Action' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction' to 'System.String'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: EngineRuleObject
      parameter-name: MatchProcessingBehavior
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSMatchProcessingBehavior
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSMatchProcessingBehavior' for parameter 'MatchProcessingBehavior'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: RulesEngineMatchConditionObject
      parameter-name: MatchCondition
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchCondition
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineMatchCondition[]
        change-description: The element type for parameter 'MatchCondition' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineMatchCondition' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineMatchCondition'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafCustomRuleObject
      parameter-name: MatchCondition
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSMatchCondition
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IMatchCondition[]
        change-description: The element type for parameter 'MatchCondition' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSMatchCondition' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IMatchCondition'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafCustomRuleObject
      parameter-name: CustomRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafCustomRuleGroupByVariable
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IGroupByVariable[]
        change-description: The element type for parameter 'CustomRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafCustomRuleGroupByVariable' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IGroupByVariable'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafLogScrubbingSettingObject
      parameter-name: ScrubbingRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallScrubbingRules[]
        change-description: The element type for parameter 'ScrubbingRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallScrubbingRules'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafManagedRuleObject
      parameter-name: RuleGroupOverride
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleGroupOverride[]
        change-description: The element type for parameter 'RuleGroupOverride' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleGroupOverride'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafManagedRuleObject
      parameter-name: Exclusion
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]
        change-description: The element type for parameter 'Exclusion' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafManagedRuleOverrideObject
      parameter-name: Exclusion
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]
        change-description: The element type for parameter 'Exclusion' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: Customrule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomRule[]
        change-description: The element type for parameter 'Customrule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: ManagedRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSet[]
        change-description: The element type for parameter 'ManagedRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSet'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: LogScrubbingSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IPolicySettingsLogScrubbing
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting' for parameter 'LogScrubbingSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafRuleGroupOverrideObject
      parameter-name: ManagedRuleOverride
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRuleOverride
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleOverride[]
        change-description: The element type for parameter 'ManagedRuleOverride' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRuleOverride' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleOverride'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: New
      subjectPrefix: FrontDoor
      subject: WafRuleGroupOverrideObject
      parameter-name: Exclusion
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]
        change-description: The element type for parameter 'Exclusion' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: RoutingRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule[]
        change-description: The element type for parameter 'RoutingRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRoutingRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: BackendPool
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool[]
        change-description: The element type for parameter 'BackendPool' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPool' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: FrontendEndpoint
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint[]
        change-description: The element type for parameter 'FrontendEndpoint' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontendEndpoint' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: LoadBalancingSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel[]
        change-description: The element type for parameter 'LoadBalancingSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSLoadBalancingSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: HealthProbeSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel[]
        change-description: The element type for parameter 'HealthProbeSetting' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSHealthProbeSetting' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subject: FrontDoor
      parameter-name: BackendPoolsSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPoolsSettings
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSetting' for parameter 'BackendPoolsSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Set
      subjectPrefix: FrontDoor
      subject: RulesEngine
      parameter-name: Rule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineRule[]
        change-description: The element type for parameter 'Rule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Update
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: EnabledState
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState
        new-parameter-type: System.String
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'EnabledState'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Update
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: Customrule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomRule[]
        change-description: The element type for parameter 'Customrule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSCustomRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomRule'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Update
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: ManagedRule
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRule
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSet[]
        change-description: The element type for parameter 'ManagedRule' has been changed from 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRule' to 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSet'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19
  - where:
      verb: Update
      subjectPrefix: FrontDoor
      subject: WafPolicy
      parameter-name: LogScrubbingSetting
    set:
      breaking-change:
        old-parameter-type: Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting
        new-parameter-type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IPolicySettingsLogScrubbing
        change-description: no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafLogScrubbingSetting' for parameter 'LogScrubbingSetting'.
        deprecated-by-version: 5.0.0
        deprecated-by-azversion: 14.0.0
        change-effective-date: 2025/5/19






