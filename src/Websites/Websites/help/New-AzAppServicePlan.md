---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
ms.assetid: 8F36244D-A4D7-40BB-AC4C-E9AD445549F8
online version: https://learn.microsoft.com/powershell/module/az.websites/new-azappserviceplan
schema: 2.0.0
---

# New-AzAppServicePlan

## SYNOPSIS
Creates an Azure App Service plan in a given Geo location.

## SYNTAX

### S1
```
New-AzAppServicePlan [-Location] <String> [[-Tier] <String>] [[-NumberofWorkers] <Int32>]
 [[-WorkerSize] <String>] [[-AseName] <String>] [[-AseResourceGroupName] <String>] [[-AseResourceId] <String>]
 [-PerSiteScaling <Boolean>] [-AsyncScalingEnabled <Boolean>] [-HyperV] [-AsJob] [-Tag <Hashtable>] [-Linux] [-ResourceGroupName] <String>
 [-Name] <String> [-ManagedInstance] [-AssignIdentity <Boolean>] [-UserAssignedIdentityId <String[]>]
 [-DefaultIdentity <String>] [-RdpEnabled <Boolean>] [-VirtualNetworkSubnetId <String>]
 [-InstallScript <InstallScript[]>] [-StorageMount <StorageMount[]>] [-RegistryAdapter <RegistryAdapter[]>]
 [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### S2
```
New-AzAppServicePlan [-Location] <String> [[-Tier] <String>] [[-NumberofWorkers] <Int32>]
 [[-WorkerSize] <String>] [[-AseName] <String>] [[-AseResourceGroupName] <String>] [[-AseResourceId] <String>]
 [-PerSiteScaling <Boolean>] [-AsyncScalingEnabled <Boolean>] [-AsJob] [-AppServicePlan] <PSAppServicePlan>
 [-AssignIdentity <Boolean>] [-UserAssignedIdentityId <String[]>] [-DefaultIdentity <String>]
 [-RdpEnabled <Boolean>] [-VirtualNetworkSubnetId <String>] [-InstallScript <InstallScript[]>]
 [-StorageMount <StorageMount[]>] [-RegistryAdapter <RegistryAdapter[]>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzAppServicePlan** cmdlet creates an Azure App Service plan in a given Geo location with the specified Tier, worker size, and number of workers.

Use **-AsyncScalingEnabled $true** to allow asynchronous scaling when there are insufficient workers to scale synchronously.
This setting requires a dedicated App Service plan and does not run the cmdlet in the background; use **-AsJob** for background execution.

Use **-ManagedInstance** to create a Managed Instance plan for Windows applications that require operating system customization.
Configure managed identities, installation scripts, storage mounts, registry adapters, plan-level virtual network integration, and Remote Desktop Protocol (RDP) access with the corresponding parameters.
Managed Instance plans cannot use **-Linux** or **-HyperV**.

## EXAMPLES

### Example 1: Create an App Service plan
```powershell
New-AzAppServicePlan -ResourceGroupName "Default-Web-WestUS" -Name "ContosoASP" -Location "West US" -Tier "Basic" -NumberofWorkers 2 -WorkerSize "Small"
```

This command creates an App Service plan named ContosoASP in the resource group named Default-Web-WestUS in Geo location West US.
The command specifies a Basic Tier and allocates two small workers.

### Example 2: Create an Isolated v4 App Service plan
```powershell
New-AzAppServicePlan -ResourceGroupName "Default-Web-WestUS" -Name "ContosoIsolatedASP" -Location "West US" -Tier "IsolatedV4" -WorkerSize "ExtraExtraExtraLarge" -AseName "ContosoAse"
```

This command creates an I6V4 App Service plan in the App Service Environment named ContosoAse.
Use worker sizes Small through ExtraExtraExtraLarge to select I1V4 through I6V4.

### Example 3: Create a memory-optimized Isolated v4 App Service plan
```powershell
New-AzAppServicePlan -ResourceGroupName "Default-Web-WestUS" -Name "ContosoMemoryOptimizedASP" -Location "West US" -Tier "IsolatedMV4" -WorkerSize "ExtraExtraLarge" -AseName "ContosoAse"
```

This command creates an I5MV4 memory-optimized App Service plan in the App Service Environment named ContosoAse.
Use worker sizes Small through ExtraExtraLarge to select I1MV4 through I5MV4.

### Example 4: Create a Managed Instance plan with an identity and networking
```powershell
$subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ContosoRG/providers/Microsoft.Network/virtualNetworks/ContosoVnet/subnets/ContosoSubnet"
New-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" -Location "eastus" -Tier "PremiumV4" -WorkerSize "Small" -NumberofWorkers 1 -ManagedInstance -AssignIdentity $true -DefaultIdentity "[system]" -RdpEnabled $true -VirtualNetworkSubnetId $subnetId
```

This command creates a Managed Instance plan, enables its system-assigned managed identity and RDP access, and integrates the plan with an existing subnet.
The subnet must meet the App Service virtual network integration requirements, including delegation to Microsoft.Web/serverFarms.
The system-assigned identity is used by default for plan integrations.

### Example 5: Configure scripts, storage mounts, and registry adapters
```powershell
$script = @{
    Name = "setup"
    Source = @{
        # The ZIP package must contain Install.ps1 at its root.
        SourceUri = "https://contosostorage.blob.core.windows.net/scripts/setup.zip"
        Type = "RemoteAzureBlob"
    }
}
$mount = @{
    Name = "data"
    Type = "AzureFiles"
    Source = "\\contosostorage.file.core.windows.net\data"
    DestinationPath = "D:\data"
    CredentialsKeyVaultReference = @{
        SecretUri = "https://contosovault.vault.azure.net/secrets/storage-credentials"
    }
}
$adapter = @{
    RegistryKey = "HKEY_LOCAL_MACHINE\Software\Contoso\Setting"
    Type = "String"
    KeyVaultSecretReference = @{
        SecretUri = "https://contosovault.vault.azure.net/secrets/registry-setting"
    }
}
New-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" -Location "eastus" -Tier "PremiumV4" -ManagedInstance -AssignIdentity $true -DefaultIdentity "[system]" -InstallScript $script -StorageMount $mount -RegistryAdapter $adapter
```

This command configures an installation script, an Azure Files mount, and a registry adapter when creating the plan.
The plan identity must have permission to access the script and the referenced Key Vault secrets.
Hashtable values are converted to the corresponding configuration objects.

### Example 6: Create an App Service plan with asynchronous scaling enabled
```powershell
New-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoASP" -Location "East US" -Tier "PremiumV3" -WorkerSize "Small" -NumberofWorkers 10 -AsyncScalingEnabled $true
```

This command creates a dedicated App Service plan that can scale asynchronously when there are insufficient workers to fulfill the request synchronously.
The cmdlet waits for the operation to complete before returning the plan.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppServicePlan
App Service Plan Object

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan
Parameter Sets: S2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AseName
App Service Environment Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AseResourceGroupName
App Service Environment Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AseResourceId
Resource id of App Service Environment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignIdentity
Enable or disable the system-assigned managed identity on the App Service plan.
User-assigned identities are configured separately with **-UserAssignedIdentityId**.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsyncScalingEnabled
Enable or disable asynchronous scaling for a dedicated App Service plan.
Set to true to allow an asynchronous operation when there are insufficient workers to scale synchronously, or false to allow only synchronous scaling.
Omit this parameter to use the service default.
This setting is independent of **-AsJob**.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultIdentity
The identity used by default for plan integrations.
Specify `[system]` to use the plan's system-assigned identity, or the resource ID of a user-assigned identity associated with the plan.
Pass an empty string to clear the default identity.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HyperV
Specify this, App Service Plan will run Windows Containers

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: S1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstallScript
The installation scripts to configure for the Managed Instance plan.
Each object specifies a Name and a Source containing SourceUri and Type.
Supported source types include RemoteAzureBlob and PlatformStorage.

```yaml
Type: Microsoft.Azure.Management.WebSites.Models.InstallScript[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Linux
Specify this, App Service Plan will run Linux Containers

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: S1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedInstance
Create a Managed Instance App Service plan by enabling custom mode.
Use this option for Windows applications that need installation scripts, registry customization, or plan-level storage mounts.
This option cannot be combined with **-Linux** or **-HyperV**.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: S1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
App Service Plan Name

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberofWorkers
Number Of Workers

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: 1
Accept pipeline input: False
Accept wildcard characters: False
```

### -PerSiteScaling
Whether or not to enable Per Site Scaling

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RdpEnabled
Enable or disable Remote Desktop Protocol (RDP) access to the Managed Instance plan.
Use **Get-AzAppServicePlanRdpCredential** to retrieve the credentials and **Get-AzAppServicePlanManagedInstance** to retrieve worker IP addresses.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryAdapter
The registry adapters to configure for the Managed Instance plan.
Each object specifies RegistryKey, Type, and a KeyVaultSecretReference containing the SecretUri of the registry value.
Supported types include Binary, String, Expand_String, Multi_String, DWord, and QWord.

```yaml
Type: Microsoft.Azure.Management.WebSites.Models.RegistryAdapter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMount
The storage mounts to configure for the Managed Instance plan.
Each object specifies Name, Type, and DestinationPath.
AzureFiles and FileShare mounts also require a Source; use CredentialsKeyVaultReference.SecretUri for credentials stored in Key Vault.
LocalStorage mounts do not require a source.

```yaml
Type: Microsoft.Azure.Management.WebSites.Models.StorageMount[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags are name/value pairs that enable you to categorize resources

```yaml
Type: System.Collections.Hashtable
Parameter Sets: S1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tier
The App Service plan tier.
Use IsolatedV4 for I1V4 through I6V4 plans and IsolatedMV4 for I1MV4 through I5MV4 memory-optimized plans in an App Service Environment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: Free
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
The resource IDs of user-assigned managed identities to associate with the App Service plan.
Use **-DefaultIdentity** to select the identity used by default for plan integrations.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkSubnetId
The full resource ID of the existing subnet used for plan-level virtual network integration.
The subnet must be configured for App Service integration, including delegation to Microsoft.Web/serverFarms.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkerSize
The size of the workers to allocate.
For IsolatedV4, Small through ExtraExtraExtraLarge select I1V4 through I6V4.
For IsolatedMV4, Small through ExtraExtraLarge select I1MV4 through I5MV4.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: ExtraSmall, Small, Medium, Large, ExtraLarge, ExtraExtraLarge, ExtraExtraExtraLarge

Required: False
Position: 5
Default value: Small
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan

## NOTES

## RELATED LINKS

[Get-AzAppServicePlan](./Get-AzAppServicePlan.md)

[Remove-AzAppServicePlan](./Remove-AzAppServicePlan.md)

[Set-AzAppServicePlan](./Set-AzAppServicePlan.md)
