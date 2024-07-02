if (($null -eq $TestName) -or ($TestName -contains 'ClusterPoolOperations')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'sessionRecords\ClusterPoolOperations.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ClusterPoolOperations' {
    BeforeAll {
        $location = "westus2"
        # need create resources group manually.
        $clusterResourceGroupName = "psGroup"
        $clusterpoolName = "ps-pool-operation"
        $vmSize = "Standard_D4a_v4"
        $LogAnalyticProfileWorkspaceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/psGroup/providers/microsoft.operationalinsights/workspaces/workspace"

    }

    It 'New AzHdInsightOnAksClusterPool' {
        $script:availableVersions = (Get-AzHdInsightOnAksAvailableClusterPoolVersion -Location $location)
        $script:availableVersions | Should -Not -Be $null
        $script:availableVersions.Count | Should -BeGreaterThan 0
        $script:availableVersions[0].ClusterPoolVersionValue | Should -Not -Be $null
        $script:availableVersions[0].Id | Should -Not -Be $null

        [Console]::WriteLine("Get-AzHdInsightOnAksAvailableClusterPoolVersion done")

        { $script:clusterpool = New-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -ClusterPoolVersion  $script:availableVersions[1].ClusterPoolVersionValue  -VmSize $vmSize -Location $location } | Should -Not -Throw
        $script:clusterpool.Name | Should -Be $clusterpoolName
        $script:clusterpool.Location | Should -Be $location
        $script:clusterpool.ClusterPoolVersion | Should -Be $clusterPoolVersion

        [Console]::WriteLine("New-AzHdInsightOnAksClusterPool done")
    }

    It 'Set AzHdInsightOnAksClusterPool LogWorkSpace' {
        { $script:clusterpool = Set-AzHdInsightOnAksClusterPool -Name $clusterpoolName -ResourceGroupName $clusterResourceGroupName -VmSize $vmSize -Location $location `
                -EnableLogAnalytics `
                -LogAnalyticWorkspaceResourceId $LogAnalyticProfileWorkspaceId
        } | Should -Not -Throw
        $script:clusterpool.LogAnalyticProfileWorkspaceId | Should -Be $LogAnalyticProfileWorkspaceId

        [Console]::WriteLine("Set-AzHdInsightOnAksClusterPool done")
    }

    It 'Get All AzHdInsightOnAksClusterPool in RG' {
        { $script:clusterpools = Get-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName } | Should -Not -Throw
        $script:clusterpools | Should -Not -BeNullOrEmpty

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPool done")
    }
        
    It 'Get AzHdInsightOnAksClusterPool with poolName' {
        { $script:clusterpool = Get-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName } | Should -Not -Throw
        $script:clusterpool.Name | Should -Be $clusterpoolName
        $script:clusterpool.Location | Should -Be $location

        [Console]::WriteLine("Get-AzHdInsightOnAksClusterPool done")
    }

    It 'Update-AzHdInsightOnAksClusterPoolTag' {
        $tag = @{ Tag = "powershell test" }

        { Update-AzHdInsightOnAksClusterPoolTag -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -Tag $tag } | Should -Not -Throw
        { $script:clusterpool = Get-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName } | Should -Not -Throw
        $script:clusterpool.Name | Should -Be $clusterpoolName
        $script:clusterpool.Location | Should -Be $location
        $script:clusterpool.Tag.Values | Should -Be $tag.Values

        [Console]::WriteLine("Update-AzHdInsightOnAksClusterPoolTag done")
    }
        

    It 'Remove AzHdInsightOnAksClusterPool' {
        { Remove-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName } | Should -Not -Throw

        [Console]::WriteLine("Remove-AzHdInsightOnAksClusterPool done")
    }
}
