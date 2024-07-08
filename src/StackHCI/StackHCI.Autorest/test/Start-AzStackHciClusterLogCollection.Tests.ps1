if(($null -eq $TestName) -or ($TestName -contains 'Start-AzStackHciClusterLogCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzStackHciClusterLogCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzStackHciClusterLogCollection' {
    It 'TriggerExpanded' {
        Start-AzStackHciClusterLogCollection -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup -FromDate "2024-08-01T17:18:19.1234567Z" -ToDate "2024-08-02T17:18:19.1234567Z"
    }

    It 'Trigger' {
        $logCollectionRequest = @{
            FromDate = "2024-08-01T17:18:19.1234567Z"
            ToDate = "2024-08-02T17:18:19.1234567Z"
        }

        Start-AzStackHciClusterLogCollection -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup -LogCollectionRequest $logCollectionRequest
    }

    # It 'TriggerViaIdentityExpanded' {

    #     $inputObject = Get-AzStackHciCluster -Name $env.ClusterName -ResourceGroupName $env.ResourceGroup

    #     Start-AzStackHciClusterLogCollection -InputObject $inputObject -FromDate "2024-08-01T17:18:19.1234567Z" -ToDate "2024-08-02T17:18:19.1234567Z"
    # }

    # It 'TriggerViaIdentity' {
    #     $inputObject = Get-AzStackHciCluster -Name $env.ClusterName -ResourceGroupName $env.ResourceGroup

    #     $logCollectionRequest = @{
    #         FromDate = "2024-08-01T17:18:19.1234567Z"
    #         ToDate = "2024-08-02T17:18:19.1234567Z"
    #     }
        
    #     Start-AzStackHciClusterLogCollection -InputObject $inputObject -LogCollectionRequest $logCollectionRequest
    # }
}
