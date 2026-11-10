<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Fixed V2 autoscale SKU lookup to match display-form locations such as East US to eastus.
    * Rejected `AutoScalePolicyEnforcement None` when creating a V2 SAN, in addition to Disabled.
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

## Version 1.7.1
* Added autoscale defaults when creating V2 SANs with `New-AzElasticSan`.
    - Defaulted enforcement to Enabled, the capacity increase to 1 TiB and the unused-capacity threshold to 1 TiB.
    - Queried the selected SKU in the target region to cap the default scale-up limit at the smaller of five times provisioned size and the regional maximum total capacity.
    - Preserved explicit inputs and skipped the SKU lookup when a scale-up limit was supplied.
* Rejected explicitly disabled autoscale when creating a V2 SAN with `New-AzElasticSan`.
* Improved validation of the packaged module when running playback tests.
* Fixed identity-based background jobs in `New-AzElasticSan`, `New-AzElasticSanVolumeGroup` and `Update-AzElasticSanVolumeGroup`.
* Added `EncryptionInTransit` to `New-AzElasticSanVolumeGroup` for iSCSI volume groups.
* Standardized reservation output properties to `ReservedIops` and `TotalReservedIops`.
    - Preserved `ReservedIop` and `TotalReservedIop` as compatibility properties.
* Added `ElasticSAN_LRS` to SKU name completion in `New-AzElasticSan`.
* Added `DirectAttach` to protocol completion in `New-AzElasticSanVolumeGroup` and `Update-AzElasticSanVolumeGroup`.
* Added V2 volume-group quality of service and performance reservation inputs.
    - Supported `QualityOfService`, `ReservedIops` and `ReservedMBps` in `New-AzElasticSanVolumeGroup`.
    - Supported `ReservedIops` and `ReservedMBps` in `Update-AzElasticSanVolumeGroup`.
* Standardized the SAN creation and update parameter name to `TotalIops`.
    - Preserved `TotalIop` as an alias for compatibility with existing scripts.
* Added V2 creation inputs to `New-AzElasticSan`.
    - Supported `Version`, `TotalSizeTiB`, `TotalIops` and `TotalMBps`.
    - Preserved default base and extended capacities for V1 without adding them to V2 requests.
    - Reported a clear error before sending V2 creation requests when a required total capacity or performance input is omitted.
* Added support for restoring soft-deleted volumes.
    - `Restore-AzElasticSanVolume`
    - Supported identity-based restore operations running as background jobs.
* Preserved the `ManagedByResourceId` volume property alongside `ManagedBy`.
    - Reading returns the first resource ID. Setting replaces the managed owners with a single resource ID.
    - Setting a null or empty value clears the managed owners.
    - Volume inputs cannot specify both properties.

## Version 1.7.0
* Supported auto scale when creating and updating an Elastic SAN.
    - `New-AzElasticSan`
    - `Update-AzElasticSan`
* Supported checking whether disk snapshot backup can be taken for volumes.
    - `Test-AzElasticSanVolumeBackup`
    - `Test-AzElasticSanVolumeRestore`
    
## Version 1.6.0
* Reverted changes for auto scale, pre-backup, and pre-restore 
    - `New-AzElasticSan`
    - `Update-AzElasticSan`
    - `Test-AzElasticSanVolumeBackup`
    - `Test-AzElasticSanVolumeRestore`

## Version 1.5.0
* Supported auto scale when creating and updating an Elastic SAN.
    - `New-AzElasticSan`
    - `Update-AzElasticSan`
* Supported checking whether disk snapshot backup can be taken for volumes.
    - `Test-AzElasticSanVolumeBackup`
    - `Test-AzElasticSanVolumeRestore`

## Version 1.4.1
* Added warning message for data integrity checking when create/update a volume group.
    - `New-AzElasticSanVolumeGroup`
    - `Update-AzElasticSanVolumeGroup`

## Version 1.4.0
* Changed parameters `BaseSizeTiB` and `ExtendedCapacitySizeTiB` in cmdlet `New-AzElasticSan` to be optional.
    - `New-AzElasticSan`

## Version 1.2.1
* Upgraded nuget package to signed package.

## Version 1.2.0
* Removed breaking change warnings for MI best practices 
    - `New-AzElasticSanVolumeGroup`
    - `Update-AzElasticSanVolumeGroup`

## Version 1.1.0
* Supported `EnforceDataIntegrityCheckForIscsi` for creating and updating volume groups

## Version 1.0.3
* Added warnings for upcoming breaking changes to align the MI best practices.

## Version 1.0.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.0.0
* General availability for module Az.ElasticSan

## Version 0.1.2
* Added support for CMK and volume snapshots

## Version 0.1.1
* Added support for private endpoint for ElasticSan

## Version 0.1.0
* First preview release for module Az.ElasticSan
