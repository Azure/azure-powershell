if ($PSVersionTable.PSVersion.Major -le 2) {
    function Exit-CoverageAnalysis { }
    function Get-CoverageReport { }
    function Write-CoverageReport { }
    function Enter-CoverageAnalysis {
        param ( $CodeCoverage )

        if ($CodeCoverage) {
            & $SafeCommands['Write-Error'] 'Code coverage analysis requires PowerShell 3.0 or later.'
        }
    }

    return
}

function Enter-CoverageAnalysis {
    [CmdletBinding()]
    param (
        [object[]] $CodeCoverage,
        [object] $PesterState
    )

    $coverageInfo =
    foreach ($object in $CodeCoverage) {
        Get-CoverageInfoFromUserInput -InputObject $object
    }

    $PesterState.CommandCoverage = @(Get-CoverageBreakpoints -CoverageInfo $coverageInfo)
}

function Exit-CoverageAnalysis {
    param ([object] $PesterState)

    & $SafeCommands['Set-StrictMode'] -Off

    # PSScriptAnalyzer it will flag this line because $null is on the LHS of -ne.
    # BUT that is correct in this case. We are filtering the list of breakpoints
    # to only get those that are not $null
    # (like if we did $breakpoints | where {$_ -ne $null})
    # so DON'T change this.
    $breakpoints = @($PesterState.CommandCoverage.Breakpoint) -ne $null
    if ($breakpoints.Count -gt 0) {
        & $SafeCommands['Remove-PSBreakpoint'] -Breakpoint $breakpoints
    }
}

function Get-CoverageInfoFromUserInput {
    param (
        [Parameter(Mandatory = $true)]
        [object]
        $InputObject
    )

    if ($InputObject -is [System.Collections.IDictionary]) {
        $unresolvedCoverageInfo = Get-CoverageInfoFromDictionary -Dictionary $InputObject
    }
    else {
        $Path = $InputObject -as [string]

        # Auto-detect IncludeTests-value from path-input
        $IncludeTests = $Path -match '\.tests\.ps1$'

        $unresolvedCoverageInfo = New-CoverageInfo -Path $Path -IncludeTests $IncludeTests
    }

    Resolve-CoverageInfo -UnresolvedCoverageInfo $unresolvedCoverageInfo
}

function New-CoverageInfo {
    param ([string] $Path, [string] $Class = $null, [string] $Function = $null, [int] $StartLine = 0, [int] $EndLine = 0, [bool] $IncludeTests = $false)

    return [pscustomobject]@{
        Path         = $Path
        Class        = $Class
        Function     = $Function
        StartLine    = $StartLine
        EndLine      = $EndLine
        IncludeTests = $IncludeTests
    }
}

function Get-CoverageInfoFromDictionary {
    param ([System.Collections.IDictionary] $Dictionary)

    [string] $path = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'Path', 'p'
    if ([string]::IsNullOrEmpty($path)) {
        throw "Coverage value '$Dictionary' is missing required Path key."
    }

    $startLine = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'StartLine', 'Start', 's'
    $endLine = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'EndLine', 'End', 'e'
    [string] $class = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'Class', 'c'
    [string] $function = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'Function', 'f'
    $includeTests = Get-DictionaryValueFromFirstKeyFound -Dictionary $Dictionary -Key 'IncludeTests'

    $startLine = Convert-UnknownValueToInt -Value $startLine -DefaultValue 0
    $endLine = Convert-UnknownValueToInt -Value $endLine -DefaultValue 0
    [bool] $includeTests = Convert-UnknownValueToInt -Value $includeTests -DefaultValue 0

    return New-CoverageInfo -Path $path -StartLine $startLine -EndLine $endLine -Class $class -Function $function -IncludeTests $includeTests
}

function Convert-UnknownValueToInt {
    param ([object] $Value, [int] $DefaultValue = 0)

    try {
        return [int] $Value
    }
    catch {
        return $DefaultValue
    }
}

function Resolve-CoverageInfo {
    param ([psobject] $UnresolvedCoverageInfo)

    $path = $UnresolvedCoverageInfo.Path

    $testsPattern = '\.tests\.ps1$'
    $includeTests = $UnresolvedCoverageInfo.IncludeTests

    try {
        $resolvedPaths = & $SafeCommands['Resolve-Path'] -Path $path -ErrorAction Stop |
            & $SafeCommands['Where-Object'] { $includeTests -or $_.Path -notmatch $testsPattern }
    }
    catch {
        & $SafeCommands['Write-Error'] "Could not resolve coverage path '$path': $($_.Exception.Message)"
        return
    }

    $filePaths =
    foreach ($resolvedPath in $resolvedPaths) {
        $item = & $SafeCommands['Get-Item'] -LiteralPath $resolvedPath
        if ($item -is [System.IO.FileInfo] -and ('.ps1', '.psm1') -contains $item.Extension) {
            $item.FullName
        }
        elseif (-not $item.PsIsContainer) {
            & $SafeCommands['Write-Warning'] "CodeCoverage path '$path' resolved to a non-PowerShell file '$($item.FullName)'; this path will not be part of the coverage report."
        }
    }

    $params = @{
        StartLine = $UnresolvedCoverageInfo.StartLine
        EndLine   = $UnresolvedCoverageInfo.EndLine
        Class     = $UnresolvedCoverageInfo.Class
        Function  = $UnresolvedCoverageInfo.Function
    }

    foreach ($filePath in $filePaths) {
        $params['Path'] = $filePath
        New-CoverageInfo @params
    }
}

function Get-CoverageBreakpoints {
    [CmdletBinding()]
    param (
        [object[]] $CoverageInfo
    )

    $fileGroups = @($CoverageInfo | & $SafeCommands['Group-Object'] -Property Path)
    foreach ($fileGroup in $fileGroups) {
        & $SafeCommands['Write-Verbose'] "Initializing code coverage analysis for file '$($fileGroup.Name)'"
        $totalCommands = 0
        $analyzedCommands = 0

        :commandLoop
        foreach ($command in Get-CommandsInFile -Path $fileGroup.Name) {
            $totalCommands++

            foreach ($coverageInfoObject in $fileGroup.Group) {
                if (Test-CoverageOverlapsCommand -CoverageInfo $coverageInfoObject -Command $command) {
                    $analyzedCommands++
                    New-CoverageBreakpoint -Command $command
                    continue commandLoop
                }
            }
        }

        & $SafeCommands['Write-Verbose'] "Analyzing $analyzedCommands of $totalCommands commands in file '$($fileGroup.Name)' for code coverage"
    }
}

