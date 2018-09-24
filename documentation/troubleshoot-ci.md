# Troubleshooting CI build failures

In case "default" CI job for your PR failed, click "Details" and analyze, messages there are usually helpful.

Find and open **msbuild.err** from build artifacts to see summarized error message. List of possible failures is below.

To get even more detailed data click "Console Output" and look for keywords like "Fail", etc.

## Help generation failure

### Message

> c:\workspace\powershell\build.proj(278,5): error MSB3073: The command ""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" -NonInteractive -NoLogo -NoProfile -Command "$ProgressPreference = 'SilentlyContinue';. c:\workspace\powershell\tools\\**GenerateHelp.ps1** -ValidateMarkdownHelp -GenerateMamlHelp -BuildConfig Debug -FilteredModules 'AzureRM.Network;AzureRM.Profile' "" exited with code -1.

This means there are issues with your help files.

### Reasons:

- Cmdlet was changed while .md help files were not regenerated [this way](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/help-generation.md) or there is no help files at all.
- Help files were re-generated, however they weren't filled with real data. I.e. help generator leaves templates like this `"{{Description there}}"` and they need to be manually filled by developer with descriptions, examples, etc.

### Solution

Regenerate MD help files [this way](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/help-generation.md) and update "{{\*}}" placeholders

## Code analysis failures

### Message

> c:\workspace\powershell\build.proj(597,5): error MSB3073: The command "c:\workspace\powershell\src\Package\\**StaticAnalysis.exe** -p c:\workspace\powershell\src\Package\Debug -r c:\workspace\powershell\src\Package  -m AzureRM.Network" exited with code 255.c:\workspace\powershell\build.proj(609,5): error : StaticAnalysis has failed.  Please follow the instructions on this doc: [https://github.com/Azure/azure-powershell/blob/preview/documentation/Debugging-StaticAnalysis-Errors.md](https://github.com/Azure/azure-powershell/blob/preview/documentation/Debugging-StaticAnalysis-Errors.md)

### Reasons

Something that is considered as unacceptable was added with your PR e.g. breaking change, incorrect signature, etc.

### Solution

According to the [link above](https://github.com/Azure/azure-powershell/blob/preview/documentation/Debugging-StaticAnalysis-Errors.md) you would need to investigate .csv files in the build artifacts.

There are several ways to act:

1. In case your changes in the listed files are unintentional, just roll them back.

2. In case changes could be improved without affecting functionality (e.g. signature is incorrect, but you could adjust it to suit requirements), try to fix.

3. In case messages in csv files describe expected changes, add them to [exclusions](https://github.com/Azure/azure-powershell/blob/preview/documentation/Debugging-StaticAnalysis-Errors.md#breaking-changes).

### Example:

One of the often reasons are BreakingChangesIssues.

If collected Breaking Changes issues are expected (e.g. cmdlet was really changed), you would need to update Exclusions file [like this](https://github.com/Azure/azure-powershell/blob/preview/documentation/Debugging-StaticAnalysis-Errors.md#breaking-changes) to bypass CI build.

## Test failures

### Message

> c:\workspace\powershell\build.proj(683,5): error MSB3073: The command ""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" -NonInteractive -NoLogo -NoProfile -Command "if ((Get-ChildItem c:\workspace\powershell\src\Publish\TestResults/FailingTests).Count -ge 1) { throw "Failing tests, please check files in src/TestResults/FailingTests" } "" exited with code 1.c:\workspace\powershell\build.proj(689,5): error : **Test failures occurred, check the files in src/Publish/TestResults/FailingTests.**

### Reasons

One or more tests failed

### Solution

See test run report in src/Publish/TestResults/FailingTests and fix failures related to your changes.

In case you see more failures, please contact test owning team. Common way is to find a person who edited the cmdlet or test last. Networking tests are also marked with header like this to simplify team search: `[Trait(Category.Owner, Category.TeamAlias)]`
