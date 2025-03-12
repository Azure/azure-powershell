# Overall
This directory contains management plane service clients of Az.Resources module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
output-folder: Generated
namespace: Microsoft.Azure.Management.ResourceManager
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
batch:
 - tag: package-privatelinks-2020-05
 - tag: package-subscriptions-2021-01
 - tag: package-features-2021-07
 - tag: package-deploymentscripts-2020-10
 - tag: package-resources-2024-07
 - tag: package-deploymentstacks-2024-03
 - tag: package-templatespecs-2021-05
```

## Configuration

```yaml
commit: 44051823078bc61d1210c324faf6d12e409497b7
```

### Tag: package-resources-2021-04
These settings apply only when `--tag=package-resources-2021-04` is specified on the command line.
``` yaml $(tag) == 'package-resources-2021-04'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/b9e6e16643bf008391b990a09995cf00d2f40a9d/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
```

### Tag: package-deploymentscripts-2023-08

These settings apply only when `--tag=package-deploymentscripts-2020-10` is specified on the command line.

```yaml $(tag) == 'package-deploymentscripts-2020-10'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2020-10-01/deploymentScripts.json

suppressions:
  - code: OperationsAPIImplementation
    reason: OperationsAPI will come from Resources
```

### Tag: package-resources-2024-07

These settings apply only when `--tag=package-resources-2024-07` is specified on the command line.

``` yaml $(tag) == 'package-resources-2024-07'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2024-07-01/resources.json
```

### Tag: package-privatelinks-2020-05

These settings apply only when `--tag=package-privatelinks-2020-05` is specified on the command line.

``` yaml $(tag) == 'package-privatelinks-2020-05'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-05-01/privateLinks.json
```

### Tag: package-subscriptions-2021-01

These settings apply only when `--tag=package-subscriptions-2021-01` is specified on the command line.

``` yaml $(tag) == 'package-subscriptions-2021-01'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
```

### Tag: package-features-2021-07

These settings apply only when `--tag=package-features-2021-07` is specified on the command line.

``` yaml $(tag) == 'package-features-2021-07'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/SubscriptionFeatureRegistration.json

# Needed when there is more than one input file
override-info:
  title: FeatureClient
```

### Tag: package-templatespecs-2021-05

These settings apply only when `--tag=package-templatespecs-2021-05` is specified on the command line.

``` yaml $(tag) == 'package-templatespecs-2021-05'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2021-05-01/templateSpecs.json
```

### Tag: package-deploymentstacks-2024-03

These settings apply only when `--tag=package-deploymentstacks-2024-03` is specified on the command line.

``` yaml $(tag) == 'package-deploymentstacks-2024-03'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/$(commit)/specification/resources/resource-manager/Microsoft.Resources/stable/2024-03-01/deploymentStacks.json

# Temporary override to make subscription id GUID a string.
directive:
  - from: deploymentStacks.json
    where: $
    transform: $ = $.replace(/common-types\/resource-management\/v5\/types.json#\/parameters\/SubscriptionIdParameter/g, 'common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter');
  - suppress: UniqueResourcePaths
    from: resources.json
    where: $.paths
    reason: route definitions under an extension resource with Microsoft.Management
  - suppress: OperationsAPIImplementation
    from: privateLinks.json
    where: $.paths
    reason: operation APIs for Microsoft.Authorization are to be defined in RBAC swagger
  - suppress: BodyTopLevelProperties
    from: resources.json
    where: $.definitions.ResourceGroup.properties
    reason: managedBy is a top level property
  - suppress: BodyTopLevelProperties
    from: resources.json
    where: $.definitions.GenericResource.properties
    reason: managedBy is a top level property
  - suppress: BodyTopLevelProperties
    from: resources.json
    where: $.definitions.GenericResourceExpanded.properties
    reason: 'createdTime,changedTime & provisioningState are top-level properties'
  - suppress: BodyTopLevelProperties
    from: resources.json
    where: $.definitions.TagDetails.properties
    reason: TagDetails is a top level property
  - suppress: BodyTopLevelProperties
    from: resources.json
    where: $.definitions.TagValue.properties
    reason: TagValue is a top level property
  - suppress: RequiredPropertiesMissingInResourceModel
    from: resources.json
    where: $.definitions.TagValue
    reason: TagValue will be deprecated soon
  - suppress: RequiredPropertiesMissingInResourceModel
    from: resources.json
    where: $.definitions.TagDetails
    reason: TagDetails will be deprecated soon
  - suppress: XmsResourceInPutResponse
    from: resources.json
    where: '$.paths["/subscriptions/{subscriptionId}/tagNames/{tagName}"].put'
    reason: TagDetails is not an Azure resource
  - from: deploymentScripts.json
    suppress: TrackedResourceGetOperation
    where: $.definitions.AzureCliScript
    reason: Tooling issue.
  - from: deploymentScripts.json
    suppress: TrackedResourcePatchOperation
    where: $.definitions.AzureCliScript
    reason: Tooling issue.
  - from: deploymentScripts.json
    suppress: TrackedResourceGetOperation
    where: $.definitions.AzurePowerShellScript
    reason: Tooling issue
  - from: deploymentScripts.json
    suppress: TrackedResourcePatchOperation
    where: $.definitions.AzurePowerShellScript
    reason: Tooling issue
  - from: deploymentScripts.json
    suppress: OperationsAPIImplementation
    where: $.paths
    reason: OperationsAPI will come from Resources
  - from: deploymentScripts.json
    suppress: R3006
    where:
      - $.definitions.DeploymentScript.properties
      - $.definitions.AzureCliScript.properties
      - $.definitions.AzurePowerShellScript.properties
    reason: Currently systemData is not allowed
  - suppress: OperationsAPIImplementation
    from: templateSpecs.json
    where: $.paths
    reason: OperationsAPI will come from Resources
  - suppress: R3006
    from: templateSpecs.json
    where:
      - $.definitions.TemplateSpec.properties
      - $.definitions.TemplateSpecVersion.properties
      - $.definitions.TemplateSpecUpdateModel.properties
      - $.definitions.TemplateSpecVersionUpdateModel.properties
    reason: Currently systemData is not allowed
  - suppress: TrackedResourceListByImmediateParent
    from: templateSpecs.json
    where: $.definitions
    reason: Tooling issue
  - suppress: TrackedResourceListByResourceGroup
    from: templateSpecs.json
    where: $.definitions.TemplateSpecVersion
    reason: Tooling issue
  - suppress: DescriptionAndTitleMissing
    where: $.definitions.AliasPathMetadata
    from: resources.json
    reason: This was already checked in - not my code
  - suppress: XmsExamplesRequired
    where: $.paths
    from: resources.json
    reason: Pre-existing lint error. Not related to this version release.
  - suppress: RequiredReadOnlySystemData
    from: privateLinks.json
    reason: We do not yet support system data
  - from: SubscriptionFeatureRegistration.json
    suppress: R4009
    reason: Currently systemData is not allowed
  - from: Subscriptions.json
    suppress: OperationsAPIImplementation
    reason: 'Duplicate Operations API causes generation issues'
  - suppress: TopLevelResourcesListByResourceGroup
    from: privateLinks.json
    reason: The resource is managed in a management group level (instead of inside a resource group)
```