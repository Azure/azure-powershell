## ShouldProcess

From [_Cmdlet Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/cmdlet-attribute-declaration):

> _All cmdlets that change resources outside of PowerShell should include the `SupportsShouldProcess` keyword when the `Cmdlet` attribute is declared, which allows the cmdlet to call the `ShouldProcess` method before the cmdlet performs its action. If the `ShouldProcess` call returns false, the action should not be taken._
>
> _The `-Confirm` and `-WhatIf` cmdlet parameters are available only for cmdlets that support `ShouldProcess` calls._

Below is an example of the declaration of this property in the `Cmdlet` attribute and the subsequent call to `ShouldProcess` in the body of the cmdlet:

```cs
[Cmdlet(VerbsCommon.Remove, "Foo", SupportsShouldProcess = true)]
public class RemoveFoo
{
    ...

    public override void ExecuteCmdlet()
    {
        if (ShouldProcess(target, actionMessage))
        {
            // make changes
        }
    }
}
```

Please see the example cmdlets found in our [`examples`](../examples) folder for additional implementations of `ShouldProcess`.

By default, `ShouldProcess` interacts with the cmdlet `ConfirmImpact` and the user's `$ConfirmPreference` setting to decide whether to prompt the user before continuing cmdlet processing. The `$ConfirmPreference` determines the level at which confirmation automatically occurs, and no prompt is shown. If the `ConfirmImpact` specified in a cmdlet is at or below the level of `$ConfirmPreference`, then processing occurs automatically without displaying a prompt. Since both `ConfirmImpact` and `$ConfirmPreference` are set by default to `Medium`, this means that, by default, no confirmation prompt is shown and the cmdlet executes normally.

PowerShell has several tools that allow users to explore and control what happens during execution of cmdlets, and this change in implementation allows them to use these tools.

Users who specify the `-Confirm` parameter on the command prompt will automatically be prompted for **any** call to `ShouldProcess`, and can decide whether to continue processing. Users can increase or decrease their `$ConfirmPreference` level to decide which kinds of changes will be confirmed automaticlaly without user interaction.

Users can specify the `-WhatIf` parameter to see all the `ShouldProcess` prompts that would occur during exeuction of a cmdlet, without actually making any changes.

Some cmdlets required additional confirmation. For example, if a cmdlet would destroy existing resources in some circumstances, the cmdlet might detect that condition and prompt the user to verify before continuing. Overwriting an existing resource during resource creation, overwriting a file when downloading data, deleting a resource that is currently in use, or deleting a container that contains additional resources are all example of this pattern. To implement additional confirmation, and allow scripts to opt out of additional prompts, the above pattern is enhanced with calles to `ShouldContinue()` and the `Force` parameter:

```cs
if (ShouldProcess(target, actionMessage))
{
    // do processing and check whether additional prompting is required

    if (Force || ShouldContinue(shouldContinueWarning, shouldContinueCaption))
    {
        // make change that required confirmation
    }
}
```

Notice that to _automatically skip prompts_ for such a cmdlet requires the user to supply the `Force` parameter.

```powershell
Remove-Foo -Force
```

Also note that if you are unsure of the `$ConfirmPreference` setting int he current environment, you can skip both sets of prompts using the following:

```powershell
Remove-Foo -Force -Confirm:$false
```

### Additional Common Methods

The following method overloads were added to `AzurePSCmdlet`. Partners may use these methods to properly implement confirmation in the implementation of `ProcessRecord()`.

```cs
/// <summary>
/// Prompt for confirmation depending on the ConfirmImpact level. By default, no confirmation prompt occurs
/// unless ConfirmImpact > $ConfirmPreference. Guarding the actions of a cmdlet with this method will enable
/// to support -WhatIf and -Confirm parameters.
/// </summary>
/// <param name="processMessage">The change being made to the resource</param>
/// <param name="target">The resource that is being changed</param>
/// <param name="action">The action to perform if confirmed</param>
void ConfirmAction(string processMessage, string target, Action action);

/// <summary>
/// Guards execution of the given action using ShouldProcess and ShouldContinue. The optional useShouldContinue
/// predicate determines whether ShouldContinue should be called for this particular action (e.g., a resource
/// is being overwritten). By Default, only ShouldProcess will be executed unless useShouldContinue returns
/// true. Cmdlets that use this method overload must have a Force parameter. Guarding the actions of a
/// cmdlet with this method will enable the cmdlet to support -WhatIf and -Confirm parameters.
/// </summary>
/// <param name="force">Do not display a ShouldContinue prompt under any circumstances</param>
/// <param name="continueMessage">A user prompt to confirm the destructive change if useShouldContinue returns true</param>
/// <param name="processMessage">A description of the normal action performed by the cmdlet.</param>
/// <param name="target">The resource that is being changed</param>
/// <param name="action">The action to perform if confirmed</param>
/// <param name="useShouldContinue">A predicate indicating whether ShouldContinue should be invoked for this action</param>
void ConfirmAction(bool force, string continueMessage, string processMessage, string target, Action action, Func<bool> useShouldContinue);
```

## ConfirmImpact

From [_Cmdlet Attribute Declaration_](https://learn.microsoft.com/en-us/powershell/developer/cmdlet/cmdlet-attribute-declaration):

> _Specifies when the action of the cmdlet should be confirmed by a call to the `ShouldProcess` method. `ShouldProcess` will only be called when the `ConfirmImpact` value of the cmdlet (by default, Medium) is equal to or greater than the value of the `$ConfirmPreference` variable. This parameter should be specified only when the `SupportsShouldProcess` parameter is specified._

Below are the possible `ConfirmImpact` values:

| Member name | Description                                                                                                    |
|-------------|----------------------------------------------------------------------------------------------------------------|
| High        | This action is potentially highly "destructive" and should be confirmed by default unless otherwise specified. |
| Low         | This action only needs to be confirmed when the user has requested the low-impact changes must be confirmed.   |
| Medium      | This action should be confirmed in most scenarios where confirmation is requested.                             |
| None        | There is never any need to confirm this action.                                                                |

_Note:_ the `ConfirmImpact` property in the `Cmdlet` attribute should never be set; ignoring this property will set the value to `Medium`, which is expected and advised.