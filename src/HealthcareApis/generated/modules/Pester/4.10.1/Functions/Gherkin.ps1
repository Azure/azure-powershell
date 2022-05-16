if (($PSVersionTable.ContainsKey('PSEdition')) -and ($PSVersionTable.PSEdition -eq 'Core')) {
    & $SafeCommands["Add-Type"] -Path "${Script:PesterRoot}/lib/Gherkin/core/Gherkin.dll"
}
else {
    & $SafeCommands["Import-Module"] -Name "${Script:PesterRoot}/lib/Gherkin/legacy/Gherkin.dll"
}

$GherkinSteps = @{ }
$GherkinHooks = @{
    BeforeEachFeature  = @()
    BeforeEachScenario = @()
    AfterEachFeature   = @()
    AfterEachScenario  = @()
}

function Invoke-GherkinHook {
    <#
        .SYNOPSIS
            Internal function to run the various gherkin hooks

        .PARAMETER Hook
            The name of the hook to run

        .PARAMETER Name
            The name of the feature or scenario the hook is being invoked for

        .PARAMETER Tags
            Tags for filtering hooks
    #>
    [CmdletBinding()]
    param([string]$Hook, [string]$Name, [string[]]$Tags)

    if ($GherkinHooks.${Hook}) {
        foreach ($GherkinHook in $GherkinHooks.${Hook}) {
            if ($GherkinHook.Tags -and $Tags) {
                :tags foreach ($hookTag in $GherkinHook.Tags) {
                    foreach ($testTag in $Tags) {
                        if ($testTag -match "^($hookTag)$") {
                            & $GherkinHook.Script $Name
                            break :tags
                        }
                    }
                }
            }
            elseif ($GherkinHook.Tags) {
                # If the hook has tags, it can't run if the step doesn't
            }
            else {
                & $GherkinHook.Script $Name
            }
        } # @{ Tags = $Tags; Script = $Test }
    }
}

