if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareAPIsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareAPIsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareAPIsWorkspace' {
    It 'CreateExpanded' {
        {
            $config = New-AzHealthcareAPIsWorkspace -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.rstr1
            
            $config = New-AzHealthcareAPIsWorkspace -Name $env.rstr2 -ResourceGroupName $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.rstr2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareAPIsWorkspace
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareAPIsWorkspace -Name $env.rstr1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.rstr1
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzHealthcareAPIsWorkspace -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.rstr1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzHealthcareAPIsWorkspace -Name $env.rstr2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzHealthcareAPIsWorkspace -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.rstr2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzHealthcareAPIsWorkspace -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareAPIsWorkspace -Name $env.rstr1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareAPIsWorkspace -Name $env.rstr2 -ResourceGroupName $env.resourceGroup
            Remove-AzHealthcareAPIsWorkspace -InputObject $config
        } | Should -Not -Throw
    }
}
