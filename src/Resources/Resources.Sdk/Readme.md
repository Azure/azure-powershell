# Overall
This directory contains management plane service clients of Az.Resources module.

## Run Generation
In this directory, run AutoRest:
```
rm -r Generated/*
autorest --reset
autorest.cmd README.md --tag=package-privatelinks-2020-05 --version=v2 --debug
autorest.cmd README.md --tag=package-subscriptions-2021-01 --version=v2 --debug
autorest.cmd README.md --tag=package-features-2021-07 --version=v2 --debug
autorest.cmd README.md --tag=package-deploymentscripts-2020-10 --version=v2 --debug
autorest.cmd README.md --tag=package-resources-2021-04 --version=v2 --debug
autorest.cmd README.md --tag=package-deploymentstacks-2022-08-preview --version=v2 --debug
autorest.cmd README.md --tag=package-templatespecs-2021-05 --version=v2 --debug
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
output-folder: Generated
namespace: Microsoft.Azure.Management.Resources
csharp: true
clear-output-folder: false
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```


## Configuration

### Tag: package-deploymentscripts-2023-08

These settings apply only when `--tag=package-deploymentscripts-2020-10` is specified on the command line.

```yaml $(tag) == 'package-deploymentscripts-2020-10'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/main/specification/resources/resource-manager/Microsoft.Resources/stable/2020-10-01/deploymentScripts.json

suppressions:
  - code: OperationsAPIImplementation
    reason: OperationsAPI will come from Resources
```

### Tag: package-resources-2021-04

These settings apply only when `--tag=package-resources-2021-04` is specified on the command line.

``` yaml $(tag) == 'package-resources-2021-04'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
```

### Tag: package-privatelinks-2020-05

These settings apply only when `--tag=package-privatelinks-2020-05` is specified on the command line.

``` yaml $(tag) == 'package-privatelinks-2020-05'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-05-01/privateLinks.json
```

### Tag: package-subscriptions-2021-01

These settings apply only when `--tag=package-subscriptions-2021-01` is specified on the command line.

``` yaml $(tag) == 'package-subscriptions-2021-01'
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/main/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
```

### Tag: package-features-2021-07

These settings apply only when `--tag=package-features-2021-07` is specified on the command line.

``` yaml $(tag) == 'package-features-2021-07'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/SubscriptionFeatureRegistration.json

# Needed when there is more than one input file
override-info:
  title: FeatureClient
```

### Tag: package-templatespecs-2021-05

These settings apply only when `--tag=package-templatespecs-2021-05` is specified on the command line.

``` yaml $(tag) == 'package-templatespecs-2021-05'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Resources/stable/2021-05-01/templateSpecs.json
```

### Tag: package-deploymentstacks-2022-08-preview

These settings apply only when `--tag=package-deploymentstacks-2022-08-preview` is specified on the command line.

``` yaml $(tag) == 'package-deploymentstacks-2022-08-preview'
input-file:
- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/resources/resource-manager/Microsoft.Resources/preview/2022-08-01-preview/deploymentStacks.json
```