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
        public IList<Tuple<Ast, Ast>> Parameters { get; set; }

        public ParameterSet(CommandAst commandAst)
        {
            Parameters = new List<Tuple<Ast, Ast>>();
            var elements = commandAst.CommandElements.Skip(1);
            Ast param = null;
            Ast arg = null;
            foreach (Ast elem in elements)
            {
                if (elem is CommandParameterAst)
                {
                    if (param != null)
                    {
                        Parameters.Add(new Tuple<Ast, Ast>(param, arg));
                    }
                    param = elem;
                    arg = null;
                }
                else
                {
                    arg = elem;
                }
            }

            if (param != null)
            {
                Parameters.Add(new Tuple<Ast, Ast>(param, arg));
            }
        }
    }
}
