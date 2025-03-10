<!-- region Generated -->
# Az.Websites
This directory contains the PowerShell module for the Websites service.

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
For information on how to develop for `Az.Websites`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: b5d78da207e9c5d8f82e95224039867271f47cdf
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/AppServiceEnvironments.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/AppServicePlans.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/Certificates.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/CommonDefinitions.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/DeletedWebApps.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/Diagnostics.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/Global.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/Provider.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/Recommendations.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/ResourceHealthMetadata.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/ResourceProvider.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/StaticSites.json
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/WebApps.json

title: Websites
module-version: 0.2.0
subject-prefix: $(service-name)
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  #Modify operationId
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites"].get.operationId
    transform: return "StaticSites_ListStaticSitesByResourceGroup"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds"].get.operationId
    transform: return "StaticSites_ListStaticSiteBuilds"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds"].get.operationId
    transform: return "StaticSites_ListStaticSiteBuilds"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds/{environmentName}/userProvidedFunctionApps"].get.operationId
    transform: return "StaticSites_ListUserProvidedFunctionAppsByBuild"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps"].get.operationId
    transform: return "StaticSites_ListUserProvidedFunctionAppsByStaticSite"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps/{functionAppName}"].get.operationId
    transform: return "StaticSites_ListUserProvidedFunctionAppByFunctionName"

  # Remove default response
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publishxml"].post.responses
    transform: >-
      return {
          "200": {
            "description": "OK",
            "schema": {
              "type": "file"
            }
          }
        }

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publishxml"].post.responses
    transform: >-
      return {
          "200": {
            "description": "OK",
            "schema": {
              "type": "file"
            }
          }
        }

  # Add 204 status code of response.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "OK."
          },
          "204": {
            "description": "OK."
          },
          "202": {
            "description": "Asynchronous operation in progress."
          },
          "default": {
            "description": "App Service error response.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/b5d78da207e9c5d8f82e95224039867271f47cdf/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
            }
          }
        }

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/customDomains/{domainName}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "OK."
          },
          "204": {
            "description": "The domain does not exist."
          },
          "202": {
            "description": "Asynchronous operation in progress."
          },
          "default": {
            "description": "App Service error response.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/b5d78da207e9c5d8f82e95224039867271f47cdf/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
            }
          }
        }

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/authproviders/{authprovider}/users/{userid}"].delete.responses
    transform: >-
      return {
          "200": {
            "description": "OK."
          },
          "204": {
            "description": "The user does not exist."
          },
          "default": {
            "description": "App Service error response.",
            "schema": {
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/b5d78da207e9c5d8f82e95224039867271f47cdf/specification/web/resource-manager/Microsoft.Web/stable/2024-04-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
            }
          }
        }

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/regenerateAccessKey"]

# Use "StaticWebApp" as subject prefix
  - where:
      subject-prefix: Websites
      subject: StaticSite(.*)
    set:
      subject-prefix: StaticWebApp
      subject: $1

# Remove the cmdlet
  - where:
      verb: Set
    remove: true

  - where:
      subject: (.*)PrivateLink(.*)
    remove: true 

  - where:
      subject: (.*)PrivateEndpoint(.*)
    remove: true

  # swagger definiition incorrect.
  - where:
      subject: PreviewWorkflow
    remove: true
  
  # Server not implement.
  - where:
      subject: ZipDeployment
    remove: true

# Rename cmdlet
  - where:
      verb: Invoke
      subject: WorkflowPreview|PreviewWorkflow
    set:
      verb: New
      subject: PreviewWorkflow
    # alternatives:
    # New-AzStaticWebAppPreviewWorkflow
    # New-AzStaticWebAppWorkflowPreview

  - where:
      subject: CustomDomainCanBeAddedToStaticSite
    set:
      subject: CustomDomain

  - where:
      subject: ^AppSetting$
    set:
      subject: Setting

  # Rename `Invoke-` cmdlets, using better verbs
  - where:
      verb: Invoke
      subject: Detach
    set:
      verb: Remove
      subject: AttachedRepository
    # alternatives:
    # Remove-AzStaticWebAppAttachedRepository
    # Remove-AzStaticWebAppAttachedRepo
    # Remove-AzStaticWebAppRepository
  - where:
      verb: Invoke
      subject: DetachUserProvidedFunctionAppFromStaticSite
    set:
      verb: Unregister
      subject: UserProvidedFunctionApp
  - where:
      verb: Invoke
      subject: DetachUserProvidedFunctionAppFromStaticSiteBuild
    set:
      verb: Unregister
      subject: BuildUserProvidedFunctionApp

# Remove variant
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^CreateViaIdentityExpanded$|^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: CustomDomain

    remove: true
  - where:
      verb: Test
      variant: ^Validate$|^ValidateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: CustomDomain
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: BuildAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: FunctionAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: Setting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: BuildFunctionAppSetting
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
      # We got to keep the Create variant of CustomDomain because it's special that it doesn't have a
      # CreateExpanded variant, because the only parameters are all in URL rather than request body
      subject: UserRoleInvitationLink
    remove: true

  - where:
      verb: New
      subject: ^$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where:
      verb: Update
      subjet: null
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Reset
      subject: ApiKey
      variant: ^Reset$|^ResetViaIdentity$
    remove: true

  - where:
      verb: Register
      subject: UserProvidedFunctionApp
      variant: ^Register$|^Register1$|^RegisterViaIdentity$|^RegisterViaIdentity1$|^RegisterViaIdentityExpanded$|^RegisterViaIdentityExpanded1$
    remove: true

# Rename parameters
  - where:
      parameter-name: BuildProperty(.*)
    set:
      parameter-name: $1

  - where:
      parameter-name: Authprovider
    set:
      parameter-name: AuthProvider

  - where:
      parameter-name: IsForced
    set:
      parameter-name: Forced

  - where:
      parameter-name: Userid
    set:
      parameter-name: UserId

  - where:
      subject: .*Setting
      parameter-name: Property
    set:
      parameter-name: AppSetting

  - where:
      verb: New|Update
      subject: $
      parameter-name: TemplatePropertyTemplateRepositoryUrl
    set:
      parameter-name: TemplateRepositoryUrl
 
  - where:
      verb: New|Update
      subject: $
      parameter-name: TemplatePropertyRepositoryName
    set:
      parameter-name: ForkRepositoryName

  - where:
      verb: New|Update
      subject: $
      parameter-name: TemplateProperty(.*)
    set:
      parameter-name: ForkRepository$1

  # Hide New/Updaete-AzStaticWebApp for remove no-require sku parameters.
  - where:
      verb: New
      subject: ^$
    hide: true
  
  # Customise for webapp swagger. Only keep continuouswebjobs path and delete others path.

  - from: swagger-document
    where: $.definitions.OperationResultProperties
    transform: delete $.properties.error

  - from: swagger-document
    where: $.definitions.Expression
    transform: delete $.properties.value

  - from: swagger-document
    where: $.definitions.ExpressionTraces
    transform: delete $.properties.value

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus/{deploymentStatusId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus/{deploymentStatusId}"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}"]

  # - from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs"].get.description
  # transform: return "List webjobs for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs/{webJobName}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs"].get.description
  #  transform: return "List webjobs for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"].get.description
  #  transform: return "Get or list triggered web for an app."

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"].delete.description
  #  transform: return "Delete a triggered web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}"].get.description
  #  transform: return "Get or list triggered web job's history for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run"].post.description
  #  transform: return "Run a triggered web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"].get.description
  #  transform: return "Get or list triggered web for a deployment slot."

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"].delete.description
  #  transform: return "Delete a triggered web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}"].get.description
  #  transform: return "Get or list triggered web job's history for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run"].post.description
  #  transform: return "Run a triggered web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"].get.description
  #  transform: return "Get or list continuous web for an app."

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"].delete.description
  #  transform: return "Delete a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/start"]
  
  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/start"].post.description
  #  transform: return "Start a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/stop"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/stop"].post.description
  #  transform: return "Stop a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"].get.description
  #  transform: return "Get or list continuous web for a deployment slot."

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"].delete.description
  #  transform: return "Delete a continuous web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/start"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/start"].post.description
  #  transform: return "Start a continuous web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/stop"]

  #- from: swagger-document
  #  where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/stop"].post.description
  #  transform: return "Stop a continuous web job for a deployment slot."

# Use "WebApp" as subject prefix
  - where:
      subject-prefix: Websites
      subject: WebApp(.*)
    set:
      subject-prefix: WebApp
      subject: $1

  - where:
      subject: ContinuouWebJob
    set:
      subject: ContinuousWebJob

  - where:
      subject: ContinuouWebJobSlot
    set:
      subject: SlotContinuousWebJob

  - where:
      subject: TriggeredWebJobSlot
    set:
      subject: SlotTriggeredWebJob

  - where:
      subject: TriggeredWebJobHistorySlot
    set:
      subject: SlotTriggeredWebJobHistory

  - where:
      subject: WebJobSlot
    set:
      subject: SlotWebJob

  # The service response result is "No route registered for '/api/webjobs/webjobname?api-version=2021-02-01'"
  #- where:
  #    verb: Get
  #    subject: ^WebJob$|^SlotWebJob$
  #    variant: Get|GetViaIdentity
  #  remove: true

  - where:
      subject: WebJob|ContinuousWebJob|TriggeredWebJob|TriggeredWebJobHistory|SlotContinuousWebJob|SlotWebJob|SlotTriggeredWebJob|SlotTriggeredWebJobHistory
      parameter-name: Name
    set:
      parameter-name: AppName

  - where:
      subject: WebJob|ContinuousWebJob|TriggeredWebJob|TriggeredWebJobHistory|SlotContinuousWebJob|SlotWebJob|SlotTriggeredWebJob|SlotTriggeredWebJobHistory
      parameter-name: WebJobName
    set:
      parameter-name: Name

  - where:
      subject: SlotWebJob|SlotContinuousWebJob|SlotTriggeredWebJob|SlotTriggeredWebJobHistory
      parameter-name: Slot
    set:
      parameter-name: SlotName

  - where:
      model-name: WebJob|TriggeredWebJob
    set:
      format-table:
        properties:
          - Name
          - Kind
          - WebJobType
  - where:
      model-name: ContinuousWebJob
    set:
      format-table:
        properties:
          - Name
          - Status
          - Kind
          - WebJobType
# Becaue add webjob swagger, according to the modle has two id properties. one is resource id, other is job history id. For keep origin id(resource id).
  - where:
      model-name: WebsitesIdentity
      property-name: Id
    set:
      property-name: JobHistoryId
  - where:
      model-name: WebsitesIdentity
      property-name: Id1
    set:
      property-name: Id
```
