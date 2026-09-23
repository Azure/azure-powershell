if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsArtifact'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsArtifact.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsArtifact' {
    It 'List' {
        $result = Get-AzDisconnectedOperationsArtifact -ImageName $env.ImageName -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Assert that result is not null or empty
        $result | Should -Not -BeNullOrEmpty

        # If result is a collection, iterate and assert properties
        foreach ($artifact in $result) {
            $artifact | Should -Not -BeNullOrEmpty
            $artifact.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images/artifacts'
            $artifact.Id | Should -Not -BeNullOrEmpty
            $artifact.Id.ToString() | Should -Not -BeNullOrEmpty
            $artifact.ResourceGroupName | Should -Be $env.ResourceGroupName
        }

        # Assert that at least one artifact was found
        ($result.Count) | Should -BeGreaterThan 0

    }

    It 'GetViaIdentityImage' {
        $imageInputObject = @{
            "ImageName" = $env.ImageName;
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $artifactName = $env.ArtifactName
        $result = Get-AzDisconnectedOperationsArtifact -ArtifactName $artifactName -ImageInputObject $imageInputObject

        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $artifactName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images/artifacts'
        $result.Id | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentityDisconnectedOperation' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $artifactName = $env.ArtifactName
        $imageName = $env.ImageName
        $result = Get-AzDisconnectedOperationsArtifact -ArtifactName $artifactName -ImageName $imageName -DisconnectedOperationInputObject $disconnectedOperationInputObject

        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $artifactName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images/artifacts'
        $result.Id | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $artifactName = $env.ArtifactName
        $result = Get-AzDisconnectedOperationsArtifact -ArtifactName $artifactName -ImageName $env.ImageName -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $artifactName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images/artifacts'
        $result.Id | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $inputObject = @{
            "ArtifactName" = $env.ArtifactName;
            "ImageName" = $env.ImageName;
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $result = Get-AzDisconnectedOperationsArtifact -InputObject $inputObject

        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.ArtifactName
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images/artifacts'
        $result.Id | Should -Not -BeNullOrEmpty
    }
}
