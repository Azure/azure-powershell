---
Module Name: Az.SelfHelp
Module Guid: 8ec16498-5aaf-4546-a6c5-5d2962fcbebe
Download Help Link: https://learn.microsoft.com/powershell/module/az.selfhelp
Help Version: 1.0.0.0
Locale: en-US
---

# Az.SelfHelp Module
## Description
Microsoft Azure PowerShell: SelfHelp cmdlets

## Az.SelfHelp Cmdlets
### [Get-AzSelfHelpDiagnostic](Get-AzSelfHelpDiagnostic.md)
Get the diagnostics using the 'diagnosticsResourceName' you chose while creating the diagnostic.

### [Get-AzSelfHelpDiscoverySolution](Get-AzSelfHelpDiscoverySolution.md)
Solutions Discovery is the initial point of entry within Help API, which helps you identify the relevant solutions for your Azure issue.\<br/\>\<br/\> You can discover solutions using resourceUri OR resourceUri + problemClassificationId.\<br/\>\<br/\>We will do our best in returning relevant diagnostics for your Azure issue.\<br/\>\<br/\> Get the problemClassificationId(s) using this [reference](https://learn.microsoft.com/en-us/rest/api/support/problem-classifications/list?tabs=HTTP).\<br/\>\<br/\> \<b\>Note: \</b\> ‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API.

### [New-AzSelfHelpDiagnostic](New-AzSelfHelpDiagnostic.md)
Diagnostics tells you precisely the root cause of the issue and how to address it.
You can get diagnostics once you discover and identify the relevant solution for your Azure issue.\<br/\>\<br/\> You can create diagnostics using the ‘solutionId’  from Solution Discovery API response and ‘additionalParameters’ \<br/\>\<br/\> \<b\>Note: \</b\>‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API

### [Test-AzSelfHelpDiagnosticNameAvailability](Test-AzSelfHelpDiagnosticNameAvailability.md)
This API is used to check the uniqueness of a resource name used for a diagnostic check.

