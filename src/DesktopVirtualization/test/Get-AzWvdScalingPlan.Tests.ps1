$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdScalingPlan.Recording.json'
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

Describe 'Get-AzWvdScalingPlan' {
    It 'Get' {
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

            Get-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $resourceLocation
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }

    It 'List' {
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

            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained2' `
                -Location $resourceLocation `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained2'
            $scalingPlan.Location | Should -Be $resourceLocation

            $scalingPlans = Get-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                | Where-Object -Property Name -Match 'ScalingPlanPowershellContained*' `
                | Sort-Object -Property Name

            $scalingPlans.Count | Should -Be 2
            $scalingPlans[0].Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlans[1].Name | Should -Be 'ScalingPlanPowershellContained2'
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained2'
        }
    }

    It 'List By Subscription' {
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

            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained2' `
                -Location $resourceLocation `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone '(UTC-08:00) Pacific Time (US & Canada)' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained2'
            $scalingPlan.Location | Should -Be $resourceLocation

            $scalingPlans = Get-AzWvdScalingPlan -SubscriptionId $env.SubscriptionId `
                | Where-Object -Property Name -Match 'ScalingPlanPowershellContained*' `
                | Sort-Object -Property Name

            $scalingPlans.Count | Should -Be 2
            $scalingPlans[0].Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlans[1].Name | Should -Be 'ScalingPlanPowershellContained2'
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained1'
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $resourceGroup `
                -Name 'ScalingPlanPowershellContained2'
        }
    }
}
