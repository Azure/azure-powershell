### Example 1: Create a sys log data source object with cron facility
```powershell
New-AzSyslogDataSourceObject -FacilityName cron -LogLevel Debug,Critical,Emergency -Name cronSyslog -Stream Microsoft-Syslog
```

```output
FacilityName LogLevel                     Name       Stream
------------ --------                     ----       ------
{cron}       {Debug, Critical, Emergency} cronSyslog {Microsoft-Syslog}
```

This command creates a sys log data source object.

### Example 2: Create a sys log data source object with sys log facility
```powershell
New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
```

```output
FacilityName LogLevel                     Name       Stream
------------ --------                     ----       ------
{syslog}     {Alert, Critical, Emergency} syslogBase {Microsoft-Syslog}
```

This command creates a sys log data source object.

