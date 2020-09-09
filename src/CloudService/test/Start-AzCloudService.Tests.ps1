$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Start-AzCloudService' {

  It 'Start Cloud Service' {
    Start-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    $cloudServiceInstanceView = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -InstanceView
    $cloudServiceInstanceView.Statuses[1].Code | Should Be $env.PowerStateStartedCode
  }
}
