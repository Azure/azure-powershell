<!-- region Generated -->
# Az.Chaos
This directory contains the PowerShell module for the Chaos service.

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
For information on how to develop for `Az.Chaos`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: f228b86c72657cd366e26c77420bfbd436938821
require:
  - $(this-folder)/../../readme.azure.noprofile.md 
input-file:
  - $(repo)/specification/chaos/resource-manager/Microsoft.Chaos/Chaos/preview/2026-05-01-preview/openapi.json

title: Chaos
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true

directive:
  # --- Sanitize the property descriptions that contain backticks. A backtick is
  #     the PowerShell escape character, so a backtick in a generated double-quoted
  #     HelpMessage string breaks the model-cmdlet proxy parse. Restate the two
  #     zone-filter descriptions without backticks. ---
  - where:
      model-name: ConfigurationFilters
      property-name: PhysicalZone
    set:
      property-description: "Array of physical availability zone identifiers in '{region}-az{N}' format (for example, 'westus2-az1'). Only resources in the corresponding logical zone for each subscription are included. At execution time, each physical zone is resolved to per-subscription logical zones via the Azure locations API. The resolved mapping is surfaced on the scenario run response. Null or omitted means physical zone targeting is not used. Only one physical zone is supported in preview. Mutually exclusive with the zones filter; set one or the other, not both."
  - from: swagger-document
    where: $..physicalZones
    transform: $.description = "SENTRECURSIVE"
  - where:
      model-name: ConfigurationFilters
      property-name: Zone
    set:
      property-description: "Array of availability zone identifiers (for example, 1, 2, 3, or zone-redundant). Only resources whose zones intersect this list are included. Null or omitted means all zones (including non-zonal). An empty array means include nothing. Mutually exclusive with the physicalZones filter; set one or the other, not both."

  # --- Prune the retired V1 experiment-era nouns (PR2). The V2 openapi.json still
  #     carries the V1 surface, so directives remove every non-V2 noun. ---
  - where:
      subject: ^.*Experiment.*$
    remove: true
  - where:
      subject: Capability
    remove: true
  - where:
      subject: CapabilityType
    remove: true
  - where:
      subject: ^Target.*$
    remove: true
  - where:
      subject: ^PrivateAccess.*$
    remove: true
  - where:
      subject: ^PrivateEndpointConnection.*$
    remove: true
  - where:
      subject: ^PrivateLinkResource.*$
    remove: true
  - where:
      subject: ^OperationStatus.*$
    remove: true
  # --- Prune the action-catalog and operation-metadata nouns; they are not part
  #     of the V2 plumbing surface. ---
  - where:
      subject: ^Action.*$
    remove: true
  - where:
      subject: Operation
    remove: true

  # --- V2 shaping: keep only the Expanded, JsonFilePath, and JsonString
  #     create/update variants; remove every other create/update variant. ---
  - where:
      variant: ^(Create|Update).*(?<!Expanded|JsonFilePath|JsonString)$
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # --- CreateOrUpdate produces New-* only; remove the auto-generated Set-*. ---
  - where:
      verb: Set
    remove: true
  # --- Scenario and ScenarioConfiguration have no PATCH operation. Their PUT
  #     CreateOrUpdate must produce New-* only; remove the auto-generated Update-*.
  #     Only Workspaces_Update (PATCH) keeps an Update-* cmdlet. ---
  - where:
      verb: Update
      subject: Scenario
    remove: true
  - where:
      verb: Update
      subject: ScenarioConfiguration
    remove: true

  # --- Verb-noun renames to approved pairs. Validate->Test (DD2), Cancel->Stop
  #     (DD3), and Refresh->Update (DD5) are applied by the generator's native verb
  #     mapping. Execute and FixResourcePermissions need explicit renames. ---
  # Execute keeps the Invoke verb; rename the subject to the Execution noun (DD7).
  - where:
      verb: Invoke
      subject: ExecuteScenarioConfiguration
    set:
      subject: ScenarioConfigurationExecution
  # FixResourcePermissions maps to the approved Repair verb (DD4).
  - where:
      verb: Invoke
      subject: FixScenarioConfigurationResourcePermission
    set:
      verb: Repair
      subject: ScenarioConfigurationResourcePermission

  # --- Expose the server-side whatIf field under -WhatIfMode so it cannot collide
  #     with the common -WhatIf switch (DD4, DD8). ---
  - where:
      verb: Repair
      subject: ScenarioConfigurationResourcePermission
      parameter-name: WhatIf
    set:
      parameter-name: WhatIfMode

  # --- V2 model helpers: the nested request-body models a user builds to call the
  #     V2 create cmdlets. ---
  - model-cmdlet:
    - model-name: ScenarioAction
    - model-name: ScenarioParameter
    - model-name: RunAfter
    - model-name: ExternalResource
    - model-name: KeyValuePair
    - model-name: ConfigurationFilters
    - model-name: ConfigurationExclusions
```
