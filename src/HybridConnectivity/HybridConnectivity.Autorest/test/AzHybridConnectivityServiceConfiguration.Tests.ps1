if(($null -eq $TestName) -or ($TestName -contains 'AzHybridConnectivityServiceConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHybridConnectivityServiceConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Variables
$resourceGroupName = "yashTestResourceGroup"
$serviceConfigName = "yashTestServiceConfig"
$endpointName = "yashTestEndpoint"
$location = "eastus"
$resourceUri = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/$resourceGroupName"

Describe 'AzHybridConnectivityServiceConfiguration' {

    It 'Create, Get, Update, and Remove a Service Configuration' -skip {
        # Step 1: Create a new Service Configuration
        Write-Host "Starting: Creating a new Service Configuration..."
        Write-Host "ResourceUri: $resourceUri"

        $serviceConfig = New-AzHybridConnectivityServiceConfigurationOrupdate `
            -EndpointName $endpointName `
            -ResourceUri $resourceUri `
            -ServiceConfigurationName $serviceConfigName
        
        $serviceConfig | Should -Not -BeNullOrEmpty
        Write-Host "Completed: Service Configuration created successfully."

        # Step 2: Get the created Service Configuration
        Write-Host "Starting: Retrieving the created Service Configuration..."
        $retrievedServiceConfig = Get-AzHybridConnectivityServiceConfiguration `
            -EndpointName $endpointName `
            -ResourceUri $resourceUri
        
        $retrievedServiceConfig.Name | Should -Be $serviceConfigName
        Write-Host "Completed: Retrieved Service Configuration successfully."

        # Step 3: Update the Service Configuration (Example: Add tags)
        Write-Host "Starting: Updating the Service Configuration with additional tags..."
        $updatedServiceConfig = Update-AzHybridConnectivityServiceConfiguration `
            -EndpointName $endpointName `
            -Name $serviceConfigName `
            -ResourceUri $resourceUri | ConvertFrom-Json

        $updatedServiceConfig.tags.Environment | Should -Be "Production"
        Write-Host "Completed: Service Configuration updated successfully."

        # Step 4: Get the updated Service Configuration
        Write-Host "Starting: Retrieving the updated Service Configuration..."
        $retrievedUpdatedServiceConfig = Get-AzHybridConnectivityServiceConfiguration `
            -EndpointName $endpointName `
            -ResourceUri $resourceUri | ConvertFrom-Json
        
        $retrievedUpdatedServiceConfig.tags.Environment | Should -Be "Production"
        Write-Host "Completed: Retrieved updated Service Configuration successfully."

        # Step 5: Remove the Service Configuration
        Write-Host "Starting: Removing the Service Configuration..."
        Remove-AzHybridConnectivityServiceConfiguration `
            -EndpointName $endpointName `
            -Name $serviceConfigName `
            -ResourceUri $resourceUri | Out-Null
        Write-Host "Completed: Service Configuration removed successfully."

        # Step 6: Verify the configuration no longer exists
        Write-Host "Starting: Verifying that the Service Configuration no longer exists..."
        { Get-AzHybridConnectivityServiceConfiguration `
            -EndpointName $endpointName `
            -ResourceUri $resourceUri } | Should -Throw
        
        Write-Host "Completed: Verification successful, Service Configuration no longer exists."
    }
}