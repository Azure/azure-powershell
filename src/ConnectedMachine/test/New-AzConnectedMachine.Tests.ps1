$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzConnectedMachine' {
    BeforeEach {
        $commonParams = @{
            Location = $env.location
            Name = (New-Guid).Guid
        }
    }
    AfterEach {
        Remove-AzConnectedMachine -Name $commonParams.Name
    }
    It 'Can connect a machine to an existing resource group' -Skip:([bool]$IsMacOS) {
        $machine = New-AzConnectedMachine @commonParams
        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly $env.location
    }
}
