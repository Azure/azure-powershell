# Verify the generated proxy split: exactly the 12 node-local cmdlets omit login
# verification, while every other exported cmdlet retains it. CI uses packaged
# exports; source-tree runs fall back to the repository's generated output.
Describe 'StackHCI generated login verification' {

    BeforeAll {
        $proxyPath = [System.IO.Path]::Combine(
            (Split-Path -Path $PSScriptRoot -Parent),
            'exports',
            'ProxyCmdletDefinitions.ps1')

        if (-not (Test-Path -LiteralPath $proxyPath)) {
            $repoRoot = $PSScriptRoot
            1..4 | ForEach-Object {
                $repoRoot = Split-Path -Path $repoRoot -Parent
            }

            $proxyPath = [System.IO.Path]::Combine(
                $repoRoot,
                'generated',
                'StackHCI',
                'StackHCI.Autorest',
                'exports',
                'ProxyCmdletDefinitions.ps1')
        }

        $expectedLocalCmdlets = @(
            'Enable-AzStackHCIRemoteSupport'
            'Disable-AzStackHCIRemoteSupport'
            'Install-AzStackHCIRemoteSupport'
            'Remove-AzStackHCIRemoteSupport'
            'Get-AzStackHCIRemoteSupportAccess'
            'Get-AzStackHCIRemoteSupportSessionHistory'
            'Get-AzStackHCIVMAttestation'
            'Add-AzStackHCIVMAttestation'
            'Remove-AzStackHCIVMAttestation'
            'Enable-AzStackHCIAttestation'
            'Disable-AzStackHCIAttestation'
            'Get-AzStackHCILogsDirectory'
        ) | Sort-Object

        $proxyContent = Get-Content -LiteralPath $proxyPath -Raw
        $proxyFunctions = [regex]::Matches(
            $proxyContent,
            '(?ms)^function\s+(?<name>[^\s{]+)\s*\{(?<body>.*?)(?=^function\s+|\z)')

        $guardedCmdlets = @(
            $proxyFunctions |
                Where-Object { $_.Groups['body'].Value -match 'No Azure login detected' } |
                ForEach-Object { $_.Groups['name'].Value } |
                Sort-Object
        )
        $unguardedCmdlets = @(
            $proxyFunctions |
                Where-Object { $_.Groups['body'].Value -notmatch 'No Azure login detected' } |
                ForEach-Object { $_.Groups['name'].Value } |
                Sort-Object
        )
    }

    It 'Should leave only the 12 node-local cmdlets unguarded' {
        $unguardedCmdlets.Count | Should -Be $expectedLocalCmdlets.Count
        $guardedCmdlets.Count | Should -Be ($proxyFunctions.Count - $expectedLocalCmdlets.Count)
        Compare-Object -ReferenceObject $expectedLocalCmdlets -DifferenceObject $unguardedCmdlets -CaseSensitive |
            Should -BeNullOrEmpty
    }
}
