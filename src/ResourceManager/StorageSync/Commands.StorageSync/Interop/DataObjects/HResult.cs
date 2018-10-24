using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.DataObjects
{
    public static class HResult
    {
        /// <summary>
        /// Determine if HResult is a success code.
        /// Definition as per Essential COM by Don Box page 42
        /// </summary>
        /// <param name="hresult">code to analyze</param>
        public static bool Succeeded(int hresult)
        {
            return (hresult >= 0);
        }

        /// <summary>
        /// Determine if HResult is a failure code.
        /// Definition as per Essential COM by Don Box page 42
        /// </summary>
        /// <param name="hresult">code to analyze</param>
        public static bool Failed(int hresult)
        {
            return (hresult < 0);
        }
    }
}
