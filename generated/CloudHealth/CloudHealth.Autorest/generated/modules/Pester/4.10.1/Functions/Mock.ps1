function Mock {

    <#
.SYNOPSIS
Mocks the behavior of an existing command with an alternate
implementation.

.DESCRIPTION
This creates new behavior for any existing command within the scope of a
Describe or Context block. The function allows you to specify a script block
that will become the command's new behavior.

Optionally, you may create a Parameter Filter which will examine the
parameters passed to the mocked command and will invoke the mocked
behavior only if the values of the parameter values pass the filter. If
they do not, the original command implementation will be invoked instead
of a mock.

You may create multiple mocks for the same command, each using a different
ParameterFilter. ParameterFilters will be evaluated in reverse order of
their creation. The last one created will be the first to be evaluated.
The mock of the first filter to pass will be used. The exception to this
rule are Mocks with no filters. They will always be evaluated last since
they will act as a "catch all" mock.

Mocks can be marked Verifiable. If so, the Assert-VerifiableMock command
can be used to check if all Verifiable mocks were actually called. If any
verifiable mock is not called, Assert-VerifiableMock will throw an
exception and indicate all mocks not called.

If you wish to mock commands that are called from inside a script module,
you can do so by using the -ModuleName parameter to the Mock command. This
injects the mock into the specified module. If you do not specify a
module name, the mock will be created in the same scope as the test script.
You may mock the same command multiple times, in different scopes, as needed.
Each module's mock maintains a separate call history and verified status.

.PARAMETER CommandName
The name of the command to be mocked.

.PARAMETER MockWith
A ScriptBlock specifying the behavior that will be used to mock CommandName.
The default is an empty ScriptBlock.
NOTE: Do not specify param or dynamicparam blocks in this script block.
These will be injected automatically based on the signature of the command
being mocked, and the MockWith script block can contain references to the
mocked commands parameter variables.

.PARAMETER Verifiable
When this is set, the mock will be checked when Assert-VerifiableMock is
called.

.PARAMETER ParameterFilter
An optional filter to limit mocking behavior only to usages of
CommandName where the values of the parameters passed to the command
pass the filter.

This ScriptBlock must return a boolean value. See examples for usage.

.PARAMETER ModuleName
Optional string specifying the name of the module where this command
is to be mocked.  This should be a module that _calls_ the mocked
command; it doesn't necessarily have to be the same module which
originally implemented the command.

.PARAMETER RemoveParameterType
Optional parameter that removes a type of a parameter in the fuction
declaration. This is useful when you are testing a function that has a
strongly typed parameter but you are not able to create an object of the
required type.

This parameter applies only to the first definintion of a mock within the
current scope. If there are multiple mocks with the same name, any subsequent
configuration of parameters will be ingored, including parameter validation
described below.

.PARAMETER RemoveParameterValidation
Optional parameter that removes validation from a parameter in the fuction
declaration. This is useful when you are testing a function that validates
it's input, but you are unable to satisfy the validation.

This parameter applies only to the first definintion of a mock within the
current scope. If there are multiple mocks with the same name, any subsequent
configuration of parameters will be ingored, including parameter types described
above.

.EXAMPLE
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} }

Using this Mock, all calls to Get-ChildItem will return a hashtable with a
FullName property returning "A_File.TXT"

.EXAMPLE
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} } -ParameterFilter { $Path -and $Path.StartsWith($env:temp) }

This Mock will only be applied to Get-ChildItem calls within the user's temp directory.

.EXAMPLE
Mock Set-Content {} -Verifiable -ParameterFilter { $Path -eq "some_path" -and $Value -eq "Expected Value" }

When this mock is used, if the Mock is never invoked and Assert-VerifiableMock is called, an exception will be thrown. The command behavior will do nothing since the ScriptBlock is empty.

.EXAMPLE
```ps
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} } -ParameterFilter { $Path -and $Path.StartsWith($env:temp\1) }
Mock Get-ChildItem { return @{FullName = "B_File.TXT"} } -ParameterFilter { $Path -and $Path.StartsWith($env:temp\2) }
Mock Get-ChildItem { return @{FullName = "C_File.TXT"} } -ParameterFilter { $Path -and $Path.StartsWith($env:temp\3) }
```

Multiple mocks of the same command may be used. The parameter filter determines which is invoked. Here, if Get-ChildItem is called on the "2" directory of the temp folder, then B_File.txt will be returned.

.EXAMPLE
```ps
Mock Get-ChildItem { return @{FullName="B_File.TXT"} } -ParameterFilter { $Path -eq "$env:temp\me" }
Mock Get-ChildItem { return @{FullName="A_File.TXT"} } -ParameterFilter { $Path -and $Path.StartsWith($env:temp) }

Get-ChildItem $env:temp\me
```

Here, both mocks could apply since both filters will pass. A_File.TXT will be returned because it was the most recent Mock created.

.EXAMPLE
```ps
Mock Get-ChildItem { return @{FullName = "B_File.TXT"} } -ParameterFilter { $Path -eq "$env:temp\me" }
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} }

Get-ChildItem c:\windows
```

Here, A_File.TXT will be returned. Since no filter was specified, it will apply to any call to Get-ChildItem that does not pass another filter.

.EXAMPLE
```ps
Mock Get-ChildItem { return @{FullName = "B_File.TXT"} } -ParameterFilter { $Path -eq "$env:temp\me" }
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} }

Get-ChildItem $env:temp\me
```

Here, B_File.TXT will be returned. Even though the filterless mock was created more recently. This illustrates that filterless Mocks are always evaluated last regardless of their creation order.

.EXAMPLE
Mock Get-ChildItem { return @{FullName = "A_File.TXT"} } -ModuleName MyTestModule

Using this Mock, all calls to Get-ChildItem from within the MyTestModule module
will return a hashtable with a FullName property returning "A_File.TXT"

.EXAMPLE
```ps
Get-Module -Name ModuleMockExample | Remove-Module
New-Module -Name ModuleMockExample  -ScriptBlock {
    function Hidden { "Internal Module Function" }
    function Exported { Hidden }

    Export-ModuleMember -Function Exported
} | Import-Module -Force

Describe "ModuleMockExample" {

    It "Hidden function is not directly accessible outside the module" {
        { Hidden } | Should -Throw
    }

    It "Original Hidden function is called" {
        Exported | Should -Be "Internal Module Function"
    }

    It "Hidden is replaced with our implementation" {
        Mock Hidden { "Mocked" } -ModuleName ModuleMockExample
        Exported | Should -Be "Mocked"
    }
}
```

This example shows how calls to commands made from inside a module can be
mocked by using the -ModuleName parameter.

.LINK
https://pester.dev/docs/commands/Assert-MockCalled

.LINK
https://pester.dev/docs/commands/Assert-VerifiableMock

.LINK
https://pester.dev/docs/commands/Describe

.LINK
https://pester.dev/docs/commands/Context

.LINK
https://pester.dev/docs/commands/It

.LINK
https://pester.dev/docs/commands/Should

.LINK
https://pester.dev/docs/usage/mocking

#>
    [CmdletBinding()]
    param(
        [string]$CommandName,
        [ScriptBlock]$MockWith = { },
        [switch]$Verifiable,
        [ScriptBlock]$ParameterFilter = { $True },
        [string]$ModuleName,
        [string[]]$RemoveParameterType,
        [string[]]$RemoveParameterValidation
    )

    Assert-DescribeInProgress -CommandName Mock
    Set-ScriptBlockHint -Hint "Unbound MockWith - Captured in Mock" -ScriptBlock $MockWith
    Set-ScriptBlockHint -Hint "Unbound ParameterFilter - Captured in Mock" -ScriptBlock $ParameterFilter

    $contextInfo = Validate-Command $CommandName $ModuleName
    $CommandName = $contextInfo.Command.Name

    if ($contextInfo.Session.Module -and $contextInfo.Session.Module.Name) {
        $ModuleName = $contextInfo.Session.Module.Name
    }
    else {
        $ModuleName = ''
    }

    if (Test-IsClosure -ScriptBlock $MockWith) {
        # If the user went out of their way to call GetNewClosure(), go ahead and leave the block bound to that
        # dynamic module's scope.
        $mockWithCopy = $MockWith
    }
    else {
        Write-Hint "Unbinding ScriptBlock from '$(Get-ScriptBlockHint $MockWith)'"
        $mockWithCopy = [scriptblock]::Create($MockWith.ToString())
        Set-ScriptBlockHint -ScriptBlock $mockWithCopy -Hint "Unbound ScriptBlock from Mock"
        Set-ScriptBlockScope -ScriptBlock $mockWithCopy -SessionState $contextInfo.Session
    }

    $block = @{
        Mock       = $mockWithCopy
        Filter     = $ParameterFilter
        Verifiable = $Verifiable
        Scope      = $pester.CurrentTestGroup
    }

    $mock = $mockTable["$ModuleName||$CommandName"]

    if (-not $mock) {
        $metadata = $null
        $originalMetadata = $null
        $cmdletBinding = ''
        $paramBlock = ''
        $dynamicParamBlock = ''
        $dynamicParamScriptBlock = $null

        if ($contextInfo.Command.psobject.Properties['ScriptBlock'] -or $contextInfo.Command.CommandType -eq 'Cmdlet') {
            $metadata = [System.Management.Automation.CommandMetaData]$contextInfo.Command
            $null = $metadata.Parameters.Remove('Verbose')
            $null = $metadata.Parameters.Remove('Debug')
            $null = $metadata.Parameters.Remove('ErrorAction')
            $null = $metadata.Parameters.Remove('WarningAction')
            $null = $metadata.Parameters.Remove('ErrorVariable')
            $null = $metadata.Parameters.Remove('WarningVariable')
            $null = $metadata.Parameters.Remove('OutVariable')
            $null = $metadata.Parameters.Remove('OutBuffer')

            # Some versions of PowerShell may include dynamic parameters here
            # We will filter them out and add them at the end to be
            # compatible with both earlier and later versions
            $dynamicParams = $metadata.Parameters.Values | & $SafeCommands['Where-Object'] { $_.IsDynamic }
            if ($null -ne $dynamicParams) {
                $dynamicparams | & $SafeCommands['ForEach-Object'] { $null = $metadata.Parameters.Remove($_.name) }
            }

            $cmdletBinding = [Management.Automation.ProxyCommand]::GetCmdletBindingAttribute($metadata)
            if ($global:PSVersionTable.PSVersion.Major -ge 3 -and $contextInfo.Command.CommandType -eq 'Cmdlet') {
                if ($cmdletBinding -ne '[CmdletBinding()]') {
                    $cmdletBinding = $cmdletBinding.Insert($cmdletBinding.Length - 2, ',')
                }
                $cmdletBinding = $cmdletBinding.Insert($cmdletBinding.Length - 2, 'PositionalBinding=$false')
            }

            # Will modify $metadata object in-place
            $originalMetadata = $metadata
            $metadata = Repair-ConflictingParameters -Metadata $metadata -RemoveParameterType $RemoveParameterType -RemoveParameterValidation $RemoveParameterValidation
            $paramBlock = [Management.Automation.ProxyCommand]::GetParamBlock($metadata)

            if ($contextInfo.Command.CommandType -eq 'Cmdlet') {
                $dynamicParamBlock = "dynamicparam { Get-MockDynamicParameter -CmdletName '$($contextInfo.Command.Name)' -Parameters `$PSBoundParameters }"
            }
            else {
                $dynamicParamStatements = Get-DynamicParamBlock -ScriptBlock $contextInfo.Command.ScriptBlock

                if ($dynamicParamStatements -match '\S') {
                    $metadataSafeForDynamicParams = [System.Management.Automation.CommandMetaData]$contextInfo.Command
                    foreach ($param in $metadataSafeForDynamicParams.Parameters.Values) {
                        $param.ParameterSets.Clear()
                    }

                    $paramBlockSafeForDynamicParams = [System.Management.Automation.ProxyCommand]::GetParamBlock($metadataSafeForDynamicParams)
                    $comma = if ($metadataSafeForDynamicParams.Parameters.Count -gt 0) {
                        ','
                    }
                    else {
                        ''
                    }
                    $dynamicParamBlock = "dynamicparam { Get-MockDynamicParameter -ModuleName '$ModuleName' -FunctionName '$CommandName' -Parameters `$PSBoundParameters -Cmdlet `$PSCmdlet }"

                    $code = @"
                        $cmdletBinding
                        param(
                            [object] `${P S Cmdlet}$comma
                            $paramBlockSafeForDynamicParams
                        )

                        `$PSCmdlet = `${P S Cmdlet}

                        $dynamicParamStatements
"@

                    $dynamicParamScriptBlock = [scriptblock]::Create($code)

                    $sessionStateInternal = Get-ScriptBlockScope -ScriptBlock $contextInfo.Command.ScriptBlock

                    if ($null -ne $sessionStateInternal) {
                        Set-ScriptBlockScope -ScriptBlock $dynamicParamScriptBlock -SessionStateInternal $sessionStateInternal
                    }
                }
            }
        }

        $EscapeSingleQuotedStringContent =
        if ($global:PSVersionTable.PSVersion.Major -ge 5) {
            { [System.Management.Automation.Language.CodeGeneration]::EscapeSingleQuotedStringContent($args[0]) }
        }
        else {
            { $args[0] -replace "['‘’‚‛]", '$&$&' }
        }

        $newContent = & $SafeCommands['Get-Content'] function:\MockPrototype
        $newContent = $newContent -replace '#FUNCTIONNAME#', (& $EscapeSingleQuotedStringContent $CommandName)
        $newContent = $newContent -replace '#MODULENAME#', (& $EscapeSingleQuotedStringContent $ModuleName)

        $canCaptureArgs = 'true'
        if ($contextInfo.Command.CommandType -eq 'Cmdlet' -or
            ($contextInfo.Command.CommandType -eq 'Function' -and $contextInfo.Command.CmdletBinding)) {
            $canCaptureArgs = 'false'
        }
        $newContent = $newContent -replace '#CANCAPTUREARGS#', $canCaptureArgs

        $code = @"
            $cmdletBinding
            param ( $paramBlock )
            $dynamicParamBlock
            begin
            {
                `${mock call state} = @{}
                $($newContent -replace '#BLOCK#', 'Begin' -replace '#INPUT#')
            }

            process
            {
                $($newContent -replace '#BLOCK#', 'Process' -replace '#INPUT#', '-InputObject @($input)')
            }

            end
            {
                $($newContent -replace '#BLOCK#', 'End' -replace '#INPUT#')
            }
"@

        $mockScript = [scriptblock]::Create($code)

        $mock = @{
            OriginalCommand         = $contextInfo.Command
            Blocks                  = @()
            CommandName             = $CommandName
            SessionState            = $contextInfo.Session
            Scope                   = $pester.CurrentTestGroup
            PesterState             = $pester
            Metadata                = $metadata
            OriginalMetadata        = $originalMetadata
            CallHistory             = @()
            DynamicParamScriptBlock = $dynamicParamScriptBlock
            Aliases                 = @()
            BootstrapFunctionName   = 'PesterMock_' + [Guid]::NewGuid().Guid
        }

        $mockTable["$ModuleName||$CommandName"] = $mock

        Invoke-CommonSetupInMockScope -Mock $mock -MockScript $MockScript -CommandName $CommandName
    }

    if ($null -ne $mock.Metadata -and $null -ne $block.Filter) {
        $block.Filter = New-BlockWithoutParameterAliases -Metadata $mock.Metadata -Block $block.Filter
    }

    $mock.Blocks = @(
        # trim the script to avoid errors when formatting adds spaces around the default
        # filter script, this only affects powershell v2, newer powershell trims it
        # automatically
        $mock.Blocks | & $SafeCommands['Where-Object'] { $_.Filter.ToString().Trim() -eq '$True' }
        if ($block.Filter.ToString().Trim() -eq '$True') {
            $block
        }

        $mock.Blocks | & $SafeCommands['Where-Object'] { $_.Filter.ToString().Trim() -ne '$True' }
        if ($block.Filter.ToString().Trim() -ne '$True') {
            $block
        }
    )
}


function Assert-VerifiableMock {
    <#
.SYNOPSIS
Checks if any Verifiable Mock has not been invoked. If so, this will throw an exception.

.DESCRIPTION
This can be used in tandem with the -Verifiable switch of the Mock
function. Mock can be used to mock the behavior of an existing command
and optionally take a -Verifiable switch. When Assert-VerifiableMock
is called, it checks to see if any Mock marked Verifiable has not been
invoked. If any mocks have been found that specified -Verifiable and
have not been invoked, an exception will be thrown.

.EXAMPLE
```ps
Mock Set-Content {} -Verifiable -ParameterFilter {$Path -eq "some_path" -and $Value -eq "Expected Value"}

{ ...some code that never calls Set-Content some_path -Value "Expected Value"... }

Assert-VerifiableMock
```

This will throw an exception and cause the test to fail.

.EXAMPLE
```ps
Mock Set-Content {} -Verifiable -ParameterFilter {$Path -eq "some_path" -and $Value -eq "Expected Value"}

Set-Content some_path -Value "Expected Value"

Assert-VerifiableMock
```

This will not throw an exception because the mock was invoked.

#>
    [CmdletBinding()]param()
    Assert-DescribeInProgress -CommandName Assert-VerifiableMock

    $unVerified = @{ }
    $mockTable.Keys | & $SafeCommands['ForEach-Object'] {
        $m = $_;

        $mockTable[$m].blocks |
        & $SafeCommands['Where-Object'] { $_.Verifiable } |
        & $SafeCommands['ForEach-Object'] { $unVerified[$m] = $_ }
    }
    if ($unVerified.Count -gt 0) {
        foreach ($mock in $unVerified.Keys) {
            $array = $mock -split '\|\|'
            $function = $array[1]
            $module = $array[0]

            $message = "$([System.Environment]::NewLine) Expected $function "
            if ($module) {
                $message += "in module $module "
            }
            $message += "to be called with $($unVerified[$mock].Filter)"
        }
        throw $message
    }
}

function Assert-MockCalled {
    <#
.SYNOPSIS
Checks if a Mocked command has been called a certain number of times
and throws an exception if it has not.

.DESCRIPTION
This command verifies that a mocked command has been called a certain number
of times.  If the call history of the mocked command does not match the parameters
passed to Assert-MockCalled, Assert-MockCalled will throw an exception.

.PARAMETER CommandName
The mocked command whose call history should be checked.

.PARAMETER ModuleName
The module where the mock being checked was injected.  This is optional,
and must match the ModuleName that was used when setting up the Mock.

.PARAMETER Times
The number of times that the mock must be called to avoid an exception
from throwing.

.PARAMETER Exactly
If this switch is present, the number specified in Times must match
exactly the number of times the mock has been called. Otherwise it
must match "at least" the number of times specified.  If the value
passed to the Times parameter is zero, the Exactly switch is implied.

.PARAMETER ParameterFilter
An optional filter to qualify which calls should be counted. Only those
calls to the mock whose parameters cause this filter to return true
will be counted.

.PARAMETER ExclusiveFilter
Like ParameterFilter, except when you use ExclusiveFilter, and there
were any calls to the mocked command which do not match the filter,
an exception will be thrown.  This is a convenient way to avoid needing
to have two calls to Assert-MockCalled like this:

Assert-MockCalled SomeCommand -Times 1 -ParameterFilter { $something -eq $true }
Assert-MockCalled SomeCommand -Times 0 -ParameterFilter { $something -ne $true }

.PARAMETER Scope
An optional parameter specifying the Pester scope in which to check for
calls to the mocked command. For RSpec style tests, Assert-MockCalled will find
all calls to the mocked command in the current Context block (if present),
or the current Describe block (if there is no active Context), by default. Valid
values are Describe, Context and It. If you use a scope of Describe or
Context, the command will identify all calls to the mocked command in the
current Describe / Context block, as well as all child scopes of that block.

For Gherkin style tests, Assert-MockCalled will find all calls to the mocked
command in the current Scenario block or the current Feature block (if there is
no active Scenario), by default. Valid values for Gherkin style tests are Feature
and Scenario. If you use a scope of Feature or Scenario, the command will identify
all calls to the mocked command in the current Feature / Scenario block, as well
as all child scopes of that block.

.EXAMPLE
```ps
PS C:\> Mock Set-Content {}

{... Some Code ...}

PS C:\> Assert-MockCalled Set-Content
```

This will throw an exception and cause the test to fail if Set-Content is not called in Some Code.

.EXAMPLE
```ps
PS C:\> Mock Set-Content -parameterFilter {$path.StartsWith("$env:temp\")}

{... Some Code ...}

PS C:\> Assert-MockCalled Set-Content 2 { $path -eq "$env:temp\test.txt" }
```

This will throw an exception if some code calls Set-Content on $path=$env:temp\test.txt less than 2 times

.EXAMPLE
```ps
PS C:\> Mock Set-Content {}

{... Some Code ...}

PS C:\> Assert-MockCalled Set-Content 0
```

This will throw an exception if some code calls Set-Content at all

.EXAMPLE
```ps
PS C:\> Mock Set-Content {}

{... Some Code ...}

PS C:\> Assert-MockCalled Set-Content -Exactly 2
```

This will throw an exception if some code does not call Set-Content Exactly two times.

.EXAMPLE
```ps
Describe 'Assert-MockCalled Scope behavior' {
    Mock Set-Content { }

    It 'Calls Set-Content at least once in the It block' {
        {... Some Code ...}

        Assert-MockCalled Set-Content -Exactly 0 -Scope It
    }
}
```

Checks for calls only within the current It block.

.EXAMPLE
```ps
Describe 'Describe' {
    Mock -ModuleName SomeModule Set-Content { }

    {... Some Code ...}

    It 'Calls Set-Content at least once in the Describe block' {
        Assert-MockCalled -ModuleName SomeModule Set-Content
    }
}
```

Checks for calls to the mock within the SomeModule module.  Note that both the Mock
and Assert-MockCalled commands use the same module name.

.EXAMPLE
Assert-MockCalled Get-ChildItem -ExclusiveFilter { $Path -eq 'C:\' }

Checks to make sure that Get-ChildItem was called at least one time with
the -Path parameter set to 'C:\', and that it was not called at all with
the -Path parameter set to any other value.

.NOTES
The parameter filter passed to Assert-MockCalled does not necessarily have to match the parameter filter
(if any) which was used to create the Mock.  Assert-MockCalled will find any entry in the command history
which matches its parameter filter, regardless of how the Mock was created.  However, if any calls to the
mocked command are made which did not match any mock's parameter filter (resulting in the original command
being executed instead of a mock), these calls to the original command are not tracked in the call history.
In other words, Assert-MockCalled can only be used to check for calls to the mocked implementation, not
to the original.

#>

    [CmdletBinding(DefaultParameterSetName = 'ParameterFilter')]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$CommandName,

        [Parameter(Position = 1)]
        [int]$Times = 1,

        [Parameter(ParameterSetName = 'ParameterFilter', Position = 2)]
        [ScriptBlock]$ParameterFilter = { $True },

        [Parameter(ParameterSetName = 'ExclusiveFilter', Mandatory = $true)]
        [scriptblock] $ExclusiveFilter,

        [Parameter(Position = 3)]
        [string] $ModuleName,

        [Parameter(Position = 4)]
        [ValidateScript( {
                if ([uint32]::TryParse($_, [ref] $null) -or
                    $_ -eq 'Describe' -or
                    $_ -eq 'Context' -or
                    $_ -eq 'It' -or
                    $_ -eq 'Feature' -or
                    $_ -eq 'Scenario') {
                    return $true
                }

                throw "Scope argument must either be an unsigned integer, or one of the words 'Describe', 'Context', 'It', 'Feature', or 'Scenario'."
            })]
        [string] $Scope,

        [switch]$Exactly
    )

    if ($PSCmdlet.ParameterSetName -eq 'ParameterFilter') {
        $filter = $ParameterFilter
        $filterIsExclusive = $false
    }
    else {
        $filter = $ExclusiveFilter
        $filterIsExclusive = $true
    }

    Assert-DescribeInProgress -CommandName Assert-MockCalled

    if (-not $PSBoundParameters.ContainsKey('ModuleName') -and $null -ne $pester.SessionState.Module) {
        $ModuleName = $pester.SessionState.Module.Name
    }

    $contextInfo = Validate-Command $CommandName $ModuleName
    $CommandName = $contextInfo.Command.Name

    $mock = $script:mockTable["$ModuleName||$CommandName"]

    $moduleMessage = ''
    if ($ModuleName) {
        $moduleMessage = " in module $ModuleName"
    }

    if (-not $mock) {
        throw "You did not declare a mock of the $commandName Command${moduleMessage}."
    }

    if (-not $PSBoundParameters.ContainsKey('Scope')) {
        $scope = 1
    }

    $matchingCalls = & $SafeCommands['New-Object'] System.Collections.ArrayList
    $nonMatchingCalls = & $SafeCommands['New-Object'] System.Collections.ArrayList

    foreach ($historyEntry in $mock.CallHistory) {
        if (-not (Test-MockCallScope -CallScope $historyEntry.Scope -DesiredScope $Scope)) {
            continue
        }

        $params = @{
            ScriptBlock     = $filter
            BoundParameters = $historyEntry.BoundParams
            ArgumentList    = $historyEntry.Args
            Metadata        = $mock.Metadata
        }

        if ($null -ne $mock.Metadata -and $null -ne $params.ScriptBlock) {
            $params.ScriptBlock = New-BlockWithoutParameterAliases -Metadata $mock.Metadata -Block $params.ScriptBlock
        }

        if (Test-ParameterFilter @params) {
            $null = $matchingCalls.Add($historyEntry)
        }
        else {
            $null = $nonMatchingCalls.Add($historyEntry)
        }
    }

    $lineText = $MyInvocation.Line.TrimEnd("$([System.Environment]::NewLine)")
    $line = $MyInvocation.ScriptLineNumber

    if ($matchingCalls.Count -ne $times -and ($Exactly -or ($times -eq 0))) {
        $failureMessage = "Expected ${commandName}${moduleMessage} to be called $times times exactly but was called $($matchingCalls.Count) times"
        throw ( New-ShouldErrorRecord -Message $failureMessage -Line $line -LineText $lineText)
    }
    elseif ($matchingCalls.Count -lt $times) {
        $failureMessage = "Expected ${commandName}${moduleMessage} to be called at least $times times but was called $($matchingCalls.Count) times"
        throw ( New-ShouldErrorRecord -Message $failureMessage -Line $line -LineText $lineText)
    }
    elseif ($filterIsExclusive -and $nonMatchingCalls.Count -gt 0) {
        $failureMessage = "Expected ${commandName}${moduleMessage} to only be called with with parameters matching the specified filter, but $($nonMatchingCalls.Count) non-matching calls were made"
        throw ( New-ShouldErrorRecord -Message $failureMessage -Line $line -LineText $lineText)
    }
}

function Test-MockCallScope {
    [CmdletBinding()]
    param (
        [object] $CallScope,
        [string] $DesiredScope
    )

    if ($null -eq $CallScope) {
        # This indicates a call from the current test case ("It" block), which always passes Test-MockCallScope
        return $true
    }

    $testGroups = $pester.TestGroups
    [Array]::Reverse($testGroups)

    $target = 0
    $isNumberedScope = [int]::TryParse($DesiredScope, [ref] $target)

    # The Describe / Context stuff here is for backward compatibility.  May be deprecated / removed in the future.
    $actualScopeNumber = -1
    $describe = -1
    $context = -1

    for ($i = 0; $i -lt $testGroups.Count; $i++) {
        if ($CallScope -eq $testGroups[$i]) {
            $actualScopeNumber = $i
            if ($isNumberedScope) {
                break
            }
        }

        if ($describe -lt 0 -and 'Describe', 'Feature' -contains $testGroups[$i].Hint) {
            $describe = $i
        }
        if ($context -lt 0 -and 'Context', 'Scenario' -contains $testGroups[$i].Hint) {
            $context = $i
        }
    }

    if ($actualScopeNumber -lt 0) {
        # this should never happen; if we get here, it's a Pester bug.

        throw "Pester error: Corrupted mock call history table."
    }

    if ($isNumberedScope) {
        # For this, we consider scope 0 to be the current test case / It block, scope 1 to be the first Test Group up the stack, etc.
        # $actualScopeNumber currently off by one from that scale (zero-indexed for test groups only; we already checked for the 0 case
        # farther up, which only applies if $CallScope is $null).
        return $target -gt $actualScopeNumber
    }
    else {
        if ('Describe', 'Feature' -contains $DesiredScope) {
            return $describe -ge $actualScopeNumber
        }
        if ('Context', 'Scenario' -contains $DesiredScope) {
            return $context -ge $actualScopeNumber
        }
    }

    return $false
}

function Exit-MockScope {
    param (
        [switch] $ExitTestCaseOnly
    )

    if ($null -eq $mockTable) {
        return
    }

    $removeMockStub =
    {
        param (
            [string] $CommandName,
            [string[]] $Aliases
        )

        if ($ExecutionContext.InvokeProvider.Item.Exists("Function:\$CommandName", $true, $true)) {
            $ExecutionContext.InvokeProvider.Item.Remove("Function:\$CommandName", $false, $true, $true)
        }

        foreach ($alias in $Aliases) {
            if ($ExecutionContext.InvokeProvider.Item.Exists("Alias:$alias", $true, $true)) {
                $ExecutionContext.InvokeProvider.Item.Remove("Alias:$alias", $false, $true, $true)
            }
        }
    }

    $mockKeys = [string[]]$mockTable.Keys

    foreach ($mockKey in $mockKeys) {
        $mock = $mockTable[$mockKey]

        $shouldRemoveMock = (-not $ExitTestCaseOnly) -and (ShouldRemoveMock -Mock $mock -ActivePesterState $pester)
        if ($shouldRemoveMock) {
            $null = Invoke-InMockScope -SessionState $mock.SessionState -ScriptBlock $removeMockStub -ArgumentList $mock.BootstrapFunctionName, $mock.Aliases
            $mockTable.Remove($mockKey)
        }
        elseif ($mock.PesterState -eq $pester) {
            if (-not $ExitTestCaseOnly) {
                $mock.Blocks = @($mock.Blocks | & $SafeCommands['Where-Object'] { $_.Scope -ne $pester.CurrentTestGroup })
            }

            $testGroups = @($pester.TestGroups)

            $parentTestGroup = $null

            if ($testGroups.Count -gt 1) {
                $parentTestGroup = $testGroups[-2]
            }

            foreach ($historyEntry in $mock.CallHistory) {
                if ($ExitTestCaseOnly) {
                    if ($null -eq $historyEntry.Scope) {
                        $historyEntry.Scope = $pester.CurrentTestGroup
                    }
                }
                elseif ($parentTestGroup) {
                    if ($historyEntry.Scope -eq $pester.CurrentTestGroup) {
                        $historyEntry.Scope = $parentTestGroup
                    }
                }
            }
        }
    }
}

function ShouldRemoveMock($Mock, $ActivePesterState) {
    if ($ActivePesterState -ne $mock.PesterState) {
        return $false
    }
    if ($mock.Scope -eq $ActivePesterState.CurrentTestGroup) {
        return $true
    }

    # These two should conditions should _probably_ never happen, because the above condition should
    # catch it, but just in case:
    if ($ActivePesterState.TestGroups.Count -eq 1) {
        return $true
    }
    if ($ActivePesterState.TestGroups[-2].Hint -eq 'Root') {
        return $true
    }

    return $false
}

function Validate-Command([string]$CommandName, [string]$ModuleName) {
    $module = $null
    $command = $null

    $scriptBlock = {
        $command = $ExecutionContext.InvokeCommand.GetCommand($args[0], 'All')
        while ($null -ne $command -and $command.CommandType -eq [System.Management.Automation.CommandTypes]::Alias) {
            $command = $command.ResolvedCommand
        }

        return $command
    }

    if ($ModuleName) {
        $module = Get-ScriptModule -ModuleName $ModuleName -ErrorAction Stop
        $command = & $module $scriptBlock $CommandName
    }

    $session = $pester.SessionState

    if (-not $command) {
        Set-ScriptBlockScope -ScriptBlock $scriptBlock -SessionState $session
        $command = & $scriptBlock $commandName
    }

    if (-not $command) {
        throw ([System.Management.Automation.CommandNotFoundException] "Could not find Command $commandName")
    }

    if ($module) {
        $session = Set-SessionStateHint -PassThru  -Hint "Module - $($module.Name)" -SessionState ( & $module { $ExecutionContext.SessionState } )
    }

    $hash = @{Command = $command; Session = $session }

    if ($command.CommandType -eq 'Function') {
        foreach ($mock in $mockTable.Values) {
            if ($command.Name -eq $mock.BootstrapFunctionName) {
                return @{
                    Command = $mock.OriginalCommand
                    Session = $mock.SessionState
                }
            }
        }
    }

    return $hash
}

function MockPrototype {
    if ($PSVersionTable.PSVersion.Major -ge 3) {
        [string] ${ignore preference} = 'Ignore'
    }
    else {
        [string] ${ignore preference} = 'SilentlyContinue'
    }

    #todo: remove pester\safegetcommand and use .net calls to get the variable instead?
    ${get Variable Command} = & (Pester\SafeGetCommand) -Name Get-Variable -Module Microsoft.PowerShell.Utility -CommandType Cmdlet

    [object] ${a r g s} = $null
    if (${#CANCAPTUREARGS#}) {
        ${a r g s} = & ${get Variable Command} -Name args -ValueOnly -Scope Local -ErrorAction ${ignore preference}
    }
    if ($null -eq ${a r g s}) {
        ${a r g s} = @()
    }

    ${p s cmdlet} = & ${get Variable Command} -Name PSCmdlet -ValueOnly -Scope Local -ErrorAction ${ignore preference}

    #todo: Add session state hint - once we are calling this in the Pester state
    ${session state} = if (${p s cmdlet}) {
        ${p s cmdlet}.SessionState
    }

    # todo: lookup Pester state and invoke it in there to remote Invoke-Mock from the public Api
    # @{mock call state} initialization is injected only into the begin block by the code that uses this prototype.
    Invoke-Mock -CommandName '#FUNCTIONNAME#' -ModuleName '#MODULENAME#' -BoundParameters $PSBoundParameters -ArgumentList ${a r g s} -CallerSessionState ${session state} -FromBlock '#BLOCK#' -MockCallState ${mock call state} #INPUT#
}

function Invoke-Mock {
    <#
        .SYNOPSIS
        This command is used by Pester's Mocking framework.  You do not need to call it directly.
    #>

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $CommandName,

        [Parameter(Mandatory = $true)]
        [hashtable] $MockCallState,

        [string]
        $ModuleName,

        [hashtable]
        $BoundParameters = @{ },

        [object[]]
        $ArgumentList = @(),

        [object] $CallerSessionState,

        [ValidateSet('Begin', 'Process', 'End')]
        [string] $FromBlock,

        [object] $InputObject
    )

    $detectedModule = $ModuleName
    $mock = FindMock -CommandName $CommandName -ModuleName ([ref]$detectedModule)

    if ($null -eq $mock) {
        # If this ever happens, it's a bug in Pester.  The scriptBlock that calls Invoke-Mock should be removed at the same time as the entry in the mock table.
        throw "Internal error detected:  Mock for '$CommandName' in module '$ModuleName' was called, but does not exist in the mock table."
    }

    switch ($FromBlock) {
        Begin {
            $MockCallState['InputObjects'] = & $SafeCommands['New-Object'] System.Collections.ArrayList
            $MockCallState['ShouldExecuteOriginalCommand'] = $false
            $MockCallState['BeginBoundParameters'] = $BoundParameters.Clone()
            $MockCallState['BeginArgumentList'] = $ArgumentList

            return
        }

        Process {
            $block = $null
            if ($detectedModule -eq $ModuleName) {
                $block = FindMatchingBlock -Mock $mock -BoundParameters $BoundParameters -ArgumentList $ArgumentList
            }

            if ($null -ne $block) {
                ExecuteBlock -Block $block `
                    -CommandName $CommandName `
                    -ModuleName $ModuleName `
                    -BoundParameters $BoundParameters `
                    -ArgumentList $ArgumentList `
                    -Mock $mock

                return
            }
            else {
                $MockCallState['ShouldExecuteOriginalCommand'] = $true
                if ($null -ne $InputObject) {
                    $null = $MockCallState['InputObjects'].AddRange(@($InputObject))
                }

                return
            }
        }

        End {
            if ($MockCallState['ShouldExecuteOriginalCommand']) {
                $MockCallState['BeginBoundParameters'] = Reset-ConflictingParameters -BoundParameters $MockCallState['BeginBoundParameters']

                if ($MockCallState['InputObjects'].Count -gt 0) {
                    $scriptBlock = {
                        param ($Command, $ArgumentList, $BoundParameters, $InputObjects)
                        $InputObjects | & $Command @ArgumentList @BoundParameters
                    }
                }
                else {
                    $scriptBlock = {
                        param ($Command, $ArgumentList, $BoundParameters, $InputObjects)
                        & $Command @ArgumentList @BoundParameters
                    }
                }

                $state = if ($CallerSessionState) {
                    $CallerSessionState
                }
                else {
                    $mock.SessionState
                }

                Set-ScriptBlockScope -ScriptBlock $scriptBlock -SessionState $state

                # In order to mock Set-Variable correctly we need to write the variable
                # two scopes above
                if ( $mock.OriginalCommand -like "Set-Variable" ) {
                    if ($MockCallState['BeginBoundParameters'].Keys -notcontains "Scope") {
                        $MockCallState['BeginBoundParameters'].Add( "Scope", 2)
                    }
                    # local is the same as scope 0, in that case we also write to scope 2
                    elseif ("Local", "0" -contains $MockCallState['BeginBoundParameters'].Scope) {
                        $MockCallState['BeginBoundParameters'].Scope = 2
                    }
                    elseif ($MockCallState['BeginBoundParameters'].Scope -match "\d+") {
                        $MockCallState['BeginBoundParameters'].Scope = 2 + $matches[0]
                    }
                    else {
                        # not sure what the user did, but we won't change it
                    }
                }

                Write-ScriptBlockInvocationHint -Hint "Mock - Original Command" -ScriptBlock $scriptBlock
                & $scriptBlock -Command $mock.OriginalCommand `
                    -ArgumentList $MockCallState['BeginArgumentList'] `
                    -BoundParameters $MockCallState['BeginBoundParameters'] `
                    -InputObjects $MockCallState['InputObjects']
            }
        }
    }
}

function FindMock {
    param (
        [string] $CommandName,
        [ref] $ModuleName
    )

    $mock = $mockTable["$($ModuleName.Value)||$CommandName"]

    if ($null -eq $mock) {
        $mock = $mockTable["||$CommandName"]
        if ($null -ne $mock) {
            $ModuleName.Value = ''
        }
    }

    return $mock
}

function FindMatchingBlock {
    param (
        [object] $Mock,
        [hashtable] $BoundParameters = @{ },
        [object[]] $ArgumentList = @()
    )

    for ($idx = $mock.Blocks.Length; $idx -gt 0; $idx--) {
        $block = $mock.Blocks[$idx - 1]

        $params = @{
            ScriptBlock     = $block.Filter
            BoundParameters = $BoundParameters
            ArgumentList    = $ArgumentList
            Metadata        = $mock.Metadata
        }

        if (Test-ParameterFilter @params) {
            return $block
        }
    }

    return $null
}

function ExecuteBlock {
    param (
        [object] $Block,
        [object] $Mock,
        [string] $CommandName,
        [string] $ModuleName,
        [hashtable] $BoundParameters = @{ },
        [object[]] $ArgumentList = @()
    )

    $Block.Verifiable = $false

    $scope = if ($pester.InTest) {
        $null
    }
    else {
        $pester.CurrentTestGroup
    }
    $Mock.CallHistory += @{CommandName = "$ModuleName||$CommandName"; BoundParams = $BoundParameters; Args = $ArgumentList; Scope = $scope }

    $scriptBlock = {
        param (
            [Parameter(Mandatory = $true)]
            [scriptblock]
            ${Script Block},

            [hashtable]
            $___BoundParameters___ = @{ },

            [object[]]
            $___ArgumentList___ = @(),

            [System.Management.Automation.CommandMetadata]
            ${Meta data},

            [System.Management.Automation.SessionState]
            ${Session State},

            ${R e p o r t S c o p e},

            ${M o d u l e N a m e}
        )

        # This script block exists to hold variables without polluting the test script's current scope.
        # Dynamic parameters in functions, for some reason, only exist in $PSBoundParameters instead
        # of being assigned a local variable the way static parameters do.  By calling Set-DynamicParameterVariable,
        # we create these variables for the caller's use in a Parameter Filter or within the mock itself, and
        # by doing it inside this temporary script block, those variables don't stick around longer than they
        # should.

        Set-DynamicParameterVariable -SessionState ${Session State} -Parameters $___BoundParameters___ -Metadata ${Meta data}
        # Name property is not present on Application Command metadata in PowerShell 2
        & ${R e p o r t S c o p e} -ModuleName ${M o d u l e N a m e} -CommandName $(try {
                ${Meta data}.Name
            }
            catch {
            }) -ScriptBlock ${Script Block}
        & ${Script Block} @___BoundParameters___ @___ArgumentList___
    }

    Set-ScriptBlockScope -ScriptBlock $scriptBlock -SessionState $mock.SessionState
    $splat = @{
        'Script Block'          = $block.Mock
        '___ArgumentList___'    = $ArgumentList
        '___BoundParameters___' = $BoundParameters
        'Meta data'             = $mock.Metadata
        'Session State'         = $mock.SessionState
        'R e p o r t S c o p e' = { param ($CommandName, $ModuleName, $ScriptBlock)
            Write-ScriptBlockInvocationHint -Hint "Mock - of command $CommandName$(if ($ModuleName) { "from module $ModuleName"})" -ScriptBlock $ScriptBlock }
    }

    # the real scriptblock is passed to the other one, we are interested in the mock, not the wrapper, so I pass $block.Mock, and not $scriptBlock

    Write-ScriptBlockInvocationHint -Hint "Mock - of command $CommandName$(if ($ModuleName) { "from module $ModuleName"})" -ScriptBlock ($block.Mock)
    & $scriptBlock @splat
}

function Invoke-InMockScope {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [System.Management.Automation.SessionState]
        $SessionState,

        [Parameter(Mandatory = $true)]
        [scriptblock]
        $ScriptBlock,

        [Parameter(ValueFromRemainingArguments = $true)]
        [object[]]
        $ArgumentList = @()
    )

    if ($SessionState.Module) {
        $SessionState.Module.Invoke($ScriptBlock, $ArgumentList)
    }
    else {
        Set-ScriptBlockScope -ScriptBlock $ScriptBlock -SessionState $SessionState
        Write-ScriptBlockInvocationHint -Hint "Mock - InMockScope" -ScriptBlock $ScriptBlock
        & $ScriptBlock @ArgumentList
    }
}

function Test-ParameterFilter {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [scriptblock]
        $ScriptBlock,

        [System.Collections.IDictionary]
        $BoundParameters,

        [object[]]
        $ArgumentList,

        [System.Management.Automation.CommandMetadata]
        $Metadata
    )

    if ($null -eq $BoundParameters) {
        $BoundParameters = @{ }
    }
    if ($null -eq $ArgumentList) {
        $ArgumentList = @()
    }

    $paramBlock = Get-ParamBlockFromBoundParameters -BoundParameters $BoundParameters -Metadata $Metadata

    $scriptBlockString = "
        $paramBlock

        Set-StrictMode -Off
        $ScriptBlock
    "
    Write-Hint "Unbinding ScriptBlock from '$(Get-ScriptBlockHint $ScriptBlock)'"
    $cmd = [scriptblock]::Create($scriptBlockString)
    Set-ScriptBlockHint -ScriptBlock $cmd -Hint "Unbound ScriptBlock from Test-ParameterFilter"
    Set-ScriptBlockScope -ScriptBlock $cmd -SessionState $pester.SessionState

    Write-ScriptBlockInvocationHint -Hint "Mock - Parameter filter" -ScriptBlock $cmd
    & $cmd @BoundParameters @ArgumentList
}

function Get-ParamBlockFromBoundParameters {
    param (
        [System.Collections.IDictionary] $BoundParameters,
        [System.Management.Automation.CommandMetadata] $Metadata
    )

    $params = foreach ($paramName in $BoundParameters.get_Keys()) {
        if (IsCommonParameter -Name $paramName -Metadata $Metadata) {
            continue
        }

        "`${$paramName}"
    }

    $params = $params -join ','

    if ($null -ne $Metadata) {
        $cmdletBinding = [System.Management.Automation.ProxyCommand]::GetCmdletBindingAttribute($Metadata)
    }
    else {
        $cmdletBinding = ''
    }

    return "$cmdletBinding param ($params)"
}

function IsCommonParameter {
    param (
        [string] $Name,
        [System.Management.Automation.CommandMetadata] $Metadata
    )

    if ($null -ne $Metadata) {
        if ([System.Management.Automation.Internal.CommonParameters].GetProperty($Name)) {
            return $true
        }
        if ($Metadata.SupportsShouldProcess -and [System.Management.Automation.Internal.ShouldProcessParameters].GetProperty($Name)) {
            return $true
        }
        if ($PSVersionTable.PSVersion.Major -ge 3 -and $Metadata.SupportsPaging -and [System.Management.Automation.PagingParameters].GetProperty($Name)) {
            return $true
        }
        if ($Metadata.SupportsTransactions -and [System.Management.Automation.Internal.TransactionParameters].GetProperty($Name)) {
            return $true
        }
    }

    return $false
}

function Set-DynamicParameterVariable {
    <#
        .SYNOPSIS
        This command is used by Pester's Mocking framework.  You do not need to call it directly.
    #>

    param (
        [Parameter(Mandatory = $true)]
        [System.Management.Automation.SessionState]
        $SessionState,

        [hashtable]
        $Parameters,

        [System.Management.Automation.CommandMetadata]
        $Metadata
    )

    if ($null -eq $Parameters) {
        $Parameters = @{ }
    }

    foreach ($keyValuePair in $Parameters.GetEnumerator()) {
        $variableName = $keyValuePair.Key

        if (-not (IsCommonParameter -Name $variableName -Metadata $Metadata)) {
            if ($ExecutionContext.SessionState -eq $SessionState) {
                & $SafeCommands['Set-Variable'] -Scope 1 -Name $variableName -Value $keyValuePair.Value -Force -Confirm:$false -WhatIf:$false
            }
            else {
                $SessionState.PSVariable.Set($variableName, $keyValuePair.Value)
            }
        }
    }
}

function Get-DynamicParamBlock {
    param (
        [scriptblock] $ScriptBlock
    )

    if ($PSVersionTable.PSVersion.Major -le 2) {
        $flags = [System.Reflection.BindingFlags]'Instance, NonPublic'
        $dynamicParams = [scriptblock].GetField('_dynamicParams', $flags).GetValue($ScriptBlock)

        if ($null -ne $dynamicParams) {
            return $dynamicParams.ToString()

        }
    }
    else {
        If ( $ScriptBlock.AST.psobject.Properties.Name -match "Body") {
            if ($null -ne $ScriptBlock.Ast.Body.DynamicParamBlock) {
                $statements = $ScriptBlock.Ast.Body.DynamicParamBlock.Statements |
                & $SafeCommands['Select-Object'] -ExpandProperty Extent |
                & $SafeCommands['Select-Object'] -ExpandProperty Text

                return $statements -join "$([System.Environment]::NewLine)"
            }
        }
    }
}

function Get-MockDynamicParameter {
    <#
        .SYNOPSIS
        This command is used by Pester's Mocking framework.  You do not need to call it directly.
    #>

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true, ParameterSetName = 'Cmdlet')]
        [string] $CmdletName,

        [Parameter(Mandatory = $true, ParameterSetName = 'Function')]
        [string] $FunctionName,

        [Parameter(ParameterSetName = 'Function')]
        [string] $ModuleName,

        [System.Collections.IDictionary] $Parameters,

        [object] $Cmdlet
    )

    switch ($PSCmdlet.ParameterSetName) {
        'Cmdlet' {
            Get-DynamicParametersForCmdlet -CmdletName $CmdletName -Parameters $Parameters
        }

        'Function' {
            Get-DynamicParametersForMockedFunction -FunctionName $FunctionName -ModuleName $ModuleName -Parameters $Parameters -Cmdlet $Cmdlet
        }
    }
}

function Get-DynamicParametersForCmdlet {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string] $CmdletName,

        [ValidateScript( {
                if ($PSVersionTable.PSVersion.Major -ge 3 -and
                    $null -ne $_ -and
                    $_.GetType().FullName -ne 'System.Management.Automation.PSBoundParametersDictionary') {
                    throw 'The -Parameters argument must be a PSBoundParametersDictionary object ($PSBoundParameters).'
                }

                return $true
            })]
        [System.Collections.IDictionary] $Parameters
    )

    try {
        $command = & $SafeCommands['Get-Command'] -Name $CmdletName -CommandType Cmdlet -ErrorAction Stop

        if (@($command).Count -gt 1) {
            throw "Name '$CmdletName' resolved to multiple Cmdlets"
        }
    }
    catch {
        $PSCmdlet.ThrowTerminatingError($_)
    }

    if ($null -eq $command.ImplementingType.GetInterface('IDynamicParameters', $true)) {
        return
    }

    if ('5.0.10586.122' -lt $PSVersionTable.PSVersion) {
        # Older version of PS required Reflection to do this.  It has run into problems on occasion with certain cmdlets,
        # such as ActiveDirectory and AzureRM, so we'll take advantage of the newer PSv5 engine features if at all possible.

        if ($null -eq $Parameters) {
            $paramsArg = @()
        }
        else {
            $paramsArg = @($Parameters)
        }

        $command = $ExecutionContext.InvokeCommand.GetCommand($CmdletName, [System.Management.Automation.CommandTypes]::Cmdlet, $paramsArg)
        $paramDictionary = [System.Management.Automation.RuntimeDefinedParameterDictionary]::new()

        foreach ($param in $command.Parameters.Values) {
            if (-not $param.IsDynamic) {
                continue
            }
            if ($Parameters.ContainsKey($param.Name)) {
                continue
            }

            $dynParam = [System.Management.Automation.RuntimeDefinedParameter]::new($param.Name, $param.ParameterType, $param.Attributes)
            $paramDictionary.Add($param.Name, $dynParam)
        }

        return $paramDictionary
    }
    else {
        if ($null -eq $Parameters) {
            $Parameters = @{ }
        }

        $cmdlet = & $SafeCommands['New-Object'] $command.ImplementingType.FullName

        $flags = [System.Reflection.BindingFlags]'Instance, Nonpublic'
        $context = $ExecutionContext.GetType().GetField('_context', $flags).GetValue($ExecutionContext)
        [System.Management.Automation.Cmdlet].GetProperty('Context', $flags).SetValue($cmdlet, $context, $null)

        foreach ($keyValuePair in $Parameters.GetEnumerator()) {
            $property = $cmdlet.GetType().GetProperty($keyValuePair.Key)
            if ($null -eq $property -or -not $property.CanWrite) {
                continue
            }

            $isParameter = [bool]($property.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true))
            if (-not $isParameter) {
                continue
            }

            $property.SetValue($cmdlet, $keyValuePair.Value, $null)
        }

        try {
            # This unary comma is important in some cases.  On Windows 7 systems, the ActiveDirectory module cmdlets
            # return objects from this method which implement IEnumerable for some reason, and even cause PowerShell
            # to throw an exception when it tries to cast the object to that interface.

            # We avoid that problem by wrapping the result of GetDynamicParameters() in a one-element array with the
            # unary comma.  PowerShell enumerates that array instead of trying to enumerate the goofy object, and
            # everyone's happy.

            # Love the comma.  Don't delete it.  We don't have a test for this yet, unless we can get the AD module
            # on a Server 2008 R2 build server, or until we write some C# code to reproduce its goofy behavior.

            , $cmdlet.GetDynamicParameters()
        }
        catch [System.NotImplementedException] {
            # Some cmdlets implement IDynamicParameters but then throw a NotImplementedException.  I have no idea why.  Ignore them.
        }
    }
}

function Get-DynamicParametersForMockedFunction {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $FunctionName,

        [string]
        $ModuleName,

        [System.Collections.IDictionary]
        $Parameters,

        [object]
        $Cmdlet
    )

    $mock = $mockTable["$ModuleName||$FunctionName"]

    if (-not $mock) {
        throw "Internal error detected:  Mock for '$FunctionName' in module '$ModuleName' was called, but does not exist in the mock table."
    }

    if ($mock.DynamicParamScriptBlock) {
        $splat = @{ 'P S Cmdlet' = $Cmdlet }
        return & $mock.DynamicParamScriptBlock @Parameters @splat
    }
}

function Test-IsClosure {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [scriptblock]
        $ScriptBlock
    )

    $sessionStateInternal = Get-ScriptBlockScope -ScriptBlock $ScriptBlock
    if ($null -eq $sessionStateInternal) {
        return $false
    }

    $flags = [System.Reflection.BindingFlags]'Instance,NonPublic'
    $module = $sessionStateInternal.GetType().GetProperty('Module', $flags).GetValue($sessionStateInternal, $null)

    return (
        $null -ne $module -and
        $module.Name -match '^__DynamicModule_([a-f\d-]+)$' -and
        $null -ne ($matches[1] -as [guid])
    )
}

function Remove-MockFunctionsAndAliases {
    # when a test is terminated (e.g. by stopping at a breakpoint and then stoping the execution of the script)
    # the aliases and bootstrap functions for the currently mocked functions will remain in place
    # Then on subsequent runs the bootstrap function will be picked up instead of the real command,
    # because there is still an alias associated with it, and the test will fail.
    # So before putting Pester state in place we should make sure that all Pester mocks are gone
    # by deleting every alias pointing to a function that starts with PesterMock_. Then we also delete the
    # bootstrap function.
    foreach ($alias in (& $script:SafeCommands['Get-Alias'] -Definition "PesterMock_*")) {
        & $script:SafeCommands['Remove-Item'] "alias:/$($alias.Name)"
    }

    foreach ($bootstrapFunction in (& $script:SafeCommands['Get-Command'] -Name "PesterMock_*")) {
        & $script:SafeCommands['Remove-Item'] "function:/$($bootstrapFunction.Name)"
    }
}

function Repair-ConflictingParameters {
    [CmdletBinding()]
    [OutputType([System.Management.Automation.CommandMetadata])]
    param(
        [Parameter(Mandatory = $true)]
        [System.Management.Automation.CommandMetadata]
        $Metadata,
        [Parameter()]
        [string[]]
        $RemoveParameterType,
        [Parameter()]
        [string[]]
        $RemoveParameterValidation
    )

    $repairedMetadata = New-Object System.Management.Automation.CommandMetadata -ArgumentList $Metadata
    $paramMetadatas = @()
    $paramMetadatas += $repairedMetadata.Parameters.Values

    $conflictingParams = Get-ConflictingParameterNames

    foreach ($paramMetadata in $paramMetadatas) {
        if ($paramMetadata.IsDynamic) {
            continue
        }

        if ($conflictingParams -contains $paramMetadata.Name) {
            $paramName = $paramMetadata.Name
            $newName = "_$paramName"
            $paramMetadata.Name = $newName
            $paramMetadata.Aliases.Add($paramName)

            $null = $repairedMetadata.Parameters.Remove($paramName)
            $repairedMetadata.Parameters.Add($newName, $paramMetadata)
        }

        $attrIndexesToRemove = New-Object System.Collections.ArrayList

        if ($RemoveParameterType -contains $paramMetadata.Name) {
            $paramMetadata.ParameterType = [object]

            for ($i = 0; $i -lt $paramMetadata.Attributes.Count; $i++) {
                $attr = $paramMetadata.Attributes[$i]
                if ($attr -is [PSTypeNameAttribute]) {
                    $null = $attrIndexesToRemove.Add($i)
                    break
                }
            }
        }

        if ($RemoveParameterValidation -contains $paramMetadata.Name) {
            for ($i = 0; $i -lt $paramMetadata.Attributes.Count; $i++) {
                $attr = $paramMetadata.Attributes[$i]
                if ($attr -is [System.Management.Automation.ValidateArgumentsAttribute]) {
                    $null = $attrIndexesToRemove.Add($i)
                }
            }
        }

        foreach ($index in $attrIndexesToRemove) {
            $null = $paramMetadata.Attributes.RemoveAt($index)
        }
    }

    $repairedMetadata
}

function Reset-ConflictingParameters {
    [CmdletBinding()]
    [OutputType([hashtable])]
    param(
        [Parameter(Mandatory = $true)]
        [hashtable]
        $BoundParameters
    )

    $parameters = $BoundParameters.Clone()
    $names = Get-ConflictingParameterNames

    foreach ($param in $names) {
        $fixedName = "_$param"

        if (-not $parameters.ContainsKey($fixedName)) {
            continue
        }

        $parameters[$param] = $parameters[$fixedName]
        $null = $parameters.Remove($fixedName)
    }

    $parameters
}

function Get-ConflictingParameterNames {
    $script:ConflictingParameterNames
}

function Initialize-ConflictingParameterNames {
    foreach ($var in (& $script:SafeCommands['Get-Variable'])) {
        if (($var.Options -band [System.Management.Automation.ScopedItemOptions]::Constant) -or ($var.Options -band [System.Management.Automation.ScopedItemOptions]::ReadOnly)) {
            $var.Name
        }
    }
}

function Get-ScriptBlockAST {
    param (
        [scriptblock]
        $ScriptBlock
    )

    if ($ScriptBlock.Ast -is [System.Management.Automation.Language.ScriptBlockAst]) {
        $ast = $Block.Ast.EndBlock
    }
    elseif ($ScriptBlock.Ast -is [System.Management.Automation.Language.FunctionDefinitionAst]) {
        $ast = $Block.Ast.Body.EndBlock
    }
    else {
        throw "Pester failed to parse ParameterFilter, scriptblock is invalid type. Please reformat your ParameterFilter."
    }

    return $ast
}

function New-BlockWithoutParameterAliases {
    [CmdletBinding()]
    [OutputType([scriptblock])]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [System.Management.Automation.CommandMetadata]
        $Metadata,
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [scriptblock]
        $Block
    )
    try {
        if ($PSVersionTable.PSVersion.Major -ge 3) {
            $params = $Metadata.Parameters.Values
            $ast = Get-ScriptBlockAST $Block
            $blockText = $ast.Extent.Text
            $variables = [array]($Ast.FindAll( { param($ast) $ast -is [System.Management.Automation.Language.VariableExpressionAst] }, $true))
            [array]::Reverse($variables)

            foreach ($var in $variables) {
                $varName = $var.VariablePath.UserPath
                $length = $varName.Length

                foreach ($param in $params) {
                    if ($param.Aliases -contains $varName) {
                        $startIndex = $var.Extent.StartOffset - $ast.Extent.StartOffset + 1 # move one position after the dollar sign

                        $blockText = $blockText.Remove($startIndex, $length).Insert($startIndex, $param.Name)

                        break # It is safe to stop checking for further params here, since aliases cannot be shared by parameters
                    }
                }
            }

            $Block = [scriptblock]::Create($blockText)
        }

        $Block
    }
    catch {
        $PSCmdlet.ThrowTerminatingError($_)
    }
}

function Invoke-CommonSetupInMockScope {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [hashtable]
        $Mock,
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [scriptblock]
        $MockScript,
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [string]
        $CommandName
    )
    try {
        $scriptBlock = { $ExecutionContext.InvokeProvider.Item.Set("Function:\script:$($args[0])", $args[1], $true, $true) }
        $null = Invoke-InMockScope -SessionState $Mock.SessionState -ScriptBlock $scriptBlock -ArgumentList $Mock.BootstrapFunctionName, $MockScript

        $mock.Aliases += $CommandName

        $scriptBlock = {
            $setAlias = & (Pester\SafeGetCommand) -Name Set-Alias -CommandType Cmdlet -Module Microsoft.PowerShell.Utility
            & $setAlias -Name $args[0] -Value $args[1] -Scope Script
        }

        $null = Invoke-InMockScope -SessionState $Mock.SessionState -ScriptBlock $scriptBlock -ArgumentList $CommandName, $Mock.BootstrapFunctionName

        if ($Mock.OriginalCommand.ModuleName) {
            $aliasName = "$($Mock.OriginalCommand.ModuleName)\$($CommandName)"
            $Mock.Aliases += $aliasName

            $scriptBlock = {
                $setAlias = & (Pester\SafeGetCommand) -Name Set-Alias -CommandType Cmdlet -Module Microsoft.PowerShell.Utility
                & $setAlias -Name $args[0] -Value $args[1] -Scope Script
            }

            $null = Invoke-InMockScope -SessionState $Mock.SessionState -ScriptBlock $scriptBlock -ArgumentList $aliasName, $Mock.BootstrapFunctionName
        }

        if ($Mock.OriginalCommand.CommandType -eq 'Application') {
            $aliasWithoutExt = $CommandName -replace $Mock.OriginalCommand.Extension

            $Mock.Aliases += $aliasWithoutExt

            $scriptBlock = {
                $setAlias = & (Pester\SafeGetCommand) -Name Set-Alias -CommandType Cmdlet -Module Microsoft.PowerShell.Utility
                & $setAlias -Name $args[0] -Value $args[1] -Scope Script
            }

            $null = Invoke-InMockScope -SessionState $Mock.SessionState -ScriptBlock $scriptBlock -ArgumentList $aliasWithoutExt, $Mock.BootstrapFunctionName
        }
    }
    catch {
        $PSCmdlet.ThrowTerminatingError($_)
    }
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQU1WSFtZu9OoGAnZ104wiwRp7Q
# fqiggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
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
# guuUgMQSmOo2WcK6689uf4FHBRMwDQYJKoZIhvcNAQEBBQAEggEAbI3rl4ASuanY
# HhTqk+RcufitCgS4bQ+sEtDlhpKpZEuDYHbdcNXy9HgI+WhBGTn521rHHSwko/dU
# OpuMOwovuQ7f085rFbsAFj7Sk7IJB6rmujMHV5cEy/jbmA+JzP3ayU+zQ7s4Y3bL
# BHs1OeY7wR/yOoxh0HtvPMHYLrL3fFq4VrmMdl9ebcUfSXtLZkdmOgeYheajjqlu
# MNNPuUduyUchQgZ8xsbQHx/62QM03DcWHy3dQYoUKw0B6LTCIY2UiAdbRWWJTFXc
# R64T7Uc4e8w7YXKalnioHnh5kELp9CQnKLZBC3aI7IWh2bfTPrq561fYGH3SGBBG
# pvCFtSYI2aGCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDA2WjAjBgkqhkiG9w0BCQQx
# FgQUvWxqYvoQCfFltNuW+MU8k/S5OHkwDQYJKoZIhvcNAQEBBQAEggEARVjhEq5+
# Er5fVlccXvHXzreIHo/tReTKXbHZi1MSTZ2zialo/y+NPHGlbGyx7WB8v7diy9LI
# DTnok3UfiR9/oSV8y4w4gf7L32ocUBR+6ZQr/ZlAS5q4ECSwWIuBuXbd85K31Htz
# 832OYTNasZeq8CoTamkeagqsomNxVWTVfcB5/ydlvvqdOkS9o6c8Yp98fv4/AMhG
# DQQmP4F0JBCBJzjebnVJY6V41PXOscVPxh9oBQKGHqFq4fJhdLpguiN2hNL7OY5/
# qICrc9RxkXSp2B4NWJO8lMve5vfkuwFSEGrdDvLGeBA6Xbb8YdqFhl76r+NnXe3B
# owJsg3aP9K4ALg==
# SIG # End signature block
