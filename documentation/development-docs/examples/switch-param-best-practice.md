# Switch Parameter Best Practice

## DO NOT use `IsParameterBound()` on a switch parameter

```csharp
// anti-pattern
if (this.IsParameterBound(c => c.PassThru))
{
    WriteObject(true);
}
```

It is possible to pass a `$false` to switch parameter, in that case, however, `IsParameterBound()` will still return `true`.

## DO use `if (SwitchParamName)` to check a switch parameter

```csharp
if (PassThru)
{
    WriteObject(true);
}