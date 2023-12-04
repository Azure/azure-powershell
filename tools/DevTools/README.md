# What's inside DevTools

## CommonRepo.psm1

A script module to help you connect the azure-powershell and azure-powershell-common repositories for developing or debugging.

```powershell
# Connect
Import-Module .\CommonRepo.psm1
Connect-CommonRepo -CommonRepoPath ..\azure-powershell-common

# Disconnect
Disconnect-CommonRepo
```
