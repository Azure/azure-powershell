if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareDicomService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareDicomService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareDicomService' {
    It 'CreateExpanded' {
        {
            $config = New-AzHealthcareDicomService -Name $env.dicom1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.dicom1)"

            $config = New-AzHealthcareDicomService -Name $env.dicom2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.dicom2)"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareDicomService -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareDicomService -Name $env.dicom2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.dicom2)"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzHealthcareDicomService -Name $env.dicom2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.dicom2)"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzHealthcareDicomService -Name $env.dicom1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config = Update-AzHealthcareDicomService -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.dicom1)"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareDicomService -Name $env.dicom1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareDicomService -Name $env.dicom2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            Remove-AzHealthcareDicomService -InputObject $config
        } | Should -Not -Throw
    }
}