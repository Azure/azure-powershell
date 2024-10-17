function New-PesterState {
    param (
        [String[]]$TagFilter,
        [String[]]$ExcludeTagFilter,
        [String[]]$TestNameFilter,
        [System.Management.Automation.SessionState]$SessionState,
        [Switch]$Strict,
        [Pester.OutputTypes]$Show = 'All',
        [object]$PesterOption,
        [Switch]$RunningViaInvokePester,
        [Hashtable[]] $ScriptBlockFilter
    )

    if ($null -eq $SessionState) {
        $SessionState = Set-SessionStateHint -PassThru  -Hint "Module - Pester (captured in New-PesterState)" -SessionState $ExecutionContext.SessionState
    }

    if ($null -eq $PesterOption) {
        $PesterOption = New-PesterOption
    }
    elseif ($PesterOption -is [System.Collections.IDictionary]) {
        try {
            $PesterOption = New-PesterOption @PesterOption
        }
        catch {
            throw
        }
    }

    & $SafeCommands['New-Module'] -Name PesterState -AsCustomObject -ArgumentList $TagFilter, $ExcludeTagFilter, $TestNameFilter, $SessionState, $Strict, $Show, $PesterOption, $RunningViaInvokePester -ScriptBlock {
        param (
            [String[]]$_tagFilter,
            [String[]]$_excludeTagFilter,
            [String[]]$_testNameFilter,
            [System.Management.Automation.SessionState]$_sessionState,
            [Switch]$Strict,
            [Pester.OutputTypes]$Show,
            [object]$PesterOption,
            [Switch]$RunningViaInvokePester
        )

        #public read-only
        $TagFilter = $_tagFilter
        $ExcludeTagFilter = $_excludeTagFilter
        $TestNameFilter = $_testNameFilter


        $script:SessionState = $_sessionState
        $script:Stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
        $script:TestStartTime = $null
        $script:TestStopTime = $null
        $script:CommandCoverage = @()
        $script:Strict = $Strict
        $script:Show = $Show
        $script:InTest = $false

        $script:TestResult = @()

        $script:TotalCount = 0
        $script:Time = [timespan]0
        $script:PassedCount = 0
        $script:FailedCount = 0
        $script:SkippedCount = 0
        $script:PendingCount = 0
        $script:InconclusiveCount = 0

        $script:IncludeVSCodeMarker = $PesterOption.IncludeVSCodeMarker
        $script:TestSuiteName = $PesterOption.TestSuiteName
        $script:ScriptBlockFilter = $PesterOption.ScriptBlockFilter
        $script:RunningViaInvokePester = $RunningViaInvokePester

        $script:SafeCommands = @{}

        $script:SafeCommands['New-Object'] = & (Pester\SafeGetCommand) -Name New-Object          -Module Microsoft.PowerShell.Utility -CommandType Cmdlet
        $script:SafeCommands['Select-Object'] = & (Pester\SafeGetCommand) -Name Select-Object       -Module Microsoft.PowerShell.Utility -CommandType Cmdlet
        $script:SafeCommands['Export-ModuleMember'] = & (Pester\SafeGetCommand) -Name Export-ModuleMember -Module Microsoft.PowerShell.Core    -CommandType Cmdlet
        $script:SafeCommands['Add-Member'] = & (Pester\SafeGetCommand) -Name Add-Member          -Module Microsoft.PowerShell.Utility -CommandType Cmdlet

        function New-TestGroup([string] $Name, [string] $Hint) {
            & $SafeCommands['New-Object'] psobject -Property @{
                Name              = $Name
                Type              = 'TestGroup'
                Hint              = $Hint
                Actions           = [System.Collections.ArrayList]@()
                BeforeEach        = & $SafeCommands['New-Object'] System.Collections.Generic.List[scriptblock]
                AfterEach         = & $SafeCommands['New-Object'] System.Collections.Generic.List[scriptblock]
                BeforeAll         = & $SafeCommands['New-Object'] System.Collections.Generic.List[scriptblock]
                AfterAll          = & $SafeCommands['New-Object'] System.Collections.Generic.List[scriptblock]
                TotalCount        = 0
                StartTime         = $Null
                Time              = [timespan]0
                PassedCount       = 0
                FailedCount       = 0
                SkippedCount      = 0
                PendingCount      = 0
                InconclusiveCount = 0
            }
        }

        $script:TestActions = New-TestGroup -Name Pester -Hint Root
        $script:TestGroupStack = & $SafeCommands['New-Object'] System.Collections.Stack
        $script:TestGroupStack.Push($script:TestActions)

        function EnterTestGroup([string] $Name, [string] $Hint) {
            $newGroup = New-TestGroup @PSBoundParameters
            $newGroup.StartTime = $script:Stopwatch.Elapsed
            $null = $script:TestGroupStack.Peek().Actions.Add($newGroup)

            $script:TestGroupStack.Push($newGroup)
        }

        function LeaveTestGroup([string] $Name, [string] $Hint) {
            $StopTime = $script:Stopwatch.Elapsed
            $currentGroup = $script:TestGroupStack.Pop()

            if ( $Hint -eq 'Script' ) {
                $script:Time += $StopTime - $currentGroup.StartTime
            }

            $currentGroup.Time = $StopTime - $currentGroup.StartTime

            # Removing start time property from output to prevent clutter
            $currentGroup.PSObject.properties.remove('StartTime')

            if ($currentGroup.Name -ne $Name -or $currentGroup.Hint -ne $Hint) {
                throw "TestGroups stack corrupted:  Expected name/hint of '$Name','$Hint'.  Found '$($currentGroup.Name)', '$($currentGroup.Hint)'."
            }
        }

        function AddTestResult {
            param (
                [string]$Name,
                [ValidateSet("Failed", "Passed", "Skipped", "Pending", "Inconclusive")]
                [string]$Result,
                [Nullable[TimeSpan]]$Time,
                [string]$FailureMessage,
                [string]$StackTrace,
                [string] $ParameterizedSuiteName,
                [System.Collections.IDictionary] $Parameters,
                [System.Management.Automation.ErrorRecord] $ErrorRecord
            )

            # defining this function in here, because otherwise it is not available
            function New-ErrorRecord ([string] $Message, [string] $ErrorId, [string] $File, [string] $Line, [string] $LineText) {
                $exception = & $SafeCommands['New-Object'] Exception $Message
                $errorCategory = [Management.Automation.ErrorCategory]::InvalidResult
                # we use ErrorRecord.TargetObject to pass structured information about the error to a reporting system.
                $targetObject = @{Message = $Message; File = $File; Line = $Line; LineText = $LineText}
                $errorRecord = & $SafeCommands['New-Object'] Management.Automation.ErrorRecord $exception, $ErrorID, $errorCategory, $targetObject
                return $errorRecord
            }

            if ($null -eq $Time) {
                if ( $script:TestStartTime -and $script:TestStopTime ) {
                    $Time = $script:TestStopTime - $script:TestStartTime
                    $script:TestStartTime = $null
                    $script:TestStopTime = [timespan]0
                }
                else {
                    $Time = [timespan]0
                }
            }

            if (-not $script:Strict) {
                $Passed = "Passed", "Skipped", "Pending" -contains $Result
            }
            else {
                $Passed = $Result -eq "Passed"
                if (@("Skipped", "Pending", "Inconclusive") -contains $Result) {
                    $FailureMessage = "The test failed because the test was executed in Strict mode and the result '$result' was translated to Failed."
                    $ErrorRecord = New-ErrorRecord -ErrorId "PesterTest$Result" -Message $FailureMessage
                    $Result = "Failed"
                }

            }

            $script:TotalCount++

            switch ($Result) {
                Passed {
                    $script:PassedCount++; break;
                }
                Failed {
                    $script:FailedCount++; break;
                }
                Skipped {
                    $script:SkippedCount++; break;
                }
                Pending {
                    $script:PendingCount++; break;
                }
                Inconclusive {
                    $script:InconclusiveCount++; break;
                }
            }

            $resultRecord = & $SafeCommands['New-Object'] -TypeName PsObject -Property @{
                Name                   = $Name
                Type                   = 'TestCase'
                Passed                 = $Passed
                Result                 = $Result
                Time                   = $Time
                FailureMessage         = $FailureMessage
                StackTrace             = $StackTrace
                ErrorRecord            = $ErrorRecord
                ParameterizedSuiteName = $ParameterizedSuiteName
                Parameters             = $Parameters
                Show                   = $script:Show
            }

            $null = $script:TestGroupStack.Peek().Actions.Add($resultRecord)

            # Attempting some degree of backward compatibility for the TestResult collection for now; deprecated and will be removed in the future
            $describe = ''
            $contexts = [System.Collections.ArrayList]@()

            # make a copy of the stack and reverse it
            $reversedStack = $script:TestGroupStack.ToArray()
            [array]::Reverse($reversedStack)

            foreach ($group in $reversedStack) {
                if ($group.Hint -eq 'Root' -or $group.Hint -eq 'Script') {
                    continue
                }
                if ($describe -eq '') {
                    $describe = $group.Name
                }
                else {
                    $null = $contexts.Add($group.Name)
                }
            }

            $context = $contexts -join '\'

            $script:TestResult += & $SafeCommands['New-Object'] psobject -Property @{
                Describe               = $describe
                Context                = $context
                Name                   = $Name
                Passed                 = $Passed
                Result                 = $Result
                Time                   = $Time
                FailureMessage         = $FailureMessage
                StackTrace             = $StackTrace
                ErrorRecord            = $ErrorRecord
                ParameterizedSuiteName = $ParameterizedSuiteName
                Parameters             = $Parameters
                Show                   = $script:Show
            }
        }

        function AddSetupOrTeardownBlock([scriptblock] $ScriptBlock, [string] $CommandName) {
            $currentGroup = $script:TestGroupStack.Peek()

            $isSetupCommand = IsSetupCommand -CommandName $CommandName
            $isGroupCommand = IsTestGroupCommand -CommandName $CommandName

            if ($isSetupCommand) {
                if ($isGroupCommand) {
                    $currentGroup.BeforeAll.Add($ScriptBlock)
                }
                else {
                    $currentGroup.BeforeEach.Add($ScriptBlock)
                }
            }
            else {
                if ($isGroupCommand) {
                    $currentGroup.AfterAll.Add($ScriptBlock)
                }
                else {
                    $currentGroup.AfterEach.Add($ScriptBlock)
                }
            }
        }

        function IsSetupCommand {
            param ([string] $CommandName)
            return $CommandName -eq 'BeforeEach' -or $CommandName -eq 'BeforeAll'
        }

        function IsTestGroupCommand {
            param ([string] $CommandName)
            return $CommandName -eq 'BeforeAll' -or $CommandName -eq 'AfterAll'
        }

        function GetTestCaseSetupBlocks {
            $blocks = @(
                foreach ($group in $this.TestGroups) {
                    $group.BeforeEach
                }
            )

            return $blocks
        }

        function GetTestCaseTeardownBlocks {
            $groups = @($this.TestGroups)
            [Array]::Reverse($groups)

            $blocks = @(
                foreach ($group in $groups) {
                    $group.AfterEach
                }
            )

            return $blocks
        }

        function GetCurrentTestGroupSetupBlocks {
            return $script:TestGroupStack.Peek().BeforeAll
        }

        function GetCurrentTestGroupTeardownBlocks {
            return $script:TestGroupStack.Peek().AfterAll
        }

        function EnterTest {
            if ($script:InTest) {
                throw 'You are already in a test case.'
            }

            $script:TestStartTime = $script:Stopwatch.Elapsed
            $script:InTest = $true
        }

        function LeaveTest {
            $script:TestStopTime = $script:Stopwatch.Elapsed
            $script:InTest = $false
        }

        $ExportedVariables = "TagFilter",
        "ExcludeTagFilter",
        "TestNameFilter",
        "ScriptBlockFilter",
        "TestResult",
        "SessionState",
        "CommandCoverage",
        "Strict",
        "Show",
        "Time",
        "TotalCount",
        "PassedCount",
        "FailedCount",
        "SkippedCount",
        "PendingCount",
        "InconclusiveCount",
        "IncludeVSCodeMarker",
        "TestActions",
        "TestGroupStack",
        "TestSuiteName",
        "InTest",
        "RunningViaInvokePester"

        $ExportedFunctions = "EnterTestGroup",
        "LeaveTestGroup",
        "AddTestResult",
        "AddSetupOrTeardownBlock",
        "GetTestCaseSetupBlocks",
        "GetTestCaseTeardownBlocks",
        "GetCurrentTestGroupSetupBlocks",
        "GetCurrentTestGroupTeardownBlocks",
        "EnterTest",
        "LeaveTest"

        & $SafeCommands['Export-ModuleMember'] -Variable $ExportedVariables -function $ExportedFunctions
    }  |
        & $SafeCommands['Add-Member'] -PassThru -MemberType ScriptProperty -Name CurrentTestGroup -Value {
        $this.TestGroupStack.Peek()
    } |
        & $SafeCommands['Add-Member'] -PassThru -MemberType ScriptProperty -Name TestGroups -Value {
        $array = $this.TestGroupStack.ToArray()
        [Array]::Reverse($array)
        return $array
    } |
        & $SafeCommands['Add-Member'] -PassThru -MemberType ScriptProperty -Name IndentLevel -Value {
        # We ignore the root node of the stack here, and don't start indenting until after the Script nodes inside the root
        return [Math]::Max(0, $this.TestGroupStack.Count - 2)
    }
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUmkuNYKsGqbcH53Y8Sif1Q1xt
# VJuggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
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
# TQqoPXwAe4wH8/3kHDHO/8NT+xwwDQYJKoZIhvcNAQEBBQAEggEAjrzykYdpU/1x
# UR4h3z7z1nB6/ruxGU8RS+wrhtZ3hIdLlCuY4EC1tFYEhBu3M161ZTHZuczHGrF3
# baO2Giyrzxay+kwU+Lqo/eChN74TC9nrTLQFzxbIiwwkio7kEKfbc59Pc1SxyPFr
# ZgIKpCWdP4gHTTzLlZ7lokrVR7qISxBC41gQWZ013xv2VwfL2KYO5rb6+aBsiywE
# G4ObtVNidKB3RGycYqMO3jBd+HrEWos1ImFYayK2qBPUWqQ88i6HXX4t+jHscASt
# jH4ZRcWRTSpDCQvDuRaodAmiOYrRNN6MR8TF46/NHmOiw/hZ6V+uceDKLw4aAygL
# MX4J/UZ5iKGCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDA3WjAjBgkqhkiG9w0BCQQx
# FgQUze02YQBhdgGNThVB1KTXxqbiG4YwDQYJKoZIhvcNAQEBBQAEggEAR8KOlUFc
# o7s+Gl/7tXRaJtDGB5dhrvhrTo3lJEs3uvtqShMa4Em4cB0bPsRPbTDtVDyMSUYT
# h6R0IyhO9zIVrGB4ftwiV9XFLs9uIyQZ2cEhdnlXdFXl1Y7Qf9bmJtoSQXK1yb4Z
# C4TuHonfv22lFVw4CJmzYixSQ0D6B7LFm7BtZcZyTNQSgZKYG0Q5a1oUAEuP8yNJ
# gB/tkgfND+Zpyo+IYgvxwDMPKY4I4p1/4BbUCk05aLsCpkPuoMtEEb12ogBQ3hjH
# x3MLW7qGSn+wnzlKdPgbY2tz9OM/bh/iIW2AkXAc1ZsCsht2p4Rlu5uE/0MDMsGY
# Ue/qyWGwEG10mw==
# SIG # End signature block
