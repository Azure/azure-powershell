if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntityQueryTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntityQueryTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntityQueryTemplate' {
    It 'List' {
        $entityQueryTemplates = Get-AzSentinelentityQueryTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entityQueryTemplates.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $entityQueryTemplates = Get-AzSentinelentityQueryTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entityQueryTemplate = Get-AzSentinelentityQueryTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $entityQueryTemplates[0].Name
        $entityQueryTemplate.Name | Should -Be $entityQueryTemplates[0].Name
    }

    It 'GetViaIdentity' -skip {
        $entityQueryTemplates = Get-AzSentinelentityQueryTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entityQueryTemplate = Get-AzSentinelentityQueryTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $entityQueryTemplates[0].Name
        $entityQueryTemplateViaId = Get-AzSentinelentityQuery -InputObject $entityQueryTemplate
        $entityQueryTemplateViaId.Name | Should -Be $entityQueryTemplates[0].Name
    }
}
