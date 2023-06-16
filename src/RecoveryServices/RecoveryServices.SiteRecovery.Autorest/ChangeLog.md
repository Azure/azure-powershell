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

## Version 2.0.0
* Added a feature of remove and update replication policy using a policy object.
* Added a feature of remove replication fabric using a fabric object.
* Added a feature of searching a fabric using fabric friendly name.
* Added a feature of getting list of replication protection containers using a fabric object.
* Added a feature of removing a replication protection containers using a protection container object.
* Fixed the ICreatePolicyInput object to receive Policy specifications using an object.
* Fixed the IFabrciCreationInput object to receive fabric specifications using an object.
* Fixed the IProtectionContainerCreationInput to receive protection container specifications using an object.
* Changed the Input InstanceType to ReplicationScenario for better understanding of the user.
* Added help examples and test recordings
  * `AzRecoveryServicesReplicationPolicy`
  * `AzRecoveryServicesReplicationFabric`
  * `AzRecoveryServicesReplicationProtectionContainer`
  * `AzRecoveryServicesReplicationProtectionContainerMapping`