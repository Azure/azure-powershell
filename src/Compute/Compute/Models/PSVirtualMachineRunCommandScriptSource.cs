using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineRunCommandScriptSource: PSOperation
    {
        public string Script { get; set; }
        //
        // Summary:
        //     Gets or sets specifies the script download location.
        public string ScriptUri { get; set; }
        //
        // Summary:
        //     Gets or sets specifies a commandId of predefined built-in script.
        public string CommandId { get; set; }
    }
}
