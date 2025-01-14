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

## Version 1.1.1
* Removed the outdated deps.json file.

## Version 1.1.0
* Added cmdlet `Get-AzDataBoxEdgeStorageContainer`
  - Get the Edge Storage Container
* Added cmdlet `New-AzDataBoxEdgeStorageContainer`
  - Create new Edge Storage Container
* Added cmdlet `Remove-AzDataBoxEdgeStorageContainer`
  - Remove the Edge Storage Container
* Added cmdlet `Invoke-AzDataBoxEdgeStorageContainer`
  - Invoke action to refresh data on Edge Storage Container
* Added cmdlet `Get-AzDataBoxEdgeStorageAccount`
  - Get the Edge Storage Account
* Added cmdlet `New-AzDataBoxEdgeStorageAccount`
  - Create new Edge Storage Account
* Added cmdlet `Remove-AzDataBoxEdgeStorageAccount`
  - Remove the Edge Storage Account
* Invoke cmdlet `Invoke-AzDataBoxEdgeShare`
  - Invoke action to refresh data on share
* Added cmdlet `Set-AzDataBoxEdgeStorageAccountCredential`
  - Set the az databoxedge storage account credential

## Version 1.0.1
* Update references in .psd1 to use relative path

## Version 1.0.0
* Added cmdlet `Get-AzDataBoxEdgeOrder`
 - Get the Order
* Added cmdlet `New-AzDataBoxEdgeOrder`
 - Create new Order
* Added cmdlet `Remove-AzDataBoxEdgeOrder`
 - Remove the Order
* Change in cmdlet `New-AzDataBoxEdgeShare`
 - Now creates Local Share
* Added cmdlet `Set-AzDataBoxEdgeRole`
 - Now IotRole can be mapped to Share
* Added cmdlet `Invoke-AzDataBoxEdgeDevice`
 - Invoke scan update, download update, install updates on the device
* Added cmdlet `Get-AzDataBoxEdgeTrigger`
 - Gets the information about Triggers
* Added cmdlet `New-AzDataBoxEdgeTrigger`
 - Create new Triggers
* Added cmdlet `Remove-AzDataBoxEdgeTrigger`
 - Remove the Triggers


## Version 0.1.1

* Remove cmdlet `Set-AzDataBoxEdgeStorageAccountCredential`

## Version 0.1.0
* General Availability of `Az.DataboxEdge` Module
* Added cmdlet `Get-AzDataBoxEdgeBandwidthSchedule`
  - Gets the information about Bandwidth schedules

* Added cmdlet `Get-AzDataBoxEdgeDevice`
  - Get the available devices

* Added cmdlet `Get-AzDataBoxEdgeJob`
  - Get job by Name

* Added cmdlet `Get-AzDataBoxEdgeRole`
  - Fetch the available roles for a device

* Added cmdlet `Get-AzDataBoxEdgeShare`
  - Gets the creted shares for this device

* Added cmdlet `Get-AzDataBoxEdgeStorageAccountCredential`
  - Get the Storage Account credential corresponding to device and storage account

* Added cmdlet `Get-AzDataBoxEdgeUser`
  - Get the created users  for this device

* Added cmdlet `New-AzDataBoxEdgeBandwidthSchedule`
  - Create a new Bandwidth schedule

* Added cmdlet `New-AzDataBoxEdgeDevice`
  - Configures a new device

* Added cmdlet `New-AzDataBoxEdgeRole`
  - Creates a new Iot Role for the device

* Added cmdlet `New-AzDataBoxEdgeShare`
  - Creates a new share in the device

* Added cmdlet `New-AzDataBoxEdgeStorageAccountCredential`
  - Create new storage account credential object

* Added cmdlet `New-AzDataBoxEdgeUser`
  - Creates a new user for the device

* Added cmdlet `Remove-AzDataBoxEdgeBandwidthSchedule`
  - Removes a Bandwidth Schedule

* Added cmdlet `Remove-AzDataBoxEdgeDevice`
  - Remove a device

* Added cmdlet `Remove-AzDataBoxEdgeRole`
  - Removes the assosciated Role for the device

* Added cmdlet `Remove-AzDataBoxEdgeRole`
  - Removes the assosciated Role for the device

* Added cmdlet `Remove-AzDataBoxEdgeStorageAccountCredential`
  - Removes a storage account credentail object for the device

* Added cmdlet `Remove-AzDataBoxEdgeUser`
  - Removes the user

* Added cmdlet `Set-AzDataBoxEdgeBandwidthSchedule`
  - Update a Bandwidth Schedule for the device

* Added cmdlet `Set-AzDataBoxEdgeShare`
  - Update the share

* Added cmdlet `Set-AzDataBoxEdgeUser`
  - Set the new password for the user

- Updated tests and associated session records.
- Cosmetic changes to help files.
