### Example 1: Create BackendPoolsSettings object using defaults
```powershell
New-AzFrontDoorBackendPoolsSettingObject
```

```output
EnforceCertificateNameCheck SendRecvTimeoutInSeconds
--------------------------- ------------------------
Enabled                                           30
```

Create BackendPoolsSettings object using defaults

### Example 2: Create BackendPoolsSettings object with user specified values
```powershell
New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 60 -EnforceCertificateNameCheck Enabled
```

```output
EnforceCertificateNameCheck SendRecvTimeoutInSeconds
--------------------------- ------------------------
Enabled                                           60
```

Create BackendPoolsSettings object with user specified values