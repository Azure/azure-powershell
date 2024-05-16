### Example 1: Create a local Script Secure String Execution object
```powershell
New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue "passwordValue"
```
```output
Name                  SecureValue   Type
----                  -----------   ----
azps_test_securevalue passwordValue SecureValue
```

Create a local Script Secure String Execution object