function Invoke-Gherkin {
    <#
        .SYNOPSIS
            Invokes Pester to run all tests defined in .feature files

        .DESCRIPTION
            Upon calling Invoke-Gherkin, all files that have a name matching *.feature in the current folder (and child folders recursively), will be parsed and executed.

            If ScenarioName is specified, only scenarios which match the provided name(s) will be run.
            If FailedLast is specified, only scenarios which failed the previous run will be re-executed.

            Optionally, Pester can generate a report of how much code is covered by the tests, and information about any commands which were not executed.
        .PARAMETER FailedLast
            Rerun only the scenarios which failed last time
        .PARAMETER Path
            This parameter indicates which feature files should be tested.

            Aliased to 'Script' for compatibility with Pester, but does not support hashtables, since feature files don't take parameters.

        .PARAMETER ScenarioName
            When set, invokes testing of scenarios which match this name.

            Aliased to 'Name' and 'TestName' for compatibility with Pester.

        .PARAMETER EnableExit
            Will cause Invoke-Gherkin to exit with a exit code equal to the number of failed tests once all tests have been run.
            Use this to "fail" a build when any tests fail.

        .PARAMETER Tag
            Filters Scenarios and Features and runs only the ones tagged with the specified tags.

        .PARAMETER ExcludeTag
            Informs Invoke-Gherkin to not run blocks tagged with the tags specified.

        .PARAMETER CodeCoverage
            Instructs Pester to generate a code coverage report in addition to running tests.  You may pass either hashtables or strings to this parameter.

            If strings are used, they must be paths (wildcards allowed) to source files, and all commands in the files are analyzed for code coverage.

            By passing hashtables instead, you can limit the analysis to specific lines or functions within a file.
            Hashtables must contain a Path key (which can be abbreviated to just "P"), and may contain Function (or "F"), StartLine (or "S"),
            and EndLine ("E") keys to narrow down the commands to be analyzed.
            If Function is specified, StartLine and EndLine are ignored.

            If only StartLine is defined, the entire script file starting with StartLine is analyzed.
            If only EndLine is present, all lines in the script file up to and including EndLine are analyzed.

            Both Function and Path (as well as simple strings passed instead of hashtables) may contain wildcards.

        .PARAMETER Strict
            Makes Pending and Skipped tests to Failed tests. Useful for continuous integration where you need
            to make sure all tests passed.

        .PARAMETER OutputFile
            The path to write a report file to. If this path is not provided, no log will be generated.

        .PARAMETER OutputFormat
            The format for output (LegacyNUnitXml or NUnitXml), defaults to NUnitXml

        .PARAMETER Quiet
            Disables the output Pester writes to screen. No other output is generated unless you specify PassThru,
            or one of the Output parameters.

        .PARAMETER PesterOption
            Sets advanced options for the test execution. Enter a PesterOption object,
            such as one that you create by using the New-PesterOption cmdlet, or a hash table
            in which the keys are option names and the values are option values.
            For more information on the options available, see the help for New-PesterOption.

        .PARAMETER Show
            Customizes the output Pester writes to the screen. Available options are None, Default,
            Passed, Failed, Pending, Skipped, Inconclusive, Describe, Context, Summary, Header, All, Fails.

            The options can be combined to define presets.
            Common use cases are:

            None - to write no output to the screen.
            All - to write all available information (this is default option).
            Fails - to write everything except Passed (but including Describes etc.).

            A common setting is also Failed, Summary, to write only failed tests and test summary.

            This parameter does not affect the PassThru custom object or the XML output that
            is written when you use the Output parameters.

        .PARAMETER PassThru
            Returns a custom object (PSCustomObject) that contains the test results.
            By default, Invoke-Gherkin writes to the host program, not to the output stream (stdout).
            If you try to save the result in a variable, the variable is empty unless you
            use the PassThru parameter.
            To suppress the host output, use the Quiet parameter.

        .EXAMPLE
            Invoke-Gherkin

            This will find all *.feature specifications and execute their tests. No exit code will be returned and no log file will be saved.

        .EXAMPLE
            Invoke-Gherkin -Path ./tests/Utils*

            This will run all *.feature specifications under ./Tests that begin with Utils.

        .EXAMPLE
            Invoke-Gherkin -ScenarioName "Add Numbers"

            This will only run the Scenario named "Add Numbers"

        .EXAMPLE
            Invoke-Gherkin -EnableExit -OutputXml "./artifacts/TestResults.xml"

            This runs all tests from the current directory downwards and writes the results according to the NUnit schema to artifacts/TestResults.xml just below the current directory. The test run will return an exit code equal to the number of test failures.

        .EXAMPLE
            Invoke-Gherkin -CodeCoverage 'ScriptUnderTest.ps1'

            Runs all *.feature specifications in the current directory, and generates a coverage report for all commands in the "ScriptUnderTest.ps1" file.

        .EXAMPLE
            Invoke-Gherkin -CodeCoverage @{ Path = 'ScriptUnderTest.ps1'; Function = 'FunctionUnderTest' }

            Runs all *.feature specifications in the current directory, and generates a coverage report for all commands in the "FunctionUnderTest" function in the "ScriptUnderTest.ps1" file.

        .EXAMPLE
            Invoke-Gherkin -CodeCoverage @{ Path = 'ScriptUnderTest.ps1'; StartLine = 10; EndLine = 20 }

            Runs all *.feature specifications in the current directory, and generates a coverage report for all commands on lines 10 through 20 in the "ScriptUnderTest.ps1" file.

        .LINK
            Invoke-Pester
            https://kevinmarquette.github.io/2017-03-17-Powershell-Gherkin-specification-validation/

        .LINK
            https://kevinmarquette.github.io/2017-04-30-Powershell-Gherkin-advanced-features/
    #>
    [CmdletBinding(DefaultParameterSetName = 'Default')]
    param(
        [Parameter(Mandatory = $True, ParameterSetName = "RetestFailed")]
        [switch]$FailedLast,

        [Parameter(Position = 0, Mandatory = $False)]
        [Alias('Script', 'relative_path')]
        [string]$Path = $Pwd,

        [Parameter(Position = 1, Mandatory = $False)]
        [Alias("Name", "TestName")]
        [string[]]$ScenarioName,

        [Parameter(Position = 2, Mandatory = $False)]
        [switch]$EnableExit,

        [Parameter(Position = 4, Mandatory = $False)]
        [Alias('Tags')]
        [string[]]$Tag,

        [string[]]$ExcludeTag,

        [object[]] $CodeCoverage = @(),

        [Switch]$Strict,

        [string] $OutputFile,

        [ValidateSet('NUnitXml')]
        [string] $OutputFormat = 'NUnitXml',

        [Switch]$Quiet,

        [object]$PesterOption,

        [Pester.OutputTypes]$Show = 'All',

        [switch]$PassThru
    )
    begin {
        & $SafeCommands["Import-LocalizedData"] -BindingVariable Script:ReportStrings -BaseDirectory $PesterRoot -FileName Gherkin.psd1 -ErrorAction SilentlyContinue

        #Fallback to en-US culture strings
        If ([String]::IsNullOrEmpty($ReportStrings)) {

            & $SafeCommands["Import-LocalizedData"] -BaseDirectory $PesterRoot -BindingVariable Script:ReportStrings -UICulture 'en-US' -FileName Gherkin.psd1 -ErrorAction Stop

        }

        # Make sure broken tests don't leave you in space:
        $CWD = [Environment]::CurrentDirectory
        $Location = & $SafeCommands["Get-Location"]
        [Environment]::CurrentDirectory = & $SafeCommands["Get-Location"] -PSProvider FileSystem

        $script:GherkinSteps = @{ }
        $script:GherkinHooks = @{
            BeforeEachFeature  = @()
            BeforeEachScenario = @()
            AfterEachFeature   = @()
            AfterEachScenario  = @()
        }
    }
    end {
        if ($PSBoundParameters.ContainsKey('Quiet')) {
            & $SafeCommands["Write-Warning"] 'The -Quiet parameter has been deprecated; please use the new -Show parameter instead. To get no output use -Show None.'
            & $SafeCommands["Start-Sleep"] -Seconds 2

            if (!$PSBoundParameters.ContainsKey('Show')) {
                $Show = [Pester.OutputTypes]::None
            }
        }

        if ($PSCmdlet.ParameterSetName -eq "RetestFailed" -and $FailedLast) {
            $ScenarioName = $script:GherkinFailedLast
            if (!$ScenarioName) {
                throw "There are no existing failed tests to re-run."
            }
        }
        $sessionState = Set-SessionStateHint -PassThru  -Hint "Caller - Captured in Invoke-Gherkin" -SessionState $PSCmdlet.SessionState
        $pester = New-PesterState -TagFilter $Tag -ExcludeTagFilter $ExcludeTag -TestNameFilter $ScenarioName -SessionState $sessionState -Strict:$Strict  -Show $Show -PesterOption $PesterOption |
        & $SafeCommands["Add-Member"] -MemberType NoteProperty -Name Features -Value (& $SafeCommands["New-Object"] System.Collections.Generic.List[PSObject] ) -PassThru |
        & $SafeCommands["Add-Member"] -MemberType ScriptProperty -Name FailedScenarios -PassThru -Value {
            $Names = $this.TestResult | & $SafeCommands["Group-Object"] Describe |
            & $SafeCommands["Where-Object"] { $_.Group |
                & $SafeCommands["Where-Object"] { -not $_.Passed } } |
            & $SafeCommands["Select-Object"] -ExpandProperty Name
            $this.Features | Select-Object -ExpandProperty Scenarios | & $SafeCommands["Where-Object"] { $Names -contains $_.Name }
        } |
        & $SafeCommands["Add-Member"] -MemberType ScriptProperty -Name PassedScenarios -PassThru -Value {
            $Names = $this.TestResult | & $SafeCommands["Group-Object"] Describe |
            & $SafeCommands["Where-Object"] { -not ($_.Group |
                    & $SafeCommands["Where-Object"] { -not $_.Passed }) } |
            & $SafeCommands["Select-Object"] -ExpandProperty Name
            $this.Features | Select-Object -ExpandProperty Scenarios | & $SafeCommands["Where-Object"] { $Names -contains $_.Name }
        }

        Write-PesterStart $pester $Path

        Enter-CoverageAnalysis -CodeCoverage $CodeCoverage -PesterState $pester

        foreach ($FeatureFile in & $SafeCommands["Get-ChildItem"] $Path -Filter "*.feature" -Recurse ) {
            Invoke-GherkinFeature $FeatureFile -Pester $pester
        }

        # Remove all the steps
        $Script:GherkinSteps.Clear()

        $Location | & $SafeCommands["Set-Location"]
        [Environment]::CurrentDirectory = $CWD

        $pester | Write-PesterReport
        $coverageReport = Get-CoverageReport -PesterState $pester
        Write-CoverageReport -CoverageReport $coverageReport
        Exit-CoverageAnalysis -PesterState $pester

        if (& $SafeCommands["Get-Variable"]-Name OutputFile -ValueOnly -ErrorAction $script:IgnoreErrorPreference) {
            Export-PesterResults -PesterState $pester -Path $OutputFile -Format $OutputFormat
        }

        if ($PassThru) {
            # Remove all runtime properties like current* and Scope
            $properties = @(
                "Path", "Features", "TagFilter", "TestNameFilter", "TotalCount", "PassedCount", "FailedCount", "Time", "TestResult", "PassedScenarios", "FailedScenarios"

                if ($CodeCoverage) {
                    @{ Name = 'CodeCoverage'; Expression = { $coverageReport } }
                }
            )
            $result = $pester | & $SafeCommands["Select-Object"] -Property $properties
            $result.PSTypeNames.Insert(0, "Pester.Gherkin.Results")
            $result
        }
        $script:GherkinFailedLast = @($pester.FailedScenarios.Name)
        if ($EnableExit) {
            Exit-WithCode -FailedCount $pester.FailedCount
        }
    }
}

