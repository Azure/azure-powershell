if(($null -eq $TestName) -or ($TestName -contains 'AzHybridConnectivitySolutionConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHybridConnectivitySolutionConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Variables
$resourceGroupName = "yashTestResourceGroup"
$solutionName = "yashTestSolutionConfiguration"
$location = "eastus"
$resourceUri = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/$resourceGroupName"

Describe 'AzHybridConnectivitySolutionConfiguration' {

    It 'Create, Get, Update, and Remove a Solution Configuration' -skip {
        # Step 1: Create a new Solution Configuration
        Write-Host "Starting: Creating a new Solution Configuration..."
        $solution = New-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri `
            -SolutionConfiguration $solutionName
        $solution | Should -Not -BeNullOrEmpty
        Write-Host "Completed: Solution Configuration created successfully."

        # Step 2: Get the created Solution Configuration
        Write-Host "Starting: Retrieving the created Solution Configuration..."
        $retrievedSolution = Get-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri
        $retrievedSolution | Should -Not -BeNullOrEmpty
        Write-Host "Completed: Retrieved Solution Configuration successfully."

        # Step 3: Update the Solution Configuration
        Write-Host "Starting: Updating the Solution Configuration..."
        $updatedSolution = Update-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri `
            -SolutionConfiguration $solutionName
        $updatedSolution | Should -Not -BeNullOrEmpty
        Write-Host "Completed: Solution Configuration updated successfully."

        # Step 4: Get the updated Solution Configuration
        Write-Host "Starting: Retrieving the updated Solution Configuration..."
        $retrievedUpdatedSolution = Get-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri
        $retrievedUpdatedSolution | Should -Not -BeNullOrEmpty
        Write-Host "Completed: Retrieved updated Solution Configuration successfully."

        # Step 5: Remove the Solution Configuration
        Write-Host "Starting: Removing the Solution Configuration..."
        Remove-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri `
            -SolutionConfiguration $solutionName `
            -Force | Out-Null
        Write-Host "Completed: Solution Configuration removed successfully."

        # Step 6: Verify the Solution Configuration no longer exists
        Write-Host "Starting: Verifying that the Solution Configuration no longer exists..."
        { Get-AzHybridConnectivitySolutionConfiguration `
            -ResourceUri $resourceUri } | Should -Throw
        Write-Host "Completed: Verification successful, Solution Configuration no longer exists."
    }
}