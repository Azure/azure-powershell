if(($null -eq $TestName) -or ($TestName -contains 'New-AzEdgeOrderItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEdgeOrderItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEdgeOrderItem' {
    It 'CreateExpanded'{
        $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone
        $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType 
        $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
        $details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation}
        
        New-AzEdgeOrderItem -Name $env.OrderItemNameTest -ResourceGroupName $env.ResourceGroup -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId $env.OrderIdTest -OrderItemDetail $details -SubscriptionId $env.SubscriptionId -ForwardShippingAddress $ShippingDetails                                                                                    
    }
}
