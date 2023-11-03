#### New-AzLoad

#### SYNOPSIS
Create a new Azure Load Testing resource.

#### SYNTAX

```powershell
New-AzLoad -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-EncryptionIdentity <String>] [-EncryptionKey <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssigned <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an Azure Load Testing resource
```powershell
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US.

+ Example 2: Create an Azure Load Testing resource with Managed Identity
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}; "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" = @{}}

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with System-Assigned and 2 provided User-Assigned managed identities.

+ Example 3: Create an Azure Load Testing resource with Customer Managed key encryption
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}}

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned -EncryptionIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with the provided User-Assigned managed identity and uses the Encryption Identity to access the Encryption Key for CMK encryption.

+ Example 4: Create an Azure Load Testing resource with tags
```powershell
$tag = @{"key1" = "value1"; "key2" = "value2"}
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US with the provided tags.


#### Get-AzLoad

#### SYNOPSIS
Get the details of an Azure Load Testing resource.

#### SYNTAX

+ List (Default)
```powershell
Get-AzLoad [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzLoad -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzLoad -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all Azure Load Testing resources in a subscription
```powershell
Get-AzLoad
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in the subscription.

+ Example 2: Get all Azure Load Testing resources in a resource group
```powershell
Get-AzLoad -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in resource group named sample-rg.

+ Example 3: Get the details of an Azure Load Testing resource
```powershell
Get-AzLoad -Name sampleres -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command gets the details of the Azure Load Testing resource named sampleres in resource group named sample-rg.


#### Remove-AzLoad

#### SYNOPSIS
Delete an Azure Load Testing resource.

#### SYNTAX

```powershell
Remove-AzLoad -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete an Azure Load Testing resource
```powershell
Remove-AzLoad -Name sampleres1 -ResourceGroupName sample-rg
```

This command deletes the Azure Load Testing resource named sampleres1 in resource group named sample-rg.


#### Update-AzLoad

#### SYNOPSIS
Update an Azure Load Testing resource.

#### SYNTAX

```powershell
Update-AzLoad -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EncryptionIdentity <String>] [-EncryptionKey <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssigned <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an Azure Load Testing resource with tags
```powershell
$tag = @{"key0" = "value0"}
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg with the provided tags.

+ Example 2: Update an Azure Load Testing resource to use System-Assigned identity for CMK encryption
```powershell
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned" -EncryptionIdentity "SystemAssigned" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to use System-assigned identity for accessing the encryption key for CMK encryption.

+ Example 3: Update an Azure Load Testing resource to remove an existing User-Assigned managed identity
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}; "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" = $null}

Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to remove the user-assigned managed identity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" if already assigned to the resource.


