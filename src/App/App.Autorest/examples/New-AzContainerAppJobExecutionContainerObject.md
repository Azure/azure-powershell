### Example 1: Create an in-memory object for JobExecutionContainer.
```powershell
New-AzContainerAppJobExecutionContainerObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
```

```output
Image                                    Name
-----                                    ----
mcr.microsoft.com/k8se/quickstart:latest simple-hello-world-container2
```

Create an in-memory object for JobExecutionContainer.