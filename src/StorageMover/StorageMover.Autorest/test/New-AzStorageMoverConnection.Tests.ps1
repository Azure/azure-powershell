if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverConnection' {
    It 'CreateExpanded' {
        $connectionName = 'nc1' + $env.RandomString
        $description = 'test connection description'
        $connection = New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId -Description $description
        $connection.Name | Should -Be $connectionName
        $connection.PrivateLinkServiceId | Should -Be $env.PrivateLinkServiceId
        Remove-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName
    }

    It 'CreateViaIdentityStorageMoverExpanded' {
        $connectionName = 'nc2' + $env.RandomString
        $description = 'test connection via identity'
        $storageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName
        $connection = New-AzStorageMoverConnection -Name $connectionName -StorageMoverInputObject $storageMover -PrivateLinkServiceId $env.PrivateLinkServiceId -Description $description
        $connection.Name | Should -Be $connectionName
        Remove-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName
    }

    It 'CreateViaJsonString' {
        $connectionName = 'nc3' + $env.RandomString
        $jsonString = @{
            properties = @{
                description = 'json string connection'
                privateLinkServiceId = $env.PrivateLinkServiceId
            }
        } | ConvertTo-Json -Depth 5
        $connection = New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -JsonString $jsonString
        $connection.Name | Should -Be $connectionName
        Remove-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName
    }

    It 'CreateViaJsonFilePath' {
        $connectionName = 'nc4' + $env.RandomString
        $jsonFilePath = Join-Path $TestDrive 'newConnection.json'
        @{
            properties = @{
                description = 'json file connection'
                privateLinkServiceId = $env.PrivateLinkServiceId
            }
        } | ConvertTo-Json -Depth 5 | Set-Content -Path $jsonFilePath
        $connection = New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -JsonFilePath $jsonFilePath
        $connection.Name | Should -Be $connectionName
        Remove-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName
    }
}