function Get-CommandsInFile {
    param ([string] $Path)

    $errors = $null
    $tokens = $null
    $ast = [System.Management.Automation.Language.Parser]::ParseFile($Path, [ref] $tokens, [ref] $errors)

    if ($PSVersionTable.PSVersion.Major -ge 5) {
        # In PowerShell 5.0, dynamic keywords for DSC configurations are represented by the DynamicKeywordStatementAst
        # class.  They still trigger breakpoints, but are not a child class of CommandBaseAst anymore.

        $predicate = {
            $args[0] -is [System.Management.Automation.Language.DynamicKeywordStatementAst] -or
            $args[0] -is [System.Management.Automation.Language.CommandBaseAst]
        }
    }
    else {
        $predicate = { $args[0] -is [System.Management.Automation.Language.CommandBaseAst] }
    }

    $searchNestedScriptBlocks = $true
    $ast.FindAll($predicate, $searchNestedScriptBlocks)
}

function Test-CoverageOverlapsCommand {
    param ([object] $CoverageInfo, [System.Management.Automation.Language.Ast] $Command)

    if ($CoverageInfo.Class -or $CoverageInfo.Function) {
        Test-CommandInScope -Command $Command -Class $CoverageInfo.Class -Function $CoverageInfo.Function
    }
    else {
        Test-CoverageOverlapsCommandByLineNumber @PSBoundParameters
    }

}

function Test-CommandInScope {
    param ([System.Management.Automation.Language.Ast] $Command, [string] $Class, [string] $Function)

    $classResult = !$Class
    $functionResult = !$Function
    for ($ast = $Command; $null -ne $ast; $ast = $ast.Parent) {
        if (!$classResult -and $PSVersionTable.PSVersion.Major -ge 5) {
            # Classes have been introduced in PowerShell 5.0
            $classAst = $ast -as [System.Management.Automation.Language.TypeDefinitionAst]
            if ($null -ne $classAst -and $classAst.Name -like $Class) {
                $classResult = $true
            }
        }
        if (!$functionResult) {
            $functionAst = $ast -as [System.Management.Automation.Language.FunctionDefinitionAst]
            if ($null -ne $functionAst -and $functionAst.Name -like $Function) {
                $functionResult = $true
            }
        }
        if ($classResult -and $functionResult) {
            return $true
        }
    }

    return $false
}

function Test-CoverageOverlapsCommandByLineNumber {
    param ([object] $CoverageInfo, [System.Management.Automation.Language.Ast] $Command)

    $commandStart = $Command.Extent.StartLineNumber
    $commandEnd = $Command.Extent.EndLineNumber
    $coverStart = $CoverageInfo.StartLine
    $coverEnd = $CoverageInfo.EndLine

    # An EndLine value of 0 means to cover the entire rest of the file from StartLine
    # (which may also be 0)
    if ($coverEnd -le 0) {
        $coverEnd = [int]::MaxValue
    }

    return (Test-RangeContainsValue -Value $commandStart -Min $coverStart -Max $coverEnd) -or
    (Test-RangeContainsValue -Value $commandEnd -Min $coverStart -Max $coverEnd)
}

function Test-RangeContainsValue {
    param ([int] $Value, [int] $Min, [int] $Max)
    return $Value -ge $Min -and $Value -le $Max
}

function New-CoverageBreakpoint {
    param ([System.Management.Automation.Language.Ast] $Command)

    if (IsIgnoredCommand -Command $Command) {
        return
    }

    $params = @{
        Script = $Command.Extent.File
        Line   = $Command.Extent.StartLineNumber
        Column = $Command.Extent.StartColumnNumber
        Action = { }
    }

    $breakpoint = & $SafeCommands['Set-PSBreakpoint'] @params

    [pscustomobject] @{
        File        = $Command.Extent.File
        Class       = Get-ParentClassName -Ast $Command
        Function    = Get-ParentFunctionName -Ast $Command
        StartLine   = $Command.Extent.StartLineNumber
        EndLine     = $Command.Extent.EndLineNumber
        StartColumn = $Command.Extent.StartColumnNumber
        EndColumn   = $Command.Extent.EndColumnNumber
        Command     = Get-CoverageCommandText -Ast $Command
        Breakpoint  = $breakpoint
    }
}

function IsIgnoredCommand {
    param ([System.Management.Automation.Language.Ast] $Command)

    if (-not $Command.Extent.File) {
        # This can happen if the script contains "configuration" or any similarly implemented
        # dynamic keyword.  PowerShell modifies the script code and reparses it in memory, leading
        # to AST elements with no File in their Extent.
        return $true
    }

    if ($PSVersionTable.PSVersion.Major -ge 4) {
        if ($Command.Extent.Text -eq 'Configuration') {
            # More DSC voodoo.  Calls to "configuration" generate breakpoints, but their HitCount
            # stays zero (even though they are executed.)  For now, ignore them, unless we can come
            # up with a better solution.
            return $true
        }

        if (IsChildOfHashtableDynamicKeyword -Command $Command) {
            # The lines inside DSC resource declarations don't trigger their breakpoints when executed,
            # just like the "configuration" keyword itself.  I don't know why, at this point, but just like
            # configuration, we'll ignore it so it doesn't clutter up the coverage analysis with useless junk.
            return $true
        }
    }

    if (IsClosingLoopCondition -Command $Command) {
        # For some reason, the closing expressions of do/while and do/until loops don't trigger their breakpoints.
        # To avoid useless clutter, we'll ignore those lines as well.
        return $true
    }

    return $false
}

function IsChildOfHashtableDynamicKeyword {
    param ([System.Management.Automation.Language.Ast] $Command)

    for ($ast = $Command.Parent; $null -ne $ast; $ast = $ast.Parent) {
        if ($PSVersionTable.PSVersion.Major -ge 5) {
            # The ast behaves differently for DSC resources with version 5+.  There's a new DynamicKeywordStatementAst class,
            # and they no longer are represented by CommandAst objects.

            if ($ast -is [System.Management.Automation.Language.DynamicKeywordStatementAst] -and
                $ast.CommandElements[-1] -is [System.Management.Automation.Language.HashtableAst]) {
                return $true
            }
        }
        else {
            if ($ast -is [System.Management.Automation.Language.CommandAst] -and
                $null -ne $ast.DefiningKeyword -and
                $ast.DefiningKeyword.BodyMode -eq [System.Management.Automation.Language.DynamicKeywordBodyMode]::Hashtable) {
                return $true
            }
        }
    }

    return $false
}

function IsClosingLoopCondition {
    param ([System.Management.Automation.Language.Ast] $Command)

    $ast = $Command

    while ($null -ne $ast.Parent) {
        if (($ast.Parent -is [System.Management.Automation.Language.DoWhileStatementAst] -or
                $ast.Parent -is [System.Management.Automation.Language.DoUntilStatementAst]) -and
            $ast.Parent.Condition -eq $ast) {
            return $true
        }

        $ast = $ast.Parent
    }

    return $false
}

function Get-ParentClassName {
    param ([System.Management.Automation.Language.Ast] $Ast)

    if ($PSVersionTable.PSVersion.Major -ge 5) {
        # Classes have been introduced in PowerShell 5.0

        $parent = $Ast.Parent

        while ($null -ne $parent -and $parent -isnot [System.Management.Automation.Language.TypeDefinitionAst]) {
            $parent = $parent.Parent
        }
    }

    if ($null -eq $parent) {
        return ''
    }
    else {
        return $parent.Name
    }
}

function Get-ParentFunctionName {
    param ([System.Management.Automation.Language.Ast] $Ast)

    $parent = $Ast.Parent

    while ($null -ne $parent -and $parent -isnot [System.Management.Automation.Language.FunctionDefinitionAst]) {
        $parent = $parent.Parent
    }

    if ($null -eq $parent) {
        return ''
    }
    else {
        return $parent.Name
    }
}

function Get-CoverageCommandText {
    param ([System.Management.Automation.Language.Ast] $Ast)

    $reportParentExtentTypes = @(
        [System.Management.Automation.Language.ReturnStatementAst]
        [System.Management.Automation.Language.ThrowStatementAst]
        [System.Management.Automation.Language.AssignmentStatementAst]
        [System.Management.Automation.Language.IfStatementAst]
    )

    $parent = Get-ParentNonPipelineAst -Ast $Ast

    if ($null -ne $parent) {
        if ($parent -is [System.Management.Automation.Language.HashtableAst]) {
            return Get-KeyValuePairText -HashtableAst $parent -ChildAst $Ast
        }
        elseif ($reportParentExtentTypes -contains $parent.GetType()) {
            return $parent.Extent.Text
        }
    }

    return $Ast.Extent.Text
}

function Get-ParentNonPipelineAst {
    param ([System.Management.Automation.Language.Ast] $Ast)

    $parent = $null
    if ($null -ne $Ast) {
        $parent = $Ast.Parent
    }

    while ($parent -is [System.Management.Automation.Language.PipelineAst]) {
        $parent = $parent.Parent
    }

    return $parent
}

function Get-KeyValuePairText {
    param (
        [System.Management.Automation.Language.HashtableAst] $HashtableAst,
        [System.Management.Automation.Language.Ast] $ChildAst
    )

    & $SafeCommands['Set-StrictMode'] -Off

    foreach ($keyValuePair in $HashtableAst.KeyValuePairs) {
        if ($keyValuePair.Item2.PipelineElements -contains $ChildAst) {
            return '{0} = {1}' -f $keyValuePair.Item1.Extent.Text, $keyValuePair.Item2.Extent.Text
        }
    }

    # This shouldn't happen, but just in case, default to the old output of just the expression.
    return $ChildAst.Extent.Text
}

function Get-CoverageMissedCommands {
    param ([object[]] $CommandCoverage)
    $CommandCoverage | & $SafeCommands['Where-Object'] { $_.Breakpoint.HitCount -eq 0 }
}

function Get-CoverageHitCommands {
    param ([object[]] $CommandCoverage)
    $CommandCoverage | & $SafeCommands['Where-Object'] { $_.Breakpoint.HitCount -gt 0 }
}

function Get-CoverageReport {
    param ([object] $PesterState)

    $properties = @(
        'File'
        @{ Name = 'Line'; Expression = { $_.StartLine } }
        'StartLine'
        'EndLine'
        'StartColumn'
        'EndColumn'
        'Class'
        'Function'
        'Command'
        @{ Name = 'HitCount'; Expression = { $_.Breakpoint.HitCount } }
    )
    $missedCommands = @(Get-CoverageMissedCommands -CommandCoverage $PesterState.CommandCoverage | & $SafeCommands['Select-Object'] $properties)
    $hitCommands = @(Get-CoverageHitCommands -CommandCoverage $PesterState.CommandCoverage | & $SafeCommands['Select-Object'] $properties)
    $analyzedFiles = @($PesterState.CommandCoverage | & $SafeCommands['Select-Object'] -ExpandProperty File -Unique)

    [pscustomobject] @{
        NumberOfCommandsAnalyzed = $PesterState.CommandCoverage.Count
        NumberOfFilesAnalyzed    = $analyzedFiles.Count
        NumberOfCommandsExecuted = $hitCommands.Count
        NumberOfCommandsMissed   = $missedCommands.Count
        MissedCommands           = $missedCommands
        HitCommands              = $hitCommands
        AnalyzedFiles            = $analyzedFiles
    }
}

function Get-CommonParentPath {
    param ([string[]] $Path)

    $pathsToTest = @(
        $Path |
            Normalize-Path |
            & $SafeCommands['Select-Object'] -Unique
    )

    if ($pathsToTest.Count -gt 0) {
        $parentPath = & $SafeCommands['Split-Path'] -Path $pathsToTest[0] -Parent

        while ($parentPath.Length -gt 0) {
            $nonMatches = $pathsToTest -notmatch "^$([regex]::Escape($parentPath))"

            if ($nonMatches.Count -eq 0) {
                return $parentPath
            }
            else {
                $parentPath = & $SafeCommands['Split-Path'] -Path $parentPath -Parent
            }
        }
    }

    return [string]::Empty
}

function Get-RelativePath {
    param ( [string] $Path, [string] $RelativeTo )
    return $Path -replace "^$([regex]::Escape("$RelativeTo$([System.IO.Path]::DirectorySeparatorChar)"))?"
}

