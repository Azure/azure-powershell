$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzStackHCIVMVirtualMachine.Recording.json'
$mockingPath = $null
$currentPath = $PSScriptRoot
while (-not $mockingPath -and $currentPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Filter 'HttpPipelineMocking.ps1' -File -ErrorAction SilentlyContinue
    $parentPath = Split-Path -Path $currentPath -Parent
    if (-not $parentPath -or $parentPath -eq $currentPath) {
        break
    }
    $currentPath = $parentPath
}
if (-not $mockingPath) {
    throw "HttpPipelineMocking.ps1 not found when searching from path '$PSScriptRoot'."
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Save-AzStackHCIVMVirtualMachine' {
    It 'ByResourceId' {
        $command = Get-Command -Name 'Save-AzStackHCIVMVirtualMachine' -ErrorAction Stop
        $command | Should -Not -BeNullOrEmpty
        $command.Parameters.Keys | Should -Contain 'ResourceId'

        # Exercise the wrapper logic for the parameter set that uses ResourceId by invoking with -WhatIf
        $resourceIdParameterSet = $command.ParameterSets |
            Where-Object { $_.Parameters.Name -contains 'ResourceId' } |
            Select-Object -First 1

        $resourceIdParameterSet | Should -Not -BeNullOrEmpty

        $mandatoryParams = $resourceIdParameterSet.Parameters |
            Where-Object { $_.IsMandatory -and $_.Name -notin @('WhatIf', 'Confirm') }

        $splat = @{}
        foreach ($param in $mandatoryParams) {
            switch ($param.ParameterType.FullName) {
                'System.Int32' { $splat[$param.Name] = 1 }
                'System.Int64' { $splat[$param.Name] = 1 }
                'System.Boolean' { $splat[$param.Name] = $true }
                default { $splat[$param.Name] = 'test' }
            }
        }

        { Save-AzStackHCIVMVirtualMachine @splat -WhatIf } | Should -Not -Throw
    }

    It 'ByName' {
        $command = Get-Command -Name 'Save-AzStackHCIVMVirtualMachine' -ErrorAction Stop
        $command | Should -Not -BeNullOrEmpty
        $command.Parameters.Keys | Should -Contain 'Name'

        # Exercise the wrapper logic for the parameter set that uses Name by invoking with -WhatIf
        $nameParameterSet = $command.ParameterSets |
            Where-Object { $_.Parameters.Name -contains 'Name' } |
            Select-Object -First 1

        $nameParameterSet | Should -Not -BeNullOrEmpty

        $mandatoryNameParams = $nameParameterSet.Parameters |
            Where-Object { $_.IsMandatory -and $_.Name -notin @('WhatIf', 'Confirm') }

        $nameSplat = @{}
        foreach ($param in $mandatoryNameParams) {
            switch ($param.ParameterType.FullName) {
                'System.Int32' { $nameSplat[$param.Name] = 1 }
                'System.Int64' { $nameSplat[$param.Name] = 1 }
                'System.Boolean' { $nameSplat[$param.Name] = $true }
                default { $nameSplat[$param.Name] = 'test' }
            }
        }

        { Save-AzStackHCIVMVirtualMachine @nameSplat -WhatIf } | Should -Not -Throw
    }
}
