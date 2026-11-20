<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Added shared cluster and pool fixtures for HorizonDB integration tests.
    * Added sample cmdlet output based on the first API example response.
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
* Clarified the password authentication State parameter help.
* Added isolated cluster, pool, and firewall rule creation tests and cluster and firewall rule deletion coverage, with cleanup after the test suite.
* Added parameter group creation, deletion, retrieval, and update tests, including shared fixtures and updating work_mem to 16384.
    - Skipped standalone cluster and firewall rule deletion tests in favor of the combined creation and deletion tests.
    - Adjusted firewall rule and password authentication checks to match service responses.
* Added tests for enabling Microsoft Entra and password authentication on an isolated cluster.
* Updated deletion examples to explicitly request confirmation before removing resources.
* Added integration tests for updating cluster backup retention to 9 days and pool capacity to 4 vCores.
* Added shared cluster and pool fixtures using Intel compute generation 1 for integration tests.
    - Refreshed shared cluster, node, and pool Get and Update recordings to match the saved fixture names.
* Fixed building Az.HorizonDB from source.
* First preview release for module Az.HorizonDB.
* Added cmdlet examples for cluster, pool, and parameter group management based on API version 2026-10-01-preview.
