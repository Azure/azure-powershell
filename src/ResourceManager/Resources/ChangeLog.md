<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release
* Support ResourceNameEquals and ResourceGroupNameEquals as parameters for Find-AzureRmResource
    - Users can now use ResourceNameEquals and ResourceGroupNameEquals with Find-AzureRmResource

## Version 3.3.0
* Lookup of AAD group by Id now uses GetObjectsByObjectId AAD Graph call instead of Groups/<id>
    - This will enable Groups lookup in CSP scenario
* Remove unnecessary AAD graph call in Get role assignments logic
    - Only make call when needed instead of always
* Fixed issue where Remove-AzureRmResource would throw an exception if one of the resources passed through the pipeline failed to be removed
    - If cmdlet fails to remove one of the resources, the result will not have an effect on the removal of other resources