### Example 1: Create a local Script Secure String Execution object
```powershell
PS C:\> New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue "passwordValue"

Name                  Type        SecureValue
----                  ----        -----------
azps_test_securevalue SecureValue passwordValue
```

Create a local Script Secure String Execution object