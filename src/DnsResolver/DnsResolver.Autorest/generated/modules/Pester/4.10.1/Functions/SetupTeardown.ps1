function BeforeEach {
    <#
    .SYNOPSIS
        Defines a series of steps to perform at the beginning of every It block within
        the current Context or Describe block.

    .DESCRIPTION
        BeforeEach, AfterEach, BeforeAll, and AfterAll are unique in that they apply
        to the entire Context or Describe block, regardless of the order of the
        statements in the Context or Describe.  For a full description of this
        behavior, as well as how multiple BeforeEach or AfterEach blocks interact
        with each other, please refer to the about_BeforeEach_AfterEach help file.

    .LINK
        https://pester.dev/docs/commands/AfterEach

    #>
    [CmdletBinding()]
    param
    (
        # the scriptblock to execute
        [Parameter(Mandatory = $true,
            Position = 1)]
        [Scriptblock]
        $Scriptblock
    )
    Assert-DescribeInProgress -CommandName BeforeEach
}

function AfterEach {
    <#
    .SYNOPSIS
        Defines a series of steps to perform at the end of every It block within
        the current Context or Describe block.

    .DESCRIPTION
        BeforeEach, AfterEach, BeforeAll, and AfterAll are unique in that they apply
        to the entire Context or Describe block, regardless of the order of the
        statements in the Context or Describe.  For a full description of this
        behavior, as well as how multiple BeforeEach or AfterEach blocks interact
        with each other, please refer to the about_BeforeEach_AfterEach help file.

    .LINK
        https://pester.dev/docs/commands/BeforeEach

    #>
    [CmdletBinding()]
    param
    (
        # the scriptblock to execute
        [Parameter(Mandatory = $true,
            Position = 1)]
        [Scriptblock]
        $Scriptblock
    )
    Assert-DescribeInProgress -CommandName AfterEach
}

function BeforeAll {
    <#
    .SYNOPSIS
        Defines a series of steps to perform at the beginning of the current Context
        or Describe block.

    .DESCRIPTION
        BeforeEach, AfterEach, BeforeAll, and AfterAll are unique in that they apply
        to the entire Context or Describe block, regardless of the order of the
        statements in the Context or Describe.

        .LINK
        https://pester.dev/docs/commands/AfterAll

    #>
    [CmdletBinding()]
    param
    (
        # the scriptblock to execute
        [Parameter(Mandatory = $true,
            Position = 1)]
        [Scriptblock]
        $Scriptblock
    )
    Assert-DescribeInProgress -CommandName BeforeAll
}

function AfterAll {
    <#
.SYNOPSIS
    Defines a series of steps to perform at the end of the current Context
    or Describe block.

.DESCRIPTION
    BeforeEach, AfterEach, BeforeAll, and AfterAll are unique in that they apply
    to the entire Context or Describe block, regardless of the order of the
    statements in the Context or Describe.

.LINK
    https://pester.dev/docs/commands/BeforeAll
#>
    [CmdletBinding()]
    param
    (
        # the scriptblock to execute
        [Parameter(Mandatory = $true,
            Position = 1)]
        [Scriptblock]
        $Scriptblock
    )
    Assert-DescribeInProgress -CommandName AfterAll
}

function Invoke-TestCaseSetupBlocks {
    Invoke-Blocks -ScriptBlock $pester.GetTestCaseSetupBlocks()
}

function Invoke-TestCaseTeardownBlocks {
    Invoke-Blocks -ScriptBlock $pester.GetTestCaseTeardownBlocks()
}

function Invoke-TestGroupSetupBlocks {
    Invoke-Blocks -ScriptBlock $pester.GetCurrentTestGroupSetupBlocks()
}

function Invoke-TestGroupTeardownBlocks {
    Invoke-Blocks -ScriptBlock $pester.GetCurrentTestGroupTeardownBlocks()
}

function Invoke-Blocks {
    param ([scriptblock[]] $ScriptBlock)

    foreach ($block in $ScriptBlock) {
        if ($null -eq $block) {
            continue
        }
        $null = . $block
    }
}

function Add-SetupAndTeardown {
    param (
        [scriptblock] $ScriptBlock
    )

    if ($PSVersionTable.PSVersion.Major -le 2) {
        Add-SetupAndTeardownV2 -ScriptBlock $ScriptBlock
    }
    else {
        Add-SetupAndTeardownV3 -ScriptBlock $ScriptBlock
    }
}

