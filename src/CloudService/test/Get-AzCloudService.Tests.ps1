$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Describe 'Get-AzCloudService' {

  # TODO: Enable this once List Cloud Service is supported

  # It 'List Cloud Service in subscription' {
  #   $cloudServices = Get-AzCloudService
  #   $cloudServices.Count | Should -BeGreaterOrEqual 1
  # }
  # 
  # It 'List Cloud Service in ResourceGroup' {
  #   $cloudServices = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName
  #   $cloudServices.Count | Should -BeGreaterOrEqual 1
  # }

  It 'Get Cloud Service' {
    $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    $cloudService.RoleProfileRole.Count | Should Be $env.RoleCount
  }

  It 'Get Cloud Service InstanceView' {
    $cloudServiceInstanceView = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -InstanceView
    $cloudServiceInstanceView.Extension.Count | Should Be $env.ExtensionCount
  }
}
