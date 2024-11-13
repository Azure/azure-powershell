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
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/stable/2024-09-01/cdnwebapplicationfirewall.json
  - $(repo)/specification/frontdoor/resource-manager/Microsoft.Network/stable/2019-11-01/networkexperiment.json

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

  # migrated from SDK
  - from: networkexperiment.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard'].get.parameters[5].format = 'date-time';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard'].get.parameters[5]['x-ms-client-name'] = 'endOn';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries'].get.parameters[5]['x-ms-client-name'] = 'startOn';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries'].get.parameters[6]['x-ms-client-name'] = 'endOn';
  - from: networkexperiment.json
    where: $.definitions
    transform: >
      $.TimeseriesProperties.properties.startDateTimeUTC['format'] = 'date-time';
      $.TimeseriesProperties.properties.endDateTimeUTC['format'] = 'date-time';
      $.TimeseriesDataPoint.properties.dateTimeUTC['format'] = 'date-time';
      $.LatencyMetric.properties.endDateTimeUTC['format'] = 'date-time';
  - from: network.json
    where: $.definitions
    transform: >
      $.Resource['x-ms-client-name'] = 'FrontDoorResourceModel';
      $.FrontDoorResource = {
        'properties': {
            'id': {
              'type': 'string',
              'description': 'Resource ID.',
              'x-ms-format': 'arm-id'
            },
            'name': {
              'type': 'string',
              'description': 'Resource name.'
            },
            'type': {
              'readOnly': true,
              'type': 'string',
              'description': 'Resource type.',
              'x-ms-format': 'resource-type'
            }
          },
        'description': 'Common resource representation.',
        'x-ms-azure-resource': true,
        'x-ms-client-name': 'FrontDoorResourceData'
      };
  - from: frontdoor.json
    where: $.definitions[?(@.allOf && @.properties.name && !@.properties.name.readOnly && @.properties.type && @.properties.type.readOnly)]
    transform: >
      if ($.allOf[0]['$ref'].includes('network.json#/definitions/SubResource'))
      {
        $.allOf[0]['$ref'] = $.allOf[0]['$ref'].replace('SubResource', 'FrontDoorResource');
        delete $.properties.name;
        delete $.properties.type;
      }
  - from: frontdoor.json
    where: $.definitions
    transform: >
      $.FrontendEndpointUpdateParameters.properties.sessionAffinityTtlSeconds['x-ms-client-name'] = 'SessionAffinityTtlInSeconds';
  - from: swagger-document
    where: $.definitions.ForwardingConfiguration.properties.cacheConfiguration
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RoutingRuleUpdateParameters.properties.rulesEngine
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointUpdateParameters.properties.webApplicationFirewallPolicyLink
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RoutingRuleUpdateParameters.properties.webApplicationFirewallPolicyLink
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateLinkResourceId
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateLinkLocation
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateEndpointStatus
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineAction.properties.routeConfigurationOverride
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineRule.properties.matchConditions
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineRule.properties.matchProcessingBehavior
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsProvisioningState
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsProvisioningSubstate
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsConfiguration
    transform: >
        $["x-nullable"] = true;
```
