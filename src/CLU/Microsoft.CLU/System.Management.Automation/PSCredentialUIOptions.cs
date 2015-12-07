namespace System.Management.Automation
{
    [Flags]
    public enum PSCredentialUIOptions
    {
        None = 0,
        Default = 1,
        ValidateUserNameSyntax = 1,
        AlwaysPrompt = 2,
        ReadOnlyUserName = 3
    }
}
