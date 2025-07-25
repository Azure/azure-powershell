$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPortalDashboardCrud.Recording.json'
$currentPath = $PSScriptRoot
$resourcesPath = Join-Path $currentPath ".\"
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'DashBardCrudTests' {
    It 'Lists all dashboards in a subscription' {
        $dash = Get-AzPortalDashboard
        $dash.Count | Should -BeGreaterOrEqual 1
    }

    It 'Create, Update, and Delete a dashboard' {
        $dashPath = Join-Path $resourcesPath "dash1.json"
		$dash = New-AzPortalDashboard -DashboardPath $dashPath -ResourceGroupName $env.ResourceGroup -Name $env.DashboardName
		$dash | Should -Not -BeNullOrEmpty
		$dash.Metadata | Should -Not -BeNullOrEmpty
		$dash.Metadata.Count | Should -BeGreaterOrEqual 1
		$dash.Lens | Should -Not -BeNullOrEmpty
		$dash.Lens.Count | Should -BeGreaterOrEqual 1
		$dashcheck = Get-AzPortalDashboard -ResourceGroupName $env.ResourceGroup -Name $env.DashboardName
		$dashcheck.Metadata.Count | Should -BeExactly $dash.Metadata.Count
		$dashcheck.Lens.Count | Should -BeExactly $dash.Lens.Count
		$dashUpdate = Update-AzPortalDashboard -Name $env.DashboardName -ResourceGroupName $env.ResourceGroup -Tag @{TestKey="TestValue"}
		$dashCheck = Get-AzPortalDashboard -ResourceGroupName $env.ResourceGroup -Name $env.DashboardName
		$dashCheck.Tag['TestKey'] | Should -BeExactly "TestValue"
		$dashSet = Set-AzPortalDashboard -DashboardPath $dashPath -ResourceGroupName $env.ResourceGroup -Name $env.DashboardName
		$dashSet.Tag.Count | Should -BeExactly 1
		$dashRemove = Remove-AzPortalDashboard -Name $env.DashboardName -ResourceGroupName $env.ResourceGroup -Passthru
		$dashRemove | Should -BeExactly $true
    }

    
}
