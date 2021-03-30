$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdScalingPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# TODO: Use this because we have limited Arm rollout for this feature, change to use $env.Location and $env.ResourceGroup
#$resourceGroup = $env.ResourceGroup
#$resourceLocation = $env.Location
$resourceGroup = 'jehurren-westcentralus'
$resourceLocation = 'westcentralus'

Describe 'Remove-AzWvdScalingPlan' {
    It 'Delete' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $resourceLocation `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $resourceLocation

            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            {
                Get-AzWvdScalingPlan `
                    -SubscriptionId $env.SubscriptionId `
                    -ResourceGroupName $resourceGroup `
                    -Name 'ScalingPlanPowershellContained1'
            } | Should -Throw
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }
}
