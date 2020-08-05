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
            Name = (New-Guid).Guid
            ResourceGroupName = $env.ResourceGroupName
        }
    }

    AfterEach {
        & $env.azcmagentPath disconnect --access-token $env.AccessToken
    }

    It 'Can connect a machine to an existing resource group' {
        $machine = New-AzConnectedMachine @commonParams -Location $env.location
        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly $env.location
    }
}
