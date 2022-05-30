### Example 1: Create an EnvironmentVar object for Env.
```powershell
New-AzContainerAppEnvironmentVarObject -Name "envVarName" -SecretRef "facebook-secret" -Value "value"
```

```output
Name       SecretRef       Value
----       ---------       -----
envVarName facebook-secret value
```

Create an EnvironmentVar object for Env.