function Normalize-Path {
    [CmdletBinding()]
    param (
        [Parameter(ValueFromPipeline = $true, ValueFromPipelineByPropertyName = $true)]
        [Alias('PSPath', 'FullName')]
        [string[]] $Path
    )

    # Split-Path and Join-Path will replace any AltDirectorySeparatorChar instances with the DirectorySeparatorChar
    # (Even if it's not the one that the split / join happens on.)  So splitting / rejoining a path will give us
    # consistent separators for later string comparison.

    process {
        if ($null -ne $Path) {
            foreach ($p in $Path) {
                $normalizedPath = & $SafeCommands['Split-Path'] $p -Leaf

                if ($normalizedPath -ne $p) {
                    $parent = & $SafeCommands['Split-Path'] $p -Parent
                    $normalizedPath = & $SafeCommands['Join-Path'] $parent $normalizedPath
                }

                $normalizedPath
            }
        }
    }
}

function Get-JaCoCoReportXml {
    param (
        [parameter(Mandatory = $true)]
        $PesterState,
        [parameter(Mandatory = $true)]
        [object] $CoverageReport
    )

    if ($null -eq $CoverageReport -or ($pester.Show -eq [Pester.OutputTypes]::None) -or $CoverageReport.NumberOfCommandsAnalyzed -eq 0) {
        return
    }

    $now = & $SafeCommands['Get-Date']
    $nineteenSeventy = & $SafeCommands['Get-Date'] -Date "01/01/1970"
    [long] $endTime = [math]::Floor((New-TimeSpan -start $nineteenSeventy -end $now).TotalMilliseconds)
    [long] $startTime = [math]::Floor($endTime - $PesterState.Time.TotalMilliseconds)

    $folderGroups = $PesterState.CommandCoverage | & $SafeCommands["Group-Object"] -Property {
        & $SafeCommands["Split-Path"] $_.File -Parent
    }

    $packageList = & $SafeCommands['New-Object'] System.Collections.Generic.List[psobject]

    $report = @{
        Instruction = @{ Missed = 0; Covered = 0 }
        Line        = @{ Missed = 0; Covered = 0 }
        Method      = @{ Missed = 0; Covered = 0 }
        Class       = @{ Missed = 0; Covered = 0 }
    }

    foreach ($folderGroup in $folderGroups) {

        $package = @{
            Name        = $folderGroup.Name
            Classes     = [ordered] @{ }
            Instruction = @{ Missed = 0; Covered = 0 }
            Line        = @{ Missed = 0; Covered = 0 }
            Method      = @{ Missed = 0; Covered = 0 }
            Class       = @{ Missed = 0; Covered = 0 }
        }

        foreach ($command in $folderGroup.Group) {
            $file = $command.File
            $function = $command.Function
            if (!$function) { $function = '<script>' }
            $line = $command.StartLine.ToString()

            $missed = if ($command.Breakpoint.HitCount) { 0 } else { 1 }
            $covered = if ($command.Breakpoint.HitCount) { 1 } else { 0 }

            if (!$package.Classes.Contains($file)) {
                $package.Class.Missed += $missed
                $package.Class.Covered += $covered
                $package.Classes.$file = @{
                    Methods     = [ordered] @{ }
                    Lines       = [ordered] @{ }
                    Instruction = @{ Missed = 0; Covered = 0 }
                    Line        = @{ Missed = 0; Covered = 0 }
                    Method      = @{ Missed = 0; Covered = 0 }
                    Class       = @{ Missed = $missed; Covered = $covered }
                }
            }

            if (!$package.Classes.$file.Methods.Contains($function)) {
                $package.Method.Missed += $missed
                $package.Method.Covered += $covered
                $package.Classes.$file.Method.Missed += $missed
                $package.Classes.$file.Method.Covered += $covered
                $package.Classes.$file.Methods.$function = @{
                    FirstLine   = $line
                    Instruction = @{ Missed = 0; Covered = 0 }
                    Line        = @{ Missed = 0; Covered = 0 }
                    Method      = @{ Missed = $missed; Covered = $covered }
                }
            }

            if (!$package.Classes.$file.Lines.Contains($line)) {
                $package.Line.Missed += $missed
                $package.Line.Covered += $covered
                $package.Classes.$file.Line.Missed += $missed
                $package.Classes.$file.Line.Covered += $covered
                $package.Classes.$file.Methods.$function.Line.Missed += $missed
                $package.Classes.$file.Methods.$function.Line.Covered += $covered
                $package.Classes.$file.Lines.$line = @{
                    Instruction = @{ Missed = 0; Covered = 0 }
                }
            }

            $package.Instruction.Missed += $missed
            $package.Instruction.Covered += $covered
            $package.Classes.$file.Instruction.Missed += $missed
            $package.Classes.$file.Instruction.Covered += $covered
            $package.Classes.$file.Methods.$function.Instruction.Missed += $missed
            $package.Classes.$file.Methods.$function.Instruction.Covered += $covered
            $package.Classes.$file.Lines.$line.Instruction.Missed += $missed
            $package.Classes.$file.Lines.$line.Instruction.Covered += $covered
        }

        $report.Class.Missed += $package.Class.Missed
        $report.Class.Covered += $package.Class.Covered
        $report.Method.Missed += $package.Method.Missed
        $report.Method.Covered += $package.Method.Covered
        $report.Line.Missed += $package.Line.Missed
        $report.Line.Covered += $package.Line.Covered
        $report.Instruction.Missed += $package.Instruction.Missed
        $report.Instruction.Covered += $package.Instruction.Covered

        $packageList.Add($package)
    }

    $commonParent = Get-CommonParentPath -Path $CoverageReport.AnalyzedFiles
    $commonParentLeaf = & $SafeCommands["Split-Path"] $commonParent -Leaf

    # the JaCoCo xml format without the doctype, as the XML stuff does not like DTD's.
    $jaCoCoReport = '<?xml version="1.0" encoding="UTF-8" standalone="no"?>'
    $jaCoCoReport += '<report name="">'
    $jaCoCoReport += '<sessioninfo id="this" start="" dump="" />'
    $jaCoCoReport += '</report>'

    [xml] $jaCoCoReportXml = $jaCoCoReport
    $reportElement = $jaCoCoReportXml.report
    $reportElement.name = "Pester ($now)"
    $reportElement.sessioninfo.start = $startTime.ToString()
    $reportElement.sessioninfo.dump = $endTime.ToString()

    foreach ($package in $packageList) {
        $packageRelativePath = Get-RelativePath -Path $package.Name -RelativeTo $commonParent

        if ($null -eq $packageRelativePath) {
            $packageName = $commonParentLeaf
        }
        else {
            $packageName = "{0}/{1}" -f $commonParentLeaf, $($packageRelativePath.Replace("\", "/"))
        }

        $packageElement = Add-XmlElement $reportElement "package" @{
            name = ($packageName -replace "/$", "")
        }

        foreach ($file in $package.Classes.Keys) {
            $class = $package.Classes.$file
            $classElementRelativePath = (Get-RelativePath -Path $file -RelativeTo $commonParent).Replace("\", "/")
            $classElementName = "{0}/{1}" -f $commonParentLeaf, $classElementRelativePath
            $classElementName = $classElementName.Substring(0, $($classElementName.LastIndexOf(".")))
            $classElement = Add-XmlElement $packageElement 'class' -Attributes ([ordered] @{
                    name           = $classElementName
                    sourcefilename = (& $SafeCommands["Split-Path"] -Path $classElementRelativePath -Leaf)
                })

            foreach ($function in $class.Methods.Keys) {
                $method = $class.Methods.$function
                $methodElement = Add-XmlElement $classElement 'method' -Attributes ([ordered] @{
                        name = $function
                        desc = '()'
                        line = $method.FirstLine
                    })
                Add-JaCoCoCounter Instruction $method $methodElement
                Add-JaCoCoCounter Line $method $methodElement
                Add-JaCoCoCounter Method $method $methodElement
            }

            Add-JaCoCoCounter Instruction $class $classElement
            Add-JaCoCoCounter Line $class $classElement
            Add-JaCoCoCounter Method $class $classElement
            Add-JaCoCoCounter Class $class $classElement
        }

        foreach ($file in $package.Classes.Keys) {
            $class = $package.Classes.$file
            $sourceFileElement = Add-XmlElement $packageElement 'sourcefile' -Attributes ([ordered] @{
                    name = (& $SafeCommands["Split-Path"] -Path $file -Leaf)
                })

            foreach ($line in $class.Lines.Keys) {
                $null = Add-XmlElement $sourceFileElement 'line' -Attributes ([ordered] @{
                        nr = $line
                        mi = $class.Lines.$line.Instruction.Missed
                        ci = $class.Lines.$line.Instruction.Covered
                        mb = 0
                        cb = 0
                    })
            }

            Add-JaCoCoCounter Instruction $class $sourceFileElement
            Add-JaCoCoCounter Line $class $sourceFileElement
            Add-JaCoCoCounter Method $class $sourceFileElement
            Add-JaCoCoCounter Class $class $sourceFileElement
        }

        Add-JaCoCoCounter Instruction $package $packageElement
        Add-JaCoCoCounter Line $package $packageElement
        Add-JaCoCoCounter Method $package $packageElement
        Add-JaCoCoCounter Class $package $packageElement
    }

    Add-JaCoCoCounter Instruction $report $reportElement
    Add-JaCoCoCounter Line $report $reportElement
    Add-JaCoCoCounter Method $report $reportElement
    Add-JaCoCoCounter Class $report $reportElement

    # There is no pretty way to insert the Doctype, as microsoft has deprecated the DTD stuff.
    $jaCoCoReportDocType = '<!DOCTYPE report PUBLIC "-//JACOCO//DTD Report 1.1//EN" "report.dtd">'
    return $jaCocoReportXml.OuterXml.Insert(54, $jaCoCoReportDocType)
}

function Add-XmlElement {
    param (
        [parameter(Mandatory = $true)] [System.Xml.XmlNode] $Parent,
        [parameter(Mandatory = $true)] [string] $Name,
        [System.Collections.IDictionary] $Attributes
    )
    $element = $Parent.AppendChild($Parent.OwnerDocument.CreateElement($Name))
    if ($Attributes) {
        foreach ($key in $Attributes.Keys) {
            $attribute = $element.Attributes.Append($Parent.OwnerDocument.CreateAttribute($key))
            $attribute.Value = $Attributes.$key
        }
    }
    return $element
}

function Add-JaCoCoCounter {
    param (
        [parameter(Mandatory = $true)] [ValidateSet('Instruction', 'Line', 'Method', 'Class')] [string] $Type,
        [parameter(Mandatory = $true)] [System.Collections.IDictionary] $Data,
        [parameter(Mandatory = $true)] [System.Xml.XmlNode] $Parent
    )
    if ($Data.$Type.Missed -isnot [int] -or $Data.$Type.Covered -isnot [int]) {
        throw 'Counter data expected'
    }
    $null = Add-XmlElement $Parent 'counter' -Attributes ([ordered] @{
            type    = $Type.ToUpperInvariant()
            missed  = $Data.$Type.Missed
            covered = $Data.$Type.Covered
        })
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUpCNEor6LW9yBnPm4twqcPLYh
# k5GggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
# AQsFADByMQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYD
# VQQLExB3d3cuZGlnaWNlcnQuY29tMTEwLwYDVQQDEyhEaWdpQ2VydCBTSEEyIEFz
# c3VyZWQgSUQgQ29kZSBTaWduaW5nIENBMB4XDTIwMDEzMTAwMDAwMFoXDTIxMDEw
# NTEyMDAwMFowSzELMAkGA1UEBhMCQ1oxDjAMBgNVBAcTBVByYWhhMRUwEwYDVQQK
# DAxKYWt1YiBKYXJlxaExFTATBgNVBAMMDEpha3ViIEphcmXFoTCCASIwDQYJKoZI
# hvcNAQEBBQADggEPADCCAQoCggEBALYF0cDtFUyYgraHpHdObGJM9dxjfRr0WaPN
# kVZcEHdPXk4bVCPZLSca3Byybx745CpB3oejDHEbohLSTrbunoSA9utpwxVQSutt
# /H1onVexiJgwGJ6xoQgR17FGLBGiIHgyPhFJhba9yENh0dqargLWllsg070WE2yb
# gz3m659gmfuCuSZOhQ2nCHvOjEocTiI67mZlHvN7axg+pCgdEJrtIyvhHPqXeE2j
# cdMrfmYY1lq2FBpELEW1imYlu5BnaJd/5IT7WjHL3LWx5Su9FkY5RwrA6+X78+j+
# vKv00JtDjM0dT+4A/m65jXSywxa4YoGDqQ5n+BwDMQlWCzfu37sCAwEAAaOCAcUw
# ggHBMB8GA1UdIwQYMBaAFFrEuXsqCqOl6nEDwGD5LfZldQ5YMB0GA1UdDgQWBBRE
# 05R/U5mVzc4vKq4rvKyyPm12EzAOBgNVHQ8BAf8EBAMCB4AwEwYDVR0lBAwwCgYI
# KwYBBQUHAwMwdwYDVR0fBHAwbjA1oDOgMYYvaHR0cDovL2NybDMuZGlnaWNlcnQu
# Y29tL3NoYTItYXNzdXJlZC1jcy1nMS5jcmwwNaAzoDGGL2h0dHA6Ly9jcmw0LmRp
# Z2ljZXJ0LmNvbS9zaGEyLWFzc3VyZWQtY3MtZzEuY3JsMEwGA1UdIARFMEMwNwYJ
# YIZIAYb9bAMBMCowKAYIKwYBBQUHAgEWHGh0dHBzOi8vd3d3LmRpZ2ljZXJ0LmNv
# bS9DUFMwCAYGZ4EMAQQBMIGEBggrBgEFBQcBAQR4MHYwJAYIKwYBBQUHMAGGGGh0
# dHA6Ly9vY3NwLmRpZ2ljZXJ0LmNvbTBOBggrBgEFBQcwAoZCaHR0cDovL2NhY2Vy
# dHMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0U0hBMkFzc3VyZWRJRENvZGVTaWduaW5n
# Q0EuY3J0MAwGA1UdEwEB/wQCMAAwDQYJKoZIhvcNAQELBQADggEBADAk7PRuDcdl
# lPZQSfZ1Y0jeItmEWPMNcAL0LQaa6M5Slrznjxv1ZiseT9SMWTxOQylfPvpOSo1x
# xV3kD7qf7tf2EuicKkV6dBgGiHb0riWZ3+wMA6C8IK3cGesJ4jgpTtYEzbh88pxT
# g2MSzpRnwyXHhrgcKSps1z34JmmmHP1lncxNC6DTM6yEUwE7XiDD2xNoeLITgdTQ
# jjMMT6nDJe8+xL0Zyh32OPIyrG7qPjG6MmEjzlCaWsE/trVo7I9CSOjwpp8721Hj
# q/tIHzPFg1C3dYmDh8Kbmr21dHWBLYQF4P8lq8u8AYDa6H7xvkx7G0i2jglAA4YK
# i1V8AlyTwRkwggUwMIIEGKADAgECAhAECRgbX9W7ZnVTQ7VvlVAIMA0GCSqGSIb3
# DQEBCwUAMGUxCzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAX
# BgNVBAsTEHd3dy5kaWdpY2VydC5jb20xJDAiBgNVBAMTG0RpZ2lDZXJ0IEFzc3Vy
# ZWQgSUQgUm9vdCBDQTAeFw0xMzEwMjIxMjAwMDBaFw0yODEwMjIxMjAwMDBaMHIx
# CzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3
# dy5kaWdpY2VydC5jb20xMTAvBgNVBAMTKERpZ2lDZXJ0IFNIQTIgQXNzdXJlZCBJ
# RCBDb2RlIFNpZ25pbmcgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB
# AQD407Mcfw4Rr2d3B9MLMUkZz9D7RZmxOttE9X/lqJ3bMtdx6nadBS63j/qSQ8Cl
# +YnUNxnXtqrwnIal2CWsDnkoOn7p0WfTxvspJ8fTeyOU5JEjlpB3gvmhhCNmElQz
# UHSxKCa7JGnCwlLyFGeKiUXULaGj6YgsIJWuHEqHCN8M9eJNYBi+qsSyrnAxZjNx
# PqxwoqvOf+l8y5Kh5TsxHM/q8grkV7tKtel05iv+bMt+dDk2DZDv5LVOpKnqagqr
# hPOsZ061xPeM0SAlI+sIZD5SlsHyDxL0xY4PwaLoLFH3c7y9hbFig3NBggfkOItq
# cyDQD2RzPJ6fpjOp/RnfJZPRAgMBAAGjggHNMIIByTASBgNVHRMBAf8ECDAGAQH/
# AgEAMA4GA1UdDwEB/wQEAwIBhjATBgNVHSUEDDAKBggrBgEFBQcDAzB5BggrBgEF
# BQcBAQRtMGswJAYIKwYBBQUHMAGGGGh0dHA6Ly9vY3NwLmRpZ2ljZXJ0LmNvbTBD
# BggrBgEFBQcwAoY3aHR0cDovL2NhY2VydHMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0
# QXNzdXJlZElEUm9vdENBLmNydDCBgQYDVR0fBHoweDA6oDigNoY0aHR0cDovL2Ny
# bDQuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEUm9vdENBLmNybDA6oDig
# NoY0aHR0cDovL2NybDMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEUm9v
# dENBLmNybDBPBgNVHSAESDBGMDgGCmCGSAGG/WwAAgQwKjAoBggrBgEFBQcCARYc
# aHR0cHM6Ly93d3cuZGlnaWNlcnQuY29tL0NQUzAKBghghkgBhv1sAzAdBgNVHQ4E
# FgQUWsS5eyoKo6XqcQPAYPkt9mV1DlgwHwYDVR0jBBgwFoAUReuir/SSy4IxLVGL
# p6chnfNtyA8wDQYJKoZIhvcNAQELBQADggEBAD7sDVoks/Mi0RXILHwlKXaoHV0c
# LToaxO8wYdd+C2D9wz0PxK+L/e8q3yBVN7Dh9tGSdQ9RtG6ljlriXiSBThCk7j9x
# jmMOE0ut119EefM2FAaK95xGTlz/kLEbBw6RFfu6r7VRwo0kriTGxycqoSkoGjpx
# KAI8LpGjwCUR4pwUR6F6aGivm6dcIFzZcbEMj7uo+MUSaJ/PQMtARKUT8OZkDCUI
# QjKyNookAv4vcn4c10lFluhZHen6dGRrsutmQ9qzsIzV6Q3d9gEgzpkxYz0IGhiz
# gZtPxpMQBvwHgfqL2vmCSfdibqFT+hKUGIUukpHqaGxEMrJmoecYpJpkUe8wggZq
# MIIFUqADAgECAhADAZoCOv9YsWvW1ermF/BmMA0GCSqGSIb3DQEBBQUAMGIxCzAJ
# BgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5k
# aWdpY2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMTAe
# Fw0xNDEwMjIwMDAwMDBaFw0yNDEwMjIwMDAwMDBaMEcxCzAJBgNVBAYTAlVTMREw
# DwYDVQQKEwhEaWdpQ2VydDElMCMGA1UEAxMcRGlnaUNlcnQgVGltZXN0YW1wIFJl
# c3BvbmRlcjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKNkXfx8s+CC
# NeDg9sYq5kl1O8xu4FOpnx9kWeZ8a39rjJ1V+JLjntVaY1sCSVDZg85vZu7dy4Xp
# X6X51Id0iEQ7Gcnl9ZGfxhQ5rCTqqEsskYnMXij0ZLZQt/USs3OWCmejvmGfrvP9
# Enh1DqZbFP1FI46GRFV9GIYFjFWHeUhG98oOjafeTl/iqLYtWQJhiGFyGGi5uHzu
# 5uc0LzF3gTAfuzYBje8n4/ea8EwxZI3j6/oZh6h+z+yMDDZbesF6uHjHyQYuRhDI
# jegEYNu8c3T6Ttj+qkDxss5wRoPp2kChWTrZFQlXmVYwk/PJYczQCMxr7GJCkawC
# wO+k8IkRj3cCAwEAAaOCAzUwggMxMA4GA1UdDwEB/wQEAwIHgDAMBgNVHRMBAf8E
# AjAAMBYGA1UdJQEB/wQMMAoGCCsGAQUFBwMIMIIBvwYDVR0gBIIBtjCCAbIwggGh
# BglghkgBhv1sBwEwggGSMCgGCCsGAQUFBwIBFhxodHRwczovL3d3dy5kaWdpY2Vy
# dC5jb20vQ1BTMIIBZAYIKwYBBQUHAgIwggFWHoIBUgBBAG4AeQAgAHUAcwBlACAA
# bwBmACAAdABoAGkAcwAgAEMAZQByAHQAaQBmAGkAYwBhAHQAZQAgAGMAbwBuAHMA
# dABpAHQAdQB0AGUAcwAgAGEAYwBjAGUAcAB0AGEAbgBjAGUAIABvAGYAIAB0AGgA
# ZQAgAEQAaQBnAGkAQwBlAHIAdAAgAEMAUAAvAEMAUABTACAAYQBuAGQAIAB0AGgA
# ZQAgAFIAZQBsAHkAaQBuAGcAIABQAGEAcgB0AHkAIABBAGcAcgBlAGUAbQBlAG4A
# dAAgAHcAaABpAGMAaAAgAGwAaQBtAGkAdAAgAGwAaQBhAGIAaQBsAGkAdAB5ACAA
# YQBuAGQAIABhAHIAZQAgAGkAbgBjAG8AcgBwAG8AcgBhAHQAZQBkACAAaABlAHIA
# ZQBpAG4AIABiAHkAIAByAGUAZgBlAHIAZQBuAGMAZQAuMAsGCWCGSAGG/WwDFTAf
# BgNVHSMEGDAWgBQVABIrE5iymQftHt+ivlcNK2cCzTAdBgNVHQ4EFgQUYVpNJLZJ
# Mp1KKnkag0v0HonByn0wfQYDVR0fBHYwdDA4oDagNIYyaHR0cDovL2NybDMuZGln
# aWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEQ0EtMS5jcmwwOKA2oDSGMmh0dHA6
# Ly9jcmw0LmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRENBLTEuY3JsMHcG
# CCsGAQUFBwEBBGswaTAkBggrBgEFBQcwAYYYaHR0cDovL29jc3AuZGlnaWNlcnQu
# Y29tMEEGCCsGAQUFBzAChjVodHRwOi8vY2FjZXJ0cy5kaWdpY2VydC5jb20vRGln
# aUNlcnRBc3N1cmVkSURDQS0xLmNydDANBgkqhkiG9w0BAQUFAAOCAQEAnSV+GzNN
# siaBXJuGziMgD4CH5Yj//7HUaiwx7ToXGXEXzakbvFoWOQCd42yE5FpA+94GAYw3
# +puxnSR+/iCkV61bt5qwYCbqaVchXTQvH3Gwg5QZBWs1kBCge5fH9j/n4hFBpr1i
# 2fAnPTgdKG86Ugnw7HBi02JLsOBzppLA044x2C/jbRcTBu7kA7YUq/OPQ6dxnSHd
# FMoVXZJB2vkPgdGZdA0mxA5/G7X1oPHGdwYoFenYk+VVFvC7Cqsc21xIJ2bIo4sK
# HOWV2q7ELlmgYd3a822iYemKC23sEhi991VUQAOSK2vCUcIKSK+w1G7g9BQKOhvj
# jz3Kr2qNe9zYRDCCBs0wggW1oAMCAQICEAb9+QOWA63qAArrPye7uhswDQYJKoZI
# hvcNAQEFBQAwZTELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERpZ2lDZXJ0IEluYzEZ
# MBcGA1UECxMQd3d3LmRpZ2ljZXJ0LmNvbTEkMCIGA1UEAxMbRGlnaUNlcnQgQXNz
# dXJlZCBJRCBSb290IENBMB4XDTA2MTExMDAwMDAwMFoXDTIxMTExMDAwMDAwMFow
# YjELMAkGA1UEBhMCVVMxFTATBgNVBAoTDERpZ2lDZXJ0IEluYzEZMBcGA1UECxMQ
# d3d3LmRpZ2ljZXJ0LmNvbTEhMB8GA1UEAxMYRGlnaUNlcnQgQXNzdXJlZCBJRCBD
# QS0xMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA6IItmfnKwkKVpYBz
# QHDSnlZUXKnE0kEGj8kz/E1FkVyBn+0snPgWWd+etSQVwpi5tHdJ3InECtqvy15r
# 7a2wcTHrzzpADEZNk+yLejYIA6sMNP4YSYL+x8cxSIB8HqIPkg5QycaH6zY/2DDD
# /6b3+6LNb3Mj/qxWBZDwMiEWicZwiPkFl32jx0PdAug7Pe2xQaPtP77blUjE7h6z
# 8rwMK5nQxl0SQoHhg26Ccz8mSxSQrllmCsSNvtLOBq6thG9IhJtPQLnxTPKvmPv2
# zkBdXPao8S+v7Iki8msYZbHBc63X8djPHgp0XEK4aH631XcKJ1Z8D2KkPzIUYJX9
# BwSiCQIDAQABo4IDejCCA3YwDgYDVR0PAQH/BAQDAgGGMDsGA1UdJQQ0MDIGCCsG
# AQUFBwMBBggrBgEFBQcDAgYIKwYBBQUHAwMGCCsGAQUFBwMEBggrBgEFBQcDCDCC
# AdIGA1UdIASCAckwggHFMIIBtAYKYIZIAYb9bAABBDCCAaQwOgYIKwYBBQUHAgEW
# Lmh0dHA6Ly93d3cuZGlnaWNlcnQuY29tL3NzbC1jcHMtcmVwb3NpdG9yeS5odG0w
# ggFkBggrBgEFBQcCAjCCAVYeggFSAEEAbgB5ACAAdQBzAGUAIABvAGYAIAB0AGgA
# aQBzACAAQwBlAHIAdABpAGYAaQBjAGEAdABlACAAYwBvAG4AcwB0AGkAdAB1AHQA
# ZQBzACAAYQBjAGMAZQBwAHQAYQBuAGMAZQAgAG8AZgAgAHQAaABlACAARABpAGcA
# aQBDAGUAcgB0ACAAQwBQAC8AQwBQAFMAIABhAG4AZAAgAHQAaABlACAAUgBlAGwA
# eQBpAG4AZwAgAFAAYQByAHQAeQAgAEEAZwByAGUAZQBtAGUAbgB0ACAAdwBoAGkA
# YwBoACAAbABpAG0AaQB0ACAAbABpAGEAYgBpAGwAaQB0AHkAIABhAG4AZAAgAGEA
# cgBlACAAaQBuAGMAbwByAHAAbwByAGEAdABlAGQAIABoAGUAcgBlAGkAbgAgAGIA
# eQAgAHIAZQBmAGUAcgBlAG4AYwBlAC4wCwYJYIZIAYb9bAMVMBIGA1UdEwEB/wQI
# MAYBAf8CAQAweQYIKwYBBQUHAQEEbTBrMCQGCCsGAQUFBzABhhhodHRwOi8vb2Nz
# cC5kaWdpY2VydC5jb20wQwYIKwYBBQUHMAKGN2h0dHA6Ly9jYWNlcnRzLmRpZ2lj
# ZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RDQS5jcnQwgYEGA1UdHwR6MHgw
# OqA4oDaGNGh0dHA6Ly9jcmwzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJ
# RFJvb3RDQS5jcmwwOqA4oDaGNGh0dHA6Ly9jcmw0LmRpZ2ljZXJ0LmNvbS9EaWdp
# Q2VydEFzc3VyZWRJRFJvb3RDQS5jcmwwHQYDVR0OBBYEFBUAEisTmLKZB+0e36K+
# Vw0rZwLNMB8GA1UdIwQYMBaAFEXroq/0ksuCMS1Ri6enIZ3zbcgPMA0GCSqGSIb3
# DQEBBQUAA4IBAQBGUD7Jtygkpzgdtlspr1LPUukxR6tWXHvVDQtBs+/sdR90OPKy
# XGGinJXDUOSCuSPRujqGcq04eKx1XRcXNHJHhZRW0eu7NoR3zCSl8wQZVann4+er
# Ys37iy2QwsDStZS9Xk+xBdIOPRqpFFumhjFiqKgz5Js5p8T1zh14dpQlc+Qqq8+c
# dkvtX8JLFuRLcEwAiR78xXm8TBJX/l/hHrwCXaj++wc4Tw3GXZG5D2dFzdaD7eeS
# DY2xaYxP+1ngIw/Sqq4AfO6cQg7PkdcntxbuD8O9fAqg7iwIVYUiuOsYGk38KiGt
# STGDR5V3cdyxG0tLHBCcdxTBnU8vWpUIKRAmMYIEOzCCBDcCAQEwgYYwcjELMAkG
# A1UEBhMCVVMxFTATBgNVBAoTDERpZ2lDZXJ0IEluYzEZMBcGA1UECxMQd3d3LmRp
# Z2ljZXJ0LmNvbTExMC8GA1UEAxMoRGlnaUNlcnQgU0hBMiBBc3N1cmVkIElEIENv
# ZGUgU2lnbmluZyBDQQIQCIQ1OU/QbU6rESO7M78utDAJBgUrDgMCGgUAoHgwGAYK
# KwYBBAGCNwIBDDEKMAigAoAAoQKAADAZBgkqhkiG9w0BCQMxDAYKKwYBBAGCNwIB
# BDAcBgorBgEEAYI3AgELMQ4wDAYKKwYBBAGCNwIBFTAjBgkqhkiG9w0BCQQxFgQU
# Wz3/Xz2ry+7L88gHxdOWwY9tP8MwDQYJKoZIhvcNAQEBBQAEggEARJZHFyOVPKwa
# 0+KbCm5HhlAEntIgtC2cgFBPGTgs4/vD/DlQxHt/P83z0cadk8/pEeI0bYF9WFA2
# l/ZraSq0fC3KxcBXbCPYCAptSJHvPxfstDySCO8LT1goMhFOTgt//0yK0HQrkbWU
# LE1RPV5GJaFomQrTTh+sioYXlTvhfs86tiKm7D+mPVLwf+Tsv+yiT+LPipMgUrDw
# UjGz1UCZJ5/bEsn8GOzifdUjp/t50Dmx13S0E4c1cQQHtOXBa7Mv8U11sUFNVBAj
# RnzdaQ0TRG6DurCctRyKaFKpS8rQWcWcaA2XaCBaKOUuACkJsjiillBMyvPb6Udr
# hZsAGT5vS6GCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDAyWjAjBgkqhkiG9w0BCQQx
# FgQUDYqMEsLu4/gwXaEB0h3tpNzlPDAwDQYJKoZIhvcNAQEBBQAEggEAi0kZUyeW
# NhZ2PN6q6Fv9aFhx4/suwwXmbscpKVQxgbRGcBPBOWODtbIQYF9HnnV9Fc9tjuEn
# /VFJu8IRyKd9HirMe+c56Nj7M9jMDj20UddmJ1x0/6jAOQL0BYt/RfTGAVy0mB5S
# RogVn0vrBPIlSY5CaPkiskOeD1o7Wv5LL67+Zx0PKLF20hRxtHwCxdXadHJ7CA97
# JIxp5bByFeycq8O2YmAVBV304BhNKUdD2mXRLH0QI1CNNXIB8oCE679qhse6NlSH
# w5Wb0YsI+jAijE6C4fpXHUlj1ZrBwuog+5uq0AKq7OPdxhm5qmTaRkAWYfHg0JaG
# nktLLE4jlsDkUA==
# SIG # End signature block
