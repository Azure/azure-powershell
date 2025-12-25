$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataProtectionJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataProtectionJob' -Tag 'LiveOnly' {
    It 'List' {
        $jobs = Get-AzDataProtectionJob -SubscriptionId $env.TestBlobHardeningScenario.SubscriptionId -ResourceGroupName $env.TestBlobHardeningScenario.ResourceGroupName -VaultName $env.TestBlobHardeningScenario.VaultName
        $jobs.Length | Should -BeGreaterThan 0
        }

    It 'Get' {
        $jobs = Get-AzDataProtectionJob -SubscriptionId $env.TestBlobHardeningScenario.SubscriptionId -ResourceGroupName $env.TestBlobHardeningScenario.ResourceGroupName -VaultName $env.TestBlobHardeningScenario.VaultName
        $jobs.Length | Should -BeGreaterThan 0
        $job = Get-AzDataProtectionJob -Id $jobs[0].Name -SubscriptionId $env.TestBlobHardeningScenario.SubscriptionId -ResourceGroupName $env.TestBlobHardeningScenario.ResourceGroupName -VaultName $env.TestBlobHardeningScenario.VaultName
        $job.Id | Should be $jobs[0].Id
    }

    # Redudant test case, covered in 'List' test case, restore will disappear eventually after retention period
    It 'ListCRR' -skip {
        $resourceGroupName  = $env.TestCrossRegionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossRegionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossRegionRestoreScenario.SubscriptionId

        $jobs = Get-AzDataProtectionJob -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -UseSecondaryRegion
        
        $jobs.Length | Should -BeGreaterThan 0
        ($jobs[0].OperationCategory -eq "CrossRegionRestore") | Should be $true
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
