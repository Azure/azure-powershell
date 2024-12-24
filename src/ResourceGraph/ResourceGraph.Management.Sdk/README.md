# Overall
This directory contains management plane service clients of Az.Storage module.

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
payload-flattening-threshold: 0
title: ResourceGraphClient
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
commit: 413612b5f24da120e83eac227264f2e0b262ed8a
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/resourcegraph/resource-manager/Microsoft.ResourceGraph/stable/2021-03-01/resourcegraph.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ResourceGraph

directive:
  - suppress: ListInOperationName
    from: resourcegraph.json
    where: '$.paths["/providers/Microsoft.ResourceGraph/resourceChanges"].post.operationId'
    reason: |-
      1. Is this rule applicable? R1003 ListInOperationName says: "Per ARM SDK guidelines, each 'GET' operation on a resource should have "list" in the name...". However, this is POST, not GET.

      2. If the rule is applicable anyway, how should we fix it? Renaming it to ResourceChanges_List causes another warning:
              "OperationId should contain the verb: 'resourcechanges' in:'ResourceChanges_List'. Consider updating the operationId"
      Renaming it to ResourceChanges_ListResourceChanges causes yet another warning:
              "Per the Noun_Verb convention for Operation Ids, the noun 'ResourceChanges' should not appear after the underscore."
      Renaming it to ResourceChanges_Listresourcechanges seems to get rid of warnings, but the result looks very strange.
  - suppress: EnumInsteadOfBoolean
    where: $.definitions.ResourceChangesRequestParameters.properties.fetchPropertyChanges
    from: resourcegraph.json
    reason: This is a clear scenario for a boolean and will not have more than 2 values in the future.
```