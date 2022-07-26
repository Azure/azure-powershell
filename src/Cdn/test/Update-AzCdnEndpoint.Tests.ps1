if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnEndpoint' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        { 
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                $tags = @{
                    Tag1 = 1
                    Tag2 = 2
                }
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -Tag $tags
                $tags = @{
                    Tag1 = 11
                    Tag2 = 22
                }
                Update-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName -Tag $tags
                $updatedEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName

                $updatedEndpoint.Tag["Tag1"] | Should -Be "11"
                $updatedEndpoint.Tag["Tag2"] | Should -Be "22"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $cdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use cdnProfileName : $($cdnProfileName)"

                $profileSku = "Standard_Microsoft";
                New-AzCdnProfile -SkuName $profileSku -Name $cdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
                
                $endpointName = 'e-' + (RandomString -allChars $false -len 6);
                $origin = @{
                    Name = "origin1"
                    HostName = "host1.hello.com"
                };
                $location = "westus"
                $tags = @{
                    Tag1 = 1
                    Tag2 = 2
                }
                Write-Host -ForegroundColor Green "Create endpointName : $($endpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"

                New-AzCdnEndpoint -Name $endpointName -ResourceGroupName $ResourceGroupName -ProfileName $cdnProfileName -Location $location -Origin $origin -Tag $tags
                $tags = @{
                    Tag1 = 11
                    Tag2 = 22
                }
                Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName | Update-AzCdnEndpoint -Tag $tags
                $updatedEndpoint = Get-AzCdnEndpoint -Name $endpointName -ProfileName $cdnProfileName -ResourceGroupName $ResourceGroupName

                $updatedEndpoint.Tag["Tag1"] | Should -Be "11"
                $updatedEndpoint.Tag["Tag2"] | Should -Be "22"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
