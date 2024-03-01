---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/connect-azconnectedmachine
schema: 2.0.0
---

# Connect-AzConnectedMachine

## SYNOPSIS
API to register a new machine and thereby create a tracked resource in ARM

## SYNTAX

```
Connect-AzConnectedMachine [-ResourceGroupName] <String> [[-SubscriptionId] <String>] [[-Name] <String>]
 [-Location] <String> [[-PSSession] <PSSession[]>] [[-Tag] <Hashtable>] [[-DefaultProfile] <PSObject>]
 [[-Proxy] <Uri>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
API to register a new machine and thereby create a tracked resource in ARM

## EXAMPLES

### Example 1: Onboards the machine you're on as a connected machine
```powershell
Connect-AzConnectedMachine -ResourceGroupName contoso-connected-machines -Name linux_eastus1_1 -Location eastus
```

```output
< truncated output of installing the azcmagent >

time="2020-08-07T13:13:25-07:00" level=info msg="Onboarding Machine. It usually takes a few minutes to complete. Sometimes it may take longer depending on network and server load status."
time="2020-08-07T13:13:25-07:00" level=info msg="Check network connectivity to all endpoints..."
time="2020-08-07T13:13:29-07:00" level=info msg="All endpoints are available... continue onboarding"
time="2020-08-07T13:13:50-07:00" level=info msg="Successfully Onboarded Resource to Azure" VM Id=978ab182-6cf0-4de3-a58b-53c8d0a3235e

Name             Location OSName   Status     ProvisioningState
----             -------- ------   ------     -----------------
linux_eastus1_1  eastus   linux    Connected  Succeeded
```

Onboards the machine you're on as a connected machine.

### Example 2: Onboards a remote machine as a connected device
```powershell
$session = Connect-PSSession -ComputerName WINBOX
Connect-AzConnectedMachine -ResourceGroupName contoso-rg -Name win_eastus1_1 -Location eastus -PSSession $session
```

```output
< truncated output of installing the azcmagent >

time="2020-08-07T13:13:25-07:00" level=info msg="Onboarding Machine. It usually takes a few minutes to complete. Sometimes it may take longer depending on network and server load status."
time="2020-08-07T13:13:25-07:00" level=info msg="Check network connectivity to all endpoints..."
time="2020-08-07T13:13:29-07:00" level=info msg="All endpoints are available... continue onboarding"
time="2020-08-07T13:13:50-07:00" level=info msg="Successfully Onboarded Resource to Azure" VM Id=978ab182-6cf0-4de3-a58b-53c8d0a3236a

Name           Location OSName   Status     ProvisioningState
----           -------- ------   ------     -----------------
win_eastus1_1  eastus   windows  Connected  Succeeded
```

Onboards a remote machine as a connected device using PowerShell remoting.
Note: only Windows as the target is supported at this time.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location for the created ConnectedMachine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name that will be used for this machine.
The hostname is used by default.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PSSession
When specified, the command that onboards machines to Azure will be run within each PSSession.
NOTE: This only works on Windows for now.

```yaml
Type: System.Management.Automation.Runspaces.PSSession[]
Parameter Sets: (All)
Aliases: Session

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group you want to add the machine to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription you want to add the machine to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
