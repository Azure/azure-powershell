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

## Version 1.0.0
First release of Managed Service Identity cmdlets

- Get-AzureRmUserAssignedIdentity
The **Get-AzureRmUserAssignedIdentity** gets existing user assigned identities.

- New-AzureRmUserAssignedIdentity
The **New-AzureRmUserAssignedIdentity** cmdlet creates a new User Assigned Identity. When used with an already existing identity, it updated the identity.
To add Azure Resource Manager tags to the identity, please use the Set-AzureRmResource cmdlet.

- Remove-AzureRmUserAssignedIdentity
The **Remove-AzureRmUserAssignedIdentity** deletes the specified User Assigned Identity.
