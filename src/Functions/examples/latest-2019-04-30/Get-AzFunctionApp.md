### Example 1: Get all function apps.
```powershell
PS C:\> Get-AzFunctionApp

Name                     Status  OSType  RuntimeName Host Location    AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ----------- ---- --------    -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet      ~2   Central US  CentralUSPlan  Functions-West-Europe-Win 07308f04-ea00-494b-b320-690df74b1ce6
Functions1-Windows-Java  Running Windows Java        ~2   West Europe Premium1-WE    Functions-West-Europe1    07308f04-ea00-494b-b320-690df74b1ce6

```

{{ Add description here }}

### Example 2: Get function apps by resource group name.
```powershell
PS C:\> Get-AzFunctionApp -ResourceGroupName Functions-West-Europe-Win

Name                     Status  OSType  RuntimeName Host Location   AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ----------- ---- --------   -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet      ~2   Central US CentralUSPlan  Functions-West-Europe-Win 07308f04-ea00-494b-b320-690df74b1ce6


```

{{ Add description here }}

