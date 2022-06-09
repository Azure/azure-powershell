<#
    .SYNOPSIS
        Tools for Measure-MarkdownOrScript.ps1.
    .NOTES
        File Name:  utils.ps1
        Class:  Scale
                Missing
                DeletePromptAndSeparateOutput
        Functions:  Get-ExamplesDetailsFromMd
                    Measure-ScriptFile
                    Add-ContentToHeadOfRule
                    Get-ScriptAnalyzerResult
                    Measure-SectionMissingAndOutputScript
#>

$SYNOPSIS_HEADING = "## SYNOPSIS"
$SYNTAX_HEADING = "## SYNTAX"
$DESCRIPTION_HEADING = "## DESCRIPTION"
$EXAMPLES_HEADING = "## EXAMPLES"
$PARAMETERS_HEADING = "## PARAMETERS"
$SINGLE_EXAMPLE_HEADING_REGEX = "\n###\s*"
$SINGLE_EXAMPLE_TITLE_HEADING_REGEX = "$SINGLE_EXAMPLE_HEADING_REGEX.+"
$CODE_BLOCK_REGEX = "``````(powershell)?\s*\n(.*\n)+?\s*``````"
$OUTPUT_BLOCK_REGEX = "``````output\s*\n(.*\n)+?\s*``````"

class Scale {
    [string]$Module
    [string]$Cmdlet
    [int]$Examples
}

class Missing {
    [string]$Module
    [string]$Cmdlet
    [int]$MissingSynopsis
    [int]$MissingDescription
    [int]$MissingExampleTitle
    [int]$MissingExampleCode
    [int]$MissingExampleOutput
    [int]$MissingExampleDescription
}

class DeletePromptAndSeparateOutput {
    [string]$Module
    [string]$Cmdlet
    [int]$NeedDeleting
    [int]$NeedSplitting
}

class AnalysisOutput{
    [string]$Module
    [string]$Cmdlet
    [int]$Example
    [string]$RuleName
    [int]$ProblemID
    [int]$Severity
    [string]$Description
    [string]$Extent
    [String]$Remediation
} 

<#
    .SYNOPSIS
    Get examples details from ".md".
    .DESCRIPTION
    Splits title, code, output, description according to regular expression.
