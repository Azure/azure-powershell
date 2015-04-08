// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    /// <summary>
    /// Migration plan to be returned
    /// </summary>
    public class MigrationModelCommon
    {
        /// <summary>
        /// Converts HcsMessageInfoToString to a displayable string
        /// </summary>
        /// <param name="msgInfo">msg info o/p</param>
        /// <returns>display string</returns>
        internal string HcsMessageInfoToString(HcsMessageInfo msgInfo)
        {
            StringBuilder consoleOp = new StringBuilder();
            if (null != msgInfo)
            {
                int maxLength = msgInfo.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                if (!string.IsNullOrEmpty(msgInfo.Message) ||
                    !string.IsNullOrEmpty(msgInfo.Recommendation))
                {
                    if (0 != msgInfo.ErrorCode)
                    {
                        consoleOp.AppendLine(IntendAndConCat("ErrorCode", msgInfo.ErrorCode, maxLength));
                    }

                    if (!string.IsNullOrEmpty(msgInfo.Message))
                    {
                        consoleOp.AppendLine(IntendAndConCat("Message", msgInfo.Message, maxLength));
                    }

                    if (!string.IsNullOrEmpty(msgInfo.Recommendation))
                    {
                        consoleOp.AppendLine(IntendAndConCat("Recommendation", msgInfo.Recommendation, maxLength));
                    }                
                }
            }

            return consoleOp.ToString();
        }

        internal string IntendAndConCat(string prefix, object suffix, int maxLength = -1, string delimiter = null)
        {
            maxLength = (-1 == maxLength) ? this.GetType().GetProperties().ToList().Max(t => t.Name.Length) : maxLength;
            delimiter = !(string.IsNullOrEmpty(delimiter)) ? delimiter : " : ";
            var intendedOp = new StringBuilder();
            intendedOp.Append(prefix);
            if (0 < maxLength - prefix.Length)
            {
                intendedOp.Append(' ', maxLength - prefix.Length);
            }

            intendedOp.Append(delimiter);
            intendedOp.Append(suffix);
            return intendedOp.ToString();
        }

        internal string ConcatStringList(List<string> stringList, string delimiter = null)
        {
            string concatedStr = string.Empty;
            delimiter = !(string.IsNullOrEmpty(delimiter)) ? delimiter : ", ";
            if (null != stringList && 0 < stringList.Count)
            {                
                foreach (string ipString in stringList)
                {
                    if (!string.IsNullOrEmpty(concatedStr))
                    {
                        concatedStr = string.Format("{0}{1}{2}", concatedStr, delimiter, ipString);
                    }
                    else
                    {
                        concatedStr = ipString;
                    }
                }
            }

            return concatedStr;
        }
    }
}