# Overall
This directory contains management plane service clients of Az.Network module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
title: NetworkManagementClient
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
use-extension:
  "@autorest/powershell": "4.x"
```



###
``` yaml
commit: e6556d8af59d346de05e19d4e6dd7d0d6b67c128
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/authenticationPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/common.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/expressRoute.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/firewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/firstPartyServiceTag.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/interconnectGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/networkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/networkManager.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/networkSecurityPerimeter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/networkingOperations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/serviceGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/virtualNetworkAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2026-01-01/virtualWan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/network/resource-manager/Microsoft.Network/Network/stable/2018-10-01/vmssNetwork.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Network

directive:
# Import only the DDoS mitigation-rule schemas from the 2026-03-01 contract
# without upgrading unrelated virtual network operations.
  - from: swagger-document
    where: $
    transform: >
      if ($.definitions?.DdosCustomPolicyPropertiesFormat) {
        Object.assign($.definitions,
      {
        "DdosContinent": {
          "type": "string",
          "description": "A continent used for DDoS geographic source matching.",
          "enum": [
            "Africa",
            "Antarctica",
            "Asia",
            "Europe",
            "NorthAmerica",
            "Oceania",
            "SouthAmerica"
          ],
          "x-ms-enum": {
            "name": "DdosContinent",
            "modelAsString": true,
            "values": [
              {
                "name": "Africa",
                "value": "Africa",
                "description": "Matches traffic originating from countries and territories in Africa."
              },
              {
                "name": "Antarctica",
                "value": "Antarctica",
                "description": "Matches traffic originating from Antarctica."
              },
              {
                "name": "Asia",
                "value": "Asia",
                "description": "Matches traffic originating from countries and territories in Asia."
              },
              {
                "name": "Europe",
                "value": "Europe",
                "description": "Matches traffic originating from countries and territories in Europe."
              },
              {
                "name": "NorthAmerica",
                "value": "NorthAmerica",
                "description": "Matches traffic originating from countries and territories in North America."
              },
              {
                "name": "Oceania",
                "value": "Oceania",
                "description": "Matches traffic originating from countries and territories in Oceania."
              },
              {
                "name": "SouthAmerica",
                "value": "SouthAmerica",
                "description": "Matches traffic originating from countries and territories in South America."
              }
            ]
          }
        },
        "DdosMitigationTrafficScope": {
          "type": "string",
          "description": "The traffic protocol to which a DDoS mitigation rule applies.",
          "enum": [
            "Tcp",
            "Udp"
          ],
          "x-ms-enum": {
            "name": "DdosMitigationTrafficScope",
            "modelAsString": true,
            "values": [
              {
                "name": "Tcp",
                "value": "Tcp",
                "description": "TCP traffic."
              },
              {
                "name": "Udp",
                "value": "Udp",
                "description": "UDP traffic."
              }
            ]
          }
        },
        "DdosSourcePolicyActionType": {
          "type": "string",
          "description": "The action applied to traffic matching a source policy override.",
          "enum": [
            "Deny",
            "Permit"
          ],
          "x-ms-enum": {
            "name": "DdosSourcePolicyActionType",
            "modelAsString": true,
            "values": [
              {
                "name": "Deny",
                "value": "Deny",
                "description": "Deny traffic from matching sources."
              },
              {
                "name": "Permit",
                "value": "Permit",
                "description": "Permit traffic from matching sources."
              }
            ]
          }
        },
        "DdosGeoMatch": {
          "type": "object",
          "description": "A geographic source match. The service validates that at least one of continent or countryCode is specified. If both are specified, the service validates that the country belongs to the continent according to the service-defined mapping. For example, RU, TR, and KZ map to Asia, EG maps to Africa, and CY maps to Europe.",
          "properties": {
            "continent": {
              "$ref": "#/definitions/DdosContinent",
              "description": "The continent to match. Country membership follows the service-defined mapping documented on DdosGeoMatch."
            },
            "countryCode": {
              "type": "string",
              "description": "The uppercase two-letter ISO 3166-1 alpha-2 code for the country or territory to match.",
              "pattern": "^[A-Z]{2}$"
            }
          }
        },
        "DdosMitigationRule": {
          "type": "object",
          "description": "A DDoS mitigation rule resource.",
          "properties": {
            "name": {
              "type": "string",
              "description": "The name of the DDoS mitigation rule."
            },
            "id": {
              "type": "string",
              "description": "The resource ID of the DDoS mitigation rule.",
              "readOnly": true
            },
            "etag": {
              "type": "string",
              "description": "A unique read-only string that changes whenever the resource is updated.",
              "readOnly": true
            },
            "type": {
              "type": "string",
              "description": "The resource type.",
              "readOnly": true
            },
            "properties": {
              "$ref": "#/definitions/DdosMitigationRulePropertiesFormat",
              "description": "Properties of the DDoS mitigation rule."
            }
          },
          "required": [
            "name",
            "properties"
          ],
          "allOf": [
            {
              "$ref": "./common.json#/definitions/SubResource"
            }
          ]
        },
        "DdosMitigationRulePropertiesFormat": {
          "type": "object",
          "description": "DDoS mitigation rule properties. The service validates that each rule specifies at least one applicable default mitigation or source policy override and that the default mitigations match the selected trafficScope.",
          "properties": {
            "provisioningState": {
              "$ref": "./common.json#/definitions/ProvisioningState",
              "description": "The provisioning state of the DDoS mitigation rule.",
              "readOnly": true
            },
            "trafficScope": {
              "$ref": "#/definitions/DdosMitigationTrafficScope",
              "description": "The traffic protocol to which the mitigation rule applies."
            },
            "tcpDefaultMitigations": {
              "$ref": "#/definitions/DdosTcpDefaultMitigations",
              "description": "The default TCP mitigations. This property is valid only when trafficScope is Tcp."
            },
            "udpDefaultMitigations": {
              "$ref": "#/definitions/DdosUdpDefaultMitigations",
              "description": "The default UDP mitigations. This property is valid only when trafficScope is Udp."
            },
            "sourcePolicyOverrides": {
              "type": "array",
              "description": "Source-specific actions that override the default mitigations. A rule supports at most one Deny override and one Permit override.",
              "items": {
                "$ref": "#/definitions/DdosSourcePolicyOverride"
              },
              "x-ms-identifiers": [
                "policyAction/actionType"
              ]
            }
          },
          "required": [
            "trafficScope"
          ]
        },
        "DdosSourceMatchConditions": {
          "type": "object",
          "description": "Source conditions for a DDoS source policy override. A source matches when it matches any IP prefix or any geographic match.",
          "properties": {
            "ipPrefixes": {
              "type": "array",
              "description": "The IPv4 or IPv6 CIDR prefixes in `<address>/<prefix-length>` format. Entries are evaluated with OR semantics.",
              "items": {
                "type": "string"
              }
            },
            "geoMatches": {
              "type": "array",
              "description": "The geographic matches. Entries are evaluated with OR semantics.",
              "items": {
                "$ref": "#/definitions/DdosGeoMatch"
              },
              "x-ms-identifiers": []
            }
          }
        },
        "DdosSourcePolicyAction": {
          "type": "object",
          "description": "The action to apply to traffic matching a source policy override.",
          "properties": {
            "actionType": {
              "$ref": "#/definitions/DdosSourcePolicyActionType",
              "description": "The source policy action type."
            }
          },
          "required": [
            "actionType"
          ]
        },
        "DdosSourcePolicyOverride": {
          "type": "object",
          "description": "A source-specific action that overrides the default mitigations.",
          "properties": {
            "policyAction": {
              "$ref": "#/definitions/DdosSourcePolicyAction",
              "description": "The action to apply to matching traffic."
            },
            "conditions": {
              "$ref": "#/definitions/DdosSourceMatchConditions",
              "description": "The source conditions that select traffic for the action."
            }
          },
          "required": [
            "policyAction",
            "conditions"
          ]
        },
        "DdosTcpDefaultMitigations": {
          "type": "object",
          "description": "Default mitigations for TCP traffic.",
          "properties": {
            "perSourceRateLimiting": {
              "$ref": "#/definitions/DdosTcpPerSourceRateLimitPolicy",
              "description": "The per-source TCP packet rate limit."
            },
            "perSourceConnectionRateLimiting": {
              "$ref": "#/definitions/DdosTcpPerSourceConnectionRateLimitPolicy",
              "description": "The per-source rate limit for new TCP connection establishments."
            }
          }
        },
        "DdosTcpPerSourceConnectionRateLimitPolicy": {
          "type": "object",
          "description": "A per-source TCP connection establishment rate limit.",
          "properties": {
            "connectionsPerSecond": {
              "type": "integer",
              "format": "int32",
              "description": "The maximum number of new TCP connections established per second from a source IP."
            }
          },
          "required": [
            "connectionsPerSecond"
          ]
        },
        "DdosTcpPerSourceRateLimitPolicy": {
          "type": "object",
          "description": "A per-source TCP packet rate limit.",
          "properties": {
            "packetsPerSecond": {
              "type": "integer",
              "format": "int32",
              "description": "The maximum number of TCP packets allowed per second from a source IP."
            }
          },
          "required": [
            "packetsPerSecond"
          ]
        },
        "DdosUdpDefaultMitigations": {
          "type": "object",
          "description": "Default mitigations for UDP traffic.",
          "properties": {
            "perSourceRateLimiting": {
              "$ref": "#/definitions/DdosUdpPerSourceRateLimitPolicy",
              "description": "The per-source UDP packet rate limit."
            }
          }
        },
        "DdosUdpPerSourceRateLimitPolicy": {
          "type": "object",
          "description": "A per-source UDP packet rate limit.",
          "properties": {
            "packetsPerSecond": {
              "type": "integer",
              "format": "int32",
              "description": "The maximum number of UDP packets allowed per second from a source IP."
            }
          },
          "required": [
            "packetsPerSecond"
          ]
        }
      }
        );
        const mitigationRules = {
          type: "array",
          description: "The list of DDoS mitigation rules associated with the custom policy.",
          items: {
            "$ref": "#/definitions/DdosMitigationRule"
          },
          "x-ms-identifiers": [
            "name"
          ]
        };
        const properties = {};
        for (const [name, value] of Object.entries(
          $.definitions.DdosCustomPolicyPropertiesFormat.properties)) {
          properties[name] = value;
          if (name === "detectionRules") {
            properties.mitigationRules = mitigationRules;
          }
        }
        $.definitions.DdosCustomPolicyPropertiesFormat.properties = properties;
      }
