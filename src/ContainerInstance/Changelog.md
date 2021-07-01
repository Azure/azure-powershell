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

## Version 2.1.0
* Removed the display of file share credential [#15224]

## Version 2.0.0
* Added new cmdlets: `Start-AzContainerGroup`, `Stop-AzContainerGroup` [#10773], `Invoke-AzContainerInstanceCommand` [#7648], `Update-AzContainerGroup`, `Add-AzContainerInstanceOutput`, `Get-AzContainerInstanceCachedImage`, `Get-AzContainerInstanceCapability`, `Get-AzContainerInstanceUsage`, `New-AzContainerGroupImageRegistryCredentialObject`, `New-AzContainerGroupPortObject`, `New-AzContainerGroupVolumeObject`, `New-AzContainerInstanceEnvironmentVariableObject`, `New-AzContainerInstanceInitDefinitionObject`, `New-AzContainerInstanceObject`, `New-AzContainerInstancePortObject` and `New-AzContainerInstanceVolumeMountObject`
* Supported Log Analytics parameters in `New-AzContainerGroup` [#11117]
* Added support to specify network profile and the name of Azure File Share in `New-AzContainerGroup` [#9993] [#12218]
* Added support to specify environment variables as SecureValue [#10110] [#10640]

## Version 1.0.3
* Fixed parameter names used by example of New-AzContainerGroup

## Version 1.0.2
* Update references in .psd1 to use relative path

## Version 1.0.1
* Fixed issue in the -Command parameter of New-AzContainerGroup which added a trailing empty argument

## Version 1.0.0
* General availability of `Az.ContainerInstance` module
* Added managed identity support
