# Overall
This directory contains management plane service clients of Az.KeyVault module.

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
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
use-extension:
  "@autorest/powershell": "4.x"
```

###
``` yaml
commit: 9f0ad696cc186c2d16cb522abc0fbd4aa3854ca5
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/keyvault/resource-manager/Microsoft.KeyVault/KeyVault/stable/2026-02-01/openapi.json

### Key Vault migrated its control plane specification to TypeSpec. The previous common.json /
### keyvault.json / managedHsm.json documents were replaced by a single emitted openapi.json under
### Microsoft.KeyVault/KeyVault/stable/<api-version>/, so the input above is one file instead of three.
### The directives below keep the generated client identical to the one produced from 2025-05-01.
###
directive:
  - no-inline:
      - Error
  ### The emitted document also carries the ARM keys/secrets/operations APIs, which Az.KeyVault does
  ### not surface. Strip those paths so the generated client keeps exactly the operation groups it
  ### had on 2025-05-01.
  - from: swagger-document
    where: $.paths
    transform: >
      delete $["/providers/Microsoft.KeyVault/operations"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}/versions"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}/keys/{keyName}/versions/{keyVersion}"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/secrets"];
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/secrets/{secretName}"];
  ### Deleting the paths above leaves their schemas behind, and modelerfour emits a class for every
  ### schema in the document. Drop the now unreferenced ones so no new model types appear either.
  - from: swagger-document
    where: $.definitions
    transform: >
      for (const name of [
        "Action", "Attributes", "DeletionRecoveryLevel", "DimensionProperties",
        "JsonWebKeyCurveName", "JsonWebKeyOperation", "JsonWebKeyType",
        "Key", "KeyAttributes", "KeyCreateParameters", "KeyListResult", "KeyProperties",
        "KeyReleasePolicy", "KeyRotationPolicyActionType", "KeyRotationPolicyAttributes",
        "LifetimeAction", "LogSpecification", "ManagedHsmAction",
        "ManagedHsmKey", "ManagedHsmKeyAttributes", "ManagedHsmKeyCreateParameters",
        "ManagedHsmKeyListResult", "ManagedHsmKeyProperties", "ManagedHsmKeyReleasePolicy",
        "ManagedHsmKeyRotationPolicyAttributes", "ManagedHsmLifetimeAction",
        "ManagedHsmRotationPolicy", "ManagedHsmTrigger", "MetricSpecification",
        "Operation", "OperationDisplay", "OperationListResult", "OperationProperties",
        "RotationPolicy", "Secret", "SecretAttributes", "SecretCreateOrUpdateParameters",
        "SecretListResult", "SecretPatchParameters", "SecretPatchProperties",
        "SecretProperties", "ServiceSpecification", "Trigger"
      ]) {
        delete $[name];
      }
  ### On 2025-05-01, keyvault.json and managedHsm.json each declared their own inline "reason" enum, and a
  ### directive here renamed the managed HSM one to ReasonForCheckMhsmNameAvailabilityResult so the two did
  ### not collide. The emitted document instead declares one shared "Reason" enum that both results $ref,
  ### so that collision is gone. Re-split it anyway: ReasonForCheckMhsmNameAvailabilityResult is public in
  ### the shipped SDK, and dropping it would be a source breaking change for SDK consumers.
  - from: swagger-document
    where: $.definitions
    transform: >
      const sharedReason = $["Reason"];
      const mhsmResult = $["CheckMhsmNameAvailabilityResult"];
      if (sharedReason && mhsmResult && mhsmResult.properties && mhsmResult.properties.reason) {
        const splitReason = Object.assign({}, sharedReason);
        splitReason["x-ms-enum"] = Object.assign({}, sharedReason["x-ms-enum"], { name: "ReasonForCheckMhsmNameAvailabilityResult" });
        $["ReasonForCheckMhsmNameAvailabilityResult"] = splitReason;
        mhsmResult.properties.reason["$ref"] = "#/definitions/ReasonForCheckMhsmNameAvailabilityResult";
      }
  ### The TypeSpec emitter drops x-ms-enum.name on the two constant query parameters of Vaults_List,
  ### which would otherwise regenerate them as Enum24 / Enum25. Restore the original names.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resources"].get
    transform: >
      for (const parameter of $.parameters) {
        if (parameter.name === "$filter" && parameter["x-ms-enum"]) {
          parameter["x-ms-enum"].name = "VaultListFilterTypes";
        }
        if (parameter.name === "api-version" && parameter["x-ms-enum"]) {
          parameter["x-ms-enum"].name = "ResourceManagerApiVersions";
        }
      }
  ### The emitted document newly declares Location / Retry-After response headers on Vaults_CreateOrUpdate
  ### and Vaults_PurgeDeleted. Generating them would change those two methods from
  ### AzureOperationResponse<Vault> to AzureOperationResponse<Vault, THeaders>, a source breaking change
  ### for SDK consumers. Long running operation polling reads the raw headers either way, so drop them.
  ### The eight operations that already declared headers on 2025-05-01 are left untouched.
  - from: swagger-document
    where: $.paths
    transform: >
      for (const path of Object.values($)) {
        for (const operation of Object.values(path)) {
          if (!operation || !operation.operationId) {
            continue;
          }
          if (operation.operationId !== "Vaults_CreateOrUpdate" && operation.operationId !== "Vaults_PurgeDeleted") {
            continue;
          }
          for (const response of Object.values(operation.responses || {})) {
            delete response.headers;
          }
        }
      }
  ### The emitted document lists the deleted vault / managed HSM parameters as (location, name) where
  ### 2025-05-01 listed them as (name, location). Both are strings, so regenerating silently swaps the
  ### arguments of GetDeleted, PurgeDeleted and BeginPurgeDeleted: the call still compiles but requests
  ### /locations/<vaultName>/deletedVaults/<location>. Restore the original order.
  - from: swagger-document
    where: $.paths
    transform: >
      const reordered = ["Vaults_GetDeleted", "Vaults_PurgeDeleted", "ManagedHsms_GetDeleted", "ManagedHsms_PurgeDeleted"];
      for (const path of Object.values($)) {
        for (const operation of Object.values(path)) {
          if (!operation || reordered.indexOf(operation.operationId) < 0) {
            continue;
          }
          const parameters = operation.parameters || [];
          let locationIndex = -1;
          let nameIndex = -1;
          for (let i = 0; i < parameters.length; i++) {
            const reference = parameters[i]["$ref"] || "";
            if (locationIndex < 0 && (parameters[i].name === "location" || reference.indexOf("LocationParameter") >= 0)) {
              locationIndex = i;
            }
            if (nameIndex < 0 && (parameters[i].name === "vaultName" || parameters[i].name === "name")) {
              nameIndex = i;
            }
          }
          if (locationIndex >= 0 && nameIndex > locationIndex) {
            const nameParameter = parameters.splice(nameIndex, 1)[0];
            parameters.splice(locationIndex, 0, nameParameter);
          }
        }
      }

output-folder: Generated
namespace: Microsoft.Azure.Management.KeyVault
```
