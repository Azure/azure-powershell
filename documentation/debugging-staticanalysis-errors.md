# Debugging StaticAnalysis Errors

Our StaticAnalysis tools help us ensure our modules follow PowerShell guidelines and prevent breaking changes from occurring outside of breaking change releases.

- [How to know if you have a StaticAnalysis Error](#how-to-know-if-you-have-a-staticanalysis-error)
- [Where to find StaticAnalysis reports](#where-to-find-staticanalysis-reports)
- [Types of StaticAnalysis Errors](#types-of-staticanalysis-errors)
    - [Breaking Changes](#breaking-changes)
    - [Signature Issues](#signature-issues)
    - [Help Issues](#help-issues)

## How to know if you have a StaticAnalysis Error
If your build is failing, click on the Jenkins job inside the PR (marked as "Default" within checks).  Then check the Console Output within the Jenkins job.  If you have this error, then you have failed StaticAnalysis:
```
d:\workspace\powershell\build.proj(511,5): error MSB3073: The command "d:\workspace\powershell\src\Package\StaticAnalysis.exe d:\workspace\powershell\src\Package\Debug d:\workspace\powershell\src\Package true false" exited with code 255.
```

## Where to find StaticAnalysis reports

The StaticAnalysis reports could show up in two different places in the CI build:
- On the status page in Jenkins, under the Build Artifacts: the relevant files are BreakingChangeIssues.csv, SignatureIssues.csv, and/or HelpIssues.csv.
- On the status page in Jenkins, click Build Artifacts then navigate to src/Package.  You will see BreakingChangeIssues.csv, SignatureIssues.csv, and/or HelpIssues.csv.

Locally, the StaticAnalysis report will show up under Azure-PowerShell/src/Package. You will see BreakingChangeIssues.csv, SignatureIssues.csv, and/or HelpIssues.csv.  You can generate these files by running
```
msbuild build.proj
```

## Types of StaticAnalysis Errors
The three most common Static Analysis errors are breaking changes, signature issues, and help issues.  To figure out which type of error is causing the build failure, open each of the relevant .csv files (if the .csv file does not exist, there is no violation detected).  Any issue marked with severity 0 or 1 must be resolved in order for the build to pass.

### Breaking Changes
If you make a change that could cause a breaking change, it will be listed in BreakingChangeIssues.csv.  Please look at each of these errors, and if they do indeed introduce a breaking change in a non-breaking change release, please revert the change that caused this violation.  Sometimes the error listed in the .csv file can be a false positive (for example, if you change a parameter attribute to span all parameter sets rather than individual parameter sets).  Please read the error thoroughly and examine the relevant code before deciding that an error is a false positive, and contact the Azure PowerShell team if you have questions.  If you are releasing a preview module, are releasing during a breaking change release, or have determined that the error is a false positive, please follow these instructions:
- Copy each of the errors you would like to suppress directly from the BreakingChangeIssues.csv file output in the Jenkins build
- Paste each of these error into the [BreakingChangeIssues.csv file](https://github.com/Azure/azure-powershell/blob/preview/tools/StaticAnalysis/Exceptions/BreakingChangeIssues.csv) in our GitHub repo. Note that you will need to edit this file in a text editor rather than Excel to prevent parsing errors.
- Push the changes to the .csv file and ensure the errors no longer show up in the BreakingChangeIssues.csv file output from the Jenkins build.

We take breaking changes very seriously, so please be mindful about the violations that you suppress in our repo.

### Signature Issues
Signature issues occur when your cmdlets do not follow PowerShell standards.  Please check [this page](https://github.com/Azure/azure-powershell/wiki/PowerShell-Cmdlet-Design-Guidelines) to ensure you are following PowerShell guidelines.  Issues with severity 0 or 1 must be addressed, while issues with severity 2 are advisory.  If you have an issue with severity 0 or 1 that has been approved by the Azure PowerShell team, you can suppress them following these steps:
- Copy each of the errors you would like to suppress directly from the SignatureIssues.csv file output in the Jenkins build
- Paste each of these error into the [SignatureIssues.csv file](https://github.com/Azure/azure-powershell/blob/preview/tools/StaticAnalysis/Exceptions/SignatureIssues.csv) in our GitHub repo. Note that you will need to edit this file in a text editor rather than Excel to prevent parsing errors.
- Push the changes to the .csv file and ensure the errors no longer show up in the SignatureIssues.csv file output from the Jenkins build.

### Help Issues
Most help issues that cause StaticAnalysis to fail occur when help has not been added for a particular cmdlet.  If you have not generated help for your new cmdlets, please follow the instructions [here](https://github.com/Azure/azure-powershell/blob/preview/documentation/help-generation.md).  If this is not the issue, follow the steps listed under "Remediation" for each violation listed in HelpIssues.csv.
