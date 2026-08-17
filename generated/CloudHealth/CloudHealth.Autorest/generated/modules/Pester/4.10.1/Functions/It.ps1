function It {
    <#
.SYNOPSIS
Validates the results of a test inside of a Describe block.

.DESCRIPTION
The It command is intended to be used inside of a Describe or Context Block.
If you are familiar with the AAA pattern (Arrange-Act-Assert), the body of
the It block is the appropriate location for an assert. The convention is to
assert a single expectation for each It block. The code inside of the It block
should throw a terminating error if the expectation of the test is not met and
thus cause the test to fail. The name of the It block should expressively state
the expectation of the test.

In addition to using your own logic to test expectations and throw exceptions,
you may also use Pester's Should command to perform assertions in plain language.

You can intentionally mark It block result as inconclusive by using Set-TestInconclusive
command as the first tested statement in the It block.

.PARAMETER Name
An expressive phrase describing the expected test outcome.

.PARAMETER Test
The script block that should throw an exception if the
expectation of the test is not met.If you are following the
AAA pattern (Arrange-Act-Assert), this typically holds the
Assert.

.PARAMETER Pending
Use this parameter to explicitly mark the test as work-in-progress/not implemented/pending when you
need to distinguish a test that fails because it is not finished yet from a tests
that fail as a result of changes being made in the code base. An empty test, that is a
test that contains nothing except whitespace or comments is marked as Pending by default.

.PARAMETER Skip
Use this parameter to explicitly mark the test to be skipped. This is preferable to temporarily
commenting out a test, because the test remains listed in the output. Use the Strict parameter
of Invoke-Pester to force all skipped tests to fail.

.PARAMETER TestCases
Optional array of hashtable (or any IDictionary) objects.  If this parameter is used,
Pester will call the test script block once for each table in the TestCases array,
splatting the dictionary to the test script block as input.  If you want the name of
the test to appear differently for each test case, you can embed tokens into the Name
parameter with the syntax 'Adds numbers <A> and <B>' (assuming you have keys named A and B
in your TestCases hashtables.)

.EXAMPLE
```ps
function Add-Numbers($a, $b) {
    return $a + $b
}

Describe "Add-Numbers" {
    It "adds positive numbers" {
        $sum = Add-Numbers 2 3
        $sum | Should -Be 5
    }

    It "adds negative numbers" {
        $sum = Add-Numbers (-2) (-2)
        $sum | Should -Be (-4)
    }

    It "adds one negative number to positive number" {
        $sum = Add-Numbers (-2) 2
        $sum | Should -Be 0
    }

    It "concatenates strings if given strings" {
        $sum = Add-Numbers two three
        $sum | Should -Be "twothree"
    }
}
```

.EXAMPLE
```ps
function Add-Numbers($a, $b) {
    return $a + $b
}

Describe "Add-Numbers" {
    $testCases = @(
        @{ a = 2;     b = 3;       expectedResult = 5 }
        @{ a = -2;    b = -2;      expectedResult = -4 }
        @{ a = -2;    b = 2;       expectedResult = 0 }
        @{ a = 'two'; b = 'three'; expectedResult = 'twothree' }
    )

    It 'Correctly adds <a> and <b> to get <expectedResult>' -TestCases $testCases {
        param ($a, $b, $expectedResult)

        $sum = Add-Numbers $a $b
        $sum | Should -Be $expectedResult
    }
}
```

.LINK
https://pester.dev/docs/commands/Describe

.LINK
https://pester.dev/docs/commands/Context

.LINK
https://pester.dev/docs/commands/Set-TestInconclusive

.LINK
https://pester.dev/docs/commands/Should

#>
    [CmdletBinding(DefaultParameterSetName = 'Normal')]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string] $Name,

        [Parameter(Position = 1)]
        [ScriptBlock] $Test = { },

        [System.Collections.IDictionary[]] $TestCases,

        [Parameter(ParameterSetName = 'Pending')]
        [Switch] $Pending,

        [Parameter(ParameterSetName = 'Skip')]
        [Alias('Ignore')]
        [Switch] $Skip
    )

    ItImpl -Pester $pester -OutputScriptBlock ${function:Write-PesterResult} @PSBoundParameters
}

function ItImpl {
    [CmdletBinding(DefaultParameterSetName = 'Normal')]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$Name,

        [Parameter(Position = 1)]
        [ScriptBlock] $Test,

        [System.Collections.IDictionary[]] $TestCases,
        [Parameter(ParameterSetName = 'Pending')]
        [Switch] $Pending,

        [Parameter(ParameterSetName = 'Skip')]
        [Alias('Ignore')]
        [Switch] $Skip,

        $Pester,
        [scriptblock] $OutputScriptBlock
    )

    Assert-DescribeInProgress -CommandName It

    # Jumping through hoops to make strict mode happy.
    if ($PSCmdlet.ParameterSetName -ne 'Skip') {
        $Skip = $false
    }
    if ($PSCmdlet.ParameterSetName -ne 'Pending') {
        $Pending = $false
    }

    #unless Skip or Pending is specified you must specify a ScriptBlock to the Test parameter
    if (-not ($PSBoundParameters.ContainsKey('test') -or $Skip -or $Pending)) {
        If ($Name.Contains("`n")) {
            throw "Name parameter has multiple lines and no script block is provided. (Have you provided a name for the test group?)"
        }
        else {
            throw 'No test script block is provided. (Have you put the open curly brace on the next line?)'
        }
    }

    #the function is called with Pending or Skipped set the script block if needed
    if ($null -eq $Test) {
        $Test = { }
    }

    #mark empty Its as Pending
    if ($PSVersionTable.PSVersion.Major -le 2 -and
        $PSCmdlet.ParameterSetName -eq 'Normal' -and
        [String]::IsNullOrEmpty((Remove-Comments $Test.ToString()) -replace "\s")) {
        $Pending = $true
    }
    elseIf ($PSVersionTable.PSVersion.Major -gt 2) {
        #[String]::IsNullOrWhitespace is not available in .NET version used with PowerShell 2
        # AST is not available also
        $testIsEmpty =
        [String]::IsNullOrEmpty($Test.Ast.BeginBlock.Statements) -and
        [String]::IsNullOrEmpty($Test.Ast.ProcessBlock.Statements) -and
        [String]::IsNullOrEmpty($Test.Ast.EndBlock.Statements)

        if ($PSCmdlet.ParameterSetName -eq 'Normal' -and $testIsEmpty) {
            $Pending = $true
        }
    }

    $pendingSkip = @{ }

    if ($PSCmdlet.ParameterSetName -eq 'Skip') {
        $pendingSkip['Skip'] = $Skip
    }
    else {
        $pendingSkip['Pending'] = $Pending
    }

    if ($null -ne $TestCases -and $TestCases.Count -gt 0) {
        foreach ($testCase in $TestCases) {
            $expandedName = [regex]::Replace($Name, '<([^>]+)>', {
                    $capture = $args[0].Groups[1].Value
                    if ($testCase.Contains($capture)) {
                        $value = $testCase[$capture]
                        # skip adding quotes to non-empty strings to avoid adding junk to the
                        # test name in case you want to expand captures like 'because' or test name
                        if ($value -isnot [string] -or [string]::IsNullOrEmpty($value)) {
                            Format-Nicely $value
                        }
                        else {
                            $value
                        }
                    }
                    else {
                        "<$capture>"
                    }
                })

            $splat = @{
                Name                   = $expandedName
                Scriptblock            = $Test
                Parameters             = $testCase
                ParameterizedSuiteName = $Name
                OutputScriptBlock      = $OutputScriptBlock
            }

            Invoke-Test @splat @pendingSkip
        }
    }
    else {
        Invoke-Test -Name $Name -ScriptBlock $Test @pendingSkip -OutputScriptBlock $OutputScriptBlock
    }
}

function Invoke-Test {
    [CmdletBinding(DefaultParameterSetName = 'Normal')]
    param (
        [Parameter(Mandatory = $true)]
        [string] $Name,

        [Parameter(Mandatory = $true)]
        [ScriptBlock] $ScriptBlock,

        [scriptblock] $OutputScriptBlock,

        [System.Collections.IDictionary] $Parameters,
        [string] $ParameterizedSuiteName,

        [Parameter(ParameterSetName = 'Pending')]
        [Switch] $Pending,

        [Parameter(ParameterSetName = 'Skip')]
        [Alias('Ignore')]
        [Switch] $Skip
    )

    if ($null -eq $Parameters) {
        $Parameters = @{ }
    }

    try {
        if ($Skip) {
            $Pester.AddTestResult($Name, "Skipped", $null)
        }
        elseif ($Pending) {
            $Pester.AddTestResult($Name, "Pending", $null)
        }
        else {
            #todo: disabling the progress for now, it adds a lot of overhead and breaks output on linux, we don't have a good way to disable it by default, or to show it after delay see: https://github.com/pester/Pester/issues/846
            # & $SafeCommands['Write-Progress'] -Activity "Running test '$Name'" -Status Processing

            $errorRecord = $null
            try {
                $pester.EnterTest()
                Invoke-TestCaseSetupBlocks

                do {
                    Write-ScriptBlockInvocationHint -Hint "It" -ScriptBlock $ScriptBlock
                    $null = & $ScriptBlock @Parameters
                } until ($true)
            }
            catch {
                $errorRecord = $_
            }
            finally {
                #guarantee that the teardown action will run and prevent it from failing the whole suite
                try {
                    if (-not ($Skip -or $Pending)) {
                        Invoke-TestCaseTeardownBlocks
                    }
                }
                catch {
                    $errorRecord = $_
                }

                $pester.LeaveTest()
            }

            $result = ConvertTo-PesterResult -Name $Name -ErrorRecord $errorRecord
            $orderedParameters = Get-OrderedParameterDictionary -ScriptBlock $ScriptBlock -Dictionary $Parameters
            $Pester.AddTestResult( $result.Name, $result.Result, $null, $result.FailureMessage, $result.StackTrace, $ParameterizedSuiteName, $orderedParameters, $result.ErrorRecord )
            #todo: disabling progress reporting see above & $SafeCommands['Write-Progress'] -Activity "Running test '$Name'" -Completed -Status Processing
        }
    }
    finally {
        Exit-MockScope -ExitTestCaseOnly
    }

    if ($null -ne $OutputScriptBlock) {
        $Pester.testresult[-1] | & $OutputScriptBlock
    }
}

function Get-OrderedParameterDictionary {
    [OutputType([System.Collections.IDictionary])]
    param (
        [scriptblock] $ScriptBlock,
        [System.Collections.IDictionary] $Dictionary
    )

    $parameters = Get-ParameterDictionary -ScriptBlock $ScriptBlock

    $orderedDictionary = & $SafeCommands['New-Object'] System.Collections.Specialized.OrderedDictionary

    foreach ($parameterName in $parameters.Keys) {
        $value = $null
        if ($Dictionary.ContainsKey($parameterName)) {
            $value = $Dictionary[$parameterName]
        }

        $orderedDictionary[$parameterName] = $value
    }

    return $orderedDictionary
}

function Get-ParameterDictionary {
    param (
        [scriptblock] $ScriptBlock
    )

    $guid = [Guid]::NewGuid().Guid

    try {
        & $SafeCommands['Set-Content'] function:\$guid $ScriptBlock
        $metadata = [System.Management.Automation.CommandMetadata](& $SafeCommands['Get-Command'] -Name $guid -CommandType Function)

        return $metadata.Parameters
    }
    finally {
        if (& $SafeCommands['Test-Path'] function:\$guid) {
            & $SafeCommands['Remove-Item'] function:\$guid
        }
    }
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUiJe2aw81vEgh/eBVEk1OxGvc
# smmggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
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
# sLVprfkEmM3nukLnE8A+yZ3jZ3cwDQYJKoZIhvcNAQEBBQAEggEAAdsdLfyfoUQZ
# gi/qUM2E1cm6FhyPUNHKZAGB8dC/xA+n+4iTD67tf/fV60q/XJXLPE5EEPnLye4Y
# cKMXQNEJG3nC8ygCEj8bdpKGACK+ZpTj9vb8/2MgSLugNc5XSODUZ9N7R9Gh7sxS
# IifIan75kyfD3vz7R5FY6jKmntnbDswxDoabJlCC60eG6dqgEQeCJpGrDi5I8wAo
# LWEnGqvnQ1rqdxXexz5hqeXyf9+4wm2z/50V5GWvgcD7rqOHualkb2xcmSiRYo63
# /6A/SuUnVU83AX/9p4Bom6OKdixN14bWRyXStiPMKFTN2uTMxSnO5FpQt777pqdB
# 8M1ZGO5kNKGCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDA1WjAjBgkqhkiG9w0BCQQx
# FgQU4vMirBvgGf4zKu41AlKwwSffDXMwDQYJKoZIhvcNAQEBBQAEggEALO7zLj/6
# +6WyW9ZGqNB4nsGOdegaNt/MkxqBsixDmGHXS9jDp+VdhL/wGIGT8jRJqa3xCc8e
# lKZBOISlI9eqMoI3j273a1/IOolXzGNGa+C5cYEKkwkFl7BvYMuUTF/HrE2ZJyoN
# n7UW3vXNcqzAgcaw2BhqTMCXBWR222GuSOKt39t9Cin16v2bEx12yuakTNKMbqJT
# TGyWOqxY8ZslXv8Fkjvkc7P2iuyGlq8LbkQWCQk0iBBy/tDRr/M5t85yXnU8vkm8
# hWaRx1Dfrj4XqccwQx4Yk4m7uKyFXSXVEXNok0NSmdn3m/Vsr5myjr+nV6OQ2ggw
# ZZGvB12VQ842ag==
# SIG # End signature block
