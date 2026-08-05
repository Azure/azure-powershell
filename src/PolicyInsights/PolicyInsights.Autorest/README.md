<!-- region Generated -->
# Az.PolicyInsights
This directory contains the PowerShell module for the PolicyInsights service.

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
For information on how to develop for `Az.PolicyInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 1006dcb616b179a62d6517d55fe44371aff4a575
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2024-10-01/attestations.json
  - $(repo)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2024-10-01/remediations.json
  - $(repo)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2024-10-01/policyStates.json
  - $(repo)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2024-10-01/policyEvents.json
  - $(repo)/specification/policyinsights/resource-manager/Microsoft.PolicyInsights/stable/2024-10-01/policyMetadata.json

# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
#  - (this-folder)/relative-path-to-your-local-readme.md

# For new RP, the version is 0.1.1
module-version: 2.0.0
# Normally, title is the service name
root-module-name: $(prefix).PolicyInsights
title: PolicyInsights
subject-prefix: Policy

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

azure: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove the cmdlets with JsonFilePath and JsonString suffix
  - where:
      variant: .*Json(FilePath|String)
    remove: true

# Directives to transform the expressionValue and targetValue of a policy state into a string
  - from: swagger-document
    where: $.definitions.ExpressionEvaluationDetails.properties.expressionValue
    transform: $['type'] = "string";
  - from: swagger-document
    where: $.definitions.ExpressionEvaluationDetails.properties.targetValue
    transform: $['type'] = "string";
# Below directive will make metadata a dictionary instead of a string
  - from: swagger-document
    where: $.definitions.AttestationProperties.properties.metadata
    transform: $['additionalProperties'] = true
  - from: swagger-document
    where: $.definitions.PolicyMetadataSlimProperties.properties.metadata
    transform: $['additionalProperties'] = true

# Directives to disable long-running operation, which will remove AsJob and NoWait behavior in Attestation creation cmdlets
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}"].put
    transform: $["x-ms-long-running-operation"] = false
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/attestations/{attestationName}"].put
    transform: $["x-ms-long-running-operation"] = false
  - from: swagger-document
    where: $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}"].put
    transform: $["x-ms-long-running-operation"] = false

# Directives that stop a Remediation object from being returned by the Remove-AzPolicyRemediation cmdlet
  - from: swagger-document
    where: $.paths["/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "The remediation was successfully deleted."
        },
        "204": {
          "description": "The remediation did not exist."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "The remediation was successfully deleted."
        },
        "204": {
          "description": "The remediation did not exist."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.PolicyInsights/remediations/{remediationName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "The remediation was successfully deleted."
        },
        "204": {
          "description": "The remediation did not exist."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "#/definitions/ErrorResponse"
          }
        }
      }
  - from: swagger-document
    where: $.paths["/{resourceId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "The remediation was successfully deleted."
        },
        "204": {
          "description": "The remediation did not exist."
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "#/definitions/ErrorResponse"
          }
        }
      }

# Directives to add parameter aliases 
  - where:
      subject: Remediation
      parameter-name: FilterLocation
    set:
      alias: LocationFilter
  - where:
      subject: Remediation
      parameter-name: ManagementGroupId
    set:
      alias: ManagementGroupName
  - where:
      subject: Remediation
      parameter-name: ResourceId
    set:
      alias: Id
  - where:
      subject: Remediation
      parameter-name: FailureThresholdPercentage
    set:
      alias: FailureThreshold
  - where:
      subject: Remediation
      parameter-name: ParallelDeployment
    set:
      alias: ParallelDeploymentCount
  - where:
      subject: Attestation
      parameter-name: ResourceId
    set:
      alias: Id
  - where:
      subject: PolicyMetadataResource
      parameter-name: ResourceName
    set:
      alias: Name

# Policy Insights specific cmdlet directives 
  # Hide Get-AzPolicyStateQueryResult, will be called by Get-AzPolicyState
  - where:
      verb: Get
      subject: PolicyStateQueryResult
    hide: true

  # Rename Get-AzPolicyEventQueryResult to Get-AzPolicyEvent
  - where:
      verb: Get
      subject: PolicyEventQueryResult
    set:
      subject: PolicyEvent
  # Hide Get-AzPolicyEvent, will be called by custom Get-AzPolicyEvent
  - where:
      verb: Get
      subject: PolicyEvent
    hide: true

  # Hide any SkipToken parameters
  - where:
      parameter-name: SkipToken
    hide: true 

  # Hiding Get-AzPolicyMetadata so that custom one can be used
  - where:
      verb: Get
      subject: PolicyMetadata
    hide: true

  # Hide Get-AzPolicyMetadataResource, will be called by Get-AzPolicyMetadata
  - select: command
    where:
      verb: Get
      subject: PolicyMetadataResource
    hide: true

  # Hide Get-AzPolicyRemediation
  - where:
      verb: Get
      subject: Remediation
    hide: true

  # Hide Get-AzPolicyRemediationDeployment
  - where:
      verb: Get
      subject: RemediationDeployment
    hide: true

  # Remove Invoke-AzPolicyLinkPolicyEventNext
  - where:
      verb: Invoke
      subject: LinkPolicyEventNext
    remove: true

  # Remove Invoke-AzPolicyLinkPolicyStateNext
  - where:
      verb: Invoke
      subject: LinkPolicyStateNext
    remove: true

  # Hide Invoke-AzPolicySummarizePolicyState so custom Get-AzPolicyStateSummary can call it
  - where:
      verb: Invoke
      subject: SummarizePolicyState
    hide: true

  # Hide New-AzPolicyRemediation so custom Start-AzPolicyRemediation can call it
  - where:
      verb: New
      subject: Remediation
    hide: true

  # Hide Stop-AzPolicyRemediation so custom Stop-AzPolicyRemediation can call it
  - where:
      verb: Stop
      subject: Remediation
    hide: true

  # Hide Remove-AzPolicyRemediation so custom Remove-AzPolicyRemediation can call it
  - where:
      verb: Remove
      subject: Remediation
    hide: true

  # Hiding Start-AzPolicyStateResourceGroupEvaluation and Start-AzPolicyStateSubscriptionEvaluation
  # to use internally to combine into Start-AzPolicyComplianceScan
  - where:
      verb: Start
      subject: PolicyStateResourceGroupEvaluation
    hide: true
  - where:
      verb: Start
      subject: PolicyStateSubscriptionEvaluation
    hide: true

  # Hide all the Attestation cmdlets
  - where:
      verb: Remove
      subject: Attestation
    hide: true
  - where:
      verb: Get
      subject: Attestation
    hide: true
  - where:
      verb: Update
      subject: Attestation
    hide: true
  - where:
      verb: New
      subject: Attestation
    hide: true

  # Remove Update-AzPolicyRemediation
  - where:
      subject: Remediation
      verb: Update
    remove: true

metadata:
  scriptsToProcess:
  - ./custom/Helpers.ps1

```
