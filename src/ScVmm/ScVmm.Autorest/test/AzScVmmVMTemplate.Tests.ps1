if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVMTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVMTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVMTemplate' -Tag 'LiveOnly'{
    It 'CreateExpanded' {
        {
            $result = New-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VmTemplateUuid -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
    
    It 'ListBySubscription - List' {
        {
            $result = Get-AzScVmmVMTemplate
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup - List1' {
        {
            $result = Get-AzScVmmVMTemplate -ResourceGroupName $env.ResourceGroupEnableInvTest
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        $result = Update-AzScVmmVMTemplate -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VmTemplateName -Tag @{tag1="value1"}
        $result.ProvisioningState | Should -Be 'Succeeded' 
        $result.Tag['tag1'] | Should -Be 'value1'
    }

    It 'Get' {
        {
            $result = Get-AzScVmmVMTemplate -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VmTemplateName
            $result.Name | Should -Be $env.VmTemplateName
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmVMTemplate -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VmTemplateName
        } | Should -Not -Throw
    }

    It 'CreateExpandedId' -Tag 'LiveOnly' {
        {
            $InvId = $env.VmmServerEnableInvTestId + '/inventoryItems/' + $env.VmTemplateUuid
            $result = New-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupEnableInvTest -InventoryItemId $InvId -VmmServerId $env.VmmServerEnableInvTestId -CustomLocationId $env.CustomLocationEnableInvTest -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmVMTemplate -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VmTemplateName
        } | Should -Not -Throw
    }
}
