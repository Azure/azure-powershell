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
  # --- Sanitize the ConfigurationFilters.physicalZones description at the swagger
  #     source. The generator escapes a double quote as a backtick-quote pair but
  #     emits the source description's own backticks verbatim. The source text
  #     contains a backtick immediately before a quote, so the generated
  #     double-quoted HelpMessage string terminates early and the model-cmdlet
  #     proxy fails to parse. Restate the description without that sequence. The
  #     sibling zones description contains quotes but no backtick before a quote,
  #     so it generates valid PowerShell and needs no transform. ---
  - from: swagger-document
    where: $..physicalZones
    transform: >-
      $.description = "Array of physical availability zone identifiers in '{region}-az{N}' format (for example, 'westus2-az1'). Only resources in the corresponding logical zone for each subscription are included. At execution time, each physical zone is resolved to per-subscription logical zones via the Azure locations API. The resolved mapping is surfaced on the scenario run response. Null or omitted means physical zone targeting is not used. Only one physical zone is supported in preview. Mutually exclusive with the zones filter; set one or the other, not both."
  # --- Sanitize the ScenarioRuns_Get operation description at the swagger source.
  #     The generator emits escaped newlines literally in the help synopsis. Keep the
  #     synopsis as one sentence so generated help has no '\n\n' text. ---
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "ScenarioRuns_Get")]
    transform: >-
      $.description = "Get a scenario run. This endpoint is also the polling target for ScenarioConfigurations.execute and ScenarioRuns.cancel (final-state-via: location). While the run is in progress the service returns 202 with a Location header pointing back to this URL; clients must keep polling until they receive 200, which carries the final ScenarioRun body."
  # --- Preserve the service field name for ScenarioRun.scenarioRunJson. Without
  #     this, flattening strips the ScenarioRun prefix and exposes the property as
  #     Json, which is easy to confuse with the -JsonString input parameter. ---
  - from: swagger-document
    where: $.definitions.ScenarioRunProperties.properties.scenarioRunJson
    transform: >-
      $["x-ms-client-name"] = "ScenarioRunJson"
  - from: code-model-v3
    where: $..virtualProperties..[?(@.property.serializedName == "scenarioRunJson")]
    transform: >-
      $.name = "ScenarioRunJson"
  - where:
      model-name: ScenarioRun
      property-name: Json
    set:
      property-name: ScenarioRunJson
  # --- The service requires Scenario.description and at least one action, but
  #     accepts a scenario with no parameters key. Requiredness for flattened body
  #     parameters only reaches the cmdlet when the containing resource envelope
  #     requires properties, so fix the envelope and the nested ScenarioProperties
  #     required list together: make -Description and -Action mandatory, keep
  #     -Parameter optional. Required cannot enforce minItems: actions: [] remains
  #     a service-side validation failure. ---
  - from: swagger-document
    where: $.definitions.Scenario
    transform: >-
      if (!$.required) { $.required = []; } if ($.required.indexOf("properties") < 0) { $.required.push("properties"); }
  - from: swagger-document
    where: $.definitions.ScenarioProperties
    transform: >-
      $.properties.description.description = "Description of what this scenario does."; $.required = ($.required || []).filter(function(x) { return x !== "parameters"; }); if ($.required.indexOf("actions") < 0) { $.required.push("actions"); } if ($.required.indexOf("description") < 0) { $.required.push("description"); }
  # --- ScenarioConfigurationProperties already marks scenarioId required, but
  #     that nested required array cannot affect flattened cmdlet parameters while
  #     the ScenarioConfiguration envelope itself leaves properties optional. Match
  #     Workspace's envelope shape so -ScenarioId becomes mandatory on expanded
  #     create variants. Scenario is handled separately above because its nested
  #     required list overstates -Parameter and must be corrected at the same time
  #     as its envelope. ---
  - from: swagger-document
    where: $.definitions.ScenarioConfiguration
    transform: >-
      if (!$.required) { $.required = []; } if ($.required.indexOf("properties") < 0) { $.required.push("properties"); }
  # --- These LRO POST operations return terminal resources from their Location
  #     polling targets. The swagger omits those final 200 response schemas, so
  #     generated cmdlets currently discard the terminal bodies and return $true. ---
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "ScenarioConfigurations_Execute")]
    transform: >-
      $.responses["200"] = $.responses["200"] || { description: "Scenario run result.", schema: { "$ref": "#/definitions/ScenarioRun" } }
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "ScenarioConfigurations_Validate")]
    transform: >-
      $.responses["200"] = $.responses["200"] || { description: "Validation result.", schema: { "$ref": "#/definitions/Validation" } }
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "ScenarioConfigurations_FixResourcePermissions")]
    transform: >-
      $.responses["200"] = $.responses["200"] || { description: "Permissions fix result.", schema: { "$ref": "#/definitions/PermissionsFix" } }
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "Workspaces_RefreshRecommendations")]
    transform: >-
      $.responses["200"] = $.responses["200"] || { description: "Workspace evaluation result.", schema: { "$ref": "#/definitions/WorkspaceEvaluation" } }
  # --- The service exposes /latest GET endpoints for the terminal resources that
  #     Location-based LROs already poll at runtime. Declare only the observed
  #     endpoints whose response schemas already exist in the pinned swagger by
  #     absolute $ref; injected paths have no reliable relative-ref base. Do not
  #     invent a discoveries/latest schema while the contract lacks one. ---
  - from: swagger-document
    where: $.paths
    transform: >-
      var api = { name: "api-version", in: "query", description: "The API version to use for this operation.", required: true, type: "string" }; var sub = { name: "subscriptionId", in: "path", description: "The ID of the target subscription.", required: true, type: "string" }; var rg = { name: "resourceGroupName", in: "path", description: "The name of the resource group.", required: true, type: "string" }; var ws = { name: "workspaceName", in: "path", description: "String that represents a Workspace resource name.", required: true, type: "string", minLength: 1 }; var scenario = { name: "scenarioName", in: "path", description: "Name of the scenario.", required: true, type: "string", minLength: 1 }; var config = { name: "scenarioConfigurationName", in: "path", description: "Name of the scenario definition.", required: true, type: "string", minLength: 1 }; $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/evaluations/latest"] = $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/evaluations/latest"] || { get: { tags: ["Workspaces"], operationId: "WorkspaceEvaluations_Get", description: "Get the latest workspace evaluation result.", produces: ["application/json"], parameters: [api, sub, rg, ws], responses: { "200": { description: "Workspace evaluation result.", schema: { "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f228b86c72657cd366e26c77420bfbd436938821/specification/chaos/resource-manager/Microsoft.Chaos/Chaos/preview/2026-05-01-preview/openapi.json#/definitions/WorkspaceEvaluation" } }, default: { description: "Error response describing why the operation failed." } } } }; $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/scenarios/{scenarioName}/configurations/{scenarioConfigurationName}/validations/latest"] = $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/scenarios/{scenarioName}/configurations/{scenarioConfigurationName}/validations/latest"] || { get: { tags: ["ScenarioConfigurations"], operationId: "ScenarioConfigurationValidations_Get", description: "Get the latest scenario configuration validation result.", produces: ["application/json"], parameters: [api, sub, rg, ws, scenario, config], responses: { "200": { description: "Validation result.", schema: { "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f228b86c72657cd366e26c77420bfbd436938821/specification/chaos/resource-manager/Microsoft.Chaos/Chaos/preview/2026-05-01-preview/openapi.json#/definitions/Validation" } }, default: { description: "Error response describing why the operation failed." } } } }; $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/scenarios/{scenarioName}/configurations/{scenarioConfigurationName}/fixResourcePermissions/latest"] = $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/workspaces/{workspaceName}/scenarios/{scenarioName}/configurations/{scenarioConfigurationName}/fixResourcePermissions/latest"] || { get: { tags: ["ScenarioConfigurations"], operationId: "ScenarioConfigurationResourcePermissions_Get", description: "Get the latest scenario configuration resource permission fix result.", produces: ["application/json"], parameters: [api, sub, rg, ws, scenario, config], responses: { "200": { description: "Permissions fix result.", schema: { "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f228b86c72657cd366e26c77420bfbd436938821/specification/chaos/resource-manager/Microsoft.Chaos/Chaos/preview/2026-05-01-preview/openapi.json#/definitions/PermissionsFix" } }, default: { description: "Error response describing why the operation failed." } } } };
  # --- DELETE on existing scenario resources returns 202 Accepted. The swagger
  #     only declares 200/204 for Scenarios_Delete, so generated clients route a
  #     successful delete to the default error handler. ScenarioConfiguration
  #     already declares 202 but incorrectly marks the operation as an LRO without
  #     the polling headers the generated LRO loop requires; the service returns a
  #     ScenarioConfiguration body with provisioningState=Deleting, so treat 202 as
  #     a terminal accepted response. ScenarioConfigurations_Delete also returns
  #     404 for an absent configuration even though ARM delete should return 204.
  #     Do NOT declare 404 here. Declaring it makes the generator treat 404 as a
  #     success shape whose onNotFound writes nothing unless -PassThru, and the
  #     generated handler cannot see *which* resource was absent -- so a wrong
  #     resource group, workspace or scenario name was reported as a successful
  #     delete while the configuration was still live (DEV-046). The service
  #     returns three different codes for the three ancestors
  #     (ResourceGroupNotFound / ResourceNotFound / NotFound) and none of them
  #     identifies the configuration itself, so the client cannot distinguish
  #     target-absent from ancestor-absent. Leaving 404 undeclared routes it to
  #     onDefault, where the C3 handler renders a real error. This matches
  #     Scenarios_Delete, which surfaces its 404. Revisit only if the service
  #     returns 204 for an absent delete, as Workspaces_Delete already does.
  #     Do not attach response body schemas here: Remove-* cmdlets should
  #     emit nothing unless -PassThru is supplied. ---
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "Scenarios_Delete")]
    transform: >-
      $.responses["202"] = $.responses["202"] || { description: "Accepted." }
  - from: swagger-document
    where: $.paths.*[?(@.operationId == "ScenarioConfigurations_Delete")]
    transform: >-
      delete $["x-ms-long-running-operation"]; delete $["x-ms-long-running-operation-options"]

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
    - model-name: ActionDependency
    - model-name: KeyValuePair
```
