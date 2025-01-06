<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->

## Upcoming Release
* upgraded nuget package to signed package.
* Added DefaultApiVersion to the returned properties of the `Get-AzResourceProvider` cmdlet's Resource Type array
* Added Diagnostics/Warnings to WhatIf/Validate results for deployments.
* Fixed bug unexpected type issue: [#26752]
* Added parameter `RequestedAccessTokenVersion` for `New-AzADApplication` and `Update-AzADApplication`

## Version 7.7.0
* Updated Resources SDK to 2024-07-01.
* Fixed overriding of Bicep parameters in Deployment Stack cmdlets to support SecureString parameters.
* Updated verbose status log during stack deployments to show deployment status.

## Version 7.6.0
* Fixed customer-reported `Remove-AzPolicyAssignment` behavior.
* Added new cmdlets of DataBoundary

## Version 7.5.0
* Added `ResourceSelector` and `Override` parameters to `New/Update-AzPolicyAssignment`.
* Added `ResourceSelector` parameter to `New/Update-AzPolicyExemption`.
* Removed `Experimental` notice from `-WithSource` parameter to `Publish-AzBicepModule`.

## Version 7.4.0
* Fixed secrets exposure in example documentation.
* `Remove-AzResourceGroup` - support parameter "[-ForceDeletionType]".
* Removed specific characters from the codebase to unblock digital signature verification.

## Version 7.3.0
* Added null check and empty list check to the permissions object in the ToPSRoleDefinition method.
* Added argument completer for `EnforcementMode`, `IdentityType`
    * `New-AzPolicyAssignment`
    * `New-AzPolicyExemption`
    * `Update-AzPolicyAssignment`
    * `Update-AzPolicyExemption`
* Fixed bug deserializing property: `policyDefinitionReferenceId` [#25112]
* Fixed overriding of Bicep parameters in Deployment cmdlets to support `SecureString` parameters.
* Added Test cmdlets for Deployment Stacks.

## Version 7.2.0
* Fixed `Set-AzPolicyAssignment` loses description and Display Name [#25362]
* Fixed `New-AzPolicyAssignment` string ID value handling for parameter '-PolicyDefinition'
* Fixed policy import issue with OP (requires serialization of null values)
* Fixed '-Scope' parameter handling at resource instance level
* Fixed error `Get-AzPolicySetDefinition`cannot find matched parameter '-Name' [#25334]
* Fixed serialization issue with empty arrays in PolicyParameterObject
* Addressed a rare case where a service principal does not have AppId
* Introduced validation of MG scoped deployment stack during New/Set cmdlet execution.
* Updated Remove/New stack cmdlets with warnings for management groups ActionOnUnmanage and removed DeleteResourcesAndResourceGroups as valid ActionOnUnmanage value.
* Supported get and assign versioned policy definitions and sets
* Fixed syntax incompatible with windows powershell [#24971]
* Fixed bug with `Get-AzPolicyExemption` requesting 'ParentResourcePath'
* Supported `ServiceManagementReference` of Entra App
    * `Get-AzADApplication`
    * `New-AzADApplication`
    * `Update-AzADApplication`
* Fixed deployment stack validation error surfacing.
* Fixed default formatting for output objects
* Removed '-InputObject' for
    * `Get-AzPolicyAssignment`
    * `Get-AzPolicyDefinition`
    * `Get-AzPolicyExemption`
    * `Get-AzPolicySetDefinition`
    * `New-AzPolicyAssignment`
    * `New-AzPolicyDefinition`
    * `New-AzPolicySetDefinition`
* Implemented '-Version' and '-ListVersion' parameters on `Get-AzPolicyDefinition` and `Get-AzPolicySetDefinition`

## Version 7.1.0
* Fixed deployment and deployment stack New/Set cmdlets to fail if template/parameter uri fails to downloads.
* Deployment Stack cmdlets GA release/updates.
* [Breaking Change] Redesigned CRUD cmdlets for `PolicyAssignment`, `PolicyDefinition`, `PolicyExemption`, `PolicySetDefinition`. Please see Az 12 migration guide https://learn.microsoft.com/en-us/powershell/azure/migrate-az-12.0.0 for more detail.
* Added null check to the permissions object in the ToPSRoleDefinition method to return if the whole permissions object array is null.

## Version 6.16.2
* Introduced secrets detection feature to safeguard sensitive data.
* Migrated SDK generation from autorest csharp to autorest powershell.

## Version 6.16.1
* Added null check to the permissions object in the ToPSRoleDefinition method.
* Added dynamic parameters to stack New/Set cmdlets.
* Used correct JSON serializer settings for all templates-related deserialization.

## Version 6.16.0
* Added breaking change warnings for Azure Policy cmdlets.
* Added `AuxTenant` parameter in `New-AzResourceGroupDeployment`to support cross-tenant deployment.
* Fixed bug with custom types and deployments whatif. [#13245]
* Fixed bug with nullable array parameters & outputs.
* Fixed bug with TemplateParameterUri not downloading parameters correctly.

## Version 6.15.1
* Fixed deadlock in Bicep CLI execution. [#24133]

## Version 6.15.0
* Supported `-SkipClientSideScopeValidation` in RoleAssignment and RoleDefinition related commands. [#22473]
* Updated Bicep build logic to use --stdout flag instead of creating a temporary file on disk.
* Fixed exception when `-ApiVersion` is specified for `Get-AzResource`, affected by some resource types.
* Refactored deployment base cmdlet.

## Version 6.14.0
* Fixed ABAC condition not included in role definition payload. Get-AzRoleDefinition will now contain ABAC Condition and ConditionVersion info when applicable.

## Version 6.13.0
* Added AppRoleAssigment related commands for service principal. [#18412]
* Added `-WithSource` parameter to `Publish-AzBicepModule` for publishing source with a module (currently experimental)
* Supported nullable Bicep parameters in Deployment cmdlets
* Updated Get-AzRoleDefinition to api-version "2022-05-01-preview" and returns ABAC condition information
* Added a couple missing validators and completers to Deployment Stack cmdlets.

## Version 6.12.1
* Used utf8 encoding for reading stdout & stderr when invoking Bicep. [#23246]
* Fixed regression in `Publish-AzBicepModule` [Azure/bicep/12461](https://github.com/Azure/bicep/issues/12461)

## Version 6.12.0
* Supported $ref statements for user-defined types in Bicep files.
* Fixed reporting duplicate warnings when compiling Bicep files.
* Updated New and Set Management Group cmdlets to allow DeploymentSubscription to be optional.
* Fixed inexplicable error message when subscription and scope are neither provided in RoleAssignment/RoleDefinition related commands. [#22716]

## Version 6.11.2
* Fixed bug where `.bicepparam` values were not being correctly serialized in the correct format.
* Allowed supplemental parameters for Deployments cmdlets when used with `.bicepparam` file.

## Version 6.11.1
* Reverted commits that caused regression in `Get-AzRoleAssignment`. [#22863]

## Version 6.11.0
* Supported `TemplateParameterFile` to accept a `.bicepparam` file.
* Fixed inexplicable error message when subscription and scope are neither provided in `Get-AzRoleDefinition`. [#22716]

## Version 6.10.0
* Added breaking change warnings for Azure Policy cmdlets.
* Implemented logic that allows Deployment Stack objects to be piped into Save and Remove Deployment Stack cmdlets.

## Version 6.9.1
* Fixed the warning prompt condition check in New-Az*DeploymentStack cmdlets.

## Version 6.9.0
* Fixed the issue that `New-AzRoleAssignment` didn't work without subscription.
* Added cmdlets for group owner
    - `Get-AzADGroupOwner`
    - `New-AzADGroupOwner`
    - `Remove-AzADGroupOwner`
* Updated Tags functionality in deployment stacks New and Set cmdlets

## Version 6.8.0
* Fixed the incorrect behavior of pagination for `Get-AzTag`
* Updated API version to 2022-09-01
* Added Deployment Stacks cmdlets
* Added support for dynamic parameters when deploying symbolic name templates.
* Fixed `Set-AzPolicyExemption` parameter PolicyDefinitionReferenceId not accept empty array.
* Fixed `Get-AzPolicyExemption` output not contain system data.

## Version 6.7.0
* Added parameter `-CountVariable` for list operations, `odataCount` can now be assigned to this variable [#20982]
    - `Get-AzADApplication`
    - `Get-AzADServicePrincipal`
    - `Get-AzADUser`
    - `Get-AzADGroup`
* Supported polymorphism for `Get-AzADGroupMember`, output of this cmdlet was now `Application` `ServicePrincipal`, `User` and `Group` based on the `odataType` [#19728]
* Added `-Force` parameter on `Publish-AzBicepModule` for supporting overwriting existing modules.
* Fixed `New-AzADApplication` when multiple redirect url types were provided. [#21108]
* Fixed `Update-AzADServicePrincipal` when empty array passed for `IdentifierUri` [#21345]
* Fixed an issue where location header was missing in the response from the service for `New-AzManagedApplication`.
* Fixed `Get-AzResourceGroup` ignored the subscription ID in `-Id` [#21725]

## Version 6.6.1
* Added support for Azure resources deployment with parameters file using Bicep parameters syntax

## Version 6.6.0
* Fixed an issue when running the `New-AzManagementGroup` command where it tried to cast an async operation as a Management Group. [#21000]
* Fixed an issue when running `Get-AzResourceGroup -Name 'some_name'`, it ignores '-Location' if specified[#21225]

## Version 6.5.3
* Updated behavior of Get-AzPolicyDefinition which previously returned all definitions when -Id was provided with a nonexistent policy definition id. Fixed to correctly throw a 404 exception in this case.
* Updated `Publish-AzBicepModule` to include new optional parameter `-DocumentationUri`

## Version 6.5.2
* Fixed query issue when objectId in assignment is empty for `Get-DenyAssignment`
* Fixed an issue where running deployment cmdlets with `-WhatIf` throws exception when formatting results with nested array changes

## Version 6.5.1
* Fixed issue introduced in previous fix for `Set-AzPolicySetDefinition` InternalServerError when the initiative is too large [#20238], which will remove space in value.
* Fixed `Get-AzRoleAssignment` BadRequest when scope is '/' [#20323]

## Version 6.5.0
* Added cmdlet `Get-AzADOrganization`
* Fixed `Set-AzPolicySetDefinition` InternalServerError when the initiative is too large [#20238]

## Version 6.4.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 6.4.0
* Fixed parameter `Count` for
    - Get-AzADApplication
    - Get-AzADServicePrincipal
    - Get-AzADUser
* Polished preview warning message for:
    - Add-AzADGroupMember
    - Get-AzADGroupMember
    - Remove-AzADGroupMember
* Fixed a `NullReferenceException` when deploying a JSON template using Bicep extensibility
* Added `-AsJob` to support running `Register-AzResourceProvider` as a Job

## Version 6.3.1
* Fixed NullReferenceException issue in `New-AzRoleAssignment` [#19793]

## Version 6.3.0
* Removed unused reference to resource identifier in role assignment create cmdlet
* Exposed parameter `-Count` for `Get-AzADApplication`, `Get-AzADServicePrincipal`, `Get-AzADGroup` [#19476]

## Version 6.2.0
* Fixed bug `-Password` overwrite `-PasswordProfile` in `New-AzADUser` [#19265]
* Exposed `EmployeeOrgData` `Manager` for `Get-AzADUSer` [#18205]
* Exposed parameter `-Count` for `Get-AzADUser` [#16874]

## Version 6.1.0
* Removed the warning messages for MSGraph migration [#18856]
* [Breaking Change] Renamed cmdlet from `{}-AzADAppFederatedIdentityCredential` to `{}-AzADAppFederatedCredential`
* [Breaking Change] Renamed `-Id` to `-FederatedCredentialId` for
    - `Get-AzADAppFederatedCredential`
    - `Remove-AzADAppFederatedCredential`
    - `Update-AzADAppFederatedCredential`
* Upgraded API version from Beta to 1.0

## Version 6.0.1
* Added feedback when deleting role assignments even if passthru is not used
* Fixed relative path failure in -AsJob scenario [#18084]
* Fixed logic of `createtime` and `ChangedTime` in `Get-AzResource --ExpandProperties`. [#18206]
* Fixed role assignment latency for `New-AzADServicePrincipal` [#16777]

## Version 6.0.0
* Added cmdlet for Application federated identity credential
    - `Get-AzADAppFederatedIdentityCredential`
    - `New-AzADAppFederatedIdentityCredential`
    - `Remove-AzADAppFederatedIdentityCredential`
    - `Update-AzADAppFederatedIdentityCredential`
* Upgraded and revised `Get-AzLocation` cmdlet:
    - Upgraded `subscriptionClient` for `Get-AzLocation`. Changed its apiVersion from 2016-01-01 to 2021-01-01.[#18002]
    - Added all attributes of location info for `Get-AzLocation`, including `pairedRegion` and so on. [#18045][#17536]
    - Support ExtendedLocations by `Get-AzLocation` [#18046]
* Added the following cmdlets to remain in parity with 2021-04-01 API version:
    - `New-AzHierarchySetting`
    - `Get-AzHierarchySetting`
    - `Update-AzHierarchySetting`
    - `Remove-AzHierarchySetting`
    - `Get-AzManagementGroupSubscription`
    - `Get-AzSubscriptionUnderManagementGroup`
    - `Start-AzTenantBackfill`
    - `Get-AzTenantBackfillStatus`
    - `Get-AzManagementGroupNameAvailability`
    - `Get-AzEntity`
* [Breaking Change] Renamed property `isSyncedFromOnPremis` to `isSyncedFromOnPremise` to align with API spec

## Version 5.6.0
* Fixed redundant quotes in list pagination [#17667]
* Added cmdlet `Update-AzADGroup` [#17514]
* Updated API version to beta for group member related cmdlet to allow service principal to be add, get and delete from group [#16698]
* Added parameter '-OwnedApplication' for `Get-AzADApplication` to get applications owned by current user
* Added parameter '-Web' for `Update-AzADApplication` [#16750]

## Version 5.5.0
* Removed `-ApplicationId` from `New-AzADServicePrincipal` `SimpleParameterSet` [#17256]
* Added `New-AzResourceManagementPrivateLink`, and `New-AzPrivateLinkAssociation` cmdlets
* Added authorization related cmdlets:
    - `Get-AzRoleAssignmentSchedule`
    - `Get-AzRoleAssignmentScheduleInstance`
    - `Get-AzRoleAssignmentScheduleRequest`
    - `Get-AzRoleEligibilitySchedule`
    - `Get-AzRoleEligibilityScheduleInstance`
    - `Get-AzRoleEligibilityScheduleRequest`
    - `Get-AzRoleEligibleChildResource`
    - `Get-AzRoleManagementPolicy`
    - `Get-AzRoleManagementPolicyAssignment`
    - `New-AzRoleAssignmentScheduleRequest`
    - `New-AzRoleEligibilityScheduleRequest`
    - `New-AzRoleManagementPolicyAssignment`
    - `Remove-AzRoleManagementPolicy`
    - `Remove-AzRoleManagementPolicyAssignment`
    - `Stop-AzRoleAssignmentScheduleRequest`
    - `Stop-AzRoleEligibilityScheduleRequest`
    - `Update-AzRoleManagementPolicy`
* Added `Get-AzResourceManagementPrivateLink`, `Remove-AzResourceManagementPrivateLink`, `Get-AzResourceManagementPrivateLinkAssociation` and  `Remove-AzResourceManagementPrivateLinkAssociation` cmdlets

## Version 5.4.0
* Fixed keycredential key format, from base64url to byte [#17131]
* Fixed add key credential overwrite existing one [#17088]
* Deleted parameter sets cannot be reached for `New-AzADSericePrincipal`
* Marked `ObjectType` as `Unknown` if object is not found or current account has insufficient privileges to get object type for role assignment [#16981]
* Fixed that `Get-AzRoleAssignment` shows empty RoleDefinitionName for custom roles when not specifying scope [#16991]
* Unified the returned `RoleDefinitionId` in PSRoleAssignment to GUID [#16991]

## Version 5.3.1
* Fixed `New-AzADServicePrincipal` not working [#17054] [#17040]

## Version 5.3.0
* Added proeprties `onPremisesLastSyncDateTime`, `onPremisesSyncEnabled` to `User` object [#16892]
* Added additional properties when creating request for `New-AzADServicePrincipal` and `Update-AzADServicePrincipal` [#16847] [#16841]
* Fixed `DisplayName` and `ApplicationId` for `New-AzADAppCredential` [#16764]
* Enabled password reset for `Update-AzADUser` [#16869]
* Updated parameter name `EnableAccount` to `AccountEnabled`, and added alias `EnableAccount` for `Update-AzADUser` [#16753] [#16795]
* Fixed `Set-AzPolicyAssignment` does not remove `notScope` if empty [#15828]

## Version 5.2.0
* Fixed incorrect alias for `Get-AzADSpCredential` [#16592]
* Fixed `ServicePrincipalName` and `InputObject` parameters for `Update-AzADServicePrincipal` [#16620]
* Fixed example for `New-AzADAppCredential` [#16682]
* Added parameter `Web` for `New-AzADApplication` [#16659]
* Added secret text in response of `New-AzADApplication` and `New-AzADServicePrincipal` [#16659]
* Deserialized the `Value` in `DeploymentVariable` as object array if its type is Array [#16523]
* Fixed the usage of `SignInName` in `New-AzRoleAssignment` [#16627]
* Formatted the output format of `DeploymentVariable`
* Remove `isUser` operation filter from GetAzureProviderOperation Cmdlet

## Version 5.1.0
* Added 'Get-AzProviderPreviewFeature', 'Register-AzProviderPreviewFeature' and 'Unregister-AzProviderPreviewFeature' cmdlets.
* Fixed a bug when running Get-AzPolicyAlias with empty value of NamespaceMatch parameter [#16370]
* [Breaking change] Migrated from AAD Graph to Microsoft Graph
* [Breaking change] Changed the returned `Id` in PSDenyAssignment from GUID string to fully qualified ID
* Allowed parameter `Id` in `Get-AzDenyAssignment` to accept fully qualified ID
* Added new cmdlet `Publish-AzBicepModule` for publishing Bicep modules
* Added deprecation message for `AssignIdentity` parameter in `*-AzPolicyAssignment` cmdlets.
* Added support for user assigned managed identities in policy assignments by adding `IdentityType` and `IdentityId` parameters to `*-AzPolicyAssignment` cmdlets.
* Updated policy cmdlets to use new api version 2021-06-01 that introduces support for user assigned managed identities in policy assignments.
* Narrowed API permission when get information about active directory object for *-AzRoleAssignment [#16054]

## Version 4.4.1
* Fixed a bug about the exitcode of Bicep [#16055]
* Added breaking change warnings for AAD cmdlets
* Added property `UIFormDefinition` to Template Spec Versions,  `Export-AzTemplateSpec` will now include a Template Spec Version's UIFormDefinition (if any) as part of the export.
* Added error catching for role assignment creation fail while creating a Service Principal
* Performance improvement for Get-AzPolicyAlias when -NamespaceMatch matches a single RP namespace

## Version 4.4.0
* Added a clearer error message for a case in which TemplateUri do not accept bicep file.
* Fixed typos with ManagementGroups breaking change descriptions [#15819].
* Fixed resource tags casing issue - resource tags casing not being preserved.
* Updated to Microsoft.Azure.Management.Authorization 2.13.0-preview.

## Version 4.3.1
* Use JsonExtensions to serialize deserialize JSON objects to ensure the use of custom serialization settings [#15552]
* Added support for `Unsupported` and `NoEffect` change types to deployment What-If cmdlets.
* Added support for `ConsentToPermissions` Boolean parameter to Register-AzResourceProvider cmdlet.

## Version 4.3.0
* Fixed bug with `PSResource` where some constructors left `SubscriptionId` property unassigned/null.  [#10783]
* Added support for creating and updating Template Spec in Bicep file [#15313]
* Added `-ProceedIfNoChange` parameter to deployment create cmdlets.

## Version 4.2.0
* Allowed naming the deployment when testing deployments [#11497]

## Version 4.1.1
* Fixed issue that property `IdentifierUri` is cleaned by `Update-AzAdApplication` [#15134]

## Version 4.1.0
* Changed `-IdentifierUris` in `New-AzADApplication` to optional parameter
* Removed generated `DisplayName` of ADApplication created by `New-AzADServicePrincipal`
* Updated SDK to 3.13.1-preview to use GA TemplateSpecs API version
* Added `AdditionalProperties` to PSADUser and PSADGroup [#14568]
* Supported `CustomKeyIdentifier` in `New-AzADAppCredential` and `Get-AzADAppCredential` [#11457], [#13723]
* Changed `MainTemplate` to be shown by the default formatter for Template Spec Versions
* Added support for `NonComplianceMessage` to `*-AzPolicyAssignment` cmdlets

## Version 3.5.0
* Added parameter `ObjectType` for `New-AzRoleAssignment`
* Fix version checking bug in `Set-AzRoleAssignment`
* Updated to use SDK version 3.13-preview
* Template Spec Versions: Renamed artifacts to linkedTemplates
* Template Spec Versions: Renamed "template" to "mainTemplate"
* Added support for UIFormDefinition for New-AzTemplateSpec and Set-AzTemplateSpec

## Version 3.4.1
* Added upcoming breaking change warnings on below cmdlets, because the value of `IdentifierUris` parameter will need verified domain.
  - `New-AzADApplication`
  - `Update-AzADApplication`
  - `New-AzADServicePrincipal`
  - `Update-AzADServicePrincipal`
* Ignored Bicep warning message in error stream if exitcode equals zero.

## Version 3.4.0
* Redirected bicep message to verbose stream
* Removed the logic of copying Bicep template file to temp folder.
* Added support of policy exemption resource type
* Fixed what-if functionality when using `-QueryString` parameter.
* Normalized `-QueryString` starting with "?" for scenarios involving dynamic parameters.

## Version 3.3.0
* Added support for Azure resources deployment in Bicep language
* Fixed issues with TemplateSpec deployments in `New-AzTenantDeployment` and `New-AzManagementGroupDeployment`
* Added support for `-QueryString` parameter in `Test-Az*Deployments` cmdlets
* Fixed issue with dynamic parameters when `New-Az*Deployments` is used with `-QueryString`
* Added support for `-TemplateParameterObject` parameter while using `-TemplateSpecId` parameter in `New-Az*Deployments` cmdlets
* Fixed the inaccurate error message received on trying to deploy a non-existent template spec
* Added support for policy export format to ```New-AzPolicyDefinition -Policy```
* Add support for property updates from ```Set-AzPolicyAssignment -InputObject```

## Version 3.2.1
* Removed principal type on New-AzRoleAssignment and Set-AzRoleAssignment because current mapping was breaking certain scenarios

## Version 3.2.0
* Added support for -QueryString parameter in New-Az*Deployments cmdlets

## Version 3.1.1
* Fixed a NullRef exception issue in `New-AzureManagedApplication` and `Set-AzureManagedApplication`.
* Updated Azure Resource Manager SDK to use latest DeploymentScripts GA api-version: 2020-10-01.

## Version 3.1.0
* Added `-Tag` parameter support to `Set-AzTemplateSpec` and `New-AzTemplateSpec`
* Added Tag display support to default formatter for Template Specs

## Version 3.0.1
* Fixed an issue where What-If shows two resource group scopes with different casing
* Updated `Export-AzResourceGroup` to use the SDK.
* Added culture info to parse methods
* Fixed issue where attempts to deploy template specs from a subscription outside of the current subscription context would fail
* Changed Double parser for version parser
* Changed New-AzRoleAssignment to include principal type during calls
* Changed Set-AzRoleAssignment to include principal type during calls

## Version 3.0.0
* Fixed parsing bug
* Updated ARM template What-If cmdlets to remove preview message from results
* Fixed an issue where template deployment cmdlets crash if `-WhatIf` is set at a higher scope [#13038]
* Fixed an issue where template deployment cmdlets does not preserve case for template parameters
* Added a default API version to be used in `Export-AzResourceGroup` cmdlet
* Added cmdlets for Template Specs (`Get-AzTemplateSpec`, `Set-AzTemplateSpec`, `New-AzTemplateSpec`, `Remove-AzTemplateSpec`, `Export-AzTemplateSpec`)
* Added support for deploying Template Specs using existing deployment cmdlets (via the new -TemplateSpecId parameter)
* Updated `Get-AzResourceGroupDeploymentOperation` to use the SDK.
* Removed `-ApiVersion` parameter from `*-AzDeployment` cmdlets.

## Version 2.5.1
* Added missing check for Set-AzRoleAssignment
* Added breaking change attribute to `SubscriptionId` parameter of `Get-AzResourceGroupDeploymentOperation`
* Updated ARM template What-If cmdlets to show "Ignore" resource changes last
* Fixed secure and array parameter serialization issues for deployment cmdlets [#12773]

## Version 2.5.0
* Updated `Get-AzPolicyAlias` response to include information indicating whether the alias is modifiable by Azure Policy.
* Created new cmdlet `Set-AzRoleAssignment`
* Added `Get-AzDeploymentManagementGroupWhatIfResult` for getting ARM template What-If results at management Group scope
* Added `Get-AzTenantWhatIfResult` new cmdlet for getting ARM template What-If results at tenant scope
* Overrode `-WhatIf` and `-Confirm` for `New-AzManagementGroupDeployment` and `New-AzTenantDeployment` to use ARM template What-If results
* Fixed the behaviors of `-WhatIf` and `-Confirm` for new deployment cmdlets so they comply with $WhatIfPreference and $ConfrimPreference
* Fixed serialization error for `-TemplateObject` and `TemplateParameterObject` [#1528] [#6292]

## Version 2.4.0
* Added properties "Condition", "ConditionVersion" and "Description" to `New-AzRoleAssignment`
    - This included all the relevant changes to the data models

## Version 2.3.0
* Updated `Save-AzResourceGroupDeploymentTemplate` to use the SDK.
* Added 'Unregister-AzResourceProvider' cmdlet.

## Version 2.2.0
* Added `UsageLocation`, `GivenName`, `Surname`, `AccountEnabled`, `MailNickname`, `Mail` on `PSADUser` [#10526] [#10497]
* Fixed issue that `-Mail` doesn't work on `Get-AzADUser` [#11981]
* Added `-ExcludeChangeType` parameter to `Get-AzDeploymentWhatIfResult` and `Get-AzResourceGroupDeploymentWhatIfResult`
* Added `-WhatIfExcludeChangeType` parameter to `New-AzDeployment` and `New-AzResourceGroupDeployment`
* Updated `Test-Az*Deployment` cmdlets to show better error messages
* Fixed help message for `-Name` parameter of deployment create and What-If cmdlets

## Version 2.1.0
* Added Tail parameter to Get-AzDeploymentScriptLog and Save-AzDeploymentScriptLog cmdlets
* Formatted Output property and show it on the Get-AzDeploymentScript cmdlet output
* Renamed -DeploymentScriptInputObject parameter to -DeploymentScriptObject
* Fixed missing file/target name in cmdlet messages.
* Updated assembly version of resource manager and tags cmdlets

## Version 2.0.1
* Added message warning about view delay when creating a new Role Definition
* Changed policy cmdlets to output strongly-typed objects
* Removed `-TenantLevel` parameter used for on the `Get-AzResourceLock` cmdlet [#11335]
* Fixed `Remove-AzResourceGroup -Id ResourceId`[#9882]
* Added new cmdlet for getting ARM template What-If results at resource group scope: `Get-AzDeploymentResourceGroupWhatIfResult`
* Added new cmdlet for getting ARM template What-If results at subscription scope: `Get-AzDeploymentWhatIfResult`
   - Alias: `Get-AzSubscriptionDeploymentWhatIf`
* Overrode `-WhatIf` and `-Confirm` parameters for `New-AzDeployment` and `New-AzResourceGroupDeployment` to use ARM template What-If results
* Added deprecation message for `ApiVersion` parameter in deployment cmdlets
* Added capability to show improved error messages for deployment failures
* Added correlationId logging for deployment failures
* Added `error` property to the deployment script output
* Updated nuget Microsoft.Azure.Management.ResourceManager to "3.7.1-preview"
* Removed specific test cases as Error property in DeploymentValidateResult has changed to readonly from nuget 3.7.1-preview
* Brought GenericResourceExpanded from SDK ResourceManager 3.7.1-preview
* Added tag support for all Get cmdlets for deployment, as well as
    - `New-AzDeployment`
    - `New-AzManagementGroupDeployment`
    - `New-AzResourceGroupDeployment`
    - `New-AzTenantDeployment`


## Version 1.13.0
* Fixed `Get-AzResource -ResourceGroupName -Name -ExpandProperties -ResourceType` to use actual apiVersion of resources instead of default apiVersion [#11267]
* Added correlationId logging for error scenarios
* Small documentation change to `Get-AzResourceLock`. Added example.
* Escaped single quote in parameter value of `Get-AzADUser` [#11317]
* Added new cmdlets for Deployment Scripts (`Get-AzDeploymentScript`, `Get-AzDeploymentScriptLog`, `Save-AzDeploymentScriptLog`, `Remove-AzDeploymentScript`)

## Version 1.12.0
* Fixed for null reference bug in `Get-AzRoleAssignment`
* Marked switch `-Force` and `-PassThru` optional in `Remove-AzADGroup` [#10849]
* Fixed issue that `MailNickname` doesn't return in `Remove-AzADGroup` [#11167]
* Fixed issue that `Remove-AzADGroup` pipe operation doesn't work [#11171]
* Fixed for null reference bug in GetAzureRoleAssignmentCommand
* Added breaking change attributes for upcoming changes to policy cmdlets
* Updated `Get-AzResourceGroup` to perform resource group tag filtering on server-side
* Extended Tag cmdlets to accept -ResourceId
    - Get-AzTag -ResourceId
    - New-AzTag -ResourceId
    - Remove-AzTag -ResourceId
* Added new Tag cmdlet
    - Update-AzTag -ResourceId
* Brought ScopedDeployment from SDK 3.3.0

## Version 1.11.0
* Refactored template deployment cmdlets
    - Added new cmdlets for managing deployments at management group: *-AzManagementGroupDeployment
    - Added new cmdlets for managing deployments at tenant scope: *-AzTenantDeployment
    - Refactored *-AzDeployment cmdlets to work specifically at subscription scope
    - Created aliases *-AzSubscriptionDeployment for *-AzDeployment cmdlets
* Fixed `Update-AzADApplication` when parameter `AvailableToOtherTenants` is not set
* Removed ApplicationObjectWithoutCredentialParameterSet to avoid AmbiguousParameterSetException.
* Regenerated help files

## Version 1.10.0
* Make -Scope optional in *-AzPolicyAssignment cmdlets with default to context subscription
* Add examples of creating ADServicePrincipal with password and key credential

## Version 1.9.1
* Fix an error in help document of `Remove-AzTag`.
* Fix for aliases missing from output of Get-AzPolicyAlias
* Update resource client to new version that retrieves providers and aliases at tenant level
* Update Get-AzPolicyAlias to retrieve aliases at tenant level
* Update -Policy parameter of New-AzPolicyDefinition and Set-AzPolicyDefinition to allow full policy object

## Version 1.9.0
* Update references in .psd1 to use relative path
* Fix an issue where template deployment fails to read a template parameter if its name conflicts with some built-in parameter name.
* Updated policy cmdlets to use new api version 2019-09-01 that introduces grouping support within policy set definitions.
* Fix the bug that the output of some sub-resource is empty when using `Get-AzResource`.

## Version 1.8.0
- Updated policy cmdlets to use new api version 2019-06-01 that has new EnforcementMode property in policy assignment.
- Updated create policy definition help example
- Fix bug Remove-AZADServicePrincipal -ServicePrincipalName, throw null reference when service principal name not found.
- Fix bug New-AZADServicePrincipal, throw null reference when tenant doesn't have any subscription.
- Change New-AzAdServicePrincipal to add credentials only to associated application.

## Version 1.7.1
* Update dependency assembly Microsoft.Extensions.Caching.Memory from 1.1.1 to 2.2

## Version 1.7.0
* Fix bug where New-AzRoleAssignment could not be called without parameter Scope.

## Version 1.6.2
* Add support for new api version 2019-05-10 for Microsoft.Resource
    - Add support for `copy.count = 0` for variables, resources and properties
    - Resources with `condition = false` or `copy.count = 0` will be deleted in complete mode
* Fixed miscellaneous typos across module
* Add an example of assigning policy at subscription level to help doc
* Added breaking change notice about new required parameter `-ScopeType` in the `AzDeployment` cmdlets
    - `Get-AzDeployment`
    - `Get-AzDeploymentOperation`
    - `New-AzDeployment`
    - `Remove-AzDeployment`
    - `Save-AzDeploymentTemplate`
    - `Stop-AzDeployment`
    - `Test-AzDeployment`

## Version 1.6.1
- Remove missing cmdlet referenced in `New-AzResourceGroupDeployment` documentation
- Updated policy cmdlets to use new api version 2019-01-01

## Version 1.6.0
- Fix help text for Get-AzPolicyState -Top parameter
- Add client-side paging support for Get-AzPolicyAlias
- Add new parameters for Set-AzPolicyAssignment, -PolicyParameters and -PolicyParametersObject
- Handful of doc and example updates for Policy cmdlets

## Version 1.5.0
* Support for additional Template Export options
    - Add `-SkipResourceNameParameterization` parameter to Export-AzResourceGroup
    - Add `-SkipAllParameterization` parameter to Export-AzResourceGroup
    - Add `-Resource` parameter to Export-AzResourceGroup for exported resource filtering

## Version 1.4.0
* Add new cmdlet Get-AzureRmDenyAssignment for retrieving deny assignments
* Added 'Description' parameter when working with Azure AD Groups:
    - Added a parameter to New-AzAdGroup
    - Added as output on Get-AzAdGroup

## Version 1.3.1
* Fix documentation for wildcards

## Version 1.3.0
* Improve handling of providers for `Get-AzResource` when providing `-ResourceId` or `-ResourceGroupName`, `-Name` and `-ResourceType` parameters
* Improve error handling for for `Test-AzDeployment` and `Test-AzResourceGroupDeployment`
    - Handle errors thrown outside of deployment validation and include them in output of command instead
    - More information here: https://github.com/Azure/azure-powershell/issues/6856
* Add `-IgnoreDynamicParameters` switch parameter to set of deployment cmdlets to skip prompt in script and job scenarios
    - More information here: https://github.com/Azure/azure-powershell/issues/6856

## Version 1.2.1
* Update wildcard support for Get-AzResource and Get-AzResourceGroup
* Update credentials used when making generic calls to ARM

## Version 1.2.0
* Add `-TemplateObject` parameter to deployment cmdlets
    - More information here: https://github.com/Azure/azure-powershell/issues/2933
* Fix issue when piping the result of `Get-AzResource` to `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/8240
* Fix issue with JSON data type change when running `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7930

## Version 1.1.3
* Fix for issue https://github.com/Azure/azure-powershell/issues/8166
* Fix for issue https://github.com/Azure/azure-powershell/issues/8235
* Fix for issue https://github.com/Azure/azure-powershell/issues/6219
* Fix bug preventing repeat creation of KeyCredentials

## Version 1.1.2
* Fix tagging for resource groups
    - More information here: https://github.com/Azure/azure-powershell/issues/8166
* Fix issue where `Get-AzureRmRoleAssignment` doesn't respect -ErrorAction
    - More information here: https://github.com/Azure/azure-powershell/issues/8235

## Version 1.1.1
* Fix incorrect examples in `New-AzADAppCredential` and `New-AzADSpCredential` reference documentation
* Fix issue where path for `-TemplateFile` parameter was not being resolved before executing resource group deployment cmdlets
* Az.Resources: Correct documentation for New-AzureRmPolicyDefinition -Mode default value
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/7522
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/5747
* Fix formatting issue with `PSResourceGroupDeployment` object
    - More information here: https://github.com/Azure/azure-powershell/issues/2123

## Version 1.1.0
* Fix parameter set issue when providing `-ODataQuery` and `-ResourceId` parameters for `Get-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7875
* Fix handling of the -Custom parameter in New/Set-AzPolicyDefinition
* Fix typo in New-AzDeployment documentation
* Made `-MailNickname` parameter mandatory for `New-AzADUser`
    - More information here: https://github.com/Azure/azure-powershell/issues/8220

## Version 1.0.0
* General availability of `Az.Resources` module
* Removed -Sku parameter from New/Set-AzPolicyAssignment
* Removed -Password parameter from New-AzADServicePrincipal and New-AzADSpCredential
