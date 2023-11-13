---
Module Name: Az.SelfHelp
Module Guid: 2705ffd2-39d8-491f-b0c6-14fca2dc3727
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
Lists the relevant Azure diagnostics and solutions using [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) AND  resourceUri or resourceType.\<br/\> Discovery Solutions is the initial entry point within Help API, which identifies relevant Azure diagnostics and solutions.
We will do our best to return the most effective solutions based on the type of inputs, in the request URL  \<br/\>\<br/\> Mandatory input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) \<br/\>Optional input: resourceUri OR resource Type \<br/\>\<br/\> \<b\>Note: \</b\>  ‘requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics and Solutions API.

### [Get-AzSelfHelpSolution](Get-AzSelfHelpSolution.md)
Get the solution using the applicable solutionResourceName while creating the solution.

### [Get-AzSelfHelpTroubleshooter](Get-AzSelfHelpTroubleshooter.md)
Gets troubleshooter instance result which includes the step status/result of the troubleshooter resource name that is being executed.\<br/\> Get API is used to retrieve the result of a Troubleshooter instance, which includes the status and result of each step in the Troubleshooter workflow.
This API requires the Troubleshooter resource name that was created using the Create API.

### [Invoke-AzSelfHelpCheckNameAvailability](Invoke-AzSelfHelpCheckNameAvailability.md)
This API is used to check the uniqueness of a resource name used for a diagnostic, troubleshooter or solutions

### [Invoke-AzSelfHelpContinueTroubleshooter](Invoke-AzSelfHelpContinueTroubleshooter.md)
Uses ‘stepId’ and ‘responses’ as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

### [New-AzSelfHelpDiagnostic](New-AzSelfHelpDiagnostic.md)
Creates a diagnostic for the specific resource using solutionId and requiredInputs* from discovery solutions.
\<br/\>Diagnostics tells you precisely the root cause of the issue and the steps to address it.
You can get diagnostics once you discover the relevant solution for your Azure issue.
\<br/\>\<br/\> \<b\>Note: \</b\> requiredInputs’ from Discovery solutions response must be passed via ‘additionalParameters’ as an input to Diagnostics API.

### [New-AzSelfHelpSolution](New-AzSelfHelpSolution.md)
Creates a solution for the specific Azure resource or subscription using the triggering criteria ‘solutionId and requiredInputs’ from discovery solutions.\<br/\> Solutions are a rich, insightful and a centralized self help experience that brings all the relevant content to troubleshoot an Azure issue into a unified experience.
Solutions include the following components : Text, Diagnostics , Troubleshooters, Images , Video tutorials, Tables , custom charts, images , AzureKB, etc, with capabilities to support new solutions types in the future.
Each solution type may require one or more ‘requiredParameters’ that are required to execute the individual solution component.
In the absence of the ‘requiredParameters’ it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
‘requiredInputs’ from Discovery solutions response must be passed via ‘parameters’ in the request body of Solutions API.
\<br/\>2.
‘requiredParameters’ from the Solutions response is the same as ‘ additionalParameters’ in the request for diagnostics \<br/\>3.
‘requiredParameters’ from the Solutions response is the same as ‘properties.parameters’ in the request for Troubleshooters

### [New-AzSelfHelpTroubleshooter](New-AzSelfHelpTroubleshooter.md)
Creates the specific troubleshooter action under a resource or subscription using the ‘solutionId’ and  ‘properties.parameters’ as the trigger.
\<br/\> Troubleshooters are step-by-step interactive guidance that scope the problem by collecting additional inputs from you in each stage while troubleshooting an Azure issue.
You will be guided down decision tree style workflow and the best possible solution will be presented at the end of the workflow.
\<br/\> Create API creates the Troubleshooter API using ‘parameters’ and ‘solutionId’ \<br/\> After creating the Troubleshooter instance, the following APIs can be used:\<br/\> CONTINUE API: to move to the next step in the flow \<br/\>GET API: to identify the next step after executing the CONTINUE API.
 \<br/\>\<br/\> \<b\>Note:\</b\> ‘requiredParameters’ from solutions response must be passed via ‘properties.
parameters’ in the request body of Troubleshooters API.

### [Restart-AzSelfHelpTroubleshooter](Restart-AzSelfHelpTroubleshooter.md)
Restarts the troubleshooter API using applicable troubleshooter resource name as the input.\<br/\> It returns new resource name which should be used in subsequent request.
The old resource name is obsolete after this API is invoked.

### [Stop-AzSelfHelpTroubleshooter](Stop-AzSelfHelpTroubleshooter.md)
Ends the troubleshooter action

### [Update-AzSelfHelpSolution](Update-AzSelfHelpSolution.md)
Update the requiredInputs or additional information needed to execute the solution

