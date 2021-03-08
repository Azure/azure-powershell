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
## Version 0.2.0
* Bug fixed in update replication migration item to pass all properties (changed/unchanged) to service, and not just the changed ones.
* Bug fixed in enable migrate to pick correct run as account id for VMware Cbt provider.
* Added new parameter (MachineName) in get replication migration item, to get replication migration item by friendly name.
* Bug fixed in enable migrate to stop passing Target Boot Diagnostic Storage Account if it is in a different subscription id than the target VM.
* Fix to in online URLs of existing code doc.

## Version 0.1.1
* Bug fixed in enable replication, to make default user scenario migrate all disks by default. Earlier the cmdlet was only migrating the OS disk, which was a bug.

## Version 0.1.0
* First preview release for module Az.Migrate. The cmdlets to support common scenarios of Migrate like enable replication, update replication item, get migration items, migrate, test migrate and clean up have been exposed.
