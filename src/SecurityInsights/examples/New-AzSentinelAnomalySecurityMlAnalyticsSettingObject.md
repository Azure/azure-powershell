### Example 1: Create an Anomaly SecurityMlAnalyticsSettings Object
```powershell
New-AzSentinelAnomalySecurityMlAnalyticsSettingObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 1) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
```

```output
AnomalySettingsVersion       : 
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : 
Frequency                    : 01:00:00
Id                           : 
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 
Name                         : 
RequiredDataConnector        : 
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : 
Technique                    : 
Type                         : 
```

This command creates an Anomaly SecurityMlAnalyticsSettings Object