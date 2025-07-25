# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'LocationCompleter'

Describe 'LocationCompleter' -Tag 'LiveOnly' {

    BeforeAll {
        # Get the current set of locations
        $response = Invoke-AzRestMethod -Uri "https://management.azure.com/subscriptions/$subscriptionId/locations?api-version=2022-12-01" -Method GET
        $currentLocations = ($response.Content | ConvertFrom-Json -Depth 100).value | Sort-Object -Property name | Select-Object -ExpandProperty name | Sort-Object

        $cmdlet = Get-Command New-AzPolicyAssignment
        $cmdletAST = [System.Management.Automation.Language.Parser]::ParseInput($cmdlet.Definition, [ref]$null, [ref]$null)
    }

    It 'ValidateLocations' {
        # Get the locations the cmdlet knows about
        $cmdletLocations = LocationCompleter -CommandName New-AzPolicyAssignment -ParameterName Location -WordToComplete '*' -CommandAst $cmdletAST -fakeBoundParameter @{}

        $cmdletLocations | Should -Be $currentLocations
    }

    It 'Location filter' {
        $cmdletLocations = LocationCompleter -CommandName New-AzPolicyAssignment -ParameterName Location -WordToComplete 'a' -CommandAst $cmdletAST -fakeBoundParameter @{}
        $cmdletLocations | Should -Be ($currentLocations | ?{ $_ -like 'a*' })
    }
}