# Overall
This directory contains management plane service clients of Az.Resources module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
title: ResourceManagementClient
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
```



###
``` yaml
input-file:
- Microsoft.Resources/preview/2022-08-01-preview/deploymentStacks.json
- Microsoft.Resources/stable/2022-09-01/resources.json
- Microsoft.Resources/stable/2021-01-01/subscriptions.json
- Microsoft.Resources/stable/2020-10-01/deploymentScripts.json
- Microsoft.Resources/stable/2021-05-01/templateSpecs.json
- Microsoft.Resources/stable/2016-09-01/links.json
- Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
- Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
- Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
- Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
- Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
- Microsoft.Authorization/stable/2020-05-01/locks.json
- Microsoft.Authorization/stable/2020-05-01/privateLinks.json
- Microsoft.Features/stable/2021-07-01/features.json
- Microsoft.Features/stable/2021-07-01/SubscriptionFeatureRegistration.json



output-folder: Generated

namespace: Microsoft.Azure.Management.Resources
```