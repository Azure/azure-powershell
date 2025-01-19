if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringAppBinding'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringAppBinding.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringAppBinding' {
    It 'List' {
        {  Get-AzSpringAppBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway } | Should -Not -Throw
    }
    
    It 'CRUD' {
        { 
            New-AzSpringAppBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -name redis `
            -Key "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" -ResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Spring-rg-0zquav/providers/Microsoft.Cache/Redis/springredis" `
            -BindingParameter @{ "useSsl"= "true" }
            Get-AzSpringAppBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -name redis
            Update-AzSpringAppBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -name redis -Key "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" -BindingParameter @{ "useSsl"= "false" }
            Remove-AzSpringAppBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -name redis
        } | Should -Not -Throw
    }
}
