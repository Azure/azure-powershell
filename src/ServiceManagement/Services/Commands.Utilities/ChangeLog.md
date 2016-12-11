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
* Updated Set-AzureVMChefExtension cmdlet to add following new options :
    - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'

    - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45

* Updated New-AzureVirtualNetworkGatewayConnection cmdlet to add validation on acceptable input parameter:GatewayConnectionType values sets and it can be case insensitive:
    - GatewayConnectionType : Added validation to accept only set of values:- 'ExpressRoute'/'IPsec'/'Vnet2Vnet'/'VPNClient' and acceptable set of values can be passed in any casing.

* Updating Managed Cache warning message which notifies customer about service deprecation on the following cmdlets :
Get-AzureManagedCache
Get-AzureManagedCacheAccessKey
Get-AzureManagedCacheLocation
Get-AzureManagedCacheNamedCache
New-AzureManagedCache
New-AzureManagedCacheAccessKey
New-AzureManagedCacheNamedCache
Remove-AzureManagedCache
Remove-AzureManagedCacheNamedCache
Set-AzureManagedCache
Set-AzureManagedCacheNamedCache

For more information about Managed Cache service deprecation, see http://go.microsoft.com/fwlink/?LinkID=717458

## Version 3.1.0