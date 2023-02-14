This folder contains ps1 scripts testing Azure Key Vault cmdlets.
Test environments and accounts:
1. Copy this folder on a server 2012 R2 and windows 8.1 machine with Azure Powershell msi installed.    
2. Setup Azure account. Please refer to "Key Vault Powershell Sign-off criteria" in spec store for user account setup.
Run tests for three types of account:
   - Service principal (DataPlane tests)
   - OrgId
   - LiveId
Run testing scripts:
1. Run scripting tests using RunKeyVaultTests.ps1. 
2. Run tests required user inputs using RunUITests.ps1.
