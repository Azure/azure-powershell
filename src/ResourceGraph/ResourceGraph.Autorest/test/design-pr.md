## ResourceGraph Release Details

- Is this an Embargoed Preview, A Public Preview, or a General Release?

    - Public Preview

- What is the expected service release date?

    - None

## Contact Information

- Main developer contacts (emails + github aliases)

    - v-diya@microsoft.com LucasYao93

- PM contact (email + github alias) 

    - Xiaogang.Ding@microsoft.com

- Other people who should attend a design review (email)

    - Dingmeng.Xue@microsoft.com

## Syntax changes

This should include PowerShell-help style syntax descriptions of all new and changed cmdlets, similar to the syntax portion of PowerShell help (or markdown help), for example:

### New Cmdlet
#### Name: Get-AzResourceGraphQuery
#### Syntax:

- List (Default)
```powershell
Get-AzResourceGraphQuery -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```
- Get
```powershell
Get-AzResourceGraphQuery -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```powershell
Get-AzResourceGraphQuery -InputObject <IResourceGraphIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### Name: New-AzResourceGraphQuery
#### Syntax:

- CreateExpanded (Default)
```powershell
New-AzResourceGraphQuery -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-ETag <String>] [-Location <String>] [-Query <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name: Remove-AzResourceGraphQuery
#### Syntax:

- Delete (Default)
```powershell
Remove-AzResourceGraphQuery -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- DeleteViaIdentity
```powershell
Remove-AzResourceGraphQuery -InputObject <IResourceGraphIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name: Update-AzResourceGraphQuery
#### Syntax:

- UpdateExpanded (Default)
```powershell
Update-AzResourceGraphQuery -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-ETag <String>] [-Query <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

- UpdateViaIdentityExpanded
```powershell
Update-AzResourceGraphQuery -InputObject <IResourceGraphIdentity> [-Description <String>] [-ETag <String>]
 [-Query <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```
