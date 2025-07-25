if(($null -eq $TestName) -or ($TestName -contains 'Assert-AzSqlVMEntraAuth'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Assert-AzSqlVMEntraAuth.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Assert-AzSqlVMEntraAuth' -Tag 'LiveOnly' {
    It 'AssertExpanded' {
    $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location
	$result1 = Assert-AzSqlVMEntraAuth -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -IdentityType 'SystemAssigned'	
	# note: system managed identity is enabled on sql vm and it has the required permissions
	$result1 | Should -Be $true
	# Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'AssertViaIdentity' {
    $sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	$result2 = $sqlVM | Assert-AzSqlVMEntraAuth -IdentityType 'UserAssigned' -ManagedIdentityClientId '6d81e2bc-dcc5-45c9-9327-1cfee9612933'
	# note: user assigned managed identity is associated to sql vm and it has the required permissions
	$result2 | Should -Be $true
    }
	
	It 'AssertFailurescenario1' {
    $sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	# note: id 'random value' is not associated to sql vm so it throws the error
	{$sqlVM | Assert-AzSqlVMEntraAuth -IdentityType 'UserAssigned' -ManagedIdentityClientId 'random value'} | Should -Throw		
    }
	
	It 'AssertFailurescenario2' {
    $sqlVM = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
	# note: id '47c329a2-0bb1-48c5-9966-b84b957c6a77' is associated to sql vm but doesn't have required permissions. so it throws the error
	{$sqlVM | Assert-AzSqlVMEntraAuth -IdentityType 'UserAssigned' -ManagedIdentityClientId '47c329a2-0bb1-48c5-9966-b84b957c6a77'} | Should -Throw		
    }
}
