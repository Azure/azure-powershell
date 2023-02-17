### Example 1: Creates or updates a new Transform.
```powershell
$transformOutput = New-AzMediaTransformOutputObject -PresetOdataType "#Microsoft.Media.BuiltInStandardEncoderPreset" -OnError 'StopProcessingJob' -RelativePriority 'Normal'

New-AzMediaTransform -AccountName azpsms -Name azpsms-transform -ResourceGroupName azps_test_group -Output $transformOutput
```

```output
Name             ResourceGroupName
----             -----------------
azpsms-transform azps_test_group
```

Creates or updates a new Transform.