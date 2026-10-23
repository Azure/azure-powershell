# Overall
This directory contains management plane service clients of Az.Monitor module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
title: MonitorManagementClient
description: Monitor Management Client
payload-flattening-threshold: 1
```

###
``` yaml
commit: 92cf370fd73318f3cf92c36403274ba695873857
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/autoscale_API.json
  # - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json
  # - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/alertRulesIncidents_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/alertRules_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2016-03-01/logProfiles_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-05-01-preview/diagnosticsSettings_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/activityLogs_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/eventCategories_API.json
  # - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/tenantActivityLogs_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metrics_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2019-03-01/metricBaselines_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-03-01/metricAlert_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
  # - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/preview/2018-11-27-preview/vmInsightsOnboarding_API.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/monitor/resource-manager/Microsoft.Insights/preview/2019-10-17-preview/privateLinkScopes_API.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Monitor

directive:
  - suppress: Example Validations
    reason: There are open issues (bugs) in the validator affecting some of the examples and since there is no way to selectively disable the validation for a particular example or paths, all of the example validation is being turned off.
  - suppress: R4009
    from: privateLinkScopes_API.json
    reason: 'Contract is defined in the Network RP private endpoint spec, can be updated by internal calls from Network RP. '
  - suppress: R3018
    from: privateLinkScopes_API.json
    where: $.definitions.PrivateEndpointConnectionProperties.properties.queryOnlyPrivateLinkResources
    reason: 'This property indicates whether data coming through this private endpoint should restrict itself only to resources in the scope - it has only ''''true'''' or ''''false'''' options, so it fits boolean type.'
  - suppress: R3018
    from: privateLinkScopes_API.json
    where: $.definitions.PrivateEndpointConnectionProperties.properties.ingestOnlyToPrivateLinkResources
    reason: 'This property indicates whether data coming through this private endpoint should restrict itself only to resources in the scope - it has only ''''true'''' or ''''false'''' options, so it fits boolean type.'
  - suppress: OperationsAPIImplementation
    from: privateLinkScopes_API.json
    where: $.paths
    reason: 'Operations API is defined in a separate swagger spec for Microsoft.Insights namespace (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json)'
  - suppress: R3016
    reason: The feature (polymorphic types) is in the process of deprecation and fixing this will require changes in the backend.

  - suppress: MissingTypeObject
    from: metrics_API.json
    where: $.definitions.LocalizableString
    reason: 'LocalizableString exists in other swaggers my team can not modify'
  - suppress: MissingTypeObject
    from: metricDefinitions_API.json
    where: $.definitions.LocalizableString
    reason: 'LocalizableString exists in other swaggers my team can not modify'
  - suppress: OperationsAPIImplementation
    where: $.paths
    from: activityLogAlerts_API.json
    reason: 'Operations API is defined in a separate swagger spec for Microsoft.Insights namespace (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json)'
  - suppress: R3016
    where: $.definitions.Action.properties["odata.type"]
    reason: 'This is an old field in a stable api version which is not camel cased'
  - suppress: EnumInsteadOfBoolean
    where: $.definitions.AlertRuleProperties.properties.enabled
    from: activityLogAlerts_API.json
    reason: 'This property indicates whether the alert rule is enabled or not  - it has only ''''true'''' or ''''false'''' options, so it fits boolean type.'
  - suppress: EnumInsteadOfBoolean
    where: $.definitions.AlertRulePatchProperties.properties.enabled
    from: activityLogAlerts_API.json
    reason: 'This property indicates whether the alert rule is enabled or not  - it has only ''''true'''' or ''''false'''' options, so it fits boolean type.'
  - suppress: DefaultErrorResponseSchema
    from: activityLogAlerts_API.json
    reason: 'Updating the error response to the new format would be a breaking change.'
  - suppress: DefaultErrorResponseSchema
    from: metricNamespaces_API.json
    reason: 'Updating the error response to the new format would be a breaking change.'
  - suppress: DefaultErrorResponseSchema
    from: metrics_API.json
    reason: 'Updating the error response to the new format would be a breaking change.'
  - suppress: DefaultErrorResponseSchema
    from: metricDefinitions_API.json
    reason: 'Updating the error response to the new format would be a breaking change.'
  - suppress: OperationsAPIImplementation
    from: operations_API.json
    where: $.paths
    reason: 'The operations API is implemented however the tool is still firing due to the casing being different'
  - suppress: OperationsAPIImplementation
    from: serviceDiagnosticsSettings_API.json
    where: $.paths
    reason: 'Operations API is defined in a separate swagger spec for Microsoft.Insights namespace (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json)'
  - suppress: OperationsAPIImplementation
    from: subscriptionDiagnosticsSettings_API.json
    where: $.paths
    reason: 'Operations API is defined in a separate swagger spec for Microsoft.Insights namespace (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json)'
  - suppress: OperationsAPIImplementation
    from: autoscale_API.json
    where: $.paths
    reason: 'Operations API is defined in a separate swagger spec for Microsoft.Insights namespace (https://github.com/Azure/azure-rest-api-specs/blob/master/specification/monitor/resource-manager/Microsoft.Insights/stable/2015-04-01/operations_API.json)'
  - where:
      model-name: HttpRequestInfo
      property-name: ClientIPAddress
    set:
      property-name: ClientIpAddress
  - where:
      model-name: AlertRuleResource
      property-name: PropertiesName
    set:
      property-name: AlertRuleResourceName
```