if(($null -eq $TestName) -or ($TestName -contains 'AzHybridConnectivityPublicCloudConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHybridConnectivityPublicCloudConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Variables
$connectorName = "yashTestPublicCloudConnector"
$resourceGroupName = "yash-rg"
$mockAwCloudProfile = "123456789012"
$location = "eastus"

Describe 'AzHybridConnectivityPublicCloudConnector' {

    It 'Create, Get, Update, and Remove a Public Cloud Connector' {
        # Step 1: Create a new Public Cloud Connector
        $connector = New-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName `
            -Location $location `
            -AwCloudProfileAccountId $mockAwCloudProfile `
            -Tag @{ "Purpose" = "Testing" }
        $connector | Should -Not -BeNullOrEmpty

        # Step 2: Get the created Public Cloud Connector
        $retrievedConnector = Get-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName
        $retrievedConnector.Name | Should -Be $connectorName

        # Step 3: Update the Public Cloud Connector (Example: Add additional tags)
        $updatedConnector = Update-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName `
            -Tag @{ "Purpose" = "Testing"; "Environment" = "Production" } | ConvertFrom-Json

        $updatedConnector.tags.Environment | Should -Be "Production"

        # Step 4: Get the updated Public Cloud Connector
        $retrievedUpdatedConnector = Get-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName | ConvertFrom-Json
        
        $retrievedUpdatedConnector.tags.Environment | Should -Be "Production"

        # Step 5: Remove the Public Cloud Connector
        Remove-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName ` | Out-Null

        # Step 6: Verify the connector no longer exists
        { Get-AzHybridConnectivityPublicCloudConnector `
            -PublicCloudConnector $connectorName `
            -ResourceGroupName $resourceGroupName } | Should -Throw
    }
}
