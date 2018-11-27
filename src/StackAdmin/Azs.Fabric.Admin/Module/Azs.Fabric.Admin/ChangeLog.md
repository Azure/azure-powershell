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

## Version 0.3.0
* New cmdlet (The features are supported by Azure Stack 1811+)
	* Get-AzsDrive
	* Get-AzsVolume
	* Get-AzsStorageSubSystem
* Deprecation
	* Get-AzsInfrastructureVolume is an alias now to the cmdlet Get-AzsVolume

## Version 0.2.1
* Bug fixes
	* Fixed a bug in Add-AzsScaleUnitNode

## Version 0.2.0
* New Module dependencies
	* AzureRM.Profile
	* AzureRM.Resources
* New cmdlet
	* Add-AzsScaleUnitNode
	* New-AzsScaleUnitNodeObject
* Support handling names of nested resources
	* Add-AzsScaleUnitNode
	* Disable-AzsScaleUnitNode
	* Enable-AzsScaleUnitNode
	* Get-AzsEdgeGateway
	* Get-AzsEdgeGatewayPool
	* Get-AzsInfrastructureRole
	* Get-AzsInfrastructureRoleInstance
	* Get-AzsInfrastructureShare
	* Get-AzsInfrastructureVolume
	* Get-AzsIpPool
	* Get-AzsLogicalNetwork
	* Get-AzsLogicalSubnet
	* Get-AzsMacAddressPool
	* Get-AzsScaleUnit
	* Get-AzsScaleUnitNode
	* Get-AzsSlbMuxInstance
	* Get-AzsStoragePool
	* Get-AzsStorageSystem
	* Repair-AzsScaleUnitNode
	* Restart-AzsInfrastructureRole
	* Restart-AzsInfrastructureRoleInstance
	* Start-AzsInfrastructureRoleInstance
	* Start-AzsScaleUnitNode
	* Stop-AzsInfrastructureRoleInstance
	* Stop-AzsScaleUnitNode