if(($null -eq $TestName) -or ($TestName -contains 'Assert-AzSqlVMADAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Assert-AzSqlVMADAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Assert-AzSqlVMADAuth' {
    It 'AssertExpanded' {
    $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location
	$result1 = Assert-AzSqlVMADAuth -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -AzureAdAuthenticationSettingClientId ''	
	$result1 | Should -Be $true
	# Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'AssertViaIdentity' {
    $sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	$result2 = $sqlVM | Assert-AzSqlVMADAuth -AzureAdAuthenticationSettingClientId '6d81e2bc-dcc5-45c9-9327-1cfee9612933'
	
	$result2 | Should -Be $true
    }
	
	It 'AssertFailurescenario' {
    $sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	{$sqlVM | Assert-AzSqlVMADAuth -AzureAdAuthenticationSettingClientId 'random value'} | Should -Throw		
    }
}
