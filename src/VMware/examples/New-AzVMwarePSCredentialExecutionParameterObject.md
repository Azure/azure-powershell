### Example 1: Create a PS Credential Execution object
```powershell
PS C:\> New-AzVMwarePSCredentialExecutionParameterObject -Name azps_test_credentialvalue -Password "passwordValue" -Username "usernameValue"

Name                      Type       Password      Username
----                      ----       --------      --------
azps_test_credentialvalue Credential passwordValue usernameValue
```

Create a PS Credential Execution object