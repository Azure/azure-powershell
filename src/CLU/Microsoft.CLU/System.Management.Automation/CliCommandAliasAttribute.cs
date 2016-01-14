namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class CliCommandAliasAttribute : System.Attribute
    {
        /// <summary>
        /// Give explicit name for command
        /// </summary>
        /// <param name="commandName">
        /// Semicolon separated command name. For example, if you expect the user to be able to run
        /// azure foo bar, the command name should be "foo;bar"
        /// </param>
        public CliCommandAliasAttribute(string commandName)
        {
            CommandName = commandName;
        }

        public string CommandName { get; private set; }
    }
}
