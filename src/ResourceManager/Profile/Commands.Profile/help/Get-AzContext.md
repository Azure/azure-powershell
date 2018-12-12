---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Profile
online version: https://docs.microsoft.com/en-us/powershell/module/az.profile/get-azcontext
schema: 2.0.0
---

# Get-AzContext

## SYNOPSIS
Gets the metadata used to authenticate Azure Resource Manager requests.

## SYNTAX

### GetSingleContext (Default)
```
Get-AzContext [-DefaultProfile <IAzureContextContainer>] [[-Name] <String>] [<CommonParameters>]
```

### ListAllContexts
```
Get-AzContext [-ListAvailable] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzContext cmdlet gets the current metadata used to authenticate Azure Resource Manager requests.
This cmdlet gets the Active Directory account, Active Directory tenant, Azure subscription, and the targeted Azure environment.
Azure Resource Manager cmdlets use these settings by default when making Azure Resource Manager requests.

## EXAMPLES

### Example 1: Getting the current context
```
PS C:\> Connect-AzAccount
PS C:\> Get-AzContext

Name                                     Account             SubscriptionName    Environment         TenantId
----                                     -------             ----------------    -----------         --------
Subscription1 (xxxxxxxx-xxxx-xxxx-xxx... test@outlook.com    Subscription1       AzureCloud          xxxxxxxx-x...
```

In this example we are logging into our account with an Azure subscription using Connect-AzAccount, and then we are getting the context of the current session by calling Get-AzContext.

### Example 2: Listing all available contexts
```
PS C:\> Get-AzContext -ListAvailable

Name                                     Account             SubscriptionName    Environment         TenantId
----                                     -------             ----------------    -----------         --------
Subscription1 (xxxxxxxx-xxxx-xxxx-xxx... test@outlook.com    Subscription1       AzureCloud          xxxxxxxx-x...
Subscription2 (xxxxxxxx-xxxx-xxxx-xxx... test@outlook.com    Subscription2       AzureCloud          xxxxxxxx-x...
Subscription3 (xxxxxxxx-xxxx-xxxx-xxx... test@outlook.com    Subscription3       AzureCloud          xxxxxxxx-x...
```

In this example, all currently available contexts are displayed.  The user may select one of these contexts using Select-AzContext.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListAvailable
List all available contexts in the current session.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListAllContexts
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the context

```yaml
Type: System.String
Parameter Sets: GetSingleContext
Aliases:
Accepted values: Core-ES-BLD (54e18c35-3863-4a17-8e52-b5aa1e65847e) - maclayto@microsoft.com, DDXLABDTL-01 (e2dc3810-f8e5-4337-a41c-8b9ec7d954ee) - maclayto@microsoft.com, Pay-As-You-Go (92ad8d84-3287-4990-b83d-5e983832f7ce) - maclayto@microsoft.com, DevDiv Key Vault (bd62906c-0a81-43c3-a2f8-126e4cf66ada) - maclayto@microsoft.com, Azure SDK Powershell Test (c9cbd920-c00c-427c-852b-8aaf38badaeb) - maclayto@microsoft.com, Azure SDK Infrastructure (6b085460-5f21-477e-ba44-1035046e9101) - maclayto@microsoft.com, Azure SDK Powershell Test - Manual (9e223dbe-3399-4e19-88eb-0975f02ac87f) - maclayto@microsoft.com, Cosmos_WDG_Core_BnB_100348 (dae41bd3-9db4-4b9b-943e-832b57cac828) - maclayto@microsoft.com, Node CLI Test (2c224e7e-3ef5-431d-a57b-e71f4662e3a6) - maclayto@microsoft.com, Key Vault Engineering Subscription (33f39d49-6173-49bf-9789-db5548ee6d73) - maclayto@microsoft.com, VS Telemetry - Data Catalog (a7bb576c-291e-4553-965a-1c588b3f29d8) - maclayto@microsoft.com

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureContext

## NOTES

## RELATED LINKS

[Set-AzContext](./Set-AzContext.md)

