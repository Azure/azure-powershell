using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace Microsoft.CLU.CommandLineParser
{
    /// <summary>
    /// Implementation of ICommandLineParser interface that can parse DOS style commandline arguments.
    /// </summary>
    internal class DOSCommandLineParser : ICommandLineParser
    {
        /// <summary>
        /// Parse the arguments based on DOS specific syntax and invoke appropriate ICommandBinder
        /// methods to bind those arguments.
        /// </summary>
        /// <param name="commandBinder">The ICommandBinder implementation</param>
        /// <param name="arguments">The arguments to parse</param>
        /// <returns>True if the command should be invoked, false if not.</returns>
        /// <remarks>
        /// The reason for Parse returning false is typically that help information was displayed.
        /// Errors are reported via exceptions.
        /// </remarks>
        public bool Parse(ICommandBinder commandBinder, string[] arguments)
        {
            Debug.Assert(commandBinder != null);

            if (arguments == null)
            {
                return true;
            }

            int position = 0;
            for (; _positionIndicator < arguments.Length; _positionIndicator++)
            {
                string arg = arguments[_positionIndicator];

                if (arg.StartsWith("/"))
                {
                    if (commandBinder.SupportsAutomaticHelp && 
                        (arg.Equals("/help", System.StringComparison.OrdinalIgnoreCase) ||
                         arg.Equals("/?", System.StringComparison.OrdinalIgnoreCase))) 
                    {
                        PresentCommandHelp(commandBinder, arguments.Take(position).ToArray(), false);
                        return false;
                    }

                    string name = arg.Substring(1);
                    string value = null;

                    int colonIdx = arg.IndexOf(':');
                    int equalIdx = arg.IndexOf('=');
                    if (colonIdx > 1)
                    {
                        // Style /a:b
                        name = arg.Substring(1, colonIdx - 1);
                        value = arg.Substring(colonIdx + 1);
                    }
                    else if (equalIdx > 1)
                    {
                        // Style /a=b
                        name = arg.Substring(1, equalIdx - 1);
                        value = arg.Substring(equalIdx + 1);
                    }

                    name = Normalize(name.ToLowerInvariant());

                    if (value == null)
                    {
                        if (commandBinder.TryBindSwitch(name))
                            continue;
                        
                        var nextArgument = (_positionIndicator < arguments.Length - 1) ? arguments[_positionIndicator + 1] : null;

                        if (nextArgument != null && !nextArgument.StartsWith("/"))
                        {
                            // Style /a b
                            value = nextArgument;
                            _positionIndicator++;
                        }
                    }
                    
                    commandBinder.BindArgument(name, value);
                }
                else
                {
                    if (position == 0 &&
                        commandBinder.SupportsAutomaticHelp &&
                        arg.Equals("help", System.StringComparison.OrdinalIgnoreCase))
                    {
                        PresentCommandHelp(commandBinder, arguments.Skip(1).ToArray(), true);
                        return false;
                    }

                    commandBinder.BindArgument(position, arg);
                    position++;
                }
            }

            return true;
        }

        /// <summary>
        /// Set the position of 'argument postion indicator' to the begining.
        /// </summary>
        public void SeekBegin()
        {
            _positionIndicator = 0;
        }

        /// <summary>
        /// Reset back the position of 'argument postion indicator' by the given offset.
        /// </summary>
        /// <param name="offset">The offset</param>
        public void SeekBack(uint offset)
        {
            Debug.Assert(_positionIndicator - (int)offset >= 0);
            _positionIndicator = _positionIndicator - offset;
        }

        /// <summary>
        /// Present the parameter names passed in using the syntax of the parser.
        /// </summary>
        /// <param name="names">The parameter names</param>
        /// <returns>The formatted parameter names</returns>
        /// <example>
        /// For DOS,  "(first,string),(second,int),(third,date),(a,null)" --> "/first:string,/second:int,/third:date,/a"
        /// For Unix, "first,second,third,a" --> "--first string ,--second int,--third date,-a"
        /// </example>
        public string FormatParameterName(string name, string type, bool isMandatory, bool isPositional)
        {
            var builder = new System.Text.StringBuilder();
            if (!isMandatory)
                builder.Append('[');
            if (isPositional)
                builder.Append('[');
            builder.Append('/').Append(name);
            if (isPositional)
                builder.Append(']');
            if (!string.IsNullOrEmpty(type))
                builder.Append(' ').Append(type);
            if (!isMandatory)
                builder.Append(']');
            return builder.ToString();
        }

        private void PresentCommandHelp(ICommandBinder commandBinder, string[] arguments, bool prefix)
        {
            var helplines = commandBinder.GenerateCommandHelp(this, arguments, prefix);
            foreach (var entry in helplines)
            {
                CLUEnvironment.Console.WriteLine(entry);
            }
        }

        /// <summary>
        /// Normalize command line argument name.
        /// </summary>
        /// <param name="value">The argument name to normailze</param>
        /// <returns>The normalized name</returns>
        private string Normalize(string value)
        {
            //TODO: #13 should we replace dashes with underscores?
            return value.Replace("-", string.Empty);
        }

        /// <summary>
        /// The position indicator.
        /// </summary>
        private uint _positionIndicator = 0;
    }
}