function Import-GherkinSteps {
    <#
        .SYNOPSIS
            Internal function for importing the script steps from a directory tree
        .PARAMETER StepPath
            The folder which contains step files
        .PARAMETER Pester
            Pester
    #>

    [CmdletBinding()]
    param(

        [Alias("PSPath")]
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipelineByPropertyName = $True)]
        $StepPath,

        [PSObject]$Pester
    )
    begin {
        # Remove all existing steps
        $Script:GherkinSteps.Clear()
        # Remove all existing hooks
        $Script:GherkinHooks.Clear()
    }
    process {
        $StepFiles = & $SafeCommands["Get-ChildItem"] $StepPath -Filter "*.?teps.ps1" -Include "*.[sS]teps.ps1" -Recurse

        foreach ($StepFile in $StepFiles) {
            $invokeTestScript = {
                [CmdletBinding()]
                param (
                    [Parameter(Position = 0)]
                    [string] $Path
                )

                & $Path
            }

            Set-ScriptBlockScope -ScriptBlock $invokeTestScript -SessionState $Pester.SessionState

            & $invokeTestScript $StepFile.FullName
        }

        & $SafeCommands["Write-Verbose"] "Loaded $($Script:GherkinSteps.Count) step definitions from $(@($StepFiles).Count) steps file(s)"
    }
}

function Import-GherkinFeature {
    <#
        .SYNOPSIS
            Internal function to import a Gherkin feature file. Wraps Gherkin.Parse

        .PARAMETER Path
            The path to the feature file to import

        .PARAMETER Pester
            Internal Pester object. For internal use only
    #>
    [CmdletBinding()]
    param($Path, [PSObject]$Pester)
    $Background = $null

    $parser = & $SafeCommands["New-Object"] Gherkin.Parser
    $Feature = $parser.Parse($Path).Feature | Convert-Tags
    $Scenarios = $(
        :scenarios foreach ($Child in $Feature.Children) {
            $null = & $SafeCommands["Add-Member"] -MemberType "NoteProperty" -InputObject $Child.Location -Name "Path" -Value $Path
            foreach ($Step in $Child.Steps) {
                $null = & $SafeCommands["Add-Member"] -MemberType "NoteProperty" -InputObject $Step.Location -Name "Path" -Value $Path
            }

            switch ($Child.Keyword.Trim()) {
                { (Test-Keyword $_ 'scenario' $Feature.Language) -or (Test-Keyword $_ 'scenarioOutline' $Feature.Language) } {
                    $Scenario = Convert-Tags -InputObject $Child -BaseTags $Feature.Tags
                }
                { Test-Keyword $_ 'background' $Feature.Language } {
                    $Background = Convert-Tags -InputObject $Child -BaseTags $Feature.Tags
                    continue scenarios
                }
                default {
                    & $SafeCommands["Write-Warning"] "Unexpected Feature Child: $_"
                }
            }

            if ( $Scenario -is [Gherkin.Ast.ScenarioOutline] ) {
                # If there is no example set name, the following index will be included in the scenario name
                $ScenarioIndex = 0
                foreach ($ExampleSet in $Scenario.Examples) {
                    ${Column Names} = @($ExampleSet.TableHeader.Cells | & $SafeCommands["Select-Object"] -ExpandProperty Value)
                    $NamesPattern = "<(?:" + (${Column Names} -join "|") + ")>"
                    # If there is an example set name, the following index will be included in the scenario name
                    $ExampleSetIndex = 0
                    foreach ($Example in $ExampleSet.TableBody) {
                        $ScenarioIndex++
                        $ExampleSetIndex++
                        $Steps = foreach ($Step in $Scenario.Steps) {
                            [string]$StepText = $Step.Text
                            if ($StepText -match $NamesPattern) {
                                for ($n = 0; $n -lt ${Column Names}.Length; $n++) {
                                    $Name = ${Column Names}[$n]
                                    if ($Example.Cells[$n].Value -and $StepText -match "<${Name}>") {
                                        $StepText = $StepText -replace "<${Name}>", $Example.Cells[$n].Value
                                    }
                                }
                            }
                            if ($StepText -ne $Step.Text) {
                                & $SafeCommands["New-Object"] Gherkin.Ast.Step $Step.Location, $Step.Keyword.Trim(), $StepText, $Step.Argument
                            }
                            else {
                                $Step
                            }
                        }
                        $ScenarioName = $Scenario.Name
                        if ($ExampleSet.Name) {
                            # Include example set name and index of example
                            $ScenarioName = $ScenarioName + " [$($ExampleSet.Name.Trim()) $ExampleSetIndex]"
                        }
                        else {
                            # Only include index of scenario
                            $ScenarioName = $ScenarioName + " [$ScenarioIndex]"
                        }
                        & $SafeCommands["New-Object"] Gherkin.Ast.Scenario $ExampleSet.Tags, $Scenario.Location, $Scenario.Keyword.Trim(), $ScenarioName, $Scenario.Description, $Steps | Convert-Tags $Scenario.Tags
                    }
                }
            }
            else {
                $Scenario
            }
        }
    )

    & $SafeCommands["Add-Member"] -MemberType NoteProperty -InputObject $Feature -Name Scenarios -Value $Scenarios -Force
    return $Feature, $Background, $Scenarios
}

function Invoke-GherkinFeature {
    <#
        .SYNOPSIS
            Internal function to (parse and) run a whole feature file
    #>
    [CmdletBinding()]
    param(
        [Alias("PSPath")]
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipelineByPropertyName = $True)]
        [IO.FileInfo]$FeatureFile,

        [PSObject]$Pester
    )
    # Make sure broken tests don't leave you in space:
    $CWD = [Environment]::CurrentDirectory
    $Location = & $SafeCommands["Get-Location"]
    [Environment]::CurrentDirectory = & $SafeCommands["Get-Location"] -PSProvider FileSystem

    try {
        $Parent = & $SafeCommands["Split-Path"] $FeatureFile.FullName
        Import-GherkinSteps -StepPath $Parent -Pester $pester
        $Feature, $Background, $Scenarios = Import-GherkinFeature -Path $FeatureFile.FullName -Pester $Pester
    }
    catch [Gherkin.ParserException] {
        & $SafeCommands["Write-Error"] -Exception $_.Exception -Message "Skipped '$($FeatureFile.FullName)' because of parser error.`n$(($_.Exception.Errors | & $SafeCommands["Select-Object"] -Expand Message) -join "`n`n")"
        continue
    }

    # To create a more user-friendly test report, we use the feature name for the test group
    $Pester.EnterTestGroup($Feature.Name, 'Script')

    $null = $Pester.Features.Add($Feature)
    Invoke-GherkinHook BeforeEachFeature $Feature.Name $Feature.Tags

    # Test the name filter first, since it will probably return one single item
    if ($Pester.TestNameFilter) {
        $Scenarios = foreach ($nameFilter in $Pester.TestNameFilter) {
            $Scenarios | & $SafeCommands["Where-Object"] { $_.Name -like $NameFilter }
        }
        $Scenarios = $Scenarios | & $SafeCommands["Get-Unique"]
    }

    # if($Pester.TagFilter -and @(Compare-Object $Tags $Pester.TagFilter -IncludeEqual -ExcludeDifferent).count -eq 0) {return}
    if ($Pester.TagFilter) {
        $Scenarios = $Scenarios | & $SafeCommands["Where-Object"] { & $SafeCommands["Compare-Object"] $_.Tags $Pester.TagFilter -IncludeEqual -ExcludeDifferent }
    }

    # if($Pester.ExcludeTagFilter -and @(Compare-Object $Tags $Pester.ExcludeTagFilter -IncludeEqual -ExcludeDifferent).count -gt 0) {return}
    if ($Pester.ExcludeTagFilter) {
        $Scenarios = $Scenarios | & $SafeCommands["Where-Object"] { !(& $SafeCommands["Compare-Object"] $_.Tags $Pester.ExcludeTagFilter -IncludeEqual -ExcludeDifferent) }
    }

    if ($Scenarios) {
        Write-Describe (New-Object PSObject -Property @{Name = "$($Feature.Keyword): $($Feature.Name)"; Description = $Feature.Description })
    }

    try {
        foreach ($Scenario in $Scenarios) {
            Invoke-GherkinScenario $Pester $Scenario $Background $Feature.Language
        }
    }
    catch {
        $firstStackTraceLine = $_.ScriptStackTrace -split '\r?\n' | & $SafeCommands["Select-Object"] -First 1
        $Pester.AddTestResult("Error occurred in test script '$($Feature.Path)'", "Failed", $null, $_.Exception.Message, $firstStackTraceLine, $null, $null, $_)

        # This is a hack to ensure that XML output is valid for now.  The test-suite names come from the Describe attribute of the TestResult
        # objects, and a blank name is invalid NUnit XML.  This will go away when we promote test scripts to have their own test-suite nodes,
        # planned for v4.0
        $Pester.TestResult[-1].Describe = "Error in $($Feature.Path)"

        $Pester.TestResult[-1] | Write-PesterResult
    }
    finally {
        $Location | & $SafeCommands["Set-Location"]
        [Environment]::CurrentDirectory = $CWD
    }

    Invoke-GherkinHook AfterEachFeature $Feature.Name $Feature.Tags

    $Pester.LeaveTestGroup($Feature.Name, 'Script')

}

function Invoke-GherkinScenario {
    <#
        .SYNOPSIS
            Internal function to (parse and) run a single scenario
    #>
    [CmdletBinding()]
    param(
        $Pester, $Scenario, $Background, $Language
    )
    $Pester.EnterTestGroup($Scenario.Name, 'Scenario')
    try {
        # We just display 'Scenario', also for 'Scenario Outline' or 'Scenario Template'
        # Thus we use the translation of 'scenario' instead of $Scenario.Keyword
        Write-Context (New-Object PSObject -Property @{Name = "$(Get-Translation 'scenario' $Language): $($Scenario.Name)"; Description = $Scenario.Description })

        $script:mockTable = @{ }

        # Create a clean variable scope in each scenario
        $script:GherkinScenarioScope = New-Module Scenario { $a = 4
        }
        $script:GherkinSessionState = Set-SessionStateHint -PassThru -Hint Scenario -SessionState $Script:GherkinScenarioScope.SessionState

        #Wait-Debugger

        New-TestDrive
        Invoke-GherkinHook BeforeEachScenario $Scenario.Name $Scenario.Tags

        $testResultIndexStart = $Pester.TestResult.Count

        # If there's a background, run that before the test, but after hooks
        if ($Background) {
            foreach ($Step in $Background.Steps) {
                # Run Background steps -Background so they don't output in each scenario
                Invoke-GherkinStep -Step $Step -Pester $Pester -Scenario $GherkinSessionState -Visible -TestResultIndexStart $testResultIndexStart
            }
        }

        foreach ($Step in $Scenario.Steps) {
            Invoke-GherkinStep -Step $Step -Pester $Pester -Scenario $GherkinSessionState -Visible -TestResultIndexStart $testResultIndexStart
        }

        Invoke-GherkinHook AfterEachScenario $Scenario.Name $Scenario.Tags
    }
    catch {
        $firstStackTraceLine = $_.ScriptStackTrace -split '\r?\n' | & $SafeCommands["Select-Object"] -First 1
        $Pester.AddTestResult("Error occurred in scenario '$($Scenario.Name)'", "Failed", $null, $_.Exception.Message, $firstStackTraceLine, $null, $null, $_)

        # This is a hack to ensure that XML output is valid for now.  The test-suite names come from the Describe attribute of the TestResult
        # objects, and a blank name is invalid NUnit XML.  This will go away when we promote test scripts to have their own test-suite nodes,
        # planned for v4.0
        $Pester.TestResult[-1].Describe = "Error in $($Scenario.Name)"

        $Pester.TestResult[-1] | Write-PesterResult
    }

    Remove-TestDrive
    $Pester.LeaveTestGroup($Scenario.Name, 'Scenario')
    Exit-MockScope
}

function Find-GherkinStep {
    <#
        .SYNOPSIS
            Find a step implmentation that matches a given step

        .DESCRIPTION
            Searches the *.Steps.ps1 files in the BasePath (current working directory, by default)
            Returns the step(s) that match

        .PARAMETER Step
            The text from feature file

        .PARAMETER BasePath
            The path to search for step implementations.

        .EXAMPLE
            ```ps
            Find-GherkinStep -Step 'And the module is imported'

            Step                       Source                      Implementation
            ----                       ------                      --------------
            And the module is imported .\module.Steps.ps1: line 39 ...
            ```
    #>

    [CmdletBinding()]
    param(

        [string]$Step,

        [string]$BasePath = $Pwd
    )

    $OriginalGherkinSteps = $Script:GherkinSteps
    try {
        Import-GherkinSteps $BasePath -Pester $PSCmdlet

        $KeyWord, $StepText = $Step -split "(?<=^(?:Given|When|Then|And|But))\s+"
        if (!$StepText) {
            $StepText = $KeyWord
        }

        & $SafeCommands["Write-Verbose"] "Searching for '$StepText' in $($Script:GherkinSteps.Count) steps"
        $(
            foreach ($StepCommand in $Script:GherkinSteps.Keys) {
                & $SafeCommands["Write-Verbose"] "... $StepCommand"
                if ($StepText -match "^${StepCommand}$") {
                    & $SafeCommands["Write-Verbose"] "Found match: $StepCommand"
                    $StepCommand | & $SafeCommands["Add-Member"] -MemberType NoteProperty -Name MatchCount -Value $Matches.Count -PassThru
                }
            }
        ) | & $SafeCommands["Sort-Object"] MatchCount | & $SafeCommands["Select-Object"] @{
            Name       = 'Step'
            Expression = { $Step }
        }, @{
            Name       = 'Source'
            Expression = { $Script:GherkinSteps["$_"].Source }
        }, @{
            Name       = 'Implementation'
            Expression = { $Script:GherkinSteps["$_"] }
        } -First 1

        # $StepText = "{0} {1} {2}" -f $Step.Keyword.Trim(), $Step.Text, $Script:GherkinSteps[$StepCommand].Source

    }
    finally {
        $Script:GherkinSteps = $OriginalGherkinSteps
    }
}

function Invoke-GherkinStep {
    <#
        .SYNOPSIS
            Run a single gherkin step, given the text from the feature file

        .PARAMETER Step
            The text of the step for matching against regex patterns in step implementations

        .PARAMETER Visible
            If Visible is true, the results of this step will be shown in the test report

        .PARAMETER Pester
            Pester state object. For internal use only

        .PARAMETER ScenarioState
            Gherkin state object. For internal use only

        .PARAMETER TestResultIndexStart
            Used to hold the test result index of the first step of the current scenario. For internal use only
    #>
    [CmdletBinding()]
    param (
        $Step,

        [Switch]$Visible,

        $Pester,

        $ScenarioState,

        [int] $TestResultIndexStart
    )
    if ($Step -is [string]) {
        $KeyWord, $StepText = $Step -split "(?<=^(?:Given|When|Then|And|But))\s+"
        if (!$StepText) {
            $StepText = $KeyWord
            $Keyword = "Step"
        }
        $Step = @{ Text = $StepText; Keyword = $Keyword }
    }
    $DisplayText = "{0} {1}" -f $Step.Keyword.Trim(), $Step.Text

    $PesterErrorRecord = $null
    $Elapsed = $null
    $NamedArguments = @{ }

    try {
        #  Pick the match with the least grouping wildcards in it...
        $StepCommand = $(
            foreach ($StepCommand in $Script:GherkinSteps.Keys) {
                if ($Step.Text -match "^${StepCommand}$") {
                    $StepCommand | & $SafeCommands["Add-Member"] -MemberType NoteProperty -Name MatchCount -Value $Matches.Count -PassThru
                }
            }
        ) | & $SafeCommands["Sort-Object"] MatchCount | & $SafeCommands["Select-Object"] -First 1

        $previousStepsNotSuccessful = $false
        # Iterate over the test results of the previous steps
        for ($i = $TestResultIndexStart; $i -lt ($Pester.TestResult.Count); $i++) {
            $previousTestResult = $Pester.TestResult[$i].Result
            if ($previousTestResult -eq "Failed" -or $previousTestResult -eq "Inconclusive") {
                $previousStepsNotSuccessful = $true
                break
            }
        }
        if (!$StepCommand -or $previousStepsNotSuccessful) {
            $skipMessage = if (!$StepCommand) {
                "Could not find implementation for step!"
            }
            else {
                "Step skipped (previous step did not pass)"
            }
            $PesterErrorRecord = New-PesterErrorRecord -Result Inconclusive -Message $skipMessage -File $Step.Location.Path -Line $Step.Location.Line -LineText $DisplayText
        }
        else {
            $NamedArguments, $Parameters = Get-StepParameters $Step $StepCommand
            $watch = & $SafeCommands["New-Object"] System.Diagnostics.Stopwatch
            $watch.Start()
            try {
                # Invoke-GherkinHook BeforeStep $Step.Text $Step.Tags

                if ($NamedArguments.Count) {
                    if ($NamedArguments.ContainsKey("Table")) {
                        $DisplayText += "..."
                    }
                    $ScriptBlock = { . $Script:GherkinSteps.$StepCommand @NamedArguments @Parameters }
                }
                else {
                    $ScriptBlock = { . $Script:GherkinSteps.$StepCommand @Parameters }
                }
                Set-ScriptBlockScope -ScriptBlock $Script:GherkinSteps.$StepCommand -SessionState $ScenarioState

                Write-ScriptBlockInvocationHint -Hint "Invoke-Gherkin step" -ScriptBlock $Script:GherkinSteps.$StepCommand
                $null = & $ScriptBlock
            }
            catch {
                $PesterErrorRecord = $_
            }
            $watch.Stop()
            $Elapsed = $watch.Elapsed
        }
    }
    catch {
        $PesterErrorRecord = $_
    }

    if ($Pester -and $Visible) {
        for ($p = 0; $p -lt $Parameters.Count; $p++) {
            $NamedArguments."Unnamed-$p" = $Parameters[$p]
        }

        # Normally, PesterErrorRecord is an ErrorRecord. Sometimes, it's an exception which HAS A ErrorRecord
        if ($PesterErrorRecord.ErrorRecord) {
            $PesterErrorRecord = $PesterErrorRecord.ErrorRecord
        }

        ${Pester Result} = ConvertTo-PesterResult -ErrorRecord $PesterErrorRecord

        # For Gherkin, we want to show the step, but not pretend to be a StackTrace
        if (${Pester Result}.Result -eq 'Inconclusive') {
            ${Pester Result}.StackTrace = "At " + $Step.Keyword.Trim() + ', ' + $Step.Location.Path + ': line ' + $Step.Location.Line
        }
        else {
            # Unless we really are a StackTrace...
            ${Pester Result}.StackTrace += "`nFrom " + $Step.Location.Path + ': line ' + $Step.Location.Line
        }
        $Pester.AddTestResult($DisplayText, ${Pester Result}.Result, $Elapsed, ${Pester Result}.FailureMessage, ${Pester Result}.StackTrace, $null, $NamedArguments, $PesterErrorRecord)
        $Pester.TestResult[-1] | Write-PesterResult
    }
}

function Get-StepParameters {
    <#
        .SYNOPSIS
            Internal function for determining parameters for a step implementation
        .PARAMETER Step
            The parsed step from the feature file

        .PARAMETER CommandName
            The text of the best matching step
    #>
    param($Step, $CommandName)
    $Null = $Step.Text -match $CommandName

    $NamedArguments = @{ }
    $Parameters = @{ }
    foreach ($kv in $Matches.GetEnumerator()) {
        switch ($kv.Name -as [int]) {
            0 {
            } # toss zero (where it matches the whole string)
            $null {
                $NamedArguments.($kv.Name) = $ExecutionContext.InvokeCommand.ExpandString($kv.Value)
            }
            default {
                $Parameters.([int]$kv.Name) = $ExecutionContext.InvokeCommand.ExpandString($kv.Value)
            }
        }
    }
    $Parameters = @($Parameters.GetEnumerator() | & $SafeCommands["Sort-Object"] Name | & $SafeCommands["Select-Object"] -ExpandProperty Value)

    # TODO: Convert parsed tables to tables....
    if ($Step.Argument -is [Gherkin.Ast.DataTable]) {
        $NamedArguments.Table = $Step.Argument.Rows | ConvertTo-HashTableArray
    }
    if ($Step.Argument -is [Gherkin.Ast.DocString]) {
        # trim empty matches if we're attaching DocStringArgument
        $Parameters = @( $Parameters | & $SafeCommands["Where-Object"] { $_.Length } ) + $Step.Argument.Content
    }

    return @($NamedArguments, $Parameters)
}

function Convert-Tags {
    <#
        .SYNOPSIS
            Internal function for tagging Gherkin feature files (including inheritance from the feature)
    #>
    [CmdletBinding()]
    param(
        [Parameter(ValueFromPipeline = $true)]
        $InputObject,

        [Parameter(Position = 0)]
        [string[]]$BaseTags = @()
    )
    process {
        # Adapt the Gherkin .Tags property to the way we prefer it...
        [string[]]$Tags = foreach ($tag in $InputObject.Tags | & $SafeCommands['Where-Object'] { $_ }) {
            $tag.Name.TrimStart("@")
        }
        & $SafeCommands["Add-Member"] -MemberType NoteProperty -InputObject $InputObject -Name Tags -Value ([string[]]($Tags + $BaseTags)) -Force
        $InputObject
    }
}

function ConvertTo-HashTableArray {
    <#
        .SYNOPSIS
            Internal function for converting Gherkin AST tables to arrays of hashtables for splatting
    #>
    [CmdletBinding()]
    param(
        [Parameter(ValueFromPipeline = $true)]
        [Gherkin.Ast.TableRow[]]$InputObject
    )
    begin {
        ${Column Names} = @()
        ${Result Table} = @()
    }
    process {
        # Convert the first table row into headers:
        ${InputObject Rows} = @($InputObject)
        if (!${Column Names}) {
            & $SafeCommands["Write-Verbose"] "Reading Names from Header"
            ${InputObject Header}, ${InputObject Rows} = ${InputObject Rows}
            ${Column Names} = @(${InputObject Header}.Cells | & $SafeCommands["Select-Object"] -ExpandProperty Value)
        }

        if ( $null -ne ${InputObject Rows} ) {
            & $SafeCommands["Write-Verbose"] "Processing $(${InputObject Rows}.Length) Rows"
            foreach (${InputObject row} in ${InputObject Rows}) {
                ${Pester Result} = @{ }
                for ($n = 0; $n -lt ${Column Names}.Length; $n++) {
                    ${Pester Result}.Add(${Column Names}[$n], ${InputObject row}.Cells[$n].Value)
                }
                ${Result Table} += @(${Pester Result})
            }
        }
    }
    end {
        ${Result Table}
    }
}

