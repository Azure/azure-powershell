namespace Microsoft.CLU
{
    /// <summary>
    /// Contract that all command line parsers needs to implement.
    /// </summary>
    public interface ICommandLineParser
    {
        /// <summary>
        /// Parse the arguments based on a specific syntax (e.g. Unix, DOS) and invoke
        /// appropriate ICommandBinder methods to bind those arguments.
        /// </summary>
        /// <param name="commandBinder">The ICommandBinder implementation</param>
        /// <param name="arguments">The arguments to parse</param>
        /// <returns>True if the command should be invoked, false if not.</returns>
        /// <remarks>
        /// The reason for Parse returning false is typically that help information was displayed.
        /// Errors are reported via exceptions.
        /// </remarks>
        bool Parse(ICommandBinder commandBinder, string[] arguments);

        /// <summary>
        /// Set the position of 'argument postion indicator' to the begining.
        /// </summary>
        void SeekBegin();

        /// <summary>
        /// Reset back the position of 'argument postion indicator' by the given offset.
        /// </summary>
        /// <param name="offset">The offset</param>
        void SeekBack(uint offset);

        /// <summary>
        /// Present the parameter names passed in using the syntax of the parser.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <returns>The formatted parameter name</returns>
        /// <example>
        /// For DOS,  "(first,string),(second,int),(third,date),(a,SwitchParameter)" --> "/first:string,/second:int,/third:date,/a"
        /// For Unix, "first,second,third,a" --> "--first string ,--second int,--third date,-a"
        /// </example>
        string FormatParameterName(string name, string type, bool isMandatory, bool isPositional);
    }
}
