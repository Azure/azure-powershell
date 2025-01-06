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

## Version 2.3.1
* Fixed secrets exposure in example documentation.

## Version 2.3.0
* Enabled Microsoft entra id on SQL VM.

## Version 2.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 2.2.0
* Fixed a bug of parameter `VirtualMachineResourceId` of cmdlet `New-AzSqlVM`.

## Version 2.1.0
* Added more parameters on cmdlet `Update-AzSqlVM`.

## Version 2.0.0
* Converted Az.SqlVirtualMachine to autorest-based module.

## Version 1.1.1
* Added breaking change notification for cmdlets to be removed and parameters to be changed.
    * Cmdlet `New-AzSqlVMConfig` will be removed.
    * Cmdlet `Set-AzSqlVMConfigGroup` will be removed.
    * Cmdlet `Update-AzAvailabilityGroupListener` will be removed.
    * Parameter `SqlVM` will be removed from cmdlet `New-AzSqlVM`.
    * Parameter `SqlVMGroupObject` will be removed from cmdlet `Get-AzAvailabilityGroupListener` and `Remove-AzAvailabilityGroupListener`.
    * Parameter alias `SqlVM` will be removed from `InputObject` of cmdlet `Remove-AzSqlVM`.
    * Parameter alias `SqlVMGroup` will be removed from `InputObject` of cmdlet `Update-AzSqlVMGroup` and `Remove-AzSqlVMGroup`.
* Added breaking change notification for SqlManagementType

## Version 1.1.0
* Added cmdlets for Availability Group Listener

## Version 1.0.2
* Add DR as a new valid License type

## Version 1.0.1
* Update references in .psd1 to use relative path

## Version 1.0.0
* Added to the Az roll-up module

## Version 0.1.0
* General availability of Az.SqlVirtualMachine module
