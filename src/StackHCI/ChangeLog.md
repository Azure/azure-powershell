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
* Made changes to registration script to register the GA version of On-Premises Azure Stack HCI with Azure.
    - Supports registering with user provided certificate thumbprint.
    - Supports On-Premises Azure Stack HCI OS changes to use independent certificate on cluster nodes.
    - Cleans up resource group during unregistration.
    - Improves registration output and logging.
* Breaks the public preview registration of On-Premises Azure Stack HCI with Azure.
    - To register public preview On-Premises Azure Stack HCi with Azure, use 0.3.1 version of Az.StackHCI.

## Version 0.3.1
* Fixed an issue that may block Stack HCI registration.
    - Workaround for the token cache issue in Az.Accounts 2.1.0. Using AuthenticationFactory.

## Version 0.3.0
* Get the App Roles assigned correctly in case of Stack HCI registration using WAC token.

## Version 0.2.0
* Added hash table for region.

## Version 0.1.1
* Added `Core` to `CompatiblePSEditions`.

## Version 0.1.0
* Public Preview of `Az.StackHCI` module.
