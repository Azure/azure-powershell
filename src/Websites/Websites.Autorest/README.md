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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Websites`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/7a2cc29033fe4027ef421267f1684efbd0d40a93/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01/StaticSites.json
  - https://github.com/Azure/azure-rest-api-specs/blob/ec2b6d1985ce89c8646276e0806a738338e98bd2/specification/web/resource-manager/Microsoft.Web/stable/2021-02-01/WebApps.json

title: Websites
module-version: 0.1.0
subject-prefix: $(service-name)
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

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
  
  # Customise for webapp swagger. Only keep continuouswebjobs path and delete others path.

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/providers/Microsoft.Web/sites"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/analyzeCustomHostname"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/applySlotConfig"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}/restore"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings/{appSettingKey}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings/{connectionStringKey}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/publishingcredentials/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}/recover"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs/zip/download"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/discoverbackup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/MSDeploy"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/MSDeploy/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/admin/token"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/keys/{keyName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/listkeys"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}/listsecrets"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listkeys"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listsyncstatus"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/sync"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/{keyType}/{keyName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/extensions/MSDeploy"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/extensions/MSDeploy/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/dump"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/threads"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/iscloneable"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listsyncfunctiontriggerstatus"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migrate"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql/status"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkConfig/virtualNetwork"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkFeatures/{view}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/operationresults/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/start"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/startOperation"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/stop"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/current/operationresults/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/newpassword"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/perfcounters"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/phplogging"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateLinkResources"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/dump"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/modules"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/modules/{baseAddress}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}/threads"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates/{publicCertificateName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publishxml"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resetSlotConfig"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restart"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromBackupBlob"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromDeletedApp"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreSnapshot"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/analyzeCustomHostname"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/applySlotConfig"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/backups/{backupId}/restore"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/appsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/appsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/azurestorageaccounts"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/azurestorageaccounts/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/backup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/backup/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings/{connectionStringKey}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/connectionstrings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/connectionstrings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/metadata"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/metadata/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/publishingcredentials/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/pushsettings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/pushsettings/list"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}/recover"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/containerlogs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/containerlogs/zip/download"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deployments/{id}/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/discoverbackup"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/extensions/MSDeploy"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/extensions/MSDeploy/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/admin/token"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listkeys"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/listsecrets"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/listkeys"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/listsyncstatus"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/sync"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/host/default/{keyType}/{keyName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hostNameBindings/{hostName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/extensions/MSDeploy"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/extensions/MSDeploy/log"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/dump"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/threads"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/iscloneable"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listsyncfunctiontriggerstatus"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/migratemysql/status"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkFeatures/{view}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/operationresults/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/start"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/startOperation"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/stop"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTrace/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTraces/current/operationresults/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkTraces/{operationId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/newpassword"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/perfcounters"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/phplogging"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateEndpointConnections/{privateEndpointConnectionName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateLinkResources"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/dump"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/modules"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/modules/{baseAddress}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}/threads"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates/{publicCertificateName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publishxml"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/resetSlotConfig"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restart"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreFromBackupBlob"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreFromDeletedApp"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/restoreSnapshot"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/slotsdiffs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/slotsswap"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/snapshots"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/snapshotsdr"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/start"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/startNetworkTrace"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/stop"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/stopNetworkTrace"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sync"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/syncfunctiontriggers"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/usages"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsdiffs"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsswap"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshots"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshotsdr"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/start"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/startNetworkTrace"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stop"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stopNetworkTrace"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sync"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/syncfunctiontriggers"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/usages"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}"]

  - from: swagger-document
    where: $.paths
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs"].get.description
    transform: return "List webjobs for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs"].get.description
    transform: return "List webjobs for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"].get.description
    transform: return "Get or list triggered web for an app."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}"].delete.description
    transform: return "Delete a triggered web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}"].get.description
    transform: return "Get or list triggered web job's history for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run"].post.description
    transform: return "Run a triggered web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"].get.description
    transform: return "Get or list triggered web for a deployment slot."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}"].delete.description
    transform: return "Delete a triggered web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}"].get.description
    transform: return "Get or list triggered web job's history for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run"].post.description
    transform: return "Run a triggered web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"].get.description
    transform: return "Get or list continuous web for an app."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}"].delete.description
    transform: return "Delete a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/start"]
  
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/start"].post.description
    transform: return "Start a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/stop"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}/stop"].post.description
    transform: return "Stop a continuous web job for an app."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs"]

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"].get.description
    transform: return "Get or list continuous web for a deployment slot."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}"].delete.description
    transform: return "Delete a continuous web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/start"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/start"].post.description
    transform: return "Start a continuous web job for a deployment slot."

  # - from: swagger-document
  #   where: $.paths
  #   transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/stop"]

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}/stop"].post.description
    transform: return "Stop a continuous web job for a deployment slot."

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
  - where:
      verb: Get
      subject: ^WebJob$|^SlotWebJob$
      variant: Get|GetViaIdentity
    remove: true

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
