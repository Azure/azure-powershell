if(($null -eq $TestName) -or ($TestName -contains 'AzHybridConnectivityEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHybridConnectivityEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Variables
$resourceUri = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/yash-rg"
$endpointName = "yashTestEndpoint"

Describe 'AzHybridConnectivityEndpoint' {

    It 'Create, Get, Update, and Remove a Hybrid Connectivity Endpoint' -skip {
        # Step 1: Create a new endpoint
        $endpoint = New-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
        $endpoint | Should -Not -BeNullOrEmpty

        # Step 2: Get the created endpoint
        $retrievedEndpoint = Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
        $retrievedEndpoint.Name | Should -Be $endpointName

        # Step 3: Update the endpoint (Example: Add tags)
        $updatedEndpoint = Update-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri -Tag @{ "Environment" = "Test" }
        $updatedEndpoint.Tags["Environment"] | Should -Be "Test"

        # Step 4: Get the updated endpoint
        $retrievedUpdatedEndpoint = Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
        $retrievedUpdatedEndpoint.Tags["Environment"] | Should -Be "Test"

        # Step 5: Remove the endpoint
        Remove-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri -Force | Out-Null

        # Step 6: Verify the endpoint no longer exists
        { Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri } | Should -Throw
    }

# # Variables
# $resourceGroupName = "yashTestResourceGroup"
# $endpointName = "yashTestEndpoint"
# $location = "eastus"
# $resourceUri = "/subscriptions/$($env:AZURE_SUBSCRIPTION_ID)/resourceGroups/$resourceGroupName"

# Describe 'AzHybridConnectivityEndpoint' {

#     BeforeAll {
#         # Create a resource group
#         New-AzResourceGroup -Name $resourceGroupName -Location $location | Out-Null
#     }

#     AfterAll {
#         # Clean up the resource group
#         Remove-AzResourceGroup -Name $resourceGroupName -Force -AsJob | Out-Null
#     }

#     It 'Create, Get, Update, and Remove a Hybrid Connectivity Endpoint' {
#         # Step 1: Create a new endpoint
#         $endpoint = New-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
#         $endpoint | Should -Not -BeNullOrEmpty

#         # Step 2: Get the created endpoint
#         $retrievedEndpoint = Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
#         $retrievedEndpoint.Name | Should -Be $endpointName

#         # Step 3: Update the endpoint (Example: Add tags)
#         $updatedEndpoint = Update-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri -Tag @{ "Environment" = "Test" }
#         $updatedEndpoint.Tags["Environment"] | Should -Be "Test"

#         # Step 4: Get the updated endpoint
#         $retrievedUpdatedEndpoint = Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri
#         $retrievedUpdatedEndpoint.Tags["Environment"] | Should -Be "Test"

#         # Step 5: Remove the endpoint
#         Remove-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri -Force | Out-Null

#         # Step 6: Verify the endpoint no longer exists
#         { Get-AzHybridConnectivityEndpoint -Name $endpointName -ResourceUri $resourceUri } | Should -Throw
#     }
}