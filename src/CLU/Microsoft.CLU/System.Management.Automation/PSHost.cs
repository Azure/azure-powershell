using System.Globalization;

namespace System.Management.Automation.Host
{
    public abstract class PSHost
    {
        protected PSHost() { }

        public abstract CultureInfo CurrentCulture { get; }
        public abstract CultureInfo CurrentUICulture { get; }
        public abstract Guid InstanceId { get; }
        public abstract string Name { get; }
        public abstract PSHostUserInterface UI { get; }
        public abstract Version Version { get; }
        public abstract bool IsInputRedirected { get; }
        public abstract bool IsOutputRedirected { get; }
        public abstract Microsoft.CLU.OutputFormat RequestedOutputFormat { get; set; }
    }
}
