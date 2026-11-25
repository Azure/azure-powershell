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
* Updated DocumentDB cmdlets from API version `2026-06-01` to `2026-09-01`.
    - Generated from the unchanged published September Swagger specification.
* Added `Planned` promotion support to `Switch-AzDocumentDBMongoCluster`.
    - Planned promotion waits for the replica to catch up with the primary before switching roles.
    - Forced promotion remains available for disaster recovery and can result in data loss.
* Corrected output metadata and help for `Switch-AzDocumentDBMongoCluster`.
    - No output is returned by default; `PassThru` returns Boolean true on success.
    - Aligned promotion examples and safety guidance for Planned and Forced.
* Clarified that `New-AzDocumentDBUser` requires a Microsoft Entra principal object ID,
  not an application (client) ID.

## Version 0.1.0
* First preview release for module Az.DocumentDB

