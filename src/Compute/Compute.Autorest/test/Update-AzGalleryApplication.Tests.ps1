if(($null -eq $TestName) -or ($TestName -contains 'Update-AzGalleryApplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzGalleryApplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
  $null = [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.PipelineMock]::Blacklist.Add('x-ms-policy-external-evaluations')
}

Describe 'Update-AzGalleryApplication' {
    BeforeAll { 
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName = "testgalapp" + $env.RandomString
        if ($TestMode -ne 'playback') {
            New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        }
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Location $env.Location -SupportedOSType Windows
    }

    It 'UpdateExpanded' {
        $description = "testDescription"
        Update-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Description $description
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galApp.Description | Should Be $description
    }

    It 'UpdateViaIdentityExpanded' {
        $description = "testDescriptionNEW"
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        Update-AzGalleryApplication -InputObject $galApp.Id -Description $description
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galApp.Description | Should Be $description
    }

    It 'UpdateExpanded-AcquirePolicyToken' {
        $description = 'testDescriptionPolicyToken'
        $observation = @{ Writes = 0 }
        $observer = New-ComputeTestPolicyTokenObserver $observation
        Update-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName `
            -GalleryName $galleryName -Name $galleryApplicationName -Description $description `
            -AcquirePolicyToken -HttpPipelineAppend $observer
        $actual = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName `
            -GalleryName $galleryName -Name $galleryApplicationName
        $actual.Description | Should -Be $description
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }
}
