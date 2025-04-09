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
* Az.ADDomainServices module is migrated to Autorest PowerShell v4:
  * Modified cmdlet `New-AzADDomainService`: Added parameters `-JsonFilePath` and `-JsonString`. Changed the type of parameter `-DomainSecuritySettingNtlmV1` from `NtlmV1` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncKerberosPassword` from `SyncKerberosPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncNtlmPassword` from `SyncNtlmPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncOnPremPassword` from `SyncOnPremPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingTlsV1` from `TlsV1` to `String`. Changed the type of parameter `-FilteredSync` from `FilteredSync` to `String`. Changed the type of parameter `-LdapSettingExternalAccess` from `ExternalAccess` to `String`. Changed the type of parameter `-LdapSettingLdaps` from `Ldaps` to `String`. Changed the type of parameter `-NotificationSettingNotifyDcAdmin` from `NotifyDcAdmins` to `String`. Changed the type of parameter `-NotificationSettingNotifyGlobalAdmin` from `NotifyGlobalAdmins` to `String`. Added parameter set `CreateViaJsonFilePath`. Added parameter set `CreateViaJsonString`.
  * Modified cmdlet `Update-AzADDomainService`: Removed parameter `-Location`. Changed the type of parameter `-DomainSecuritySettingNtlmV1` from `NtlmV1` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncKerberosPassword` from `SyncKerberosPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncNtlmPassword` from `SyncNtlmPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingSyncOnPremPassword` from `SyncOnPremPasswords` to `String`. Changed the type of parameter `-DomainSecuritySettingTlsV1` from `TlsV1` to `String`. Changed the type of parameter `-FilteredSync` from `FilteredSync` to `String`. Changed the type of parameter `-LdapSettingExternalAccess` from `ExternalAccess` to `String`. Changed the type of parameter `-LdapSettingLdaps` from `Ldaps` to `String`. Changed the type of parameter `-NotificationSettingNotifyDcAdmin` from `NotifyDcAdmins` to `String`. Changed the type of parameter `-NotificationSettingNotifyGlobalAdmin` from `NotifyGlobalAdmins` to `String`. Parameter set `UpdateExpanded` removed parameter `-Location`. Parameter set `UpdateViaIdentityExpanded` removed parameter `-Location`.

## Version 0.2.3
* Upgraded nuget package to signed package.

## Version 0.2.2
* Fixed secrets exposure in example documentation.

## Version 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.2.0
* Changed the input method of certificate from base64 string to file path
* Renamed `New-AzADDomainServiceForestTrust` to `New-AzADDomainServiceForestTrustObject`, and `New-AzADDomainServiceReplicaSet` to `New-AzADDomainServiceReplicaSetObject` to align with naming convention

## Version 0.1.0
* First preview release for module Az.ADDomainServices

