### Example 1: Create an object as a parameter for submitting cluster work.
```powershell
 $flinkJobProperties = New-AzHdInsightOnAksFlinkJobObject -Action "NEW" -JobName "job1" `
        -JarName "JarName" -EntryClass "com.microsoft.hilo.flink.job.streaming.SleepJob" `
        -JobJarDirectory "abfs://flinkjob@hilosa.dfs.core.windows.net/jars" `
        -FlinkConfiguration @{parallelism=1}
```

```output
Id Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-- ---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ----

```

Create an object as a parameter for submitting cluster work.
