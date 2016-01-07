using Microsoft.CLU.Metadata;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace System.Management.Automation
{
    public class CmdletInfo : CommandInfo
    {
        internal CmdletInfo(Type cmdlet, PSModuleInfo module, ICommandRuntime runtime, string nounPrefix = null)
        {
            var attrs = cmdlet.GetTypeInfo().GetCustomAttributes(typeof(CmdletAttribute), false);
            var info = attrs.FirstOrDefault() as CmdletAttribute;

            if (!string.IsNullOrEmpty(nounPrefix) && info.NounName.ToLowerInvariant().StartsWith(nounPrefix))
                this.Noun = info.NounName.Substring(nounPrefix.Length);
            else
                this.Noun = info.NounName;
            this.Verb = info.VerbName;
            if (!string.IsNullOrEmpty(info.DefaultParameterSetName))
                this._defaultParameterSet = info.DefaultParameterSetName;
            this.Name = $"{info.VerbName}-{info.NounName}".ToLowerInvariant();
            this.Module = module;

            this._outputTypes = new ReadOnlyCollection<PSTypeName>(
                cmdlet.GetTypeInfo().GetCustomAttributes(typeof(OutputTypeAttribute), true)
                .Select(a => a as OutputTypeAttribute)
                .SelectMany(ot => ot.Type).ToList());

            _typeMetadata = new TypeMetadata(cmdlet);
            _typeMetadata.Load();
        }

        public string Noun
        {
            get; private set;
        }

        public string Verb
        {
            get; private set;
        }

        public override Dictionary<string, ParameterMetadata> Parameters
        {
            get
            {
                return _typeMetadata.Parameters;
            }
        }
        public override ReadOnlyCollection<PSTypeName> OutputType
        {
            get
            {
                return _outputTypes;
            }
        }

        public string DefaultParameterSet
        {
            get
            {
                return _defaultParameterSet;
            }
        }
        private string _defaultParameterSet;

        public string HelpFile
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private TypeMetadata _typeMetadata;
        private ReadOnlyCollection<PSTypeName> _outputTypes;
    }
}
