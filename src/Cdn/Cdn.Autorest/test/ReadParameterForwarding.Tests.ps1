$helperPath = Join-Path $PSScriptRoot '..\custom\Get-AzCdnReadParameters.ps1'
$helperSource = Get-Content -Path $helperPath -Raw
$helperSource = $helperSource -replace '(?m)^\s*\[Microsoft\.Azure\.PowerShell\.Cmdlets\.Cdn\.DoNotExportAttribute\(\)\]\r?\n', ''
. ([scriptblock]::Create($helperSource))

function Get-AzCdnReadTestResource {
    [CmdletBinding()]
    param(
        [Alias('ResourceName')]
        [string] $Name,
        [object] $DefaultProfile
    )

    $script:cdnReadParameters = @{} + $PSBoundParameters
}

function Set-AzCdnReadTestResource {
    [CmdletBinding()]
    param(
        [string] $Name,
        [object] $DefaultProfile,
        [switch] $AcquirePolicyToken,
        [string] $ChangeReference,
        [string] $SyntheticWriteOnly
    )

    $script:cdnWriteParameters = @{} + $PSBoundParameters
}

Set-Alias -Name Get-AzCdnReadTestAlias -Value Get-AzCdnReadTestResource

Describe 'CDN read parameter forwarding' {
    It 'filters write-only parameters without changing the write dictionary' {
        $writeParameters = @{
            Name = 'profile'
            DefaultProfile = 'profile-context'
            ErrorAction = 'Stop'
            AcquirePolicyToken = $true
            ChangeReference = 'change-123'
            SyntheticWriteOnly = 'future-value'
        }

        $readParameters = Get-AzCdnReadParameters -CommandName 'Get-AzCdnReadTestAlias' -BoundParameters $writeParameters
        Get-AzCdnReadTestResource @readParameters
        Set-AzCdnReadTestResource @writeParameters

        $script:cdnReadParameters.Name | Should Be 'profile'
        $script:cdnReadParameters.DefaultProfile | Should Be 'profile-context'
        $script:cdnReadParameters.ErrorAction | Should Be 'Stop'
        $script:cdnReadParameters.ContainsKey('AcquirePolicyToken') | Should Be $false
        $script:cdnReadParameters.ContainsKey('ChangeReference') | Should Be $false
        $script:cdnReadParameters.ContainsKey('SyntheticWriteOnly') | Should Be $false
        $script:cdnWriteParameters.AcquirePolicyToken | Should Be $true
        $script:cdnWriteParameters.ChangeReference | Should Be 'change-123'
        $script:cdnWriteParameters.SyntheticWriteOnly | Should Be 'future-value'
    }

    It 'includes aliases from the resolved read command metadata' {
        $command = Get-Command -Name 'Get-AzCdnReadTestAlias'
        while ($command.CommandType -eq [System.Management.Automation.CommandTypes]::Alias) {
            $command = Get-Command -Name $command.ResolvedCommandName
        }
        $parameterNames = @($command.Parameters.Keys)
        $parameterNames += @($command.Parameters.Values | ForEach-Object { $_.Aliases })

        ($parameterNames -contains 'ResourceName') | Should Be $true
    }

    It 'uses an exact helper and GET pair in every affected parameter-set branch' {
        $cases = @(
            @{ File = 'Remove-AzCdnProfile.ps1'; ReadCommand = 'Get-AzCdnProfile'; WriteCommand = 'Remove-AzCdnProfile' },
            @{ File = 'Remove-AzFrontDoorCdnProfile.ps1'; ReadCommand = 'Get-AzFrontDoorCdnProfile'; WriteCommand = 'Remove-AzCdnProfile' },
            @{ File = 'Update-AzCdnProfile.ps1'; ReadCommand = 'Get-AzCdnProfile'; WriteCommand = 'Update-AzCdnProfile' },
            @{ File = 'Update-AzFrontDoorCdnProfile.ps1'; ReadCommand = 'Get-AzFrontDoorCdnProfile'; WriteCommand = 'Update-AzCdnProfile' }
        )
        $pairPattern = "(?m)^[ \t]*\`$readParameters = Get-AzCdnReadParameters -CommandName '([^']+)' -BoundParameters \`$PSBoundParameters\r?\n[ \t]*\`$\w+ = \1 @readParameters[ \t]*\r?$"

        foreach ($case in $cases) {
            $source = Get-Content -Path (Join-Path $PSScriptRoot "..\custom\$($case.File)") -Raw
            $pairs = [regex]::Matches($source, $pairPattern)

            $pairs.Count | Should Be 2
            foreach ($pair in $pairs) {
                $pair.Groups[1].Value | Should Be $case.ReadCommand
            }
            $source | Should Not Match '\$targetParameters'
            $source | Should Match ([regex]::Escape("Az.Cdn.internal\$($case.WriteCommand) @PSBoundParameters"))
        }
    }

    It 'packages the internal helper and triggers regeneration' {
        $customPath = Join-Path $PSScriptRoot '..\custom'
        $moduleSource = Get-Content -Path (Join-Path $customPath 'Az.Cdn.custom.psm1') -Raw
        $helperSource = Get-Content -Path (Join-Path $customPath 'Get-AzCdnReadParameters.ps1') -Raw
        $generation = Get-Content -Path (Join-Path $PSScriptRoot '..\generate-info.json') -Raw | ConvertFrom-Json

        $helperSource | Should Match '\[Microsoft\.Azure\.PowerShell\.Cmdlets\.Cdn\.DoNotExportAttribute\(\)\]'
        $moduleSource | Should Match "Get-ChildItem\s+-Path\s+\`$PSScriptRoot\s+-Recurse\s+-Include\s+'\*\.ps1'"
        { [guid]::Parse($generation.generate_Id) } | Should Not Throw
        $generation.generate_Id | Should Not Be '39d7c1e4-7bfb-4e14-a49a-ba3e1c9354f5'
    }
}
