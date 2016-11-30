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
* Added storage properties to cmdlets for Azure SQL threat detection policy management at database and server level
    - StorageAccountName
    - RetentionInDays
* Removed the unsupported param "AuditAction" from Set-AzureSqlDatabaseServerAuditingPolicy
* Added new param "AuditAction" to Set-AzureSqlDatabaseAuditingPolicy
* Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool
	- If Tags is used in command it will save tags, if not it will not wipe out tags on resource.
## Version 2.3.0
* Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool
	- If Tags is used in command it will save tags, if not it will not wipe out tags on resource.