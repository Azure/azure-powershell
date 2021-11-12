if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelMetadata'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelMetadata.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelMetadata' {
    It 'CreateExpanded' {
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-cybersecuritymaturitymodel" -AuthorEmail "NMPSTest@test.com" -AuthorName "NMPSTest" `
            -CategoryDomain (@('Compliance')) -ContentId "azuresentinel.azure-sentinel-solution-cybersecuritymaturitymodel" `
            -DependencyContentId "CybersecurityMaturityModelCertificationCMMC_workbook" -DependencyKind "Workbook" -DependencyOperator "And" `
            -DependencyVersion "1.0.0" -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-cybersecuritymaturitymodel" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-cybersecuritymaturitymodel" -SourceKind "Solution" `
            -SourceName "CybersecurityMaturityModelCertification(CMMC)" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.0"
        $metadata.Name | Should -Be "azuresentinel.azure-sentinel-solution-cybersecuritymaturitymodel"
    }
}