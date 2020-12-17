using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// A command predicted by the predictor service.
    /// </summary>
    public class PredictiveCommand
    {
        /// <summary>
        /// The command name.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// The description of the command.
        /// </summary>
        public string Description { get; set; }
    }
}
