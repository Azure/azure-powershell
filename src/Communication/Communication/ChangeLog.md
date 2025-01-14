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

## Version 0.4.1
* Added support for inline attachments in the send mail operation.
    - This update introduced a new property in the EmailAttachment object called contentId, which serves as a unique identifier in the HTML content.
    - The contentId property should be referenced in the HTML body of the email for inline rendering.

## Version 0.4.0
* Added dataplane cmdlets:
    * `Get-AzEmailServicedataEmailSendResult`
    * `Send-AzEmailServicedataEmail`
* Upgraded API version to 2023-06-01-preview

## Version 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.3.0
* First preview release for module Az.EmailService

## Version 0.2.0
* Added a new cmdlet `Test-AzCommunicationServiceNameAvailability`
* Updated API version to 2020-08-20

## Version 0.1.0
* First preview release for module Az.Communication

