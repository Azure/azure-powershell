### Example 1: Create an in-memory object for InitContainer.
```powershell
New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","while true; do echo hello; sleep 10;done"
```

```output
Image                                    Name                          ResourceCpu ResourceEphemeralStorage ResourceMemory
-----                                    ----                          ----------- ------------------------ --------------
mcr.microsoft.com/k8se/quickstart:latest simple-hello-world-container2 0.25                                 0.5Gi
```

Create an in-memory object for InitContainer.