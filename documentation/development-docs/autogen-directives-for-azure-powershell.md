# Autogen Directives for Azure Powershell
## Directive Scenarios
- [Resource Group Append](#Resource-Group-Append)
### Resource Group Append
To provide `ResourceGroupName` in returned object,  set `resourcegroup-append` as true in readme.md 
```
branch: ebe90b1dfef9ec9706dee06e84676a6c6979ab53
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/purview/resource-manager/Microsoft.Purview/stable/2021-07-01/purview.json 

module-version: 0.1.0
title: Purview
subject-prefix: $(service-name)
resourcegroup-append: true
```