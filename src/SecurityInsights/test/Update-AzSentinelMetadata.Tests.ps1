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
        $metaDependencies = [ Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MetadataDependencies]::new()
        $metaDependencies.Kind = "Workbook"
        $metaDependencies.ContentId = "InsiderRiskManagement_workbook"
        $metaDependencies.Version = "1.0.0"
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -AuthorEmail "UpdateMetadataPSTest@test.com" -AuthorName "UpdateMetadataPSTest" `
            -CategoryDomain (@('Security - Insider Threat')) -ContentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-insiderriskmanagement" -SourceKind "Solution" `
            -SourceName "MicrosoftInsiderRiskManagement" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3" -DependencyCriterion $metaDependencies
        $metadataUpdate = Update-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -name $metadata.Name -Version "1.0.4"
        $metadataUpdate.Version | Should -Be "1.0.4"
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $metaDependencies = [ Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MetadataDependencies]::new()
        $metaDependencies.Kind = "Workbook"
        $metaDependencies.ContentId = "MITREATT&CK_workbook"
        $metaDependencies.Version = "1.0.0"
        $metadata = New-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-mitreattck" -AuthorEmail "UpdateViaIdMetadataPSTest@test.com" -AuthorName "UpdateviaIdMetadataPSTest" `
            -CategoryDomain (@('Security - Threat Protection"')) -ContentId "azuresentinel.azure-sentinel-solution-mitreattck" `
            -FirstPublishDate "2021-10-20" -Kind "Solution" -ParentId "azuresentinel.azure-sentinel-solution-mitreattck" `
            -Provider "Microsoft" -SourceId "azuresentinel.azure-sentinel-solution-mitreattck" -SourceKind "Solution" `
            -SourceName "MITREATT&CK" -SupportEmail "support@microsoft.com" -SupportLink "https://support.microsoft.com" `
            -SupportName "Microsoft Corporation" -SupportTier "Microsoft" -Version "1.0.3" -DependencyCriterion $metaDependencies
        $metadata = Get-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Name "azuresentinel.azure-sentinel-solution-mitreattck"
        $metadataUpdate = Update-AzSentinelMetadata -InputObject $metadata -Version "1.0.4"
        $metadataUpdate.Version | Should -Be "1.0.4"
    }
} 