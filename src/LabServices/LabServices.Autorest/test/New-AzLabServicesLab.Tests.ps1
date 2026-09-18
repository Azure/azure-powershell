if(($null -eq $TestName) -or ($TestName -contains 'New-AzLabServicesLab'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLabServicesLab.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# $loadVarsPath = Join-Path $PSScriptRoot '\test\SetVariables.ps1'
# . ($loadVarsPath)

Describe 'New-AzLabServicesLab' {
    It 'Create' {
        $string = ConvertTo-SecureString "REDACTED" -AsPlainText -Force
        New-AzLabServicesLab `
        -Name $env.NewLabName `
        -ResourceGroupName $env.ResourceGroupName `
        -Location $env.Location `
        -LabPlanId "subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labPlans/$($env.LabPlanName)" `
        -AdditionalCapabilityInstallGpuDriver Disabled `
        -AdminUserPassword $string `
        -AdminUserUsername $env.UserName `
        -AutoShutdownProfileShutdownOnDisconnect Disabled `
        -AutoShutdownProfileShutdownOnIdle None `
        -AutoShutdownProfileShutdownWhenNotConnected Disabled `
        -ConnectionProfileClientRdpAccess Public `
        -ConnectionProfileClientSshAccess None `
        -ConnectionProfileWebRdpAccess None `
        -ConnectionProfileWebSshAccess None `
        -Description "New lab description" `
        -ImageReferenceOffer "Windows-11" `
        -ImageReferencePublisher "MicrosoftWindowsDesktop" `
        -ImageReferenceSku "win11-23h2-pro" `
        -ImageReferenceVersion "latest" `
        -SecurityProfileOpenAccess Disabled `
        -SkuCapacity 3 `
        -SkuName "Classic_Fsv2_2_4GB_128_S_SSD" `
        -Title $env.NewLabName `
        -VirtualMachineProfileCreateOption "TemplateVM" `
        -VirtualMachineProfileUseSharedPassword Enabled | Select-Object -Property Name | Should -Be "@{Name=$($env.NewLabName)}"
        
        Remove-AzLabServicesLab -Name $env.NewLabName -ResourceGroupName $env.ResourceGroupName
    }
}
