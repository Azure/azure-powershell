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