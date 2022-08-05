##################### NetworkSecurityPerimeter starts ########################
````powershell

 Get-AzNetworkSecurityPerimeter -ResourceGroupName kumarkaushal-PS-RG-1

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap nsp4
eastus2euap nsp3
eastus2euap test-nsp1
eastus2euap nsp1
eastus2euap nsp6
eastus2euap nsp5


````
List NetworkSecurityPerimeter

````powershell

 Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName kumarkaushal-PS-RG-1

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap nsp3


````
Gets a NetworkSecurityPerimeter by Name

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName kumarkaushal-PS-RG-1      $GETObjViaIdentity = Get-AzNetworkSecurityPerimeter -InputObject $GETObj

````

````output

````
Gets a NetworkSecurityPerimeter by identity (using pipe)

````powershell

 New-AzNetworkSecurityPerimeter -ResourceGroupName kumarkaushal-PS-RG-1 -Name nsp1 -Location eastus2euap

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap nsp1


````
Creates a NetworkSecurityPerimeter

````powershell

 Remove-AzNetworkSecurityPerimeter -Name nsp5 -ResourceGroupName kumarkaushal-PS-RG-1

````

````output

````
Deletes a NetworkSecurityPerimeter by Name

````powershell

 $nspObj = Get-AzNetworkSecurityPerimeter -Name nsp6 -ResourceGroupName kumarkaushal-PS-RG-1     Remove-AzNetworkSecurityPerimeter -InputObject $nspObj

````

````output

````
Deletes a NetworkSecurityPerimeter by identity (using pipe)

##################### NetworkSecurityPerimeter ends \n\n\n
##################### NetworkSecurityPerimeterProfile starts ########################
````powershell

 Get-AzNetworkSecurityPerimeterProfile -Name profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap profile1


````
Gets a NetworkSecurityPerimeterProfile by Name

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeterProfile -Name profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3     Get-AzNetworkSecurityPerimeterProfile -InputObject $GETObj

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap profile1


````
Gets a NetworkSecurityPerimeterProfile by identity (using pipe)

````powershell

 New-AzNetworkSecurityPerimeterProfile -Name profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation    Name[0m
[32;1m--------    ----[0m
eastus2euap profile1


````
Creates a NetworkSecurityPerimeterProfile

````powershell

 Remove-AzNetworkSecurityPerimeterProfile -Name profile6 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4

````

````output

````
Deletes a NetworkSecurityPerimeterProfile by Name

````powershell

 $profileObj = Get-AzNetworkSecurityPerimeterProfile -Name profile7 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4      Remove-AzNetworkSecurityPerimeterProfile -InputObject $profileObj

````

````output

````
Deletes a NetworkSecurityPerimeterProfile by identity (using pipe)

##################### NetworkSecurityPerimeterProfile ends \n\n\n
##################### NetworkSecurityPerimeterAccessRule starts ########################
````powershell

 Get-AzNetworkSecurityPerimeterAccessRule -ProfileName profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         ar4
         ar3


````
List NetworkSecurityPerimeterAccessRule

````powershell

 Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ProfileName profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         ar3


````
Gets a NetworkSecurityPerimeterAccessRule by Name

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ProfileName profile1 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3     $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj

````

````output

````
Gets a NetworkSecurityPerimeterAccessRule by identity (using pipe)

````powershell

 New-AzNetworkSecurityPerimeterAccessRule -Name accessRule1 -ProfileName profile2 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location eastus2euap

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         accessRule1


````
Creates a NetworkSecurityPerimeterAccessRule

````powershell

 Remove-AzNetworkSecurityPerimeterAccessRule -Name ar5 -ProfileName profile4 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4

````

````output

````
Deletes a NetworkSecurityPerimeterAccessRule by Name

````powershell

 $accessRuleObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar6 -ProfileName profile4 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4     Remove-AzNetworkSecurityPerimeterAccessRule -InputObject $accessRuleObj

````

````output

````
Deletes a NetworkSecurityPerimeterAccessRule by identity (using pipe)

````powershell

 Update-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3 -ProfileName profile1  -AddressPrefix @('10.10.0.0/17')

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         ar3


````
Updates a NetworkSecurityPerimeterAccessRule

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name ar3 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3 -ProfileName profile1     $UpdateObj = Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -AddressPrefix @('10.0.0.0/16')

````

````output

````
Updates a NetworkSecurityPerimeterAccessRule by identity (using pipe)

##################### NetworkSecurityPerimeterAccessRule ends \n\n\n
##################### NetworkSecurityPerimeterAccessAssociation starts ########################
````powershell

 Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         association1
         association3


````
List NetworkSecurityPerimeterAccessAssociation

````powershell

 Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         association3


````
Gets a NetworkSecurityPerimeterAccessAssociation by Name

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp3     Get-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         association3


````
Gets a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)

````powershell

 $profileId = '/subscriptions/3846cb0f-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/kumarkaushal-PS-RG-1/providers/Microsoft.Network/networkSecurityPerimeters/nsp3/profiles/profile2'   $privateLinkResourceId = '/subscriptions/3846cb0f-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/kumarkaushal-PS-RG-1/providers/Microsoft.KeyVault/vaults/rp4'     New-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName kumarkaushal-PS-RG-1 -Location eastus2euap -AccessMode Learning -ProfileId $profileId -PrivateLinkResourceId $privateLinkResourceId

````

````output

[32;1mLocation Name[0m
[32;1m-------- ----[0m
         association1


````
Creates a NetworkSecurityPerimeterAccessAssociation

````powershell

 Remove-AzNetworkSecurityPerimeterAssociation -Name association4 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4

````

````output

````
Deletes a NetworkSecurityPerimeterAccessAssociation by Name

````powershell

 $associationObj = Get-AzNetworkSecurityPerimeterAssociation -Name association5 -ResourceGroupName kumarkaushal-PS-RG-1 -SecurityPerimeterName nsp4     Remove-AzNetworkSecurityPerimeterAssociation -InputObject $associationObj

````

````output

````
Deletes a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)

````powershell

 $UpdateObj = Update-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName kumarkaushal-PS-RG-1 -AccessMode Enforced

````

````output

````
Updates a NetworkSecurityPerimeterAccessAssociation

````powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association1 -SecurityPerimeterName nsp3 -ResourceGroupName kumarkaushal-PS-RG-1     $UpdateObj = Update-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj -AccessMode Learning

````

````output

````
Updates a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)

##################### NetworkSecurityPerimeterAccessAssociation ends \n\n\n
