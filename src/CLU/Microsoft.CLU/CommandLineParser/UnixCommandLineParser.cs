﻿using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU.CommandLineParser
{
    /// <summary>
    /// Implementation of ICommandLineParser interface that can parse Unix style commandline arguments.
    ///  In Unix style:
    /// 1. The name of the commandline argument start with -- (e.g. --name). 
    /// 2. There can be dashes within the argument name (e.g. --vm-name),
    ///    parser will normalize such name by replacing dash with empty char
    ///    (e.g. --vm-name will be normalized to --vmname).
    /// 3. Value of an argument follows argument name (--region westus).
    /// 4. If a value is not preceeded by argument name then it will be considered
    ///    as positional value.
    /// When parser identifies a named argument it invokes ICommandBinder::TryBindSwitch(name::string),
    /// binder returns true if it identifies the named argument as a switch, if binder returns false 
    /// then the parser invokes ICommandBinder::BindNamedArgument(name:string, value:string) with the 
    /// same named argument and value following the named argument (if any).
    /// For non-named argument, parser invokes ICommandBinder::BindArgument(position::int, value::string).
    /// 
    /// </summary>
    internal class UnixCommandLineParser : ICommandLineParser
    {
        /// <summary>
        /// Parse the arguments based on Unix specific syntax and invoke appropriate ICommandBinder
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
                var arg = arguments[_positionIndicator];

                if (arg.StartsWith("-"))
                {
                    if (arg.StartsWith("--"))
                    {
                        if (commandBinder.SupportsAutomaticHelp && arg.Equals("--help", System.StringComparison.OrdinalIgnoreCase))
                        {
                            PresentCommandHelp(commandBinder, arguments.Take(position).ToArray(), false);
                            return false;
                        }

                        if (arg.Length > 3)
                        {
                            string name = Normalize(arg.Substring(2).ToLowerInvariant());
                            if (!commandBinder.TryBindSwitch(name))
                            {
                                var nextArgument = _positionIndicator < arguments.Length - 1 ? arguments[_positionIndicator + 1] : null;
                                if (nextArgument != null && !nextArgument.StartsWith("--"))
                                {
                                    commandBinder.BindArgument(name, nextArgument);
                                    _positionIndicator++;
                                }
                                else
                                {
                                    commandBinder.BindArgument(name, null);
                                }
                            }
                        }
                        else
                        {
                            throw new System.Management.Automation.ParseException(string.Format(Strings.UnixCommandLineParser_Parse_UnknownArgumentName, arg.Substring(2)));
                        }
                    }
                    else
                    {
                        if (arg.Length > 2)
                        {
                            var name = arg.Substring(1);

                            // This is something like -abc, which means that all must be switches
                            foreach (var swtch in name)
                            {
                                var argName = new string(new char[] { swtch });
                                if (!commandBinder.TryBindSwitch(argName))
                                {
                                    // Call bind just in order to produce an error message.
                                    throw new System.Management.Automation.ParseException(string.Format(Strings.UnixCommandLineParser_Parse_UnknownArgumentCombination, name));
                                }
                            }
                        }
                        else
                        {
                            // A single character. Try binding as a switch first. Single-char arguments are case-sensitive.
                            var name = arg.Substring(1);
                            if (!commandBinder.TryBindSwitch(name))
                            {
                                var nextArgument = _positionIndicator < arguments.Length - 1 ? arguments[_positionIndicator + 1] : null;
                                if (nextArgument != null && !nextArgument.StartsWith("--") && !nextArgument.StartsWith("-"))
                                {
                                    commandBinder.BindArgument(name, nextArgument);
                                    _positionIndicator++;
                                }
                                else
                                {
                                    commandBinder.BindArgument(name, null);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (position == 0 && 
                        commandBinder.SupportsAutomaticHelp && 
                        arg.Equals("help", System.StringComparison.OrdinalIgnoreCase))
                    {
                        PresentCommandHelp(commandBinder, arguments.Skip(position + 1).ToArray(), true);
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
            Func<string,string> nameFunc = n => n.Length == 1 ? "-" + n : "--" + n.ToLowerInvariant();

            var builder = new System.Text.StringBuilder();
            if (!isMandatory)
                builder.Append('[');
            if (isPositional)
                builder.Append('[');
            builder.Append(nameFunc(name));
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
        /// The position of the current argument under process.
        /// </summary>
        private uint _positionIndicator = 0;
    }
}
