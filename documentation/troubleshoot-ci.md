# Troubleshooting CI Build Failures

When the "default" CI job for your pull request fails, click "Details" to analyze the failure. The error messages there are usually helpful.

Find and open **msbuild.err** from the build artifacts to see a summarized error message. A list of possible failures is provided below.

To get more detailed information, click "Console Output" and search for keywords like "Fail", "Error", etc.

## Help Generation Failure

### Error Message

> c:\workspace\powershell\build.proj(278,5): error MSB3073: The command ""C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" -NonInteractive -NoLogo -NoProfile -Command "$ProgressPreference = 'SilentlyContinue';. c:\workspace\powershell\tools\\**GenerateHelp.ps1** -ValidateMarkdownHelp -GenerateMamlHelp -BuildConfig Debug -FilteredModules 'Az.Network;Az.Profile' "" exited with code -1.

This error indicates there are issues with your help files.

### Common Causes

- Cmdlets were modified but the corresponding .md help files were not regenerated [following this process](development-docs/help-generation.md), or there are no help files at all.
- Help files were regenerated but not properly filled with actual content. The help generator leaves template placeholders like `"{{Description here}}"` that need to be manually updated by the developer with descriptions, examples, etc.

### Solution

Regenerate MD help files [following this process](development-docs/help-generation.md) and update all "{{\*}}" placeholders with appropriate content.

## Help Generation Failure (Online Version URL)

### Error Message

> Online version in the header of the file is incorrect.

### Common Causes

This error occurs when the online version URL in the header of the help document is either incorrect or missing.

### Solution

The URL should follow the exact schema: `https://learn.microsoft.com/en-us/powershell/module/az.{modulename}/{cmdlet-name}`, with all text in lowercase.

### Example
> https://learn.microsoft.com/en-us/powershell/module/az.keyvault/new-azkeyvault

## Code Analysis Failures

### Error Message

> c:\workspace\powershell\build.proj(597,5): error MSB3073: The command "c:\workspace\powershell\artifacts\\**StaticAnalysis.exe** -p c:\workspace\powershell\artifacts\Debug -r c:\workspace\powershell\artifacts -m Az.Network" exited with code 255.c:\workspace\powershell\build.proj(609,5): error : StaticAnalysis has failed. Please follow the instructions on this doc: [https://github.com/Azure/azure-powershell/blob/main/documentation/Debugging-StaticAnalysis-Errors.md](Debugging-StaticAnalysis-Errors.md)

### Common Causes

This error occurs when your pull request introduces something considered unacceptable, such as breaking changes, incorrect signatures, etc.

### Solution

Follow the [instructions in the link above](Debugging-StaticAnalysis-Errors.md) to investigate the .csv files in the build artifacts.

You have several options to address these issues:

1. **Unintentional changes**: If your changes in the listed files were unintentional, simply roll them back.

2. **Improvable changes**: If the changes can be improved without affecting functionality (e.g., incorrect signature that can be adjusted to meet requirements), fix the issues.

3. **Expected changes**: If the messages in the csv files describe expected changes, add them to the [exclusions](Debugging-StaticAnalysis-Errors.md#breaking-changes).

### Example

One common reason for failures is BreakingChangesIssues.

If the collected Breaking Changes issues are expected (e.g., a cmdlet was intentionally changed), you'll need to update the exclusions file [as described here](Debugging-StaticAnalysis-Errors.md#breaking-changes) to bypass the CI build.

## Test Failures

### Error Message

> **Test failures occurred, check the files in artifacts/Test**

### Common Causes

One or more tests have failed during the build process.

### Solution

Review the test reports in the artifacts/Test directory and fix any failures related to your changes.

If you encounter additional failures not related to your changes, please contact the team that owns those tests. A common approach is to identify the person who last edited the cmdlet or test. Networking tests are also marked with headers like `[Trait(Category.Owner, Category.TeamAlias)]` to help identify the responsible team.

## Test Failures (Missing .psd1 Files from Other Modules)

### Error Message

> Exception:System.IO.FileNotFoundException: The specified module 'D:\a\1\s\artifacts\Debug\Az.Network\Az.Network.psd1' was not loaded because no valid module file was found in any module directory.

### Common Causes

This error occurs when your test cases use cmdlets from other modules, but those modules were not built by the CI process.

### Solution

Add the missing module's .csproj file to your module's .sln file. For example, here's how `Compute.sln` references `Network.csproj`:
https://github.com/Azure/azure-powershell/blob/58ded2ba3e0a5f7da0d1ffed9e0adb986986ab6f/src/Compute/Compute.sln#L11

