### Example 1: Create a local PS Credential Execution object
```powershell
$mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
New-AzVMwarePSCredentialExecutionParameterObject -Name azps_test_credentialvalue -Password $mypwd -Username "usernameValue"
```
```output
Name                                          Password Type       Username
----                                          -------- ----       --------
azps_test_credentialvalue System.Security.SecureString Credential usernameValue
```

Create a local PS Credential Execution object