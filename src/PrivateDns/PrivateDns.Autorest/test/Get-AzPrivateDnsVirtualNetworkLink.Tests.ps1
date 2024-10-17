if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPrivateDnsVirtualNetworkLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPrivateDnsVirtualNetworkLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPrivateDnsVirtualNetworkLink' {
    It 'Get' {
	# SETUP
	New-AzPrivateDnsVirtualNetworkLink -Name "mylink" -PrivateZoneName "privatelink.com"  -ResourceGroupName "powershelltestrg"  -ResolutionPolicy "Default" -VirtualNetworkId "/subscriptions/58768663-9606-45cf-a196-136d98585866/resourceGroups/powershelltestrg/providers/Microsoft.Network/virtualNetworks/vnet1" -Location "global" -RegistrationEnabled
	
	# TEST
	$config = Get-AzPrivateDnsVirtualNetworkLink -Name "mylink" -ResourceGroupName "powershelltestrg" -PrivateZoneName "privatelink.com" 
        $config.ResolutionPolicy | Should -Be "Default"

	# CLEANUP
	Remove-AzPrivateDnsVirtualNetworkLink -Name "mylink" -PrivateZoneName "privatelink.com"  -ResourceGroupName "powershelltestrg"
    }
}
