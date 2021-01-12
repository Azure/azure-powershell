#### Name :Get-AzHealthBot

#### Syntax:

- List1 (Default)
```Powershell
Get-AzHealthBot [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- Get
```Powershell
Get-AzHealthBot -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- GetViaIdentity
```Powershell
Get-AzHealthBot -InputObject <IHealthBotIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

- List
```Powershell
Get-AzHealthBot -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### Name :New-AzHealthBot

#### Syntax:

```Powershell
New-AzHealthBot -Name <String> -ResourceGroupName <String> -Location <String> -Sku <SkuName>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### Name :Remove-AzHealthBot

#### Syntax:

- Delete (Default)
```Powershell
Remove-AzHealthBot -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- DeleteViaIdentity
```Powershell
Remove-AzHealthBot -InputObject <IHealthBotIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### Name :Update-AzHealthBot

#### Syntax:

- UpdateExpanded (Default)
```Powershell
Update-AzHealthBot -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Sku <SkuName>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

- UpdateViaIdentityExpanded
```Powershell
Update-AzHealthBot -InputObject <IHealthBotIdentity> [-Sku <SkuName>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


