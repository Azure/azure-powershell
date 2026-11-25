<!-- region Generated -->
# Az.DocumentDB
This directory contains the PowerShell module for the DocumentDb service.

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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 5.5.2 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DocumentDB`, see [how-to.md](how-to.md).
<!-- endregion -->

## Public module compatibility

The public module requires Az.Accounts 5.5.2 or later, as declared by
[`../DocumentDB/Az.DocumentDB.psd1`](../DocumentDB/Az.DocumentDB.psd1). AutoRest may
regenerate the overview above with its generic 2.7.5 minimum; that boilerplate does not
override the public wrapper's requirement.

The standard build adaptation can raise the packaged minimum to the loaded Az.Accounts
version. Check the packaged module's manifest for the requirement of that artifact.

### AutoRest Configuration

> see https://aka.ms/autorest

The module uses the unchanged published September 2026 Swagger specification. The
configuration below preserves the public cmdlet surface and the custom user and promotion
wrappers. See [how-to.md](how-to.md) for the standard generation and build workflow.

```yaml
# Pin the published specification and generation tools for reproducible output.
version: 3.10.9
commit: ee379f8c12cf88a75926a218a105550406bbb06c
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/mongocluster/resource-manager/Microsoft.DocumentDB/MongoCluster/stable/2026-09-01/mongoCluster.json
title: DocumentDB
service-name: DocumentDB
subject-prefix: DocumentDB
module-version: 0.1.0
use-extension:
  "@autorest/powershell": "4.0.758"
  "@autorest/modelerfour": "4.26.2"
# Preserve the public dictionary model name; the published JSON schema is unchanged.
modelerfour:
  naming:
    override:
      UserAssignedIdentities: ManagedServiceIdentityUserAssignedIdentities

directive:
  # Operation discovery is internal, not part of the customer-facing command surface.
  - where:
      subject: ^Operation$
    hide: true
  # Promotion is exposed through the source-validating Switch custom cmdlet.
  - where:
      verb: Invoke
      subject: ^PromoteMongoCluster$
    hide: true
  # The custom New-User wrapper builds the discriminated Microsoft Entra identity body.
  - where:
      verb: New
      subject: ^User$
    hide: true
  # Private Link and private endpoint management are outside this module's public scope.
  - where:
      subject: ^Private(Link|EndpointConnection).*$
    remove: true
  # Users are granted access through New-User; there is no public update-user workflow.
  - where:
      verb: Update
      subject: ^User$
    remove: true
  # Omitted subscription IDs continue to resolve from the current Az context.
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: "(Get-AzContext).Subscription.Id"
  # Preserve expanded and JSON body variants rather than adding raw request-body sets.
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|ViaJsonString|ViaJsonFilePath))
    remove: true
  # New resources use names; retain existing child-resource parent-identity variants only.
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Retain the existing managed-identity GET+PUT Update flow, not the extra Set PUT sets.
  - where:
      verb: Set
      subject: ^(MongoCluster|FirewallRule|User)$
    remove: true
  # Swagger lists subscriptions first; reserve the established List1 set before swapping.
  - where:
      verb: Get
      subject: ^MongoCluster$
      variant: ^List$
    set:
      variant: ListSubscription
  # Preserve List as the resource-group parameter set used by the TypeSpec module.
  - where:
      verb: Get
      subject: ^MongoCluster$
      variant: ^List1$
    set:
      variant: List
  # Preserve List1 as the subscription parameter set used by the TypeSpec module.
  - where:
      verb: Get
      subject: ^MongoCluster$
      variant: ^ListSubscription$
    set:
      variant: List1
  # Auto-derived casing must match the established DocumentDB command prefix.
  - where:
      subject-prefix: DocumentDb(.*)
    set:
      subject-prefix: DocumentDB$1
```
