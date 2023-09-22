### Example 1: Create an in-memory object for JobExecutionContainer.
```powershell
New-AzContainerAppJobExecutionContainerObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","while true; do echo hello; sleep 10;done"
```

```output
Image                                    Name
-----                                    ----
mcr.microsoft.com/k8se/quickstart:latest simple-hello-world-container2
```

Create an in-memory object for JobExecutionContainer.