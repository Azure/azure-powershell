### Example 1: Create an EnvironmentVar object for Env.
```powershell
New-AzContainerAppEnvironmentVarObject -Name "envVarName" -SecretRef "redis-secret" -Value "value"
```

```output
Name       SecretRef    Value
----       ---------    -----
envVarName redis-secret value
```

Create an EnvironmentVar object for Env.