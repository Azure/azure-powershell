using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Binder that analyze command discriminators and resolve the Cmdlet.
    ///
    ///    A CLU command literals are listed in the below table.
    ///
    ///    A literal start with capital letter followed by small letters.
    ///    () : The surrounded literals can appear in any order and are optional.
    ///    [] : The surrounded literals needs to appear in the exact order and are required.
    ///
    ///    Literals        Representation
    ///    ------------------------------
    ///     Any             .*
    ///     Space           ^[ ]*$
    ///     Char            ^[a-ZA-Z]$
    ///     Num             ^[0-9]$
    ///     Txt             ^Char(CharNum)*$
    ///     Verb            Txt
    ///     Noun            Txt
    ///     Nouns           ([NounSpace])+
    ///     Discriminators  VerbSpaceNouns
    ///     Argname         Representation depends on the instance of ICommandLineParser
    ///     Argvalue        Any
    ///     Namedarg        ArgnameSpaceArgvalue
    ///     Posarg          Argvalue
    ///     Switcharg       Argname
    ///     Args            (NamedargPosargSwitcharg)*
    ///
    ///    A CLU command has the following format:

    ///    Discriminators Args

    ///    e.g.create vm image  --name sample --size 30GB label --debug
    ///         ==============  ======================================
    ///              |                                  |
    ///         Discriminators                         Args
    ///         ==============                        =====
    ///            |                                     |
    ///     VerbSpaceNouns                    (NamedargPosargSwitcharg)*
    ///     ===============                   =================================================================
    ///      |            |                   |                        |                         |            |
    ///     Verb        Nouns              Namedarg##               Namedarg##                #Posarg#     ##Switcharg
    ///     ====       ========            ==========               ==========                ========     ===========
    ///      |              |                    |                        |                         |             |
    ///   ~create~/Space/([NounSpace])*   [ArgnameSpaceArgvalue]  [ArgnameSpaceArgvalue]           Argvalue     Argname
    ///                   ===========     ======================  ======================           =========   ==========
    ///                     |                       |       |               |           |                 |             |
    ///                 =============             Argname  Argvalue        Argname   Argvalue           ~label~/Space/~--debug~
    ///                 |           |            ========  ========        =======   ==========
    ///                 Noun        Noun            |           |               |             |
    ///                 ====       =====        ~--name~/Space/~sample~/Space/~--size~/Space/~30G~/Space/
    ///                  |          |
    ///                 ~vm~/Space/~image~/Space/
    ///
    /// Cmdlets are indexed using descriminators. See comment section of Microsoft.CLU.Common\CmdletIndex.cs
    /// type for indexing details.
    ///
    /// DiscriminatorBinder is used to identify command discriminators and resolve the Cmdlet that can handle
    /// the command.
    ///
    /// As long as CmdletBinderAndCommand (CBAC) is concerned, discriminators are just positional arguments.
    /// Once the discriminators are identified the following positional arguments are "actual" positional
    /// arguments for the Cmdlet identified by the discriminators.
    ///
    /// CBAC invokes DiscriminatorBinder::BindIfInProgress method for each positional argument it receive from
    /// the command parser. The DiscriminatorBinder (DB) search the index to find a matching Cmdlet using the
    /// positional arguments (would-be descriminators) it received so far.
    ///
    /// A call to DB::BindIfInProgress is NOP once:
    ///
    ///  #1.CBAC invokes DB::EnsureBound, in this case DB mark the last matching Cmdlet as the resolved Cmdlet.
    ///     CBAC invokes DB::EnsureBound when it receives first named/switch argument. If there is no named/switch
    ///     argument then DB::EnsureBound will be invoked when when CBAC reaches end-of-command stream.
    ///
    /// Among the m + n positional arguments that DB received it is possible that there are m discriminators
    /// and n actual positional arguments for the Cmdlet. DB let CBAC know this "offset" (n) through the
    /// _bindFinishedInvoked call-back it invokes when DB::EnsureBound get called.
    ///
    /// e.g. Suppose there is a command "A B C", consider the input "A B C X @file M N --name "ijk", here
    /// discriminators are "A B C", EnsureBound invoked when CBAC encounter --name. The ICommandLineParser current
    /// pointer will be pointing to the 'name' named argument, The offset will be 4 in this case (X, @file, M and N).
    ///
    /// </summary>
    internal class DiscriminatorBinder
    {
        /// <summary>
        /// The modules (packages) that DiscriminatorBinder search for Cmdlet resolution.
        /// </summary>
        public IEnumerable<string> Modules
        {
            get { return _modules; }
        }

        /// <summary>
        /// The LocalPackage instance containing the resolved Cmdlet.
        /// </summary>
        public LocalPackage Package
        {
            get; private set;
        }

        /// <summary>
        /// The discriminators that binder used so far for Cmdlet lookup.
        /// </summary>
        public IEnumerable<string> Discriminators
        {
            get { return _commandDiscriminators; }
        }

        /// <summary>
        /// Creates an instance of DiscriminatorBinder.
        /// </summary>
        /// <param name="modules">The modules to look for the cmdlet</param>
        /// <param name="bindFinishedCallback">Callback to invoke once the binding is finished</param>
        public DiscriminatorBinder(IEnumerable<string> modules, Action<Type, uint, string> bindFinishedCallback)
        {
            Debug.Assert(bindFinishedCallback != null);
            _modules = modules;
            _inProgress = true;
            _bindFinished = bindFinishedCallback;
        }

        /// <summary>
        /// Creates an instance of DiscriminatorBinder which is in resolved state.
        /// </summary>
        /// <param name="modules">The modules to look for the cmdlet</param>
        /// <param name="bindFinishedCallback">Callback to invoke when caller calls EnsureBound method</param>
        /// <param name="cmdletValue">The resolved Cmdlet</param>
        public DiscriminatorBinder(IEnumerable<string> modules, Action<Type, uint, string> bindFinishedCallback, CmdletValue cmdletValue) : this(modules, bindFinishedCallback)
        {
            Debug.Assert(cmdletValue != null);
            Debug.Assert(cmdletValue.Package != null);
            Debug.Assert(cmdletValue.LoadCmdlet() != null);

            _offset = 0;
            _cmdletValue = cmdletValue;
            _commandDiscriminators = cmdletValue.CommandDiscriminators.ToList<string>();
            _inProgress = false;
            Package = cmdletValue.Package;
        }

        /// <summary>
        /// Bind a discriminator argument if binding is progress.
        /// Invoke BindFinished callback if the discriminators are successfully analyzed and
        /// cmdlet resolved successfully.
        /// </summary>
        /// <param name="position">The argument position in the command line</param>
        /// <param name="value">The value of the argument</param>
        public void BindIfInProgress(int position, string value)
        {
            if (!_inProgress)
            {
                if (!_bindFinishedInvoked)
                {
                    // Count positional arguments after @/@@file
                    _offset++;
                }

                return;
            }

            if (!string.IsNullOrEmpty(value) && value.StartsWith(Constants.FileArgumentPrefix))
            {
                _offset++;
                _inProgress = false;
                return;
            }

            _commandDiscriminators.Add(value);
            var cmdletValue = CmdletLocalPackage.FindCmdlet(_modules, _commandDiscriminators);
            if (cmdletValue != null)
            {
                _offset = 0;
                _cmdletValue = cmdletValue;
                Package = cmdletValue.Package;
            }
            else
            {
                _offset++;
            }
        }

        /// <summary>
        /// Ensure the discriminators are bound successfully so that cmdlet is resolved.
        /// Invokes BindFinished callback if not invoked so far.
        /// </summary>
        public void EnsureBound()
        {
            if (_bindFinishedInvoked)
            {
                return;
            }

            if (_cmdletValue == null)
            {
                if (_commandDiscriminators.Count == 0)
                {
                    throw new CommandNotFoundException(Strings.DiscriminatorBinder_EnsureBound_CommandCannotBeResolved);
                }
                else
                {
                    throw new CommandNotFoundException(_commandDiscriminators);
                }
            }

            _inProgress = false;
            _bindFinishedInvoked = true;
            var cmdLetType = _cmdletValue.LoadCmdlet();
            _bindFinished(cmdLetType, _offset, System.IO.Path.Combine(_cmdletValue.Package.FullName, cmdLetType.GetTypeInfo().Assembly.GetName().Name + ".dll"));
        }

        #region Private fields

        /// <summary>
        /// Callback to invoke once the binding is finished.
        /// </summary>
        private Action<Type, uint, string> _bindFinished;

        /// <summary>
        /// Indicates the BindFinished callback is invoked.
        /// </summary>
        private bool _bindFinishedInvoked;

        /// <summary>
        /// True if discriminator analysis is in progress, False if analysis is finished.
        /// </summary>
        private bool _inProgress;

        /// <summary>
        /// The Cmdlet index value
        /// </summary>
        private CmdletValue _cmdletValue;

        /// <summary>
        /// The packages (modules) to look for cmdlet.
        /// Backing field for Modules property.
        /// </summary>
        private IEnumerable<string> _modules;

        /// <summary>
        /// The current command discriminators.
        /// </summary>
        private List<string> _commandDiscriminators = new List<string>();

        /// <summary>
        /// The discriminator count since the last Cmdlet match.
        /// </summary>
        private uint _offset = 0;

        #endregion
    }
}