# Use the API version that implements DDoS custom policy mitigation rules.
  - from: DdosCustomPoliciesOperations.cs
    where: $
    transform: $ = $.replace(/string apiVersion = "2026-01-01";/g, 'string apiVersion = "2026-03-01";');
# Add the IPAM allocation bounds introduced by azure-rest-api-specs commit
# cd2c909bbb9c0c59ab219bb68222f9d6c6a64100 without upgrading unrelated
# virtual network operations from the module's 2025-09-01 API baseline.
  - from: swagger-document
    where: $
    transform: >
      if ($.definitions?.IpamPoolProperties &&
          $.definitions?.IpamPoolUpdateProperties) {
        $.definitions.IpamPoolProperties.properties.minAllocationSize = {
          type: "string",
          description: "Minimum number of IP addresses required for allocations from this IpamPool to be compliant. Must be less than or equal to the maximum allocation size. If not specified or empty, no minimum is enforced."
        };
        $.definitions.IpamPoolProperties.properties.maxAllocationSize = {
          type: "string",
          description: "Maximum number of IP addresses allowed for allocations from this IpamPool to be compliant. Must be greater than or equal to the minimum allocation size. If not specified or empty, no maximum is enforced."
        };
        $.definitions.IpamPoolUpdateProperties.properties.minAllocationSize = {
          type: "string",
          description: "Minimum number of IP addresses required for allocations from this IpamPool to be compliant. Must be less than or equal to the maximum allocation size. Omit to leave the current value unchanged; set to an empty string to clear it."
        };
        $.definitions.IpamPoolUpdateProperties.properties.maxAllocationSize = {
          type: "string",
          description: "Maximum number of IP addresses allowed for allocations from this IpamPool to be compliant. Must be greater than or equal to the minimum allocation size. Omit to leave the current value unchanged; set to an empty string to clear it."
        };
      }
# Use the API version that implements allocation bounds for IPAM pool requests.
  - from: IpamPoolsOperations.cs
    where: $
    transform: $ = $.replace(/string apiVersion = "2025-09-01";/g, 'string apiVersion = "2026-01-01";');
# The 2025-09-01 service response returns resourceGuid at the resource root, while the
# published swagger places it under properties. Move the schema property during generation
# until the current and next API specifications are corrected.
  - from: swagger-document
    where: $.definitions
    transform: >
      if ($["FirstPartyServiceTag"] &&
          $["FirstPartyServiceTagPropertiesFormat"]?.properties?.resourceGuid) {
        $["FirstPartyServiceTag"].properties.resourceGuid =
          $["FirstPartyServiceTagPropertiesFormat"].properties.resourceGuid;
        delete $["FirstPartyServiceTagPropertiesFormat"].properties.resourceGuid;
      }
# start of directives added by xiaogang
# Remove lro response headers. Srijani, you may ignore this part.
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Azure-AsyncOperation"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Azure-AsyncOperation"]
# remove tags in https://github.com/Azure/azure-rest-api-specs/blob/906c9971ea117692ad6e7e15fe1a0b38ac109c76/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/virtualNetwork.json#L17498, since it has been defined in the parent TrackedResourceWithOptionalLocation.
# Srijani, this is a workaround. I think it should be fixed in your typespec.
# Yabo, Ideally, our code generator should be able to handle case like this. If the property is redundant in the child, we could just ignore it.
  - from: swagger-document
    where: $.definitions.DdosProtectionPlan.properties
    transform: delete $["tags"]
  - from: swagger-document
    where: $.definitions.EffectiveNetworkSecurityGroup.properties.tagMap
    transform: $.type = "object"
