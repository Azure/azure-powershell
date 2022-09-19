#### Get-AzAttestationDefaultProvider

#### SYNOPSIS
Get the default provider by location.

#### SYNTAX

+ List (Default)
```powershell
Get-AzAttestationDefaultProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ Get
```powershell
Get-AzAttestationDefaultProvider -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzAttestationDefaultProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### New-AzAttestationProvider

#### SYNOPSIS
Creates a new Attestation Provider.

#### SYNTAX

```powershell
New-AzAttestationProvider -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-PolicySigningCertificateKeyPath <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzAttestationProvider

#### SYNOPSIS
Get the status of Attestation Provider.

#### SYNTAX

+ List (Default)
```powershell
Get-AzAttestationProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzAttestationProvider -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzAttestationProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzAttestationProvider -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```


#### Remove-AzAttestationProvider

#### SYNOPSIS
Delete Attestation Service.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzAttestationProvider -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzAttestationProvider -InputObject <IAttestationIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzAttestationProvider

#### SYNOPSIS
Updates the Attestation Provider.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzAttestationProvider -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzAttestationProvider -InputObject <IAttestationIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


