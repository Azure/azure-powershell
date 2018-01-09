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

using Microsoft.Azure.Commands.Common.Strategies;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    internal sealed class ShouldProcess : IShouldProcess
    {
        readonly IAsyncCmdlet _Cmdlet;

        public ShouldProcess(IAsyncCmdlet cmdlet)
        {
            _Cmdlet = cmdlet;
        }

        public Task<bool> ShouldCreate<TModel>(ResourceConfig<TModel> config, TModel model)
            where TModel : class
            => _Cmdlet.ShouldProcessAsync(
                config.GetFullName(), VerbsCommon.New);
    }
}
