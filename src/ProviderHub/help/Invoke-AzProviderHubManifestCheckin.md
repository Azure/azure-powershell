---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/invoke-azproviderhubmanifestcheckin
schema: 2.0.0
---

# Invoke-AzProviderHubManifestCheckin

## SYNOPSIS
Checkin the manifest.

## SYNTAX

### ManifestExpanded (Default)
```
Invoke-AzProviderHubManifestCheckin -ProviderNamespace <String> [-SubscriptionId <String>]
 -BaselineArmManifestLocation <String> -Environment <String> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Manifest
```
Invoke-AzProviderHubManifestCheckin -ProviderNamespace <String> [-SubscriptionId <String>]
 -CheckinManifestParam <ICheckinManifestParams> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManifestViaIdentityExpanded
```
Invoke-AzProviderHubManifestCheckin -InputObject <IProviderHubIdentity> -BaselineArmManifestLocation <String>
 -Environment <String> [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManifestViaIdentity
```
Invoke-AzProviderHubManifestCheckin -InputObject <IProviderHubIdentity>
 -CheckinManifestParam <ICheckinManifestParams> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checkin the manifest.

## EXAMPLES

### Example 1: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace $env.ProviderNamespace -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"
```

### Example 2: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace $env.ProviderNamespace -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"
```

## PARAMETERS

### -BaselineArmManifestLocation
The baseline ARM manifest location supplied to the checkin manifest operation.

```yaml
Type: System.String
Parameter Sets: ManifestExpanded, ManifestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckinManifestParam
.
To construct, see NOTES section for CHECKINMANIFESTPARAM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestParams
Parameter Sets: Manifest, ManifestViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
The environment supplied to the checkin manifest operation.

```yaml
Type: System.String
Parameter Sets: ManifestExpanded, ManifestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: ManifestViaIdentityExpanded, ManifestViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: ManifestExpanded, Manifest
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: ManifestExpanded, Manifest
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestParams
### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfo
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

CHECKINMANIFESTPARAM \<ICheckinManifestParams\>: .
  BaselineArmManifestLocation \<String\>: The baseline ARM manifest location supplied to the checkin manifest operation.
  Environment \<String\>: The environment supplied to the checkin manifest operation.

INPUTOBJECT \<IProviderHubIdentity\>: Identity Parameter
  \[Id \<String\>\]: Resource identity path
  \[NestedResourceTypeFirst \<String\>\]: The first child resource type.
  \[NestedResourceTypeSecond \<String\>\]: The second child resource type.
  \[NestedResourceTypeThird \<String\>\]: The third child resource type.
  \[NotificationRegistrationName \<String\>\]: The notification registration.
  \[ProviderNamespace \<String\>\]: The name of the resource provider hosted within ProviderHub.
  \[ResourceType \<String\>\]: The resource type.
  \[RolloutName \<String\>\]: The rollout name.
  \[Sku \<String\>\]: The SKU.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.providerhub/invoke-azproviderhubmanifestcheckin](https://docs.microsoft.com/en-us/powershell/module/az.providerhub/invoke-azproviderhubmanifestcheckin)

