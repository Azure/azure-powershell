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

## Version 0.2.0
* Added commands
  - `New-AzHdInsightOnAksManagedIdentityObject` for create an in-memory object for ManagedIdentitySpec.
  - `New-AzHdInsightOnAksClusterMavenLibraryObject` for create an in-memory object for Maven library properties.
  - `New-AzHdInsightOnAksClusterPyPiLibraryObject` for create an in-memory object for PyPi library properties.
  - `Get-AzHdInsightOnAksClusterPoolUpgradeHistory` for get a list for cluster pool upgrade history.
  - `Get-AzHdInsightOnAksClusterUpgradeHistory` for get a list for cluster upgrade history.
  - `Invoke-AzHdInsightOnAksManageClusterLibrary` for manage libraries on cluster.
  - `Invoke-AzHdInsightOnAksClusterManualRollback` for manual rollback upgrade for a cluster.
* Renamed command `New-AzHdInsightOnAksClusterPoolAKSUpgradeObject` to `New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject`. 
* Separated the Upgrade function from command `Update-AzHdInsightOnAksCluster`, the new command is `Invoke-AzHdInsightOnAksClusterUpgrade`. 
* Separated the Upgrade function from command `Update-AzHdInsightOnAksClusterPool`, the new command is `Invoke-AzHdInsightOnAksClusterPoolUpgrade`.

## Version 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.1.1
* Changes in the Cluster Pool
  - Enable create cluster pool with user network profile.
  - Enable get cluster pool available upgrade versions.
  - Enable upgrade cluster pool.
* Changes in the Cluster
  - Enable create Ranger cluster.
  - Enable get cluster available upgrade versions.
  - Enable set internal ingress.
  - Enable upgrade cluster.
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.1.0
* First preview release for module Az.HdInsightOnAks

