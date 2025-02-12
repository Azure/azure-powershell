### Example 1: Create a local Script Secure String Execution object
```powershell
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue $mypwd
```
```output

Name                                   SecureValue Type
----                                   ----------- ----
azps_test_securevalue System.Security.SecureString SecureValue
```

Create a local Script Secure String Execution object