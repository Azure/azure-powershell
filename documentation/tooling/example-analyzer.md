## Example Analysis

### What is the purpose of example analysis?
As we know, our cmdlet help markdown is handwritten, which is an error-prone process. Example analysis is one of steps of static analysis, which checks the syntax correctness and completeness of cmdlet help markdown, especially for code blocks in example sections. 

### What will be checked by example analyzer?
Example analyzer will check 
- if there are any missing section heading, like '## EXAMPLES', '## PARAMETERS' and so on.
- if code block type is defined clearly like ```powershell
- if code block is separated into two parts: ```powershell and ```output
- if customized rules are violated. Customized rules include
   - Invalid_Cmdlet
   - Is_Alias
   - Capitalization_Conventions_Violated
   - Unknown_Parameter_Set
   - Invalid_Parameter_Name
   - Duplicate_Parameter_Name
   - Unassigned_Parameter
   - Unassigned_Variable
   - Unbinded_Expression
   - Mismatched_Parameter_Value_Type

### What will be ignore by example analyzer?
 - If the example begins with `<!-- Aladdin Generated Example -->` or matches with regex `<!-- Skip.*-->`, its scan will be skipped.

### How to run example analyzer locally to debug issues reported in CIs
Run following script in PowerShell console, which requires PSScriptAnalyzer installed on local
```powershell
tools/StaticAnalysis/ExampleAnalyzer/Measure-MarkdownOrScript.ps1 -MarkdownPaths {your-help-folder} -RulePaths tools/StaticAnalysis/ExampleAnalyzer/AnalyzeRules/*.psm1
```

### TroubleShooting
 - If a cmdlet is recognized as Invalid_Cmdlet, most likely its module is not imported correctly. Check its import process and configuration. If it's correct, it may be caused by parallel importing all psd1 files. Currently, the workaround is suppressing false positive. Maybe only importing changed modules are one of potential solutions. 

### Miscellaneous
 - Storage module has not been separated into ```powershell and ```output as their examples contain many outputs. They skips scan by regex `<!-- Skip.*-->` at the beginning of code block.
