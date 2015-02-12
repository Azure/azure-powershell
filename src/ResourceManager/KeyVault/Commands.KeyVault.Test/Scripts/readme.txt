This folder contains ps1 scripts testing Azure Key Vault cmdlets.
The steps to run these tests are:
1. Copy this folder on a server 2012 R2 or windows 8.1 machine with Azure Powershell msi installed.
2. Setup Azure account. Please refer to "Key Vault Powershell Sign-off criteria" in spec store for user account setup.
3. Run 63 scripting tests using RunKeyVaultTests.ps1. Run 8 tests required user inputs using RunUITests.ps1.