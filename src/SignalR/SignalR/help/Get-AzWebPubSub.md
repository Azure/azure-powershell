---
external help file: Az.SignalR-help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/get-azwebpubsub
schema: 2.0.0
---

# Get-AzWebPubSub

## SYNOPSIS
Get the resource and its properties.

## SYNTAX

### List (Default)
```
Get-AzWebPubSub [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [<CommonParameters>]
```

### Get
```
Get-AzWebPubSub -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### List1
```
Get-AzWebPubSub -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebPubSub -InputObject <IWebPubSubIdentity> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials]
 [<CommonParameters>]
```

## DESCRIPTION
Get the resource and its properties.

## EXAMPLES

### Example 1: List all Web PubSub resources in a subscription
```powershell
Get-AzWebPubSub -SubscriptionId ef72249e-9785-4799-a76b-7cdd80e1b1d0
```

```output
Name                Location      SkuName
----                --------      -------
demo1               eastus        Standard_S1
demo2               eastus        Free_F1
```

### Example 2: List all Web PubSub resources in a resource group
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```

### Example 3: Get a specific Web PubSub resource
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```

### Example 4: Get a specific Web PubSub resource via identity object
```powershell
$identity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

$identity | Get-AzWebPubSub
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```

## PARAMETERS

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.SendAsyncStep[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.SendAsyncStep[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ResourceName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.IWebPubSubResource

## NOTES

## RELATED LINKS
