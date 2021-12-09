if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelMetadata'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelMetadata.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelMetadata' {
    It 'UpdateExpanded' {
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -AuthorEmail "UpdateMetadataPSTest@test.com" -AuthorName "UpdateMetadataPSTest" `
            -CategoryDomain (@('Security - Insider Threat')) -ContentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -DependencyContentId "InsiderRiskManagement_workbook" -DependencyKind "Workbook" -DependencyOperator "And" `
            -DependencyVersion "1.0.3" -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -SourceKind "Solution" `
            -SourceName "MicrosoftInsiderRiskManagement" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3"
        $metadataUpdate = Update-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -name $metadata.Name -Version "1.0.4"
        $metadataUpdate.Version | Should -Be "1.0.4"
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-mitreattck" -AuthorEmail "UpdateViaIdMetadataPSTest@test.com" -AuthorName "UpdateviaIdMetadataPSTest" `
            -CategoryDomain (@('Security - Threat Protection"')) -ContentId "azuresentinel.azure-sentinel-solution-mitreattck" `
            -DependencyContentId "MITREATT&CK_workbook" -DependencyKind "Workbook" -DependencyOperator "And" `
            -DependencyVersion "1.0.3" -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-mitreattck" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-mitreattck" -SourceKind "Solution" `
            -SourceName "MITREATT&CK" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3"
        $metadata = Get-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-mitreattck"
        $metadataUpdate = $metadata | Update-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Version "1.0.4"
        $metadataUpdate.Version | Should -Be "1.0.4"
    }
}