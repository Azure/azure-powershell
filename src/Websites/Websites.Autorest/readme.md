<!-- region Generated -->
# Az.Websites
This directory contains the PowerShell module for the Websites service.

---
## Status
[![Az.Websites](https://img.shields.io/powershellgallery/v/Az.Websites.svg?style=flat-square&label=Az.Websites "Az.Websites")](https://www.powershellgallery.com/packages/Az.Websites/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Websites`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7a2cc29033fe4027ef421267f1684efbd0d40a93
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/StaticSites.json

title: Websites
module-version: 0.1.0
subject-prefix: $(service-name)
identity-correction-for-post: true

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
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/7a2cc29033fe4027ef421267f1684efbd0d40a93/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
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
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/7a2cc29033fe4027ef421267f1684efbd0d40a93/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
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
              "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/7a2cc29033fe4027ef421267f1684efbd0d40a93/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/CommonDefinitions.json#/definitions/DefaultErrorResponse"
            }
          }
        }
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
```
