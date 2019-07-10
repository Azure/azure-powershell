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

## Version 0.3.2
* Support single role restore for Azures stack infrastructure backup
    * Add parameter `RoleName` to cmdlet `Restore-AzsBackup`

## Version 0.3.1
* Module dependencies updated
    * AzureRM.Resources module updated to 6.4.3

## Version 0.3.0
* Breaking change: Backup changes to cert-based encryption mode. Support for symmetric keys is deprecated.
    * Set-AzsBackupConfiguration now accepts parameter EncryptionCertPath instead of EncryptionKey:
        Before: Set-AzsBackupConfiguration -EncryptionKey $symmetricKey
        After: Set-AzsBackupConfiguration -EncryptionCertPath $pathToEncryptionCert
    * Restore-AzsBackup now requires parameter DecryptionCertPath and DecryptionCertPassword:
        Before: Restore-AzsBackup -Name $backupResourceName
        After: Restore-AzsBackup -Name $backupResourceName -DecryptionCertPath $decryptionCertPath -DecryptionCertPassword $decryptionCertPassword