#>
function Get-ExamplesDetailsFromMd {
    param (
        [string]$MarkdownPath
    )

    $fileContent = Get-Content $MarkdownPath -Raw
    $indexOfExamples = $fileContent.IndexOf($EXAMPLES_HEADING)
    $indexOfParameters = $fileContent.IndexOf($PARAMETERS_HEADING)

    $exampleNumber = 0
    $examplesProperties = @()
    $examplesContent = $fileContent.Substring($indexOfExamples, $indexOfParameters - $indexOfExamples)
    $examplesTitles = ($examplesContent | Select-String -Pattern $SINGLE_EXAMPLE_TITLE_HEADING_REGEX -AllMatches).Matches
    # Skip the 1st because it is $EXAMPLES_HEADING. Extract content without title.
    $examplesContentWithoutTitle = $examplesContent -split $SINGLE_EXAMPLE_TITLE_HEADING_REGEX | Select-Object -Skip 1


    foreach ($exampleContent in $examplesContentWithoutTitle) {
        $exampleTitle = ($examplesTitles[$exampleNumber].Value -split $SINGLE_EXAMPLE_HEADING_REGEX)[1].Trim()
        $exampleNumber++
        $exampleCodes = @()
        $exampleOutputs = @()
        $exampleDescriptions = @()

        $exampleCodeBlocks = ($exampleContent | Select-String -Pattern $CODE_BLOCK_REGEX -AllMatches).Matches
        $exampleOutputBlocks = ($exampleContent | Select-String -Pattern $OUTPUT_BLOCK_REGEX -AllMatches).Matches
        if ($exampleCodeBlocks.Count -eq 0) {
            $description = $exampleContent.Trim()
            if ($description -ne "") {
                $exampleDescriptions += $description
            }
        }
        else {
            # From the start to the start of the first codeblock is example description.
            $description = $exampleContent.SubString(0, $exampleCodeBlocks[0].Index).Trim()
            if ($description -ne "") {
                $exampleDescriptions += $description
            }

            # if there is no ```output``` split codelines and outputlines
            if ($exampleOutputBlocks.Count -eq 0) {
                foreach ($exampleCodeBlock in $exampleCodeBlocks) {
                    $codeRegex = "\n(([A-Za-z \t])*(PS|[A-Za-z]:)(\w|[\\/\[\].\- ])*(>|&gt;)+( PS)*)*[ \t]*((([A-Za-z]\w+-[A-Za-z]\w+\b(.ps1)?(?!(-|   +\w)))|(" +
                    "(@?\((?>\((?<pair>)|[^\(\)]+|\)(?<-pair>))*(?(pair)(?!))\) *[|.-] *\w)|" +
                    "(\[(?>\[(?<pair>)|[^\[\]]+|\](?<-pair>))*(?(pair)(?!))\]\$)|" +
                    "(@{(?>{(?<pair>)|[^{}]+|}(?<-pair>))*(?(pair)(?!))})|" +
                    "('(?>'(?<pair>)|[^']+|'(?<-pair>))*(?(pair)(?!))' *[|.-] *\w)|" +
                    "((?<!``)`"(?>(?<!``)`"(?<pair>)|[\s\S]|(?<!``)`"(?<-pair>))*(?(pair)(?!))(?<!``)`" *[|.-] *\w)|" +
                    "\$))(?!\.)([\w-~``'`"$= \t:;<>@()\[\]{},.+*/|\\&!?%#]*[``|][ \t]*(\n|\r\n)?)*([\w-~``'`"$= \t:;<>@()\[\]{},.+*/|\\&!?%#]*(?=\n|\r\n|#)))"
                    $exampleCodeLines = ($exampleCodeBlock.Value | Select-String -Pattern $codeRegex -CaseSensitive -AllMatches).Matches
                    if ($exampleCodeLines.Count -eq 0) {
                        $exampleCodes = @()
                        $exampleOutputs = @()
                    }
                    else {
                        for ($i = 0; $i -lt $exampleCodeLines.Count; $i++) {
                            # If a codeline contains " :", it's not a codeline but an output line of "Format-List".
                            if ($exampleCodeLines[$i].Value -notmatch " : *\w") {
                                # If a codeline ends with "`", "\r", or "\n", it should end at the last "`". 
                                $lastCharacter = $exampleCodeLines[$i].Value.Substring($exampleCodeLines[$i].Value.Length - 1, 1)
                                if ($lastCharacter -eq "``" -or $lastCharacter -eq "`r" -or $lastCharacter -eq "`n") {
                                    $exampleCodes += $exampleCodeLines[$i].Value.Substring(0, $exampleCodeLines[$i].Value.LastIndexOf("``")).Trim()
                                }
                                else {
                                    $exampleCodes += $exampleCodeLines[$i].Value.Trim()
                                }

                                # Content before the first codeline, between codelines, and after the last codeline is output.
                                if ($i -eq 0) {
                                    $startIndex = $exampleCodeBlock.Value.IndexOf("`n")
                                    $output = $exampleCodeBlock.Value.Substring($startIndex, $exampleCodeLines[$i].Index - $startIndex).Trim()
                                    if ($output -ne "") {
                                        $exampleOutputs += $output
                                    }
                                }
                                $startIndex = $exampleCodeLines[$i].Index + $exampleCodeLines[$i].Length
                                if ($i -lt $exampleCodeLines.Count - 1) {
                                    $nextStartIndex = $exampleCodeLines[$i + 1].Index
                                }
                                else {
                                    $nextStartIndex = $exampleCodeBlock.Value.LastIndexOf("`n")
                                }
                                 # If an output line starts with "-", it's an incomplete codeline, but it should still be added to output.
                                $output = $exampleCodeBlock.Value.Substring($startIndex, $nextStartIndex - $startIndex).Trim()
                                if ($output -match "^-+\w") {
                                    $exampleOutputs += $output
                                }
                                elseif ($output -ne "") {
                                    $exampleOutputs += $output
                                }
                            }
                        }
                    }
                }
            }
            # if there is ```output```
            else {
                # extract code from the first "\n" to the last "\n"
                foreach ($exampleCodeBlock in $exampleCodeBlocks) {
                    $code = $exampleCodeBlock.Value.Substring($exampleCodeBlock.Value.IndexOf("`n"), $exampleCodeBlock.Value.LastIndexOf("`n") - $exampleCodeBlock.Value.IndexOf("`n")).Trim()
                    if ($code -ne "") {
                        $exampleCodes += $code
                    }
                }
                # extract output from the first "\n" to the last "\n"
                foreach ($exampleOutputBlock in $exampleOutputBlocks) {
                    $output = $exampleOutputBlock.Value.Substring($exampleOutputBlock.Value.IndexOf("`n"), $exampleOutputBlock.Value.LastIndexOf("`n") - $exampleOutputBlock.Value.IndexOf("`n")).Trim()
                    if ($output -ne "") {
                        $exampleOutputs += $output
                    }
                }
            }

            # From the end of the last codeblock to the end is example description. 
            $description = $exampleContent.SubString($exampleCodeBlocks[-1].Index + $exampleCodeBlocks[-1].Length).Trim()
            if ($description -ne "") {
                $exampleDescriptions += $description
            }
        }

        $examplesProperties += [PSCustomObject]@{
            Num = $exampleNumber
            Title = $exampleTitle
            Codes = $exampleCodes
            CodeBlocks = $exampleCodeBlocks
            Outputs = $exampleOutputs
            OutputBlocks = $exampleOutputBlocks
            Description = ([string]$exampleDescriptions).Trim()
        }
    }

    return $examplesProperties
}

