// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Management.Automation;
    using Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models;

    internal static class CmdletRestExtension
    {
        public static void writeError(this Cmdlet cmdlet, HttpResponseMessage responseMessage, Task<IErrorResponse> errorResponseTask, ref Task<bool> returnNow)
        {
            string code;
            string message;
            if (!TryCreateDetailedErrorMessage(errorResponseTask, out code, out message))
            {
                return;
            }

            cmdlet.WriteError(new ErrorRecord(new System.Exception(message), code, ErrorCategory.InvalidOperation, new { })
            {
                ErrorDetails = new ErrorDetails(message) { RecommendedAction = string.Empty }
            });
            returnNow = Task.FromResult(true);
        }

        internal static bool TryCreateDetailedErrorMessage(Task<IErrorResponse> errorResponseTask, out string code, out string message)
        {
            code = null;
            message = null;

            IErrorResponse error;
            try
            {
                error = errorResponseTask.ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                return false;
            }

            if (error == null || error.Detail == null || error.Detail.Count == 0 || string.IsNullOrEmpty(error.Code) || string.IsNullOrEmpty(error.Message))
            {
                return false;
            }

            code = error.Code;
            message = FormatErrorWithDetails(error);
            return true;
        }

        private static string FormatErrorWithDetails(IErrorResponse error)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("[{0}] : {1}", error.Code, error.Message);
            AppendDetails(builder, error.Detail, 0, 5);
            return builder.ToString();
        }

        private static void AppendDetails(StringBuilder builder, IList<IErrorDetail> details, int depth, int maxDepth)
        {
            if (details == null || details.Count == 0 || depth >= maxDepth)
            {
                return;
            }

            var indent = new string(' ', (depth * 2) + 2);
            foreach (var detail in details)
            {
                if (detail == null)
                {
                    continue;
                }

                builder.AppendLine();
                builder.Append(indent).Append("- ");
                if (!string.IsNullOrEmpty(detail.Target))
                {
                    builder.AppendFormat("Target: {0}; ", detail.Target);
                }
                if (!string.IsNullOrEmpty(detail.Code))
                {
                    builder.AppendFormat("Code: {0}; ", detail.Code);
                }
                builder.AppendFormat("Message: {0}", detail.Message ?? string.Empty);
                AppendDetails(builder, detail.Detail, depth + 1, maxDepth);
            }
        }
    }
}