function Add-SetupAndTeardownV3 {
    param (
        [scriptblock] $ScriptBlock
    )

    $pattern = '^(?:Before|After)(?:Each|All)$'
    $predicate = {
        param ([System.Management.Automation.Language.Ast] $Ast)

        $Ast -is [System.Management.Automation.Language.CommandAst] -and
        $Ast.CommandElements[0].ToString() -match $pattern -and
        $Ast.CommandElements[-1] -is [System.Management.Automation.Language.ScriptBlockExpressionAst]
    }

    $searchNestedBlocks = $false

    $calls = $ScriptBlock.Ast.FindAll($predicate, $searchNestedBlocks)

    foreach ($call in $calls) {
        # For some reason, calling ScriptBlockAst.GetScriptBlock() sometimes blows up due to failing semantics
        # checks, even though the code is perfectly valid.  So we'll poke around with reflection again to skip
        # that part and just call the internal ScriptBlock constructor that we need

        $iPmdProviderType = [scriptblock].Assembly.GetType('System.Management.Automation.Language.IParameterMetadataProvider')

        $flags = [System.Reflection.BindingFlags]'Instance, NonPublic'
        $constructor = [scriptblock].GetConstructor($flags, $null, [Type[]]@($iPmdProviderType, [bool]), $null)

        $block = $constructor.Invoke(@($call.CommandElements[-1].ScriptBlock, $false))

        Set-ScriptBlockScope -ScriptBlock $block -SessionState $pester.SessionState
        $commandName = $call.CommandElements[0].ToString()
        Add-SetupOrTeardownScriptBlock -CommandName $commandName -ScriptBlock $block
    }
}

function Add-SetupAndTeardownV2 {
    param (
        [scriptblock] $ScriptBlock
    )

    $codeText = $ScriptBlock.ToString()
    $tokens = @(ParseCodeIntoTokens -CodeText $codeText)

    for ($i = 0; $i -lt $tokens.Count; $i++) {
        $token = $tokens[$i]
        $type = $token.Type
        if ($type -eq [System.Management.Automation.PSTokenType]::Command -and
            (IsSetupOrTeardownCommand -CommandName $token.Content)) {
            $openBraceIndex, $closeBraceIndex = Get-BraceIndicesForCommand -Tokens $tokens -CommandIndex $i

            $block = Get-ScriptBlockFromTokens -Tokens $Tokens -OpenBraceIndex $openBraceIndex -CloseBraceIndex $closeBraceIndex -CodeText $codeText
            Add-SetupOrTeardownScriptBlock -CommandName $token.Content -ScriptBlock $block

            $i = $closeBraceIndex
        }
        elseif ($type -eq [System.Management.Automation.PSTokenType]::GroupStart) {
            # We don't want to parse Setup or Teardown commands in child scopes here, so anything
            # bounded by a GroupStart / GroupEnd token pair which is not immediately preceded by
            # a setup / teardown command name is ignored.
            $i = Get-GroupCloseTokenIndex -Tokens $tokens -GroupStartTokenIndex $i
        }
    }
}

function ParseCodeIntoTokens {
    param ([string] $CodeText)

    $parseErrors = $null
    $tokens = [System.Management.Automation.PSParser]::Tokenize($CodeText, [ref] $parseErrors)

    if ($parseErrors.Count -gt 0) {
        $currentScope = $pester.CurrentTestGroup.Hint
        if (-not $currentScope) {
            $currentScope = 'test group'
        }
        throw "The current $currentScope block contains syntax errors."
    }

    return $tokens
}

function IsSetupOrTeardownCommand {
    param ([string] $CommandName)
    return (IsSetupCommand -CommandName $CommandName) -or (IsTeardownCommand -CommandName $CommandName)
}

function IsSetupCommand {
    param ([string] $CommandName)
    return $CommandName -eq 'BeforeEach' -or $CommandName -eq 'BeforeAll'
}

function IsTeardownCommand {
    param ([string] $CommandName)
    return $CommandName -eq 'AfterEach' -or $CommandName -eq 'AfterAll'
}

function IsTestGroupCommand {
    param ([string] $CommandName)
    return $CommandName -eq 'BeforeAll' -or $CommandName -eq 'AfterAll'
}

function Get-BraceIndicesForCommand {
    param (
        [System.Management.Automation.PSToken[]] $Tokens,
        [int] $CommandIndex
    )

    $openingGroupTokenIndex = Get-GroupStartTokenForCommand -Tokens $Tokens -CommandIndex $CommandIndex
    $closingGroupTokenIndex = Get-GroupCloseTokenIndex -Tokens $Tokens -GroupStartTokenIndex $openingGroupTokenIndex

    return $openingGroupTokenIndex, $closingGroupTokenIndex
}

function Get-GroupStartTokenForCommand {
    param (
        [System.Management.Automation.PSToken[]] $Tokens,
        [int] $CommandIndex
    )

    $commandName = $Tokens[$CommandIndex].Content

    # gets ScriptBlock from positional parameter e.g. BeforeEach { <code> }
    if ($CommandIndex + 1 -lt $tokens.Count -and
        ($tokens[$CommandIndex + 1].Type -eq [System.Management.Automation.PSTokenType]::GroupStart -or
            $tokens[$CommandIndex + 1].Content -eq '{')) {
        return $CommandIndex + 1
    }

    # gets ScriptBlock from named parameter e.g. BeforeEach -ScriptBlock { <code> }
    if ($CommandIndex + 2 -lt $tokens.Count -and
        ($tokens[$CommandIndex + 2].Type -eq [System.Management.Automation.PSTokenType]::GroupStart -or
            $tokens[$CommandIndex + 2].Content -eq '{')) {
        return $CommandIndex + 2
    }

    throw "The $commandName command must be followed by the script block as the first argument or named parameter value."
}

