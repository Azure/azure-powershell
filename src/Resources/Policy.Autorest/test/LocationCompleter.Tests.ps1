# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'LocationCompleter'

Describe 'LocationCompleter' {

    It 'ValidateLocations' {
        {
            # Get the current set of locations
            $response = Invoke-AzRestMethod -Uri "https://management.azure.com/subscriptions/$subscriptionId/locations?api-version=2022-12-01" -Method GET
            $currentLocations = ($response.Content | ConvertFrom-Json -Depth 100).value | Sort-Object -Property name | Select-Object -ExpandProperty name | Sort-Object

            # Get the locations the cmdlet knows about
            $cmdlet = Get-Command New-AzPolicyAssignment
            $cmdletAST = [System.Management.Automation.Language.Parser]::ParseInput($cmdlet.Definition, [ref]$null, [ref]$null)
            $cmdletLocations = LocationCompleter -CommandName New-AzPolicyAssignment -ParameterName Location -WordToComplete '*' -CommandAst $cmdletAST -fakeBoundParameter @{}
            $cmdletLocations | Should -Be $currentLocations
        } | Should -Not -Throw
    }
}