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
* Changed output of `Search-AzGraph` to PSResourceGraphResponse which wrapped previous output under Data property.

## Version 0.9.0
* Added support for the new api version with the ability to query with management group scopes using -ManagementGroup param.
* Deprecated parameter -Include.
* Introduced -SkipToken param and aligned max resources returned per page with server value.

## Version 0.8.0
* Added new cmdlets to support query resource

## Version 0.7.7
* Update references in .psd1 to use relative path

## Version 0.7.6
* Ignoring subscription from azure context
* Add two examples for cmdlet `Search-AzGraph` with parameter `-Include`.

## Version 0.7.5
* Showing warnings in cases when too many subscriptions were used or results got truncated.
* Adding param to extend query result with subscription and tenant names

## Version 0.7.4
* Updated package Microsoft.Azure.Management.ResourceGraph to version 2.0

## Version 0.7.3
* Improving logic of getting subscriptions for query to ARG

## Version 0.7.2
* Fix conversion to PSCustomObject[] for top-level arrays

## Version 0.7.1
* Initial release
