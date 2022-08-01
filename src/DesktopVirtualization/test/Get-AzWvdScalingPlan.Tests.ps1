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

Describe 'Get-AzWvdScalingPlan' {
    It 'Get' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $env.Scaling_location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            Get-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'
        }
    }

    It 'List' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $env.Scaling_Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained2' `
                -Location $env.Scaling_Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained2'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            $scalingPlans = Get-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                | Where-Object -Property Name -Match 'ScalingPlanPowershellContained*' `
                | Sort-Object -Property Name

            $scalingPlans.Count | Should -Be 2
            $scalingPlans[0].Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlans[1].Name | Should -Be 'ScalingPlanPowershellContained2'
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained2'
        }
    }

    It 'List By Subscription' {
        try {
            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1' `
                -Location $env.Scaling_Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            $scalingPlan = New-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained2' `
                -Location $env.Scaling_Location `
                -Description 'desc' `
                -FriendlyName 'fri' `
                -HostPoolType 'Pooled' `
                -TimeZone 'Pacific Standard Time' `
                -Schedule @() `
                -HostPoolReference @()

            $scalingPlan.Name | Should -Be 'ScalingPlanPowershellContained2'
            $scalingPlan.Location | Should -Be $env.Scaling_Location

            $scalingPlans = Get-AzWvdScalingPlan -SubscriptionId $env.Scaling_SubscriptionId `
                | Where-Object -Property Name -Match 'ScalingPlanPowershellContained*' `
                | Sort-Object -Property Name

            $scalingPlans.Count | Should -Be 2
            $scalingPlans[0].Name | Should -Be 'ScalingPlanPowershellContained1'
            $scalingPlans[1].Name | Should -Be 'ScalingPlanPowershellContained2'
        }
        finally {
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained1'
            $scalingPlan = Remove-AzWvdScalingPlan `
                -SubscriptionId $env.Scaling_SubscriptionId `
                -ResourceGroupName $env.Scaling_ResourceGroup `
                -Name 'ScalingPlanPowershellContained2'
        }
    }
}