<#
    .SYNOPSIS
    Tests whether the script is integral, outputs examples in ".md" to ".ps1" 
    and records the Scale, Missing,  DeletePromptAndSeparateOutput class.
#>
function Measure-SectionMissingAndOutputScript {
    param (
        [string]$Module,
        [string]$Cmdlet,
        [string]$MarkdownPath,
        [switch]$OutputScriptsInFile,
        [string]$OutputFolder
    )
    $results = @()

    $fileContent = Get-Content $MarkdownPath -Raw

    $indexOfSynopsis = $fileContent.IndexOf($SYNOPSIS_HEADING)
    $indexOfSyntax = $fileContent.IndexOf($SYNTAX_HEADING)
    $indexOfDescription = $fileContent.IndexOf($DESCRIPTION_HEADING)
    $indexOfExamples = $fileContent.IndexOf($EXAMPLES_HEADING)

    $exampleNumber = 0
    $missingSynopsis = 0
    $missingDescription = 0
    $missingExampleTitle = 0
    $missingExampleCode = 0
    $missingExampleOutput = 0
    $missingExampleDescription = 0
    $needDeleting = 0
    $needSplitting = 0

    # If Synopsis section exists
    if ($indexOfSynopsis -ne -1) {
        $synopsisContent = $fileContent.Substring($indexOfSynopsis + $SYNOPSIS_HEADING.Length, $indexOfSyntax - ($indexOfSynopsis + $SYNOPSIS_HEADING.Length))
        if ($synopsisContent.Trim() -eq "") {
            $missingSynopsis = 1
        }
        else {
            $missingSynopsis = ($synopsisContent | Select-String -Pattern "{{[A-Za-z ]*}}").Count
        }
    }
    else {
        $missingSynopsis = 1
    }
    if($missingSynopsis -ne 0){
        $result = [AnalysisOutput]@{
            Module = $Module
            Cmdlet = $Cmdlet
            Example = ""
            Description = "Synopsis is missing."
            RuleName = "MissingSynopsis"
            Severity = 1
            Extent = "$Module\help\$Cmdlet.md"
            ProblemID = 3040
            Remediation = "Add Synopsis. Remove any placeholders."
        }
        $results += $result
    }

    # If Description section exists
    if ($indexOfDescription -ne -1) {
        $descriptionContent = $fileContent.Substring($indexOfDescription + $DESCRIPTION_HEADING.Length, $indexOfExamples - ($indexOfDescription + $DESCRIPTION_HEADING.Length))
        if ($descriptionContent.Trim() -eq "") {
            $missingDescription = 1
        }
        else {
            $missingDescription = ($descriptionContent | Select-String -Pattern "{{[A-Za-z ]*}}").Count
        }
    }
    else {
        $missingDescription = 1
    }
    if($missingDescription -ne 0){
        $result = [AnalysisOutput]@{
            Module = $Module
            Cmdlet = $Cmdlet
            Example = ""
            Description = "Description is missing."
            RuleName = "MissingDescription"
            Severity = 1
            Extent = "$Module\help\$Cmdlet.md"
            ProblemID = 3041
            Remediation = "Add Description. Remove any placeholders."
        }
        $results += $result
    }

    $examplesDetails = Get-ExamplesDetailsFromMd $MarkdownPath
    # If no examples
    if ($examplesDetails.Count -eq 0) {
        $missingExampleTitle++
        $missingExampleCode++
        $missingExampleOutput++
        $missingExampleDescription++
        $result = [AnalysisOutput]@{
            Module = $Module
            Cmdlet = $Cmdlet
            Example = ""
            Description = "Example is missing."
            RuleName = "MissingExample"
            Severity = 1
            Extent = "$Module\help\$Cmdlet.md"
            ProblemID = 3042
            Remediation = "Add Example. Remove any placeholders."
        }
        $results += $result
    }
    else {
        foreach ($exampleDetails in $examplesDetails) {
            $exampleNumber++

            switch ($exampleDetails) {
                {$exampleDetails.Title -eq ""} {
                    $missingExampleTitle++
                    $result = [AnalysisOutput]@{
                        Module = $Module
                        Cmdlet = $Cmdlet
                        Example = $exampleDetails.Num
                        Description = "Title of the example is missing."
                        RuleName = "MissingExampleTitle"
                        Severity = 1
                        Extent = "$Module\help\$Cmdlet.md"
                        ProblemID = 3043
                        Remediation = "Add title for the example. Remove any placeholders."
                    }
                    $results += $result
                }
                {$exampleDetails.Codes.Count -eq 0} {
                    $missingExampleCode++
                    $result = [AnalysisOutput]@{
                        Module = $Module
                        Cmdlet = $Cmdlet
                        Example = $exampleDetails.Num
                        Description = "Code of the example is missing."
                        RuleName = "MissingExampleCode"
                        Severity = 1
                        Extent = "$Module\help\$Cmdlet.md"
                        ProblemID = 3044
                        Remediation = "Add code for the example. Remove any placeholders."
                    }
                    $results += $result
                }
                {$exampleDetails.OutputBlocks.Count -ne 0 -and $exampleDetails.Outputs.Count -eq 0} {
                    $missingExampleOutput++
                    $result = [AnalysisOutput]@{
                        Module = $Module
                        Cmdlet = $Cmdlet
                        Example = $exampleDetails.Num
                        Description = "Output of the example is missing."
                        RuleName = "MissingExampleOutput"
                        Severity = 1
                        Extent = "$Module\help\$Cmdlet.md"
                        ProblemID = 3045
                        Remediation = "Add output for the example. Remove any placeholders."
                    }
                    $results += $result
                }
                {$exampleDetails.OutputBlocks.Count -eq 0 -and $exampleDetails.Outputs.Count -ne 0} {
                    $needSplitting++
                    $result = [AnalysisOutput]@{
                        Module = $Module
                        Cmdlet = $Cmdlet
                        Example = $exampleDetails.Num
                        Description = "The output need to be split from example."
                        RuleName = "NeedSplitting"
                        Severity = 1
                        Extent = "$Module\help\$Cmdlet.md"
                        ProblemID = 3051
                        Remediation = "Split output from example."
                    }
                    $results += $result
                }
                {$exampleDetails.Description -eq ""} {
                    $missingExampleDescription++
                    $result = [AnalysisOutput]@{
                        Module = $Module
                        Cmdlet = $Cmdlet
                        Example = $exampleDetails.Num
                        Description = "Description of the example is missing."
                        RuleName = "MissingExampleDescription"
                        Severity = 1
                        Extent = "$Module\help\$Cmdlet.md"
                        ProblemID = 3046
                        Remediation = "Add description for the example. Remove any placeholders."
                    }
                    $results += $result
                }
            }
            $needDeleting = ($examplesDetails.CodeBlocks | Select-String -Pattern "\n([A-Za-z \t\\:>])*(PS|[A-Za-z]:)(\w|[\\/\[\].\- ])*(>|&gt;)+( PS)*[ \t]*" -CaseSensitive).Count +
                ($examplesDetails.CodeBlocks | Select-String -Pattern "(?<=[A-Za-z]\w+-[A-Za-z]\w+)\.ps1" -CaseSensitive).Count
            
            if($needDeleting -ne 0){
                $result = [AnalysisOutput]@{
                    Module = $Module
                    Cmdlet = $Cmdlet
                    Example = $exampleDetails.Num
                    Description = "The prompt of example need to be deleted."
                    RuleName = "NeedDeleting"
                    Severity = 1
                    Extent = "$Module\help\$Cmdlet.md"
                    ProblemID = 3051
                    Remediation = "Delete the prompt of example."
                }
                $results += $result
            }

            # Delete prompts
            $exampleCodes = $exampleDetails.Codes
            for ($i = $exampleCodes.Count - 1; $i -ge 0; $i--) {
                $newCode = $exampleDetails.Codes[$i] -replace "([A-Za-z \t\\:>])*(PS|[A-Za-z]:)(\w|[\\/\[\].\- ])*(>|&gt;)+( PS)*[ \t]*", ""
                $newCode = $newCode -replace "(?<=[A-Za-z]\w+-[A-Za-z]\w+)\.ps1", ""
                $exampleCodes[$i] = $newCode
            }
            
            # Output codes by example
            if ($OutputScriptsInFile.IsPresent) {
                $cmdletExamplesScriptPath = "$OutputFolder\TempScript.ps1"
                $functionHead = "function $Module-$Cmdlet-$exampleNumber{"
                Add-Content -Path (Get-Item $cmdletExamplesScriptPath).FullName -Value $functionHead
                $exampleCodes = $exampleCodes -join "`n"
                Add-Content -Path (Get-Item $cmdletExamplesScriptPath).FullName -Value $exampleCodes
                $functionTail = "}`n"
                Add-Content -Path (Get-Item $cmdletExamplesScriptPath).FullName -Value $functionTail
            }
        }
    }

    # ScaleTable
    $examples = $examplesDetails.Count
    $scale = [Scale]@{
        Module = $module
        Cmdlet = $cmdlet
        Examples = $examples
    }

    # MissingTable
    $missingExampleTitle += ($examplesDetails.Title | Select-String -Pattern "{{[A-Za-z ]*}}").Count
    $missingExampleCode += ($examplesDetails.Codes | Select-String -Pattern "{{[A-Za-z ]*}}").Count
    $missingExampleOutput += ($examplesDetails.Outputs | Select-String -Pattern "{{[A-Za-z ]*}}").Count
    $missingExampleDescription += ($examplesDetails.Description | Select-String -Pattern "{{[A-Za-z ]*}}").Count

    if ($missingSynopsis -ne 0 -or $missingDescription -ne 0 -or $missingExampleTitle -ne 0 -or $missingExampleCode -ne 0 -or $missingExampleOutput -ne 0 -or $missingExampleDescription -ne 0) {
        $missing = [Missing]@{
            Module = $module
            Cmdlet = $cmdlet
            MissingSynopsis = $missingSynopsis
            MissingDescription = $missingDescription
            MissingExampleTitle = $missingExampleTitle
            MissingExampleCode = $missingExampleCode
            MissingExampleOutput = $missingExampleOutput
            MissingExampleDescription = $missingExampleDescription
        }
    }

    # DeletePromptAndSeparateOutputTable
    if ($needDeleting -ne 0 -or $needSplitting -ne 0) {
        $deletePromptAndSeparateOutput = [DeletePromptAndSeparateOutput]@{
            Module = $module
            Cmdlet = $cmdlet
            NeedDeleting = $needDeleting
            NeedSplitting = $needSplitting
        }
    }

    return @{
        Scale = $scale
        Missing = $missing
        DeletePromptAndSeparateOutput = $deletePromptAndSeparateOutput
        Errors = $results
    }
}

