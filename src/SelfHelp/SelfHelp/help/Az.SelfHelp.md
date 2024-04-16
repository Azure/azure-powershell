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
\<br/\>\<br/\> Required Input :  problemClassificationId (Use the [problemClassification API](https://learn.microsoft.com/rest/api/support/problem-classifications/list?tabs=HTTP)) \<br/\>Optional input: resourceUri OR resource Type \<br/\>\<br/\> \<b\>Note: \</b\>  'requiredInputs' from Discovery solutions response must be passed via 'additionalParameters' as an input to Diagnostics and Solutions API.

### [Get-AzSelfHelpSimplifiedSolution](Get-AzSelfHelpSimplifiedSolution.md)
Get the simplified Solutions using the applicable solutionResourceName while creating the simplified Solutions.

### [Get-AzSelfHelpSolution](Get-AzSelfHelpSolution.md)
Get the solution using the applicable solutionResourceName while creating the solution.

### [Get-AzSelfHelpSolutionSelfHelp](Get-AzSelfHelpSolutionSelfHelp.md)
Finds and Executes a Self Help Solution based on the Solution Id.
These are static self help content to help users troubleshoot their issues.

### [Get-AzSelfHelpTroubleshooter](Get-AzSelfHelpTroubleshooter.md)
Gets troubleshooter instance result which includes the step status/result of the troubleshooter resource name that is being executed.\<br/\> Get API is used to retrieve the result of a Troubleshooter instance, which includes the status and result of each step in the Troubleshooter workflow.
This API requires the Troubleshooter resource name that was created using the Create API.

### [Invoke-AzSelfHelpCheckNameAvailability](Invoke-AzSelfHelpCheckNameAvailability.md)
This API is used to check the uniqueness of a resource name used for a diagnostic, troubleshooter or solutions

### [Invoke-AzSelfHelpContinueTroubleshooter](Invoke-AzSelfHelpContinueTroubleshooter.md)
Uses 'stepId' and 'responses' as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

### [Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope](Invoke-AzSelfHelpDiscoverySolutionNlpSubscriptionScope.md)
Solution discovery using natural language processing.

### [Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope](Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope.md)
Solution discovery using natural language processing.

### [Invoke-AzSelfHelpWarmSolutionUp](Invoke-AzSelfHelpWarmSolutionUp.md)
Warm up the solution resource by preloading asynchronous diagnostics results into cache

### [New-AzSelfHelpDiagnostic](New-AzSelfHelpDiagnostic.md)
Creates a diagnostic for the specific resource using solutionId and requiredInputs* from discovery solutions.
\<br/\>Diagnostics are powerful solutions that access product resources or other relevant data and provide the root cause of the issue and the steps to address the issue.\<br/\>\<br/\> \<b\>Note: \</b\> 'requiredInputs' from Discovery solutions response must be passed via 'additionalParameters' as an input to Diagnostics API.

### [New-AzSelfHelpSimplifiedSolution](New-AzSelfHelpSimplifiedSolution.md)
Creates a simplified Solutions for the specific Azure resource or subscription using the inputs 'solutionId and requiredInputs' from discovery solutions.
In the absence of the 'Parameters' it is likely that some of the simplified Solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
'requiredInputs' from Discovery solutions response must be passed via 'parameters' in the request body of simplified Solutions API.
\<br/\>

### [New-AzSelfHelpSolution](New-AzSelfHelpSolution.md)
Creates a solution for the specific Azure resource or subscription using the inputs 'solutionId and requiredInputs' from discovery solutions.
\<br/\> Azure solutions comprise a comprehensive library of self-help resources that have been thoughtfully curated by Azure engineers to aid customers in resolving typical troubleshooting issues.
These solutions encompass (1.) dynamic and context-aware diagnostics, guided troubleshooting wizards, and data visualizations, (2.) rich instructional video tutorials and illustrative diagrams and images, and (3.) thoughtfully assembled textual troubleshooting instructions.
All these components are seamlessly converged into unified solutions tailored to address a specific support problem area.
Each solution type may require one or more 'requiredParameters' that are required to execute the individual solution component.
In the absence of the 'requiredParameters' it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
'requiredInputs' from Discovery solutions response must be passed via 'parameters' in the request body of Solutions API.
\<br/\>2.
'requiredParameters' from the Solutions response is the same as ' additionalParameters' in the request for diagnostics \<br/\>3.
'requiredParameters' from the Solutions response is the same as 'properties.parameters' in the request for Troubleshooters

### [New-AzSelfHelpTroubleshooter](New-AzSelfHelpTroubleshooter.md)
Creates the specific troubleshooter action under a resource or subscription using the 'solutionId' and  'properties.parameters' as the trigger.
\<br/\> Azure Troubleshooters help with hard to classify issues, reducing the gap between customer observed problems and solutions by guiding the user effortlessly through the troubleshooting process.
Each Troubleshooter flow represents a problem area within Azure and has a complex tree-like structure that addresses many root causes.
These flows are prepared with the help of Subject Matter experts and customer support engineers by carefully considering previous support requests raised by customers.
Troubleshooters terminate at a well curated solution based off of resource backend signals and customer manual selections.

### [Restart-AzSelfHelpTroubleshooter](Restart-AzSelfHelpTroubleshooter.md)
Restarts the troubleshooter API using applicable troubleshooter resource name as the input.\<br/\> It returns new resource name which should be used in subsequent request.
The old resource name is obsolete after this API is invoked.

### [Stop-AzSelfHelpTroubleshooter](Stop-AzSelfHelpTroubleshooter.md)
Ends the troubleshooter action

### [Update-AzSelfHelpSolution](Update-AzSelfHelpSolution.md)
Update the requiredInputs or additional information needed to execute the solution

