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

## Version 0.13.0
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.12.0
* Added cmdlet `Invoke-AzReservationReturn`
* Removed parameters `RefreshSummary`, `Skiptoken`, `Take` from cmdlet `Get-AzReservation`
* Added parameters `First`, `Skip` for cmdlet `Get-AzReservation`

## Version 0.11.0
* Added new commands to CalculateRefund and Return reservation
* Added new commands to Archive/Unarchive cancelled/expired/failed reservation 

## Version 0.10.0
* Converted Az.Reservations to autorest-based module

## Version 0.9.0
* Added new reserved resource types.

## Version 0.8.2
* Spelling fix in the docs.

## Version 0.8.1
* Update references in .psd1 to use relative path

## Version 0.8.0
* Add billing plan details in getCatalog
	- new object in the response of get-Catalog
* Add new Api CalculatePrice
	- new Api for calculate ReservationOrder price
* Add new Api Purchase
	- new Api for Purchase ReservationOrder in powershell
