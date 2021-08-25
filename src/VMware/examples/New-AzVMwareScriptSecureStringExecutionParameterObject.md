### Example 1: Create a in-memory object for ScriptSecureStringExecutionParameter
```powershell
PS C:\> New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue "passwordValue"

Name                  Type        SecureValue
----                  ----        -----------
azps_test_securevalue SecureValue passwordValue
```

Create a in-memory object for ScriptSecureStringExecutionParameter