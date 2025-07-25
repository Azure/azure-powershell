### Example 1: Enable a receiver for specified action group
```powershell
Enable-AzActionGroupReceiver -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -ReceiverName user1 -PassThru
```

```output
True
```

This command enable a receiver in an action group.

