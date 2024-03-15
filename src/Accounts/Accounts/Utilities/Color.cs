using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public class Foreground
    {
        public static string BrightYellow { get; } = "\x1b[93m";
        public static string BrightBlack { get; } = "\x1b[90m";
        public static string White { get; } = "\x1b[37m";
        public static string Cyan { get; } = "\x1b[36m";

        public static string BoldOff { get; } = "\x1b[22m";

        /// <summary>
        /// Gets value to turn on blink.
        /// </summary>
        public static string Bold { get; } = "\x1b[1m";

    }
}
