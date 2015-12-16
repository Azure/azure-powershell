namespace System.Management.Automation
{
    [Flags]
    public enum PSMemberTypes
    {
        AliasProperty = 1,
        CodeProperty = 2,
        Property = 4,
        NoteProperty = 8,
        ScriptProperty = 16,
        Properties = 31,
        PropertySet = 32,
        Method = 64,
        CodeMethod = 128,
        ScriptMethod = 256,
        Methods = 448,
        ParameterizedProperty = 512,
        MemberSet = 1024,
        Event = 2048,
        All = 4095
    }
}
