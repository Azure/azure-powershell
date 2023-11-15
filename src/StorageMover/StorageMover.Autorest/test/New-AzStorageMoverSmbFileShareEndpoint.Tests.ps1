if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverSmbFileShareEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverSmbFileShareEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New/Update-AzStorageMoverSmbFileShareEndpoint' {
    It 'Create and update' {
        $endpointName = "fseendpoint1" + $env.RandomString
        $fsendpoint = New-AzStorageMoverSmbFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -FileShareName "testfs" -Description "New smb file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId
        
        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Update-AzStorageMoverSmbFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description "updated file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId
    }
}