& $SafeCommands['Add-Type'] -TypeDefinition @'
    namespace Pester
    {
        using System;
        using System.Management.Automation;

        public static class ClosingBraceFinder
        {
            public static int GetClosingBraceIndex(PSToken[] tokens, int startIndex)
            {
                int groupLevel = 1;
                int len = tokens.Length;

                for (int i = startIndex + 1; i < len; i++)
                {
                    PSTokenType type = tokens[i].Type;
                    if (type == PSTokenType.GroupStart)
                    {
                        groupLevel++;
                    }
                    else if (type == PSTokenType.GroupEnd)
                    {
                        groupLevel--;

                        if (groupLevel <= 0) { return i; }
                    }
                }

                return -1;
            }
        }
    }
'@

function Get-GroupCloseTokenIndex {
    param (
        [System.Management.Automation.PSToken[]] $Tokens,
        [int] $GroupStartTokenIndex
    )

    $closeIndex = [Pester.ClosingBraceFinder]::GetClosingBraceIndex($Tokens, $GroupStartTokenIndex)

    if ($closeIndex -lt 0) {
        throw 'No corresponding GroupEnd token was found.'
    }

    return $closeIndex
}

function Get-ScriptBlockFromTokens {
    param (
        [System.Management.Automation.PSToken[]] $Tokens,
        [int] $OpenBraceIndex,
        [int] $CloseBraceIndex,
        [string] $CodeText
    )

    $blockStart = $Tokens[$OpenBraceIndex + 1].Start
    $blockLength = $Tokens[$CloseBraceIndex].Start - $blockStart
    $setupOrTeardownCodeText = $codeText.Substring($blockStart, $blockLength)

    $scriptBlock = [scriptblock]::Create($setupOrTeardownCodeText)
    Set-ScriptBlockHint -Hint "Unbound ScriptBlock from Get-ScriptBlockFromTokens" -ScriptBlock $scriptBlock
    Set-ScriptBlockScope -ScriptBlock $scriptBlock -SessionState $pester.SessionState

    return $scriptBlock
}

function Add-SetupOrTeardownScriptBlock {
    param (
        [string] $CommandName,
        [scriptblock] $ScriptBlock
    )

    $Pester.AddSetupOrTeardownBlock($ScriptBlock, $CommandName)
}

# SIG # Begin signature block
# MIIcVgYJKoZIhvcNAQcCoIIcRzCCHEMCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUqIaObdWMQcKsTArM41YKB8d/
# cLCggheFMIIFDjCCA/agAwIBAgIQCIQ1OU/QbU6rESO7M78utDANBgkqhkiG9w0B
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
# vo/J1Kd2MqH1bQrZ84Dd778soAQwDQYJKoZIhvcNAQEBBQAEggEAqipDZOTqVZCq
# VgqEsauG1eMKlutWTqCLDw1WrLQ4+c2KzVBFfN+UObcAGiFWQY/jXprzOaRycptI
# Xo+zsvFPunvJiRBxr5q0L007Zv74uX/hKsPS21E/lGdwLT06pEQc3ZDVaBv0reyy
# 2l+zaUpfT1PW66Xaq7TSQTXXAVf6AqXrXwT6Mfz3tZr6YGLoO3/jDfW8Gl/HEqOG
# jzK+eUwaMXh/pXGLtAKC1e4x7cIN+0fHQzmAz2XRTkeMzEsQtIZasiIbgl0yM3CV
# ddaYDG2J3ZPkZRaBX6tujQDvpRQYRtnHb6NzY4ly32eSUGa/3iD6kq8xJEe+uUiO
# rN3oFLxEHaGCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGa
# Ajr/WLFr1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
# DQEHATAcBgkqhkiG9w0BCQUxDxcNMjAwMjA3MTk1NDA4WjAjBgkqhkiG9w0BCQQx
# FgQUYrRGkRHX3JJz4JSuR5QDCSn+j4QwDQYJKoZIhvcNAQEBBQAEggEAcwCZdGsC
# O7VZrRlySROx0hb62mzk0Pc6P76eQU+pbfjDsV4atSMPwWIdqd8o/pXiWH4xCLRc
# VJODoH2ed/AVENITFxg8IqOWfTZueA1+WqYsLHVw70DxJPtXIG3EyM/fSrPAtxTi
# pRhqagclWGqGHW23BV2w6kgUCL/Ndh9lJpJgPAlxXNxdq953pTuJv3rJbmXMMI6+
# fjSxUHhb5wCFDH6mFfR5zzvHhY0G6h6DnXqUyBtP4olOvjW8vRAJj6A/ZPnJ/j7d
# fnH/3zr+spLw7n+gr47O9DOLLZhNrfITZLK25SHF0yzE8WGvofdviBp4S54IruBL
# Z9/90vKq6FHooA==
# SIG # End signature block
