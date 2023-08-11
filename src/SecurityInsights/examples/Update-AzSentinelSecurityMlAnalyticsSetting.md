### Example 1: Update specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 2) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
Update-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName f209187f-1d17-4431-94af-c141bf5f23db -SecurityMlAnalyticsSetting $setting
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 02:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command updates specific SecurityMlAnalyticsSetting with specified resource group and workspace

