---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringservice
schema: 2.0.0
---

# Get-AzPeeringService

## SYNOPSIS
Gets an existing peering service with the specified name under the given subscription and resource group.

## SYNTAX

### List1 (Default)
```
Get-AzPeeringService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPeeringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPeeringService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringService -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing peering service with the specified name under the given subscription and resource group.

## EXAMPLES

### Example 1: List all peering services under subscription
```powershell
Get-AzPeeringService
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all peering services under default subscription

### Example 2: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all the peering services under a resource group

### Example 3: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG -Name TestExtension
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
```

Gets a peering service with matching name and resource group

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the peering.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PeeringServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringService

## NOTES

## RELATED LINKS
