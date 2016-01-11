using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CLU;
using Microsoft.CLU.Common;
using Microsoft.CLU.Helpers;

namespace System.Management.Automation
{
    public abstract class Cmdlet
    {
        protected Cmdlet()
        {
        }

        internal protected ICommandRuntime CommandRuntime { get; set; }

        internal protected bool Stopping { get; private set; }

        protected virtual string GetResourceString(string baseName, string resourceId) { return null; }

        protected bool ShouldContinue(string query, string caption)
        {
            return CommandRuntime.ShouldContinue(query, caption);
        }

        protected bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            return CommandRuntime.ShouldContinue(query, caption, ref yesToAll, ref noToAll);
        }
        protected bool ShouldProcess(string target)
        {
            return CommandRuntime.ShouldProcess(target);
        }

        protected bool ShouldProcess(string target, string action)
        {
            return CommandRuntime.ShouldProcess(target, action);
        }

        protected bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            return CommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption);
        }

        protected bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            return CommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption, out shouldProcessReason);
        }

        protected void ThrowTerminatingError(ErrorRecord errorRecord) { CommandRuntime.ThrowTerminatingError(errorRecord); }

        protected void WriteCommandDetail(string text)	{ if (!string.IsNullOrEmpty(text)) CommandRuntime.WriteCommandDetail(text); }

        protected void WriteDebug(string text)
        {
            if (!string.IsNullOrEmpty(text)) CommandRuntime.WriteDebug(text);
        }

        protected void WriteError(ErrorRecord errorRecord) { if (errorRecord != null) CommandRuntime.WriteError(errorRecord); }

        protected void WriteObject(object sendToPipeline)
        {
            if (sendToPipeline != null)
            {
                if (ShouldWriteJsonOutput())
                { 
                    CommandRuntime.WriteObject(sendToPipeline);
                }
                else
                {
                    _written.Add(sendToPipeline);
                }
            }
        }

        protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            if (sendToPipeline != null)
            {
                if (ShouldWriteJsonOutput())
                {
                    CommandRuntime.WriteObject(sendToPipeline, enumerateCollection);
                }
                else
                {
                    if (sendToPipeline is IEnumerable)
                    {
                        foreach (var obj in sendToPipeline as IEnumerable)
                        {
                            _written.Add(obj);
                        }
                    }
                    else
                    {
                        _written.Add(sendToPipeline);
                    }
                }
            }
        }

        /// <summary>
        /// When output is going to the console, not to a file or pipe, flush all objects that have been written.
        /// </summary>
        /// <param name="package"></param>
        internal void FlushPipeline(LocalPackage package)
        {
            bool wroteHeader = false;

            FormatReader.ViewDescriptor view = null;
            Type formattedType = null;

            foreach (var obj in _written)
            {
                PrimitiveTypeCode code = PrimitiveTypeCode.None;

                if (obj.GetType().IsPrimitive(out code))
                {
                    CommandRuntime.WriteObject(obj);
                    continue;
                }

                if (view == null)
                {
                    view = FormatReader.ReadFormatFile(package, this.GetType().GetTypeInfo().Assembly.GetName().Name, obj.GetType());
                    wroteHeader = false;
                }
                else if (formattedType != obj.GetType())
                {
                    var viewName = view.ViewName;
                    view = FormatReader.ReadFormatFile(package, this.GetType().GetTypeInfo().Assembly.GetName().Name, obj.GetType());
                    wroteHeader = view != null && view.ViewName.Equals(viewName);
                }

                if (view == null)
                {
                    formattedType = null;
                    CommandRuntime.WriteObject(obj);
                }
                else
                {
                    formattedType = obj.GetType();
                    if (!wroteHeader)
                    {
                        CommandRuntime.WriteObject(view.FormatHeader(CLUEnvironment.Console.WindowWidth));
                        CommandRuntime.WriteObject("");
                        wroteHeader = true;
                    }
                    CommandRuntime.WriteObject(view.FormatObject(obj));
                }
            }
        }

        internal bool ShouldWriteJsonOutput()
        {
            var requestedOutputFormat = CommandRuntime.Host.RequestedOutputFormat;
            return (CommandRuntime.Host.IsOutputRedirected && requestedOutputFormat == OutputFormat.Auto) 
                || requestedOutputFormat == OutputFormat.JSON;
        }
        protected void WriteProgress(ProgressRecord progressRecord) { if (progressRecord != null) CommandRuntime.WriteProgress(progressRecord); }

        protected void WriteVerbose(string text) { if (!string.IsNullOrEmpty(text)) CommandRuntime.WriteVerbose(text);  }

        protected void WriteWarning(string text) { if (!string.IsNullOrEmpty(text)) CommandRuntime.WriteWarning(text); }

        internal protected virtual void BeginProcessing() {  }

        internal protected virtual void EndProcessing() {  }

        internal protected virtual void ProcessRecord() {  }

        internal protected virtual void StopProcessing() { Stopping = true; }

        private List<object> _written = new List<object>();
    }
}
