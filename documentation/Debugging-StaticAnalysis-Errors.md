# Debugging StaticAnalysis Errors

Our StaticAnalysis tools help us ensure our modules follow PowerShell guidelines and prevent breaking changes from occurring outside of breaking change releases.

- [How to know if you have a StaticAnalysis Error](#how-to-know-if-you-have-a-staticanalysis-error)
- [Where to find StaticAnalysis reports](#where-to-find-staticanalysis-reports)
- [Types of StaticAnalysis Errors](#types-of-staticanalysis-errors)
    - [Breaking Changes](#breaking-changes)
    - [Signature Issues](#signature-issues)
    - [Help Issues](#help-issues)
    - [Example Issues](#example-issues)
- [Troubleshotting Example Issues](#troubleshotting-example-issues)

## How to know if you have a StaticAnalysis Error
If your build is failing, click on the Jenkins job inside the PR (marked as "Default" within checks).  Then check the Console Output within the Jenkins job.  If you have this error, then you have failed StaticAnalysis:
```
d:\workspace\powershell\build.proj(511,5): error MSB3073: The command "d:\workspace\powershell\artifacts\StaticAnalysis.exe d:\workspace\powershell\artifacts\Debug d:\workspace\powershell\artifacts true false" exited with code 255.
```

## Where to find StaticAnalysis reports

The StaticAnalysis reports could show up in two different places in the CI build:
- On the status page in Jenkins, under the Build Artifacts: the relevant files are `BreakingChangeIssues.csv`, `SignatureIssues.csv`, `HelpIssues.csv` and/or `ExampleIssues.csv`.
- On the status page in Jenkins, click Build Artifacts then navigate to artifacts.  You will see `BreakingChangeIssues.csv`, `SignatureIssues.csv`, `HelpIssues.csv` and/or `ExampleIssues.csv`.

Locally, the StaticAnalysis report will show up under Azure-PowerShell/artifacts. You will see `BreakingChangeIssues.csv`, `SignatureIssues.csv`, `HelpIssues.csv` and/or `ExampleIssues.csv`.  You can generate these files by running
```
msbuild build.proj
```

## Types of StaticAnalysis Errors
The three most common Static Analysis errors are breaking changes, signature issues, and help issues.  To figure out which type of error is causing the build failure, open each of the relevant .csv files (if the .csv file does not exist, there is no violation detected).  Any issue marked with severity 0 or 1 must be resolved in order for the build to pass.

### Breaking Changes
If you make a change that could cause a breaking change, it will be listed in `BreakingChangeIssues.csv`.  Please look at each of these errors in this file, and if they do indeed introduce a breaking change in a non-breaking change release, please revert the change that caused this violation. 

_Note_: Sometimes the error listed in the .csv file can be a false positive (for example, if you change a parameter attribute to span all parameter sets rather than individual parameter sets).  Please read the error thoroughly and examine the relevant code before deciding that an error is a false positive, and contact the Azure PowerShell team if you have questions.  If you are releasing a preview module, are releasing during a breaking change release, or have determined that the error is a false positive, please follow these instructions to suppress the errors:

- Download the `BreakingChangeIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `BreakingChangeIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g._, if a breaking change is being suppressed for Compute, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Compute/BreakingChangeIssues.csv` file) using the same text editor
- Push the changes to the .csv file and ensure the errors no longer show up in the `BreakingChangeIssues.csv` file output from the CI pipeline artifacts.

We take breaking changes very seriously, so please be mindful about the violations that you suppress in our repo.

### Signature Issues
Signature issues occur when your cmdlets do not follow PowerShell standards.  Please check the [_Cmdlet Best Practices_](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/cmdlet-best-practices.md) and the [_Parameter Best Practices_](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md) documents to ensure you are following PowerShell guidelines.  Issues with severity 0 or 1 must be addressed, while issues with severity 2 are advisory.  If you have an issue with severity 0 or 1 that has been approved by the Azure PowerShell team, you can suppress them following these steps:

- Download the `SignatureIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `SignatureIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g.,_ if a signature issue is being suppressed for Sql, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Sql/SignatureIssues.csv` file) using the same text editor
- Copy each of the errors you would like to suppress directly from the SignatureIssues.csv file output in the CI pipeline artifacts
- Push the changes to the .csv file and ensure the errors no longer show up in the `SignatureIssues.csv` file output from the CI pipeline artifacts.

### Help Issues
Most help issues that cause StaticAnalysis to fail occur when help has not been added for a particular cmdlet.  If you have not generated help for your new cmdlets, please follow the instructions [here](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/help-generation.md). If this is not the issue, follow the steps listed under "Remediation" for each violation listed in HelpIssues.csv.

### Example Issues
Example issues occur when your changed markdown files in the `help` folder (_e.g.,_ `src/Accounts/Accounts/help`) violate PowerShell language best practices. Please follow the suggestion displayed in "Remediation" entry for each violation listed in `ExampleIssues.csv`. Issues with severity 0 or 1 must be addressed, while issues with severity 2 are advisory. To better standardize the writing of documents, please also check the warning issues with severity 2 in log or download the `ExampleIssues.csv` file. If you have an issue with severity 0 or 1 that has been approved by the Azure PowerShell team, you can suppress them following these steps:

- Download the `ExampleIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `ExampleIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g.,_ if an example issue is being suppressed for Accounts, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Accounts/ExampleIssue.csv` file) using the same text editor
- Copy each of the errors you would like to suppress directly from the ExampleIssues.csv file output in the CI pipeline artifacts
- Push the changes to the .csv file and ensure the errors no longer show up in the `ExampleIssues.csv` file output from the CI pipeline artifacts.

## Troubleshotting Example Issues
### Scenario 1: Unexpected errors caused by the mixture of outputs and codes 
PowerShell code and output are required to be in sepreated code blocks (```). If you have put outputs in the code block, then the outputs will be recognized as invalid PowerShell syntax. Please make sure you have splitted outputs from codes. The following shows the correct scene. Note that if the example has no output, you don't need to add an output block.
### Example: Codes and outputs are split correctly
````
```powershell
Get-AzConfig -EnableDataCollection
```

```output
Key                           Value Applies To Scope       Help Message
---                           ----- ---------- -----       ------------
EnableDataCollection          False Az         CurrentUser When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the custom…
```
````
If outputs cannot be separated from codes, then please add the tag `<!-- Skip: Output cannot be splitted from code -->` to the next line of the example title and in front of the code block. The following is an example. 
### Example: Add skip tag to the example whose outputs cannot be separated from codes
````
<!-- Skip: Output cannot be splitted from code -->
```powershell
$Context = Get-AzBatchAccountKey -AccountName myaccount
$Context.PrimaryAccountKey
ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMN==
$Context.SecondaryAccountKey
ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMN==
```
````

### Scenario 2: Unexpected errors caused by unpaired quotes or brackets
Please check whether you have matched the correct number of **quotes** and **brackets**. The common error messages in this scenario are as follows.
- MissingEndParenthesisInExpression: Missing closing ')' in expression.
- MissingEndCurlyBrace: Missing closing '}' in statement block or type definition.
- MissingArrayIndexExpression: Array index expression is missing or not valid.
- UnexpectedToken: Unexpected token xxx. (Check whether you have missed or added extra quote)

In this scenario, many other unreasonable errors will occur. Leave them alone. Just make sure you have correct the number of **quotes** and **brackets** and rerun the CI verification. 