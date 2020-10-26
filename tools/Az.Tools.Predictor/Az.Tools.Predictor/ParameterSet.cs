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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Treating parameter lists as sets of parameters to show that parameter order
    /// does not matter to resulting prediction - the prediction should adapt to the
    /// order of the parameters typed by the user.
    /// </summary>
    sealed class ParameterSet
    {
        public IList<Tuple<string, string>> Parameters { get; }

        public ParameterSet(CommandAst commandAst)
        {
            Parameters = new List<Tuple<string, string>>();
            var elements = commandAst.CommandElements.Skip(1);
            Ast param = null;
            Ast arg = null;
            foreach (Ast elem in elements)
            {
                if (elem is CommandParameterAst)
                {
                    if (param != null)
                    {
                        Parameters.Add(new Tuple<string, string>(param.ToString(), arg?.ToString()));
                    }
                    param = elem;
                    arg = null;
                }
                else if (AzPredictorConstants.ParameterIndicator == elem?.ToString().Trim().FirstOrDefault())
                {
                    // We have an incomplete command line such as
                    // `New-AzResourceGroup -Name ResourceGroup01 -Location WestUS -`
                    // We'll ignore the incomplete parameter.
                    if (param != null)
                    {
                        Parameters.Add(new Tuple<string, string>(param.ToString(), arg?.ToString()));
                    }

                    param = null;
                    arg = null;
                }
                else
                {
                    arg = elem;
                }
            }

            if (param != null)
            {
                Parameters.Add(new Tuple<string, string>(param.ToString(), arg?.ToString()));
            }
        }
    }
}
