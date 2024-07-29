### Example 1: Update the Monitoring Setting.
```powershell
Update-AzSpringMonitoringSetting -ResourceGroupName azps_test_group_spring -Name azps-spring-02 -AppInsightsSamplingRate 15
```

```output
AppInsightAgentVersionJava    : 3.4.19
AppInsightsInstrumentationKey :
AppInsightsSamplingRate       : 15
Code                          :
Id                            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/monitoringSettings/default
Message                       :
Name                          : default
ProvisioningState             : Succeeded
ResourceGroupName             : azps_test_group_spring
SystemDataCreatedAt           :
SystemDataCreatedBy           :
SystemDataCreatedByType       :
SystemDataLastModifiedAt      :
SystemDataLastModifiedBy      :
SystemDataLastModifiedByType  :
TraceEnabled                  : False
Type                          : Microsoft.AppPlatform/Spring/monitoringSettings
```

Update the Monitoring Setting.