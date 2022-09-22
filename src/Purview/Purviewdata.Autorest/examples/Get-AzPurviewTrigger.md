### Example 1: Get trigger schedule for scan run
```powershell
Get-AzPurviewTrigger -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan-6HK'
```

```output
CreatedAt                  : 2/17/2022 1:35:12 PM
Id                         : datasources/DataScanTestData-Parv/scans/Scan-6HK/triggers/default
IncrementalScanStartTime   :
Interval                   : 1
LastModifiedAt             : 2/17/2022 1:35:12 PM
LastScheduled              :
Name                       : default
RecurrenceEndTime          : 7/20/2022 12:00:00 AM
RecurrenceFrequency        : Month
RecurrenceInterval         :
RecurrenceStartTime        : 2/17/2022 1:32:00 PM
RecurrenceTimeZone         :
ResourceGroupName          :
ScanLevel                  : Incremental
ScheduleAdditionalProperty : {
                             }
ScheduleHour               : {9}
ScheduleMinute             : {0}
ScheduleMonthDay           : {10}
ScheduleMonthlyOccurrence  :
ScheduleWeekDay            :
```

Get trigger schedule for scan run