# Strip the "Common." prefix from all definitions so the generated C# class names
# stay backward-compatible with the handwritten Az.Network layer. Without this directive
# every "Common.X" swagger definition becomes a "CommonX" C# class (e.g. CommonRouteTable,
# CommonSubResource, CommonLoadBalancer), breaking the handwritten cmdlets that reference
# the legacy names.
# Long-term fix: drop the "Common." prefix at the TypeSpec/swagger source so this workaround
# can be removed.
  - from: swagger-document
    where: $.definitions
    transform: >
      for (const k of Object.keys($)) {
        if (k.startsWith('Common.')) {
          $[k]['x-ms-client-name'] = k.substring('Common.'.length);
        }
      }
# rename Common.CloudError to CloudError, see https://github.com/Azure/azure-rest-api-specs/blob/906c9971ea117692ad6e7e15fe1a0b38ac109c76/specification/network/resource-manager/Microsoft.Network/Network/stable/2025-07-01/common.json#L2026
# Srijani, I noticed in the swaggers generated from tsp, some model names are added the prefix "common.", the change will lead to the change of the generated C# class name. As a result, it may cause some issues and breaking changes. Following is a case. I would suggest you remove the prefix "common.".
  - from: swagger-document
    where: $.definitions["Common.CloudError"]
    transform: $["x-ms-client-name"] = "CloudError"
# Keep SubscriptionId on NetworkManagementClient typed as string. TypeSpec emits the global subscriptionId
# parameter with `format: uuid`, which makes the generated client property a System.Guid and breaks the
# handwritten helpers (e.g. ApplicationGatewayChildResourceHelper) that expect a string.
  - from: swagger-document
    where: $.parameters.SubscriptionIdParameter
    transform: delete $.format
  - from: swagger-document
    where: $..parameters[?(@.name=='subscriptionId')]
    transform: delete $.format
# Srijani, following cases are also breaking changes. I have to change them back with directives.
# Yabo, Not sure if allof and x-ms-azure-resource could co-existed in a model. If so, we need to add support for it.
# move x-ms-azure-resource from Common.SubResourceModel to Common.SubResource
# 2025-09-01 note: the "Common." prefix was dropped in this api-version, so target the un-prefixed keys.
  - from: swagger-document
    where: $.definitions["SubResourceModel"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["SubResource"]
    transform: $["x-ms-azure-resource"] = true
# move x-ms-azure-resource from CommonProxyResource and CommonTrackedResource to CommonResource
  - from: swagger-document
    where: $.definitions["CommonProxyResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["CommonTrackedResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["CommonResource"]
    transform: $["x-ms-azure-resource"] = true
# move x-ms-azure-resource from SecurityPerimeterProxyResource and SecurityPerimeterTrackedResource to SecurityPerimeterResource
  - from: swagger-document
    where: $.definitions["SecurityPerimeterProxyResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["SecurityPerimeterTrackedResource"]
    transform: delete $["x-ms-azure-resource"]
  - from: swagger-document
    where: $.definitions["SecurityPerimeterResource"]
    transform: $["x-ms-azure-resource"] = true
# Keep ApplicationGatewayFirewallDisabledRuleGroup.rules element non-nullable (IList<int>).
# rules.items carried "x-nullable": false in every hand-written swagger api-version from 2017-03-01
# through 2025-03-01. The TypeSpec migration (azure-rest-api-specs #40226, api-version 2025-05-01)
# dropped it, so the emitted swagger now allows null elements and autorest generates IList<int?>.
# WAF rule IDs are never null; this is an unintended breaking change (analyzer 3030) vs the released
# IList<int>. Restore x-nullable=false here until the TypeSpec source is fixed to re-emit it.
  - from: swagger-document
    where: $.definitions.ApplicationGatewayFirewallDisabledRuleGroup.properties.rules.items
    transform: $["x-nullable"] = false
# end of directives added by xiaogang
  - where:
      model-name: ManagedServiceIdentityUserAssignedIdentities
    set:
      model-name: ManagedServiceIdentityUserAssignedIdentitiesValue
```
