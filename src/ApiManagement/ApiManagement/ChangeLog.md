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
* Fixed model creation parameters of ApiCreateOrUpdateParameter, ProductContract, SubscriptionCreateParameters, GroupCreateParameters, OpenidConnectProviderContract, IdentityProviderCreateContract, BackendContract, CacheContract and DiagnosticContract with [#26672].

## Version 4.0.5
* Removed Microsoft.Azure.Management.ApiManagement 8.0.0.0-preview
* Added ApiManagement.Management.Sdk

## Version 4.0.4
* Fixed secrets exposure in example documentation.

## Version 4.0.3
* Removed the outdated deps.json file.

## Version 4.0.2
* Updated description of ResourceId param 'New-AzApiManagementBackend' and 'Set-AzApiManagementBackend' cmdlet [#16868]
* Fixed Path mandatory bug 'Import-AzureApiManagementApi' cmdlet [#17991]

## Version 4.0.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 4.0.0
* [Breaking Change] Changed the type of parameter `Sku` from Enum to String in `Add-AzApiManagementRegion`, `New-AzApiManagement` and `Update-AzApiManagementRegion`.

## Version 3.0.1
* Supported GraphQL Specification Format

## Version 3.0.0

* [Breaking change] Replaced parameter `Sample` by `Examples` in `New-AzApiManagementOperation` and `Set-AzApiManagementOperation`
* Updated APIM .Net SDK version to 8.0.0 / Api Version 2021-08-01

## Version 2.3.2
* Added warning message for upcoming breaking change.

## Version 2.3.1
* Fixed a bug in `Get-AzApiManagementTenantGitAccess` cmdlet.

## Version 2.3.0
* Added new `Sync-AzApiManagementKeyVaultSecret` cmdlet.
* Added new `New-AzApiManagementKeyVaultObject` cmdlet.
* Added new optional [-useFromLocation] parameter to the `Get-ApiManagementCache` `New-ApiManagementCache``Update-ApiManagementCache` cmdlet.

* Updated cmdlet **New-AzApiManagement** to manage ApiManagement service
    - Added support for the new `Isolated` SKU
    - Added support for managing Availability Zones using `Zone` property
    - Added support for Disabling Gateway in a Region using `DisableGateway` property
    - Added support for managing the minimum Api Version to allow for Control Plane using `MinimalControlPlaneApiVersion` property.

* Updated cmdlet **New-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using `Zone` property
    - Added support for Disabling Gateway in a Region using `DisableGateway` property

* Updated cmdlet **Add-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using `Zone` property
    - Added support for Disabling Gateway in a Region using `DisableGateway` property

* Updated cmdlet **Update-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using `Zone` property
    - Added support for Disabling Gateway in a Region using `DisableGateway` property

* Updated cmdlet **New-AzApiManagementCustomHostnameConfiguration** to manage Custom Hostname Configuration
    - Added support for specifying `IdentityClientId` to provide Managed Identity User Assigned ClientId to use with KeyVault

## Version 2.2.0
* [Breaking change] `New-AzApiManagementProduct` by default has no subscription limit.

## Version 2.1.0
* Added new `Add-AzApiManagementApiToGateway` cmdlet.
* Added new `Get-AzApiManagementGateway` cmdlet.
* Added new `Get-AzApiManagementGatewayHostnameConfiguration` cmdlet.
* Added new `Get-AzApiManagementGatewayKey` cmdlet.
* Added new `New-AzApiManagementGateway` cmdlet.
* Added new `New-AzApiManagementGatewayHostnameConfiguration` cmdlet.
* Added new `New-AzApiManagementResourceLocationObject` cmdlet.
* Added new `Remove-AzApiManagementApiFromGateway` cmdlet.
* Added new `Remove-AzApiManagementGateway` cmdlet.
* Added new `Remove-AzApiManagementGatewayHostnameConfiguration` cmdlet.
* Added new `Update-AzApiManagementGateway` cmdlet.
* Added new optional [-GatewayId] parameter to the `Get-AzApiManagementApi` cmdlet.

## Version 2.0.1
* Updated assembly version of service management cmdlets

## Version 2.0.0
* `New-AzApiManagement` and `Set-AzApiManagement`: [-AssignIdentity] parameter renamed as [-SystemAssignedIdentity]
* `New-AzApiManagement` and `Set-AzApiManagement`: New parameter added: [-UserAssignedIdentity <String[]>]
* `Get-AzApiManagementProperty`: renamed as `Get-AzApiManagementNamedValue`. PropertyId parameter renamed as NamedValueId.
* `New-AzApiManagementProperty`: renamed as `New-AzApiManagementNamedValue`. PropertyId parameter renamed as NamedValueId.
* `Set-AzApiManagementProperty`: renamed as `Set-AzApiManagementNamedValue`. PropertyId parameter renamed as NamedValueId.
* `Remove-AzApiManagementProperty`: renamed as `Remove-AzApiManagementNamedValue`. PropertyId parameter renamed as NamedValueId.
* Added new `Get-AzApiManagementAuthorizationServerClientSecret` cmdlet and `Get-AzApiManagementAuthorizationServer` will not return client secret anymore.
* Added new `Get-AzApiManagementNamedValueSecretValue` cmdlet and `Get-AzApiManagementNamedValue` will not return secret value.
* Added new `Get-AzApiManagementOpenIdConnectProviderClientSecret` cmdlet and `Get-AzApiManagementOpenIdConnectProvider` will not return client secret anymore.
* Added new `Get-AzApiManagementSubscriptionKey` cmdlet and `Get-AzApiManagementSubscription` will not return subscription keys anymore.
* Added new `Get-AzApiManagementTenantAccessSecret` cmdlet and `Get-AzApiManagementTenantAccess` will not return keys anymore.
* Added new `Get-AzApiManagementTenantGitAccessSecret` cmdlet and `Get-AzApiManagementTenantGitAccess` will not return keys anymore.

## Version 1.4.1
* Added breaking change notice for Azure File cmdlets output change in a future release
* `Set-AzApiManagementGroup` Updated documentation to specify the GroupId parameter

## Version 1.4.0
* Added support for retrieving and configuring Custom Domain on the DeveloperPortal Endpoint [#11007]
* `Export-AzApiManagementApi` Added support for downloading Api Definition in Json format [#9987]
* `Import-AzApiManagementApi` Added support for importing OpenApi 3.0 definition from Json document
* `New-AzApiManagementIdentityProvider` and `Set-AzApiManagementIdentityProvider` Added support for configuring `Signin Tenant` for AAD B2C Provider [#9784]

## Version 1.3.4
* `Get-AzApiManagementApiSchema` Fixed getting Open-Api Schema associated with an API [#10626]
* `New-AzApiManagementProduct` and `Set-AzApiManagementProduct` Fixed documentation for [#10472]
* `Set-AzApiManagementApi` Added example to show how to update the ServiceUrl using the cmdlet

## Version 1.3.3
* Update references in .psd1 to use relative path

## Version 1.3.2
* **Set-AzApiManagementApi** - Added support for Updating Api into ApiVersionSet
    - Fix for issue https://github.com/Azure/azure-powershell/issues/10068

## Version 1.3.1
* Update `-Format` parameter description in `Set-AzApiManagementPolicy` reference documentation
* Removed references of deprecated cmdlet `Update-AzApiManagementDeployment` from reference documentation. Use `Set-AzApiManagement` instead.

## Version 1.3.0
* Fixed miscellaneous typos across module

* Fix for issue https://github.com/Azure/azure-powershell/issues/9351
	- Update .net nuget version, which does not enforce restrictions on productId, apiId, groupId and userId

* **Get-AzApiManagementProduct** - Added support for querying products using Api.
  https://github.com/Azure/azure-powershell/issues/9482

* **New-AzApiManagementApiRevision** - Fix for issue where ApiRevisionDescription was not being set when creating new api revision
https://github.com/Azure/azure-powershell/issues/9752

* Fixed typo in model `PsApiManagementOAuth2AuthrozationServer` to `PsApiManagementOAuth2AuthorizationServer`

## Version 1.2.0

* Fix for issue https://github.com/Azure/azure-powershell/issues/8671
    - **Get-AzApiManagementSubscription**
        - Added support for querying subscriptions by User and Product
        - Added support for querying using Scope "/", "/apis", "/apis/echo-api"

* Fix for issue https://github.com/Azure/azure-powershell/issues/9307 and https://github.com/Azure/azure-powershell/issues/8432
    - **Import-AzApiManagementApi**
        - Added support for specifiying `ApiVersion` and `ApiVersionSetId` when importing Apis

## Version 1.1.0

* Created new Cmdlets for managing diagnostics at the global and API Scope
    - **Get-AzApiManagementDiagnostic** - Get the diagnostics configured a global or api Scope
    - **New-AzApiManagementDiagnostic** - Create new diagnostics at the global scope or api Scope
    - **New-AzApiManagementHttpMessageDiagnostic** - Create diagnostic setting for which Headers to log and the size of Body Bytes
    - **New-AzApiManagementPipelineDiagnosticSetting** - Create Diagnostic settings for incoming/outgoing HTTP messages to the Gateway.
    - **New-AzApiManagementSamplingSetting** - Create Sampling Setting  for the requests/response for a diagnostic
    - **Remove-AzApiManagementDiagnostic** - Remove a diagnostic entity at global or api scope
    - **Set-AzApiManagementDiagnostic** - Update a diagnostic Entity at global or api scope

* Created new Cmdlets for managing Cache in ApiManagement service
    - **Get-AzApiManagementCache** - Get the details of the Cache specified by identifier or all caches
    - **New-AzApiManagementCache** - Create a new `default` Cache or Cache in a particular azure `region`
    - **Remove-AzApiManagementCache** - Remove a cache
    - **Update-AzApiManagementCache** - Update a cache

* Created new Cmdlets for managing API Schema
    - **New-AzApiManagementSchema** - Create a new Schema for an API
    - **Get-AzApiManagementSchema** - Get the schemas configured in the API
    - **Remove-AzApiManagementSchema** - Remove the schema configured in the API
    - **Set-AzApiManagementSchema** - Update the schema configured in the API

* Created new Cmdlet for generating a User Token.
    - **New-AzApiManagementUserToken** - Generate a new User Token valid for 8 hours by default.Token for the `GIT` user can be generated using this cmdlet./

* Created a new cmdlet to retrieving the Network Status
    - **Get-AzApiManagementNetworkStatus** - Get the Network status connectivity of resources on which API Management service depends on. This is useful when deploying ApiManagement service into a Virtual Network and validing whether any of the dependencies are broken.

* Updated cmdlet **New-AzApiManagement** to manage ApiManagement service
    - Added support for the new `Consumption` SKU
    - Added support to turn the `EnableClientCertificate` flag on for `Consumption` SKU
    - The new cmdlet **New-AzApiManagementSslSetting** allows configuring `TLS/SSL` setting on the `Backend` and `Frontend`. This can also be used to configure `Ciphers` like `3DES` and `ServerProtocols` like `Http2` on the `Frontend` of an ApiManagement service.
    - Added support for configuring the `DeveloperPortal` hostname on ApiManagement service.

* Updated cmdlets **Get-AzApiManagementSsoToken** to take `PsApiManagement` object as input
* Updated the cmdlet to display Error Messages inline
     - `PS D:\github\azure-powershell> Set-AzApiManagementPolicy -Context  -PolicyFilePath C:\wrongpolicy.xml -ApiId httpbin`
       - `Set-AzApiManagementPolicy :`
       - `Error Code: ValidationError`
       - `Error Message: One or more fields contain incorrect values:`
       - `Error Details: [Code=ValidationError, Message=Error in element 'log-to-eventhub' on line 3, column 10: Logger not found, Target=log-to-eventhub]`

* Updated cmdlet **Export-AzApiManagementApi** to export APIs in `OpenApi 3.0` format
* Updated cmdlet **Import-AzApiManagementApi**
    - To import Api from `OpenApi 3.0` document specification
    - To override the `PsApiManagementSchema` property specified in any (`Swagger`, `Wadl`, `Wsdl`, `OpenApi`) document.
    - To override the `ServiceUrl` property specified in any document.

* Updated cmdlet **Get-AzApiManagementPolicy** to return policy in Non-Xml escaped `format` using `rawxml`
* Updated cmdlet **Set-AzApiManagementPolicy** to accept policy in Non-Xml escaped `format` using `rawxml` and Xml escaped using `xml`

* Updated cmdlet **New-AzApiManagementApi**
    - To configure API with `OpenId` authorization server.
    - To create an API in an `ApiVersionSet`
    - To clone an API using `SourceApiId` and `SourceApiRevision`.
    - Ability to configure `SubscriptionRequired` at the Api scope.

* Updated cmdlet **Set-AzApiManagementApi**
    - To configure API with `OpenId` authorization server.
    - To updated an API into an `ApiVersionSet`
    - Ability to configure `SubscriptionRequired` at the Api scope.

* Updated cmdlet **New-AzApiManagementRevision**
    - To clone (copy tags, products, operations and policies) an existing revision using `SourceApiRevision`. The new Revision assumes the `ApiId` of the parent.
    - To provide an `ApiRevisionDescription`
    - To override the `ServiceUrl` when cloning an API.

* Updated cmdlet **New-AzApiManagementIdentityProvider**
    - To configure `AAD` or `AADB2C` with an `Authority`
    - To setup `SignupPolicy`, `SigninPolicy`, `ProfileEditingPolicy` and `PasswordResetPolicy`

* Updated cmdlet **New-AzApiManagementSubscription**
    - To account for the new SubscriptonModel using `Scope` and `UserId`
    - To account for the old subscription model using `ProductId` and `UserId`
    - Add support to enable `AllowTracing` at the subscription level.

* Updated cmdlet **Set-AzApiManagementSubscription**
    - To account for the new SubscriptonModel using `Scope` and `UserId`
    - To account for the old subscription model using `ProductId` and `UserId`
    - Add support to enable `AllowTracing` at the subscription level.

* Updated following cmdlets to accept `ResourceId` as input
    - 'New-AzApiManagementContext'
      - `New-AzApiManagementContext -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso`
    - 'Get-AzApiManagementApiRelease'
      - `Get-AzApiManagementApiRelease -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/apis/echo-api/releases/releaseId`
    - 'Get-AzApiManagementApiVersionSet'
      - `Get-AzApiManagementApiVersionSet -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/constoso/apiversionsets/pathversionset`
    - 'Get-AzApiManagementAuthorizationServer'
    - 'Get-AzApiManagementBackend'
      - `Get-AzApiManagementBackend -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/backends/servicefabric`
    - `Get-AzApiManagementCertificate`
    - `Remove-AzApiManagementApiVersionSet`
    - `Remove-AzApiManagementSubscription`

## Version 1.0.0
* General availability of `Az.ApiManagement` module
* Removing cmdlets which have been marked Obsolete in May 2018
    - New-AzureRmApiManagementHostnameConfiguration
    - Set-AzureRmApiManagementHostnames
    - Update-AzureRmApiManagementDeployment
    - Import-AzureRmApiManagementHostnameCertificate
    Please refer to examples of **Set-AzureRmApiManagement** cmdlet instead.
* Following properties were removed
    - Removed property `PortalHostnameConfiguration`, `ProxyHostnameConfiguration`, `ManagementHostnameConfiguration` and `ScmHostnameConfiguration` of type `PsApiManagementHostnameConfiguration` from PsApiManagementContext. Instead use `PortalCustomHostnameConfiguration`, `ProxyCustomHostnameConfiguration`, `ManagementCustomHostnameConfiguration` and `ScmCustomHostnameConfiguration` of type `PsApiManagementCustomHostNameConfiguration`.
    - Removed property `StaticIPs` from PsApiManagementContext. The property has been split into `PublicIPAddresses` and `PrivateIPAddresses`.
    - Removed required property `Location` from NewAzureApiManagementVirtualNetwork cmdlet, as it was redundant parameter.
* Fix for issue https://github.com/Azure/azure-powershell/issues/7002