<#
    .SYNOPSIS
    Invoke PSScriptAnalyzer with custom rules, return the error set.
#>
function Get-ScriptAnalyzerResult {
    param (
        [string]$ScriptPath,
        [Parameter(Mandatory, HelpMessage = "PSScriptAnalyzer custom rules path. Supports wildcard.")]
        [string[]]$RulePath,
        [switch]$IncludeDefaultRules
    )

    # Validate script file exists.
    if (!(Test-Path $ScriptPath -PathType Leaf)) {
        throw "Cannot find cached script file '$ScriptPath'."
    }
    
    # Invoke PSScriptAnalyzer : input scriptblock, output error set in $result with property: RuleName, Message, Extent
    if ($RulePath -eq $null) {
        $analysisResults = Invoke-ScriptAnalyzer -Path $ScriptPath -IncludeDefaultRules:$IncludeDefaultRules.IsPresent
    }
    else {
        $analysisResults = Invoke-ScriptAnalyzer -Path $ScriptPath -CustomRulePath $RulePath -IncludeDefaultRules:$IncludeDefaultRules.IsPresent
    }
    $results = @()
    foreach($analysisResult in $analysisResults){
        if($analysisResult.Severity -eq "Error"){
            $Severity = 1
        }
        elseif($analysisResult.Severity -eq "Warning"){
            $Severity = 2
        }
        $result = [AnalysisOutput]@{
            Module = ($analysisResult.Message -split "-")[0]
            Cmdlet = ($analysisResult.Message -split "-")[1] + "-" + ($analysisResult.Message -split "-")[2]
            Example = ($analysisResult.Message -split "-")[3]
            RuleName = $analysisResult.RuleName
            Description = ($analysisResult.Message -split "@")[1] -replace "`"","`'"
            Severity = $Severity
            Extent = $analysisResult.Extent -replace "`"","`'"
            ProblemID = $analysisResult.RuleSuppressionID
            Remediation = ($analysisResult.Message -split "@")[2] -replace "`"","`'"
        }
        $results += $result
    }

    return $results
}