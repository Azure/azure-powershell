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

## Version 0.4.0
* Upgrade API version to 2021-12-01
* Added cmdlet:
    - `Get-AzVMwareVirtualMachine`
    - `New-AzVMwarePlacementPolicy`
    - `Update-AzVMwarePlacementPolicy`
    - `Remove-AzVMwarePlacementPolicy`

## Version 0.3.0
* Updated api version to `2021-06-01`.
* Created some new cmdlets:
  * `New-AzVMwareAddon`, `Get-AzVMwareAddon`, `Remove-AzVMwareAddon`
  * `New-AzVMwareAddonSrmPropertiesObject`
  * `New-AzVMwareAddonVrPropertiesObject`
  * `New-AzVMwareCloudLink`, `Get-AzVMwareCloudLink`, `Remove-AzVMwareCloudLink`
  * `New-AzVMwareGlobalReachConnection`, `Get-AzVMwareGlobalReachConnection`, `Remove-AzVMwareGlobalReachConnection`
  * `New-AzVMwarePrivateCloudAdminCredential`
  * `New-AzVMwarePrivateCloudNsxtPassword`
  * `New-AzVMwarePrivateCloudVcenterPassword`
  * `New-AzVMwarePSCredentialExecutionParameterObject`
  * `New-AzVMwareScriptSecureStringExecutionParameterObject`

## Version 0.2.0
* [BreakingChange] Renamed module to Az.VMware
* Set confirmation prompt poped by default
* Displayed legal term and added parameter `AcceptEULA` for `New-AzVMwarePrivateCloud`

## Version 0.1.0
* First preview release for module Az.VMWare

