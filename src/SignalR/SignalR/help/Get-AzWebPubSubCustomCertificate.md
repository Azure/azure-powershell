---
external help file: Az.SignalR-help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/get-azwebpubsubcustomcertificate
schema: 2.0.0
---

# Get-AzWebPubSubCustomCertificate

## SYNOPSIS
Get a custom certificate.

## SYNTAX

### List (Default)
```
Get-AzWebPubSubCustomCertificate -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzWebPubSubCustomCertificate -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebPubSubCustomCertificate -InputObject <IWebPubSubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a custom certificate.

## EXAMPLES

### Example 1: List all the custom certificates of a Azure Web PubSub resource
```powershell
Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

We can see this Web PubSub resource only contains one custom certificate.

### Example 2: Get a custom certificate by its name
```powershell
Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps -Name mycustomcert
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

### Example 3: Get a custom certificate by its identity
```powershell
$customCert = Get-AzWebPubSubCustomCertificate -ResourceGroupName rg -ResourceName wps -Name mycustomcert
$customCert | Get-AzWebPubSubCustomCertificate
```

```output
Name         KeyVaultBaseUri                                  KeyVaultSecretName KeyVaultSecretVersion ProvisioningState
----         ---------------                                  ------------------ --------------------- -----------------
mycustomcert https://kvcustomcertificatetest.vault.azure.net/ manual-test                              Succeeded
```

## PARAMETERS

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
Custom certificate name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.ICustomCertificate

## NOTES

## RELATED LINKS