function Get-Translations($TranslationKey, $Language) {
    <#
        .SYNOPSIS
            Internal function to get all translations for a translation key and language

        .PARAMETER TranslationKey
            The key name inside the language in gherkin-languages.json, e.g. 'scenarioOutline'

        .PARAMETER Language
            The used language, e.g. 'en'

        .OUTPUTS
            System.String[] an array of all the translations
    #>
    if (-not (Test-Path variable:Script:GherkinLanguagesJson)) {
        $Script:GherkinLanguagesJson = ConvertFrom-Json2 (Get-Content "${Script:PesterRoot}/lib/Gherkin/gherkin-languages.json" | Out-String)
        # We override the fixed values for 'Describe' and 'Context' of Gherkin.psd1 or Output.ps1 since the language aware keywords
        # (e.g. 'Feature'/'Funktionalität' or 'Scenario'/'Szenario') are provided by Gherkin.dll and we do not want to duplicate them.
        $Script:ReportStrings.Describe = "{0}" # instead of 'Feature: {0}'  or 'Describing {0}'
        $Script:ReportStrings.Context = "{0}" # instead of 'Scenario: {0}' or 'Context {0}'
    }
    $foundTranslations = $Script:GherkinLanguagesJson."$Language"."$TranslationKey"
    if (-not $foundTranslations) {
        Write-Warning "Translation key '$TranslationKey' is invalid"
    }
    return , $foundTranslations
}

function ConvertFrom-Json2([string] $jsonString) {
    <#
        .SYNOPSIS
            Internal function to convert from JSON even for PowerShell 2

        .PARAMETER jsonString
            The JSON content as string

        .OUTPUTS
            the JSON content as array
    #>
    if ($PSVersionTable.PSVersion.Major -le 2) {
        # On PowerShell <= 2 we use JavaScriptSerializer
        Add-Type -Assembly System.Web.Extensions
        return , (New-Object System.Web.Script.Serialization.JavaScriptSerializer).DeserializeObject($jsonString)
    }
    else {
        # On PowerShell > 2 we use the built-in ConvertFrom-Json cmdlet
        return ConvertFrom-Json $jsonString
    }
}

function Get-Translation($TranslationKey, $Language, $Index = -1) {
    <#
        .SYNOPSIS
            Internal function to get the first translation for a translation key and language

        .PARAMETER TranslationKey
            The key name inside the language in gherkin-languages.json, e.g. 'scenarioOutline'

        .PARAMETER Language
            The used language, e.g. 'en'

        .PARAMETER Index
            The index in the array of JSON values
            If -1 is used for Index (the default value), this function will choose the most common translation of the JSON values

        .OUTPUTS
            System.String the chosen translation
    #>
    $translations = (Get-Translations $TranslationKey $Language)
    if (-not $translations) {
        return
    }
    if ($Index -lt 0 -or $Index -ge $translations.Length) {
        # Fallback: if the index is not in range, we choose the most common translation
        # Normally, the most common translation will be found at index one, but under some keys the index is zero.
        $Index = if ($TranslationKey -eq "scenarioOutline" -or $TranslationKey -eq "feature" -or $TranslationKey -eq "examples") {
            0
        }
        else {
            1
        }
    }
    return $translations[$Index]
}

function Test-Keyword($Keyword, $TranslationKey, $Language) {
    <#
        .SYNOPSIS
            Internal function to check if the given keyword matches one of the translations for a translation key and language

        .PARAMETER Keyword
            The keyword, e.g. 'Scenario Outline'

        .PARAMETER TranslationKey
            The key name inside the language in gherkin-languages.json, e.g. 'scenarioOutline'

        .PARAMETER Language
            The used language, e.g. 'en'

        .OUTPUTS
            System.Boolean true, if the keyword matches one of the translations, false otherwise
    #>
    return (Get-Translations $TranslationKey $Language) -contains $Keyword
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUdTvC2KcMXO/CsBfUa5KS01xL
# WCKggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
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
# AJxVSq657FnSWaCvrqVzM3tGXIYwDQYJKoZIhvcNAQEBBQAEggEAfoI3k4sS82hN
# uFh8ZzgBLcj2CsYGME3SyofK/QrnVK9IhWqn3gjPoYnqZ9hsJjH+u5I5re9UEyEW
# qr+6H6lFRfuVaOsK7cTt5Had3eixndwAbr92F9dyuoEDsfjKZ41H3o1NBqgvYcLN
# VQSWDg79wbXmzm67EyHYi4HNjSl+mR85niqS/1CqHBhXJVBTN41BK+Z1ZHpSTeN8
# VIlW2N2VBYKSN5rY17UzV/lKyVwkCJanTn2MH1wADK0h9mE7the/ktbig7vfON23
# R+i9ILIYB4bqS57CndUYFx/tcWp1EGdb4NRed8cwMINjPrOTLTlgP4IgujMz5FhO
# tNdM3F0fbqGCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDAzWjAjBgkqhkiG9w0BCQQx
# FgQUb9LBE/o5giPkcAaD28kWP7K2lYIwDQYJKoZIhvcNAQEBBQAEggEAj0J/KSZC
# IKL6v1b/tPzhT9Mblq2QxQHmSsu/zmGYGkQKsNOZKDOccPEvTVkqNu4ImfbPwbmU
# V86T3cq3UO6kLOyl9bGM72Uwi7t5qmAmxtCcCxN3pT39sh8ZyUmjSwgwByDOVPBj
# HpOYlct9vpdYe9E4EqlRlugVEPJXHhXHQeBqijHPHovvhfM+HJowK98+Iek+p637
# 5qfPMt5FnshPX0em+wftvX6YQiE1YbKr14OoKEaO1jMNdLgv97S6PCtD3lWCgeiz
# 6nsqW2FZCadIwq/j4AOZpjzsqr46tJDNqb3Ge/UketCiYvx1YD3ZFeKzRd8D+puQ
# OPpcgkgPs6/tOQ==
# SIG # End signature block
