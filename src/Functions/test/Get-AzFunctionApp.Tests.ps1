$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzFunctionApp' {
    It 'GetAll' {
        $functionApps = @(Get-AzFunctionApp)
        $functionApps.Count | Should -BeGreaterThan 0
    }

    It "ByLocation '$($env.location)'" {

        $functionApps = @(Get-AzFunctionApp -Location "$($env.location)")
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.Location | Should Be $env.location
        }
    }

    It "-SubscriptionId $($env.SubscriptionId)" {

        $functionApps = @(Get-AzFunctionApp -SubscriptionId $env.SubscriptionId)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.SubscriptionId | Should Be $env.SubscriptionId
        }
    }

    It "-ResourceGroupName '$($env.resourceGroupNameWindowsPremium)'" {

        $functionApps = @(Get-AzFunctionApp -ResourceGroupName $env.resourceGroupNameWindowsPremium)
        $functionApps.Count | Should -BeGreaterThan 0

        $functionApps | ForEach-Object {
            $_.ResourceGroupName | Should Be $env.resourceGroupNameWindowsPremium
        }
    }

    # ByName
    foreach ($functionDefinition in $env.functionAppsToCreate)
    {
        It "Get-AzFunctionApp -Name '$($functionDefinition.Name)' and validate properties" {
            $functionApp = Get-AzFunctionApp -Name $functionDefinition.Name `
                                             -ResourceGroupName $functionDefinition.ResourceGroupName

            $functionApp.OSType | Should -Be $functionDefinition.OSType
            $functionApp.Runtime | Should -Be $functionDefinition.Runtime
            $functionApp.ResourceGroupName | Should -Be $functionDefinition.ResourceGroupName
        }
    }
}
