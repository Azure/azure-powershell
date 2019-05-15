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
     > PS D:\github\azure-powershell> Set-AzApiManagementPolicy -Context $context -PolicyFilePath C:\wrongpolicy.xml -ApiId httpbin

     >   Set-AzApiManagementPolicy : 
     Error Code: ValidationError
     Error Message: One or more fields contain incorrect values:
     Error Details:
        [Code=ValidationError, Message=Error in element 'log-to-eventhub' on line 3, column 10: Logger not found, Target=log-to-eventhub]

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
    - `New-AzApiManagementContext`
        > New-AzApiManagementContext -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso
    - `Get-AzApiManagementApiRelease`
        > Get-AzApiManagementApiRelease -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/apis/echo-api/releases/releaseId
    - `Get-AzApiManagementApiVersionSet`
        > Get-AzApiManagementApiVersionSet -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/constoso/apiversionsets/pathversionset
    - `Get-AzApiManagementAuthorizationServer`
    - `Get-AzApiManagementBackend`
        > Get-AzApiManagementBackend -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/backends/servicefabric
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
