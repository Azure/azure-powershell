# Overall
This directory contains management plane service clients of Az.Policyinsights module.

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
title: PolicyInsightsClient
```

### Validations

Run validations when `--validate` is specified on command line

``` yaml $(validate)
azure-validator: true
semantic-validator: true
model-validator: true
message-format: json
```


###
``` yaml
commit: f3312d0962e91b065f287e44f5ae76db038fcd87
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/preview/2018-07-01-preview/policyTrackedResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2021-10-01/remediations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2019-10-01/policyEvents.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2019-10-01/policyStates.json

  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2019-10-01/policyMetadata.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2022-03-01/checkPolicyRestrictions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2022-09-01/attestations.json

output-folder: Generated

namespace: Microsoft.Azure.Management.PolicyInsights

directive:
  - suppress: EnumInsteadOfBoolean
    reason: The data type in store is boolean. If we change the type in RP, it will break existing clients, and we will incur runtime conversion cost.
    where:
      - $.definitions.PolicyEvent.properties.isCompliant
      - $.definitions.PolicyState.properties.isCompliant

  - suppress: NonApplicationJsonType
    reason: ODATA $metadata endpoint for each resource type returns metadata document as XML.
    where:
      - $.paths["/{scope}/providers/Microsoft.PolicyInsights/policyEvents/$metadata"].get.produces[0]
      - $.paths["/{scope}/providers/Microsoft.PolicyInsights/policyStates/$metadata"].get.produces[0]

  - suppress: OperationIdNounConflictingModelNames
    reason: Metadata is already in plural form.
    where:
      - $.paths["/providers/Microsoft.PolicyInsights/policyMetadata/{resourceName}"].get.operationId
      - $.paths["/providers/Microsoft.PolicyInsights/policyMetadata"].get.operationId

  - suppress: PageableOperation
    reason: The operations API is not pagable.
    where:
      - $.paths["/providers/Microsoft.PolicyInsights/operations"].get

  - suppress: PostOperationIdContainsUrlVerb
    reason: The operation can be performed at multiple scopes. The operationId needs to indicate the scope.
    where:
      - $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/policyStates/latest/triggerEvaluation"].post.operationId
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/policyStates/latest/triggerEvaluation"].post.operationId
      - $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/checkPolicyRestrictions"].post.operationId
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/checkPolicyRestrictions"].post.operationId

  - suppress: BodyTopLevelProperties
    from: attestations.json
    where: $.definitions.Attestation.properties
    reason: systemData is now a required top level property

  - suppress: OBJECT_ADDITIONAL_PROPERTIES
    from: policyEvents.json
    reason: unnecessary check

  - suppress: OBJECT_ADDITIONAL_PROPERTIES
    from: policyStates.json
    reason: unnecessary check

  - suppress: MISSING_REQUIRED_PARAMETER
    from: policyEvents.json
    reason: unnecessary check

  - suppress: MISSING_REQUIRED_PARAMETER
    from: policyStates.json
    reason: unnecessary check

  - from: policyEvents.json
    where: $
    transform: delete $['x-ms-paths']
    reason: other languages which still use track1 does not support remove '/' for 'next_link'

  - from: policyStates.json
    where: $
    transform: delete $['x-ms-paths']
    reason: other languages which still use track1 does not support remove '/' for 'next_link'

  - from: policyEvents.json
    where:
      - $.paths["/providers/{managementGroupsNamespace}/managementGroups/{managementGroupName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults"]
    transform: delete $['post']['x-ms-pageable']['operationName']

  - from: policyStates.json
    where:
      - $.paths["/providers/{managementGroupsNamespace}/managementGroups/{managementGroupName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
      - $.paths["/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults"]
    transform: delete $['post']['x-ms-pageable']['operationName']

#Adjust parameter order
  - from: swagger-document
    where: $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}/listDeployments"].post.parameters
    transform: >-
      return [
          {
            "$ref": "#/parameters/resourceIdParameter"
          },
          {
            "$ref": "#/parameters/remediationNameParameter"
          },
          {
            "$ref": "#/parameters/apiVersionParameter"
          },
          {
            "$ref": "#/parameters/topParameter"
          }
        ]
  - from: swagger-document
    where: $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/remediations"].get.parameters
    transform: >-
      return [
          {
            "$ref": "#/parameters/resourceIdParameter"
          },
          {
            "$ref": "#/parameters/apiVersionParameter"
          },
          {
            "$ref": "#/parameters/topParameter"
          },
          {
            "$ref": "#/parameters/filterParameter"
          }
        ]
  - from: swagger-document
    where: $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/attestations"].get.parameters
    transform: >-
      return [
          {
            "$ref": "#/parameters/resourceIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "#/parameters/topParameter"
          },
          {
            "$ref": "#/parameters/filterParameter"
          }
        ]
  - from: swagger-document
    where:
      - $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/attestations"].get.parameters
    transform: >-
      return [
          {
            "$ref": "#/parameters/resourceIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "#/parameters/topParameter"
          },
          {
            "$ref": "#/parameters/filterParameter"
          }
        ]
```