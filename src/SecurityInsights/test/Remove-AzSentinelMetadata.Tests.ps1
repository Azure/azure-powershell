if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelMetadata'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelMetadata.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelMetadata' {
    It 'Delete' {
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -AuthorEmail "RemoveMetadataPSTest@test.com" -AuthorName "RemoveMetadataPSTest" `
            -CategoryDomain (@('Security - Insider Threat')) -ContentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -DependencyContentId "InsiderRiskManagement_workbook" -DependencyKind "Workbook" -DependencyOperator "And" `
            -DependencyVersion "1.0.3" -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -SourceKind "Solution" `
            -SourceName "MicrosoftInsiderRiskManagement" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3"
        { Remove-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $metadata.Name} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -AuthorEmail "RemoveViaIdMetadataPSTest@test.com" -AuthorName "RemoveViaIdMetadataPSTest" `
            -CategoryDomain (@('Security - Insider Threat')) -ContentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -DependencyContentId "InsiderRiskManagement_workbook" -DependencyKind "Workbook" -DependencyOperator "And" `
            -DependencyVersion "1.0.3" -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -SourceKind "Solution" `
            -SourceName "MicrosoftInsiderRiskManagement" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3"
        { $metadata = Remove-AzSentinelMetadata } | Should -Not -Throw
    }
}