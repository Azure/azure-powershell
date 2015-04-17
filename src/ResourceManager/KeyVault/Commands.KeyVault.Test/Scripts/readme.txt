This folder contains ps1 scripts testing Azure Key Vault cmdlets.
Test environments and accounts:
1. Copy this folder on a server 2012 R2 and windows 8.1 machine with Azure Powershell msi installed.    
2. Setup Azure account. Please refer to "Key Vault Powershell Sign-off criteria" in spec store for user account setup.
   Both OrgId user and Live user need to be tested.   
Run testing scripts:
1. Run scripting tests using RunKeyVaultTests.ps1. 
2. Run tests required user inputs using RunUITests.ps1.
3. Run RunListKeys that creates 50 keys and list them.
4. RunListKeyVersions that creates 50 versions of a key and list them. 