$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Stop-AzCloudService' {

  It 'Stop Cloud Service' {
    Stop-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    $cloudServiceInstanceView = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -InstanceView
    $cloudServiceInstanceView.Statuses[1].Code | Should Be $env.PowerStateStoppedCode
  }
}
