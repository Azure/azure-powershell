# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
npx autorest@3.8.0 --version:3.9.7 --use:@autorest/powershell@4.0.754 --use:@autorest/modelerfour@4.26.0
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
payload-flattening-threshold: 2
```



###
``` yaml
commit: 548d44095be067632e36c74969cce42472ed1431
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/storage/resource-manager/Microsoft.Storage/Storage/stable/2026-09-01/openapi.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Storage

directive:
  # Append new account fields to preserve existing positional SDK constructor arguments.
  - from: source-file-csharp
    where: $
    transform: |
      $ = $.replace(/\bpublic (StorageAccount(?:Properties)?(?:(?:Create|Update)Parameters)?|StorageDataCollaborationPolicyProperties)\(([^\r\n]*)\)/g, (declaration, name, parameters) => {
        if (!parameters.trim()) {
          return declaration;
        }
        const parts = [];
        let start = 0;
        let depth = 0;
        for (let i = 0; i < parameters.length; i++) {
          if ("(<[".includes(parameters[i])) {
            depth++;
          } else if (")>]".includes(parameters[i])) {
            depth--;
          } else if (parameters[i] === "," && depth === 0) {
            parts.push(parameters.slice(start, i).trim());
            start = i + 1;
          }
        }
        parts.push(parameters.slice(start).trim());
        const added = name === "StorageDataCollaborationPolicyProperties"
          ? /\ballowBlobAccessPoints\s*=/
          : /\b(turboTier|allowCrossTenantDelegationSas)\s*=/;
        return `public ${name}(${[
          ...parts.filter(parameter => !added.test(parameter)),
          ...parts.filter(parameter => added.test(parameter))
        ].join(", ")})`;
      });
  # Preserve the existing public list-key expansion enum as additional schemas are introduced.
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys"].post.parameters[?(@.name == "$expand")]
    transform: $["x-ms-enum"].name = "Enum75";
  # Preserve the existing public failover enum instead of renumbering it as new schemas are added.
  - from: openapi.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/failover"].post.parameters[?(@.name == "failoverType")]
    transform: $["x-ms-enum"].name = "Enum61";
  # Keep the existing storage-account identity model name when context caches add the common ARM model.
  - from: managedidentity.json
    where: $.definitions.UserAssignedIdentity
    transform: $["x-ms-client-name"] = "ContextCacheUserAssignedIdentity";
  # Preserve the public tracked-resource update type name.
  - from: openapi.json
    where: $.definitions.TrackedResourceUpdate
    transform: $["x-ms-client-name"] = "AzureResourceManagerCommonTypesTrackedResourceUpdate";
```