### Example 1: Create an in-memory object for TransformOutput.
```powershell
New-AzMediaTransformOutputObject -PresetOdataType "#Microsoft.Media.BuiltInStandardEncoderPreset" -OnError 'StopProcessingJob' -RelativePriority 'Normal'
```

```output
OnError           RelativePriority
-------           ----------------
StopProcessingJob Normal
```

Create an in-memory object for TransformOutput.