<!-- region Generated -->
# Az.KeyVault
This directory contains the PowerShell module for the KeyVault service.

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
For information on how to develop for `Az.KeyVault`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 9f0ad696cc186c2d16cb522abc0fbd4aa3854ca5
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md

input-file:
# Key Vault migrated its control plane specification to TypeSpec, so a single emitted openapi.json
# replaces the previous keyvault.json / managedHsm.json pair.
  - $(repo)/specification/keyvault/resource-manager/Microsoft.KeyVault/KeyVault/stable/2026-02-01/openapi.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: KeyVault
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# because autorest.powershell is unable to transform IdentityType as the best practice design if it uses managed identity
# we hide the original cmdlet and custom it under /custom folder
disable-transform-identity-type-for-operation:
  - ManagedHsms_Update

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Check$|^CheckViaIdentity$|^CheckViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Combine Test-AzKeyVaultNameAvailability and Test-AzKeyVaultManagedHsmNameAvailability
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^ManagedHsms_CheckMhsmNameAvailability$/g, "ManagedHsms_CheckNameAvailability")
  - no-inline:
      - Error
  # The emitted document also carries the ARM keys/secrets/operations APIs. Strip those paths: the
  # subject filter below keeps anything matching "ManagedHsm", which would otherwise let the new
  # ManagedHsmKey cmdlets through.
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
  # Deleting the paths above leaves their schemas behind, and a model class is emitted for every
  # schema in the document. Drop the now unreferenced ones so no new model types appear either.
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
  # Remove all commands except Test-AzKeyVault*NameAvailability, *-AzKeyVaultManagedHsm, *-AzKeyVaultRegion
  - where:
      subject: ^((?!MhsmRegion|ManagedHsm|NameAvailability).)*$
    remove: true
  # Rename *-AzKeyVaultMhsmRegion to *-AzKeyVaultManagedHsmRegion
  - where:
      subject: ^MhsmRegion$
    set:
      subject: ManagedHsmRegion
  - where:
      subject: ^ManagedHsmRegion$
      parameter-name: Name
    set:
      parameter-name: HsmName
  # Remove *-AzKeyVaultManagedHsmDeleted
  - where:
      subject: ^ManagedHsmDeleted$
    remove: true
  # Hide *-AzKeyVaultManagedHsm
  - where:
      subject: ^ManagedHsm$
    hide: true
  # Remove New|Remove-AzKeyVaultManagedHsm
  - where:
      verb: New|Remove
      subject: ^ManagedHsm$
    remove: true
```
