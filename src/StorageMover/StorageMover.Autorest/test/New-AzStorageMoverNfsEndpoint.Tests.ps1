if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverNfsEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverNfsEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverNfsEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "testNfsEndpoint" + $env.RandomString
        $description = "Nfs endpoint description"
        $nfsVersion = "NFSv3"
        $endpointHost = "10.0.0.1"
        $export = "/"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Host $endpointHost -Export $export -NfsVersion $nfsVersion -Description $description 
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export
    }

    It 'CreateExpandedFsxEfs' {
        $endpointName = "nfsfsx"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -Host "10.0.0.5" -Export "/export" -SourceType FSX-EFS -EndpointKind Source
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.EndpointKind | Should -Be "Source"

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName
        $nfsEndpoint.Property.ProvisioningState | Should -Be "Succeeded"
    }

    It 'CreateExpandedSourceTypeRequest' {
        # The service does not return sourceType, so this checks the request offline.
        Mock -CommandName New-AzStorageMoverEndpoint -ModuleName Az.StorageMover.custom -MockWith { [pscustomobject]@{ Property = $Property } }
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name "nfsfsxo" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -Host "10.0.0.5" -Export "/export" -NfsVersion NFSv4_1 -SourceType FSX-EFS
        $request = $nfsEndpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.nfsVersion | Should -Be "NFSv4_1"
        $request.sourceType | Should -Be "FSX-EFS"
        $request.PSObject.Properties.Name | Should -Not -Contain "endpointKind"
    }
}