### Example 1: Get the diagnostics data for a Managed Environment used to host container apps.
```powershell
Get-AzContainerAppManagedEnvDiagnosticDetector -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name                                 ResourceGroupName
----                                 -----------------
containerappenvironmentreplicacounts azps_test_group_app
managedenvironmentdeployment         azps_test_group_app
```

Get the diagnostics data for a Managed Environment used to host container apps.