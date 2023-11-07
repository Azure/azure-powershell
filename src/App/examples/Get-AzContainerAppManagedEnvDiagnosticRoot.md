### Example 1: Get the properties of a Managed Environment used to host container apps.
```powershell
Get-AzContainerAppManagedEnvDiagnosticRoot -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

Get the properties of a Managed Environment used to host container apps.