### Example 1: Create BackendPoolsSettings object using defaults
```powershell
New-AzFrontDoorBackendPoolsSettingObject
```

```output
EnforceCertificateNameCheck : Enabled
SendRecvTimeoutInSeconds      : 30
Id                          :
Name                        :
Type                        :
```

Create BackendPoolsSettings object using defaults

### Example 2: Create BackendPoolsSettings object with user specified values
```powershell
New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 60 -EnforceCertificateNameCheck Enabled
```

```output
EnforceCertificateNameCheck : Enabled
SendRecvTimeoutInSeconds      : 60
Id                          :
Name                        :
Type                        :
```

Create BackendPoolsSettings object with user specified values