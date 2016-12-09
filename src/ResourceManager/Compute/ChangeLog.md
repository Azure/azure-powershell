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

* Add Remove-AzureRmVMSecret cmdlet.

* Add DisplayHint property to VM object to enable Compact and Expand display modes.

* Add DisplayHint parameter to Get-AzureRmVM to choose display mode of VM object.

* Updated Set-AzureRmVMChefExtension cmdlet to add following new options :
    - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'

    - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45

## Version 2.3.0
* Update formats for list of VMs, VMScaleSets and ContainerService
    - The default format of Get-AzureRmVM, Get-AzureRmVmss and Get-AzureRmContainerService is not table format when these cmdlets call List Operation
* Fix overprovision issue for VMScaleSet
    - Because of the bug in Compute client library (and Swagger spec) regarding overprovision property of VMScaleSet, this property did not show up correctly.
* Better piping scenario for VMScaleSets and ContainerService cmdlets
    - VMScaleSet and ContainerService now have "ResourceGroupName" property, so when piping Get command to Delete/Update command, -ResourceGroupName is not required.
* Separate paremater sets for Set-AzureRmVM with Generalized and Redeploy parameter
* Reduce time taken by Get-AzureRmVMDiskEncryptionStatus cmdlet from two minutes to under five seconds
* Allow Set-AzureRmVMDiskEncryptionStatus to be used with VHDs residing in multiple resource groups