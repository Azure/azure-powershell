### Example 1: Create a local Script Secure String Execution object
```powershell
New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue "passwordValue"
```
```output
Name                  Type        SecureValue
----                  ----        -----------
azps_test_securevalue SecureValue passwordValue
```

Create a local Script Secure String Execution object