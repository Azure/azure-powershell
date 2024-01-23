### Example 1: {{ Add title here }}
```powershell
New-AzVMwarePSCredentialExecutionParameterObject -Name azps_test_credentialvalue -Password "passwordValue" -Username "usernameValue"
```
```output
Name                      Password      Type       Username
----                      --------      ----       --------
azps_test_credentialvalue passwordValue Credential usernameValue
```

Create a local PS Credential Execution object