<!-- region Generated -->
# Az.Commvault
This directory contains the PowerShell module for the Commvault service.

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
For information on how to develop for `Az.Commvault`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: e91f0b95c03a435a7d745e8c70930aadce552d39
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/liftrcommvault/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require:
  - $(repo)/specification/liftrcommvault/resource-manager/readme.powershell.md

# generate from the stable API version
input-file:
  - $(repo)/specification/liftrcommvault/resource-manager/Commvault.ContentStore/stable/2026-09-30/commvault.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Commvault
service-name: Commvault
subject-prefix: Commvault

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required

  # Keep only the expanded, JsonFilePath and JsonString parameter sets of the create and update cmdlets.
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # New-* cmdlets create a resource by name, so the ViaIdentity parameter sets are not needed.
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Remove the set-* cmdlet. New-* and Update-* cover the same operations.
  - where:
      verb: Set
    remove: true

  # The operationIds Plans_CreateOrupdate and ProtectionGroups_CreateOrupdate contain a typo in the swagger
  # (lower-case "u"), which leaks into the cmdlet noun. Rename the nouns instead of changing the released API.
  - where:
      verb: New
      subject: PlanOrupdate
    set:
      subject: Plan
  # Same typo as above, for the protection group.
  - where:
      verb: New
      subject: ProtectionGroupOrupdate
    set:
      subject: ProtectionGroup

  # The operation group name SaaSOperationGroup leaks into the cmdlet noun. Use a readable name.
  - where:
      verb: Initialize
      subject: SaaSOperationGroupResource
    set:
      subject: SaaS
  # The operation group name ProtectedItemsOperationGroup leaks into the cmdlet noun, and the count is a read-only POST.
  - where:
      verb: Invoke
      subject: CountProtectedItemsOperationGroup
    set:
      verb: Get
      subject: ProtectedItemCount
  # The body parameter set of this action is named exactly "Count". The test coverage analysis of the Azure PowerShell
  # pipeline reads ParameterSets.Count of every parameter, which returns that parameter set instead of a number and
  # fails every Test job. Remove the unexpanded set, as for the other cmdlets; -ResourceId, -JsonString and
  # -JsonFilePath remain.
  - where:
      verb: Get
      subject: ProtectedItemCount
      variant: ^Count$
    remove: true

  # POST actions without a mapped verb are generated as Invoke-*. Use approved verbs that describe the action.
  - where:
      verb: Invoke
      subject: LatestCloudAccountLinkedSaaS
    set:
      verb: Get
      subject: CloudAccountLatestLinkedSaaS
  # Linking a SaaS resource to the cloud account is a connect operation.
  - where:
      verb: Invoke
      subject: LinkCloudAccountSaaS
    set:
      verb: Connect
      subject: CloudAccountSaaS

  # The Refresh action maps to the Update verb and would share Update-AzCommvaultStorage with the PUT-based update.
  - where:
      verb: Update
      subject: Storage
      variant: ^Refresh
    set:
      verb: Sync

  # The parameter name Class ends with "s", which static analysis (rule 8410) reports as a plural noun.
  # Use the name of the swagger enum type instead.
  - where:
      verb: New|Update
      subject: Storage
      parameter-name: Class
    set:
      parameter-name: StorageClassType

  # These cmdlets are POST operations that only read data. Hide -WhatIf and -Confirm because they have no side effects.
  - where:
      verb: Get
      subject: CloudAccountLatestLinkedSaaS|ProtectedItemCount|ProtectedItemRestorePoint
    set:
      suppress-should-process: true

  # A cloud account has exactly one role mapping, named "default". The List parameter set has the same parameters as
  # Get, so PowerShell can never select it. Remove it to keep the help unambiguous.
  - where:
      verb: Get
      subject: RoleMapping
      variant: ^List$
    remove: true

  # The swagger description of ProtectedItems_GetRestorePoints ("Limits used for creation of resources.") belongs to an
  # unrelated operation and would become the cmdlet synopsis. Replace it with an accurate description.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Commvault.ContentStore/cloudAccounts/{cloudAccountName}/protectionGroups/{protectionGroupName}/protectedItems/{protectedItemName}/getRestorePoints"].post.description
    transform: >-
      return "Gets the restore points that are available for a protected item."
```
