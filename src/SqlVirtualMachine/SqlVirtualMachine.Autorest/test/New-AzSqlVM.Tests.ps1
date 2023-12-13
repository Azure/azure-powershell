if (($null -eq $TestName) -or ($TestName -contains 'New-AzSqlVM')) {
	$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
	if (-Not (Test-Path -Path $loadEnvPath)) {
		$loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
	}
	. ($loadEnvPath)
	$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSqlVM.Recording.json'
	$currentPath = $PSScriptRoot
	while (-not $mockingPath) {
		$mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
		$currentPath = Split-Path -Path $currentPath -Parent
	}
	. ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSqlVM' {
	It 'CreateExpanded-Simple' {
		$sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location
		$sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
		$sqlVM.SqlImageSku | Should -Be 'Enterprise'
		$sqlVM.SqlManagement | Should -Be 'Full'
		$sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
		
		$sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
		$sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
		$sqlVM.SqlImageSku | Should -Be 'Enterprise'
		$sqlVM.SqlManagement | Should -Be 'Full'
		$sqlVM.SqlServerLicenseType | Should -Be 'PAYG'

		Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	}

	It 'CreateExpanded-LicenseType' {
		$sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -LicenseType 'AHUB'
		$sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
		$sqlVM.SqlImageSku | Should -Be 'Enterprise'
		$sqlVM.SqlManagement | Should -Be 'Full'
		$sqlVM.SqlServerLicenseType | Should -Be 'AHUB'

		$sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
		$sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
		$sqlVM.SqlImageSku | Should -Be 'Enterprise'
		$sqlVM.SqlManagement | Should -Be 'Full'
		$sqlVM.SqlServerLicenseType | Should -Be 'AHUB'

		Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	}
}
