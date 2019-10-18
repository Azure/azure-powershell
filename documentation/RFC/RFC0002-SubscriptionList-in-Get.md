---
RFC: RFC0002
Author: Azure PowerShell team
Status:  Draft
SupercededBy: n/a
Version: 1.0
---

# List of subscriptions for GET commands

A GET cmdlet is mostly used to obtain an Azure resource or validate its existence in Azure.
With more and more customers using multiple subscriptions the ability to search for resources accross subscriptions has become a more needed convenience.

We are planning to run GET accross subscriptions within a tenant.

## Motivation

Explain the benefits of the change for the users.

```code
As a PowerShell script developer
I can run a GET command accross several subscriptions
so I can search for Azure resources that meet scpecific criteria no matter what subscription they are in.
```

## User Experience

The default behavior will not change, but the user can specify a different subscription, or multiple subscriptions when performing gats.  The output of these gets can be filtered and piped into any other cmdlet.

```PowerShell
Get-AzVM -name "bla"
```

One can specify one of several subscriptions to use:

```PowerShell
Get-AzVm -name "bla" -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Restart-AzVM

Get-AzVm -name "bla" -SubscriptionId ['xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx', 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'] | Restart-AzVM
```

## Comments and Questions

Please insert below your anwser to the following questions or add any additional questions that you may have:

- Should the default behavior select all subscriptions in a tenant as part of connecting an account?

  - _Your prefered default behavior_

- What is most likely going to help you select a subset of subscriptions as the default? A new cmdlet, the use of `$PSDefaultParameterValues` or any other suggestion that you may have:

  - _Your prefered default behavior_

## Specifications

## Alernate proposals and considerations
