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
## Version 0.7.4
* Change enum type parameters to string.

## Version 0.7.3
* Configure redirect routing rule.
* Enable/Disable cetificate name check for backend pools
* Modify WAF policy cmdlets to implement new swagger
    - Adds new managed rule sets capabilities
    - Adds redirect action

## Version 0.7.2
* Add cmdlets to enable/disable custom domain SSL
    - `Enable-AzFrontDoorCustomDomainHttps`
    - `Disable-AzFrontDoorCustomDomainHttps`
* Add cmdlet to get all existing frontend endpoints in the current front door resource
    - `Get-AzFrontDoorFrontendEndpoint`

## Version 0.7.1
* Add new cmdlets to enable/disable HTTPS for a custom domain
* Add new cmdlet to get frontend endpoint
