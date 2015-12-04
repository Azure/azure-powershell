namespace System.Management.Automation
{
    [Flags]
    public enum ShouldProcessReason
    {
        None = 0,
        WhatIf = 1
    }
}
