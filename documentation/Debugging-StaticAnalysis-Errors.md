# Debugging StaticAnalysis Errors

Our StaticAnalysis tools help us ensure our modules follow PowerShell guidelines and prevent breaking changes from occurring outside of breaking change releases.

- [How to know if you have a StaticAnalysis Error](#how-to-know-if-you-have-a-staticanalysis-error)
- [How to locate the StaticAnalysis Error](#how-to-locate-the-staticanalysis-error)
- [Where to find StaticAnalysis reports](#where-to-find-staticanalysis-reports)
- [Types of StaticAnalysis Errors](#types-of-staticanalysis-errors)
  - [Assembly Version Conflict](#assembly-version-conflict)
  - [Breaking Changes](#breaking-changes)
  - [Example Issues](#example-issues)
  - [Extra Assemblies](#example-issues)
  - [Help Issues](#help-issues)
  - [Missing Assemblies](#missing-assemblies)
  - [Signature Issues](#signature-issues)
- [Troubleshotting Example Issues](#troubleshotting-example-issues)

## How to know if you have a StaticAnalysis Error
If your build is failing, see the ADO pipeline checks. If check `azure-powershell - powershell-core (Analyze)` failed, then you have a StaticAnalysis Error.

## How to locate the StaticAnalysis Error
Click into the failed check, then click `View more details on Azure Pipelines` to redirect to ADO pipeline page. Click the sub task with errors and search `csv` or `error` to locate the specific errors. 

## Where to find StaticAnalysis reports
The StaticAnalysis reports could show up in the CI build. On the status page in ADO, under the Build Artifacts, expand the folder whose name starts with `analyze`. Under the `StaticAnalysisResults` folder: the relevant files are `AssemblyVersionConflict.csv`, `BreakingChangeIssues.csv`, `ExampleIssues.csv`, `ExtraAssemblies.csv`, `HelpIssues.csv`, `MissingAssemblies.csv`, and/or `SignatureIssues.csv` .

Locally, the StaticAnalysis report will show up under Azure-PowerShell/artifacts. You will see the `.csv` fils listed. You can generate these files by running
```
msbuild build.proj
```

## Types of StaticAnalysis Errors
The three most common Static Analysis errors are breaking changes, signature issues, and help issues.  To figure out which type of error is causing the build failure, open each of the relevant .csv files (if the .csv file does not exist, there is no violation detected).  Any issue marked with severity 0 or 1 must be resolved in order for the build to pass.

### Assembly Version Conflict
We utilize some shared assemblies, such as Azure.Core, accross all the modules to avoid duplicating. To maintain consistency, only one version is allowed to be loaded within a single PowerShell session. If any errors occur, they will be recorded in the `AssemblyVersionConflict.csv` file. We recommend reviewing each error listed in this file and updating your package dependencies accordingly. Generally, suppressing these issues is not advised.

### Breaking Changes
If you make a change that could cause a breaking change, it will be listed in `BreakingChangeIssues.csv`.  Please look at each of these errors in this file, and if they do indeed introduce a breaking change in a non-breaking change release, please revert the change that caused this violation. 

_Note_: Sometimes the error listed in the .csv file can be a false positive (for example, if you change a parameter attribute to span all parameter sets rather than individual parameter sets).  Please read the error thoroughly and examine the relevant code before deciding that an error is a false positive, and contact the Azure PowerShell team if you have questions.  If you are releasing a preview module, are releasing during a breaking change release, or have determined that the error is a false positive, please follow these instructions to suppress the errors:

- Download the `BreakingChangeIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `BreakingChangeIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g._, if a breaking change is being suppressed for Compute, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Compute/BreakingChangeIssues.csv` file) using the same text editor
- Push the changes to the .csv file and ensure the errors no longer show up in the `BreakingChangeIssues.csv` file output from the CI pipeline artifacts.

We take breaking changes very seriously, so please be mindful about the violations that you suppress in our repo.

### Example Issues
Example issues occur when your changed markdown files in the `help` folder (_e.g.,_ `src/Accounts/Accounts/help`) violate PowerShell language best practices. Please follow the suggestion displayed in "Remediation" entry for each violation listed in `ExampleIssues.csv`. Issues with severity 0 or 1 must be addressed, while issues with severity 2 are advisory. To better standardize the writing of documents, please also check the warning issues with severity 2 in log or download the `ExampleIssues.csv` file. If you have an issue with severity 0 or 1 that has been approved by the Azure PowerShell team, you can suppress them following these steps:

- Download the `ExampleIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `ExampleIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g.,_ if an example issue is being suppressed for Accounts, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Accounts/ExampleIssue.csv` file) using the same text editor
- Copy each of the errors you would like to suppress directly from the ExampleIssues.csv file output in the CI pipeline artifacts
- Push the changes to the .csv file and ensure the errors no longer show up in the `ExampleIssues.csv` file output from the CI pipeline artifacts.
- 
### Extra Assemblies
We will examine each assembly within the module's artifacts folder to identify any assembly that is actually not needed to pack into the package, for example a a system assembly. The names of these assemblies will be documented in the `ExtraAssemblies.csv` file. As these assemblies serve no purpose for this module, they should be removed to decrease the module package size. It is important to verify whether these files were copied due to an incorrect copy step, such as a `Copy` action in a `props` or `csproj` file. Generally, suppressing these issues is not advised.

### Help Issues
Most help issues that cause StaticAnalysis to fail occur when help has not been added for a particular cmdlet.  If you have not generated help for your new cmdlets, please follow the instructions [here](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/help-generation.md). If this is not the issue, follow the steps listed under "Remediation" for each violation listed in HelpIssues.csv.

### Missing Assemblies
We will ensure that all required assemblies are located within the module's artifacts folder for packaging purposes. If a necessary assembly is not included, the module cannot be imported. Any missing assemblies will be documented in the `MissingAssemblies.csv` file. It is important to investigate the reason behind a missing assembly, such as the assembly being loaded as a shared assembly but not added to the allowed list defined in `DependencyAnalyzer.cs`.

### Signature Issues
Signature issues occur when your cmdlets do not follow PowerShell standards.  Please check the [_Cmdlet Best Practices_](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/cmdlet-best-practices.md) and the [_Parameter Best Practices_](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md) documents to ensure you are following PowerShell guidelines.  Issues with severity 0 or 1 must be addressed, while issues with severity 2 are advisory.  If you have an issue with severity 0 or 1 that has been approved by the Azure PowerShell team, you can suppress them following these steps:

- Download the `SignatureIssues.csv` file from the CI pipeline artifacts
- Open the file using a text editor (such as VS Code) and copy each of the errors you'd like to suppress
- Paste each of these errors into the `SignatureIssues.csv` file found in their respective [module folder](../tools/StaticAnalysis/Exceptions) (_e.g.,_ if a signature issue is being suppressed for Sql, then you would paste the corresponding line(s) in the `tools/StaticAnalysis/Exceptions/Az.Sql/SignatureIssues.csv` file) using the same text editor
- Copy each of the errors you would like to suppress directly from the SignatureIssues.csv file output in the CI pipeline artifacts
- Push the changes to the .csv file and ensure the errors no longer show up in the `SignatureIssues.csv` file output from the CI pipeline artifacts.

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
