### Example 1: Create SecuritySetting for ADDOmain
```powershell
PS C:\> New-AzADDomainServiceDomainSecuritySettingObject -NtlmV1 Disabled -SyncKerberosPassword Disabled -SyncNtlmPassword Disabled -SyncOnPremPassword Disabled -TlsV1 Disabled

NtlmV1   SyncKerberosPassword SyncNtlmPassword SyncOnPremPassword TlsV1
------   -------------------- ---------------- ------------------ -----
Disabled Disabled             Disabled         Disabled           Disabled
```

Create SecuritySetting for ADDOmain

