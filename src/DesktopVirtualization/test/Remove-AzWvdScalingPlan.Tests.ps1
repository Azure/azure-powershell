$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
Write-Host $loadEnvPath
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath) "scalingEnv.json"

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdScalingPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdScalingPlan' {
    It 'Delete' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $env.Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Location

            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            {
                Get-AzWvdScalingPlan `
                    -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $env.ResourceGroup `
                    -Name 'ScalingPlanPowershellContained1'
            } | Should -Throw
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }
}
