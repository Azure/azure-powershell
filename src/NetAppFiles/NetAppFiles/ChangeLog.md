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

* Includes replication operations

## Version 0.1.4
* Update references in .psd1 to use relative path

* Includes some additional volume properties associated with upcoming replication operations

## Version 0.1.3

* Volume creation --protocol-types accepts now "NFSv4.1" not "NFSv4"
* Volume export policy property now named 'nfsv41' not 'nfsv4'
* Snapshot creation date now named just 'created'

## Version 0.1.2

* Addition of ProtocolTypes and MountTargets to volume properties
* Addition of ProtocolType parameter for new volume creation
* Pool size and Volume usageThreshold required on creation

* Fixed miscellaneous typos across module

## Version 0.1.1
* Add new cmdlets:
    - `Set-AzNetAppFilesAccount`
    - `Update-AzNetAppFilesAccount`
* Account:
    * Active Directory `PSNetAppFilesActiveDirectory` added to account methods `New-AnfAccount`, `Set-AnfAccount` and `Update-AnfAccount`
* Volume:
    * Export Policy `PSNetAppFilesVolumeExportPolicy` added to volume methods `New-AnfVolume` and `Update-AnfVolume`
* Snapshot:
    * FileSystemId is now optional during snapshot creation `New-AnfSnapshot`

## Version 0.1.0
* Preview of `Az.NetAppFiles` module
