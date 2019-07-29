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

## Version 0.1.0
* General Availability of `Az.Databox` Module
* Added cmdlet `Get-AzDataBoxJob`
	- This cmdlet fetches the databox job/jobs of the user based on the filters applied like resource group name etc.
* Added cmdlet `Get-AzDataBoxCredential`
	- This cmdlet fetches the databox credentials of the specified databox job.
* Added cmdlet `Stop-AzDataBoxJob`
	- This cmdlet is used to cancel an ongoing databox job.
* Added cmdlet `Remove-AzDataBoxJob`
	- This cmdlet is used to delete a finished(completed/cancelled/aborted) databox job.
* Added cmdlet `New-AzDataBoxJob`
	- This cmdlet is used to create a new databox job.
* Added confirmation message to `Stop-AzDataBoxJob` and `Remove-AzDataBoxJob` cmdlets
	- Added prompting for confirmation to `Stop-AzDataBoxJob` and `Remove-AzDataBoxJob` cmdlets.
	- Added Force switch parameter to skip confirmation for `Stop-AzDataBoxJob` and `Remove-AzDataBoxJob` cmdlets.
	- Updated tests and associated session records.
	- Cosmetic changes to help files.
