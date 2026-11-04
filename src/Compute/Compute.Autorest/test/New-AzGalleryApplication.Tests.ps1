if(($null -eq $TestName) -or ($TestName -contains 'New-AzGalleryApplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzGalleryApplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
  $null = [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.PipelineMock]::Blacklist.Add('x-ms-policy-external-evaluations')
}

Describe 'New-AzGalleryApplication' {
    It 'CreateExpanded' {
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName = "testgalapp" + $env.RandomString
        if ($TestMode -ne 'playback') {
            New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        }
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Location $env.Location -SupportedOSType Windows

        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'CreateExpanded-AcquirePolicyToken' {
        $galleryName = "testgallerypolicy" + $env.RandomString
        $applicationName = "testgalapppolicy" + $env.RandomString
        if ($TestMode -ne 'playback') {
            New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        }
        $observation = @{ Writes = 0 }
        $observer = New-ComputeTestPolicyTokenObserver $observation
        $application = New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName `
            -GalleryName $galleryName -Name $applicationName -Location $env.Location `
            -SupportedOSType Windows -AcquirePolicyToken -HttpPipelineAppend $observer
        $application.Name | Should -Be $applicationName
        $actual = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName `
            -GalleryName $galleryName -Name $applicationName
        $actual.Name | Should -Be $applicationName
        if ($TestMode -ne 'playback') {
            $observation.Writes | Should -BeGreaterThan 0
        }
    }
}
