### Example 1: Create an image object for Container.
```powershell
New-AzContainerAppTemplateObject -Name azps-containerapp -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
```

```output
Arg Command Image                                                       Name
--- ------- -----                                                       ----
            mcr.microsoft.com/azuredocs/containerapps-helloworld:latest azps-containerapp
```

Create an image object for Container.