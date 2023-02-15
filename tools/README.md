This folder contains the utilities for Azure PowerShell.

## Build

**Common.Netcore.Dependencies.targets** contains common dependencies for Azure PowerShell modules.

## Test

**Common.Netcore.Dependencies.Test.targets** contains common dependencies of test execution for Azure PowerShell modules.

## Release

### Version Control

**RunVersionController.ps1** bumps versions after comparing cmdlet signature between current version and snapshot of previous version. It can be executed after `build`

### Reference Docs

**CreateMappings.ps1** creates the mappings between service and cmdlet. It scans all help folders and cmdlet help files in markdown and calculates service name according to rules defined by `CreateMappings_rules.json`. Output are `groupMapping.json` and `groupMappingWarnings.json`. It can be executed after `build`.

### Others

**GenerateExternalContributors.ps1** generates the list of external contributors which is appended as part of release notes. It needs personal access token of Github with sufficient permission.

**GenerateCmdletDesignMarkdown.ps1** generates the cmdlet signatures for review. The content bases on generated cmdlet reference docs in markdown under docs folder. You can try below code from the root folder of your module after reference doc is generated.
```
..\..\tools\GenerateCmdletDesignMarkdown.ps1 -Path .\docs\ -OutPath .\docs\
```
Cmdldet is catorized by noun, resource type name by default, with Az prefix. `-NounPriority` is used to adjust the order of cmdlets in output.
