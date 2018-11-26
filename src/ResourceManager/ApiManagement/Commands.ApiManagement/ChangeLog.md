<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release
* Removing cmdlets which have been marked Obsolete in May 2018
    - New-AzureRmApiManagementCustomHostnameConfiguration
    - Set-AzureRmApiManagementHostnames
    - Update-AzureRmApiManagementDeployment
    - Import-AzureRmApiManagementHostnameCertificate
    Please use **Set-AzureRmApiManagement** instead.

* Fix for issue https://github.com/Azure/azure-powershell/issues/7002