---
RFC: RFC0003
Author: Mark Cowlishaw
Status: Implemented
SupercededBy: 
Version: 1.0
---

# Asynchronous Operations

In the Az 4.0 preview, cmdlets have deep support for asynchronous execution, allowing the user to defer cmdlet execution to the background, support low latency scenarios, and cancel execution to make interactive and scripted management tasks more efficient.

## Motivation

### AsJob
Interactive cmdlet users can easily run all Azure long-running tasks in the background, and check their status only when needed, using the AsJob parameter.  The new implementation of AsJob uses fewer resources than the implemetation in existing cmdlets

```code
As an interactive user
I can efficiently perform tasks in the background using AsJob
so that I can continue interactively managing Azure resources until the results of the task are needed.
```

### NoWait
Users writing scripts running in low-latency environments (such as hosted in a web application) can start Azure management functions and exit without awaiting results, or cancelling the operation.

```code
As a scripting user hosting PowerShell scripts in a low latency environnment, such as a web application or Azure function
I can efficiently begin Azure operations without having to wait for results
so that I can exit the script without cancelling the operation, or cleaning up background tasks.
```

### Cancellation
Interactive cmdlet users can cancel execiution of cmdlets at any time using the standard `Command-<period>` key code.  This allows the user to cancel cmdlet execution that is unexpectedly long or returns an unexpected number of results.

```code
As an interactive user
I can cancel any cmdlet execution using standard keyboard shortcuts for cancellation
so that interactive sessions are not blocked by cmdlets that take an unexpectedly long time, or return n unexpectedly large number of results.
```


## User Experience

### AsJob

```PowerShell
$job = New-AzStorageAccount <parameters> -AsJob
... Mode cmdlets until storage account is needed ...
Wait-Job $job
Receive-Job $job
```

### NoWait

```PowerShell
$job = New-AzStorageAccount <parameters> -NoWait
... Mode cmdlets until storage account is needed ...
Get-AzStorageAccount <parameters>
```


## Comments and Questions

- Do you have any scenarios in which `NoWait` would be a better fit than `AsJob`?

