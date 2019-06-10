## Storage

### ActivityLog

* `Get-AzActivityLog`
    - [ ] Replace `-Filter` with the other parameters:
        - `StartTime`, `EndTime`, `Status`, `Caller`, `CorrelationId`, `ResourceProvider`, `ResourceGroupName`
    - [ ] Implement `-MaxRecord`


### ActivityLogAlert

* `Set-AzActivityLogAlert`
    - [ ] (?) `-Condition` is an array of two strings: `Field` and `Equals`. Create an cmdlet that creates in-memory objects for these conditions
        - According to the specs: "The possible values for this 'Field' are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'."
    - [ ] Since the default is creating an enabled alert. Remove `-Enabled` switch parameter and add `-DisableAlert`, that disables the alert if used.
    - Verify if normal action groups (the ones created using the action groups cmdlets) can be used in the `-ActionGroup` parameter.
* `Update/Enable/Disable-AzActivityLogAlert`
    - The PATCH only works for changing the tags and the `Enabled` property thus,
    - [ ] Create `Enable/Disable-AzActivityLogAlert`
    - [ ] Remove `Update-AzActivityLogAlert`

### ActionGroup

* `Set-AzActionGroup`
    - `-GroupShortName` -> `-ShortName`
    - [ ] Hide the specific `Receiver` parameters i.e. `-EmailReceiver` and implement like the original code an parameter for an array of generic receivers
        - Obs: It seems that the spec specify more kinds of receiver that the original code actually uses/creates with the in-memory creation cmdlet `New-AzActionGroupReceiver`
* `New-AzActionGroup`
    - Obs: This is not similar to the original `New-AzActionGroup` which is used only for `ActivityLogAlerts`.
    - [ ] Apply the same changes made to `Set-AzActionGroup`
