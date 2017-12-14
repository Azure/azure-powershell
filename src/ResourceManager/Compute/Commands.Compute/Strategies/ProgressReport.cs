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
using System.Collections.Concurrent;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    sealed class ProgressReport : IProgressReport
    {
        readonly IAsyncCmdlet _Cmdlet;

        double _Completed = 0;

        ConcurrentDictionary<IResourceConfig, Void> _Set =
            new ConcurrentDictionary<IResourceConfig, Void>(); 

        public ProgressReport(IAsyncCmdlet cmdlet)
        {
            _Cmdlet = cmdlet;
        }

        public void Done<TModel>(ResourceConfig<TModel> config, double progress) where TModel : class
        {
            _Completed += progress;
            Void _;
            _Set.TryRemove(config, out _);
            _Cmdlet.WriteVerbose(config.Name + " " + config.Strategy.Type);
            Update();
        }

        public void Update()
        {
            var x = string.Join(", ", _Set.Keys.Select(c => "'" + c.Name + "' " + c.Strategy.Type));
            var p = (int)(_Completed * 100.0);
            _Cmdlet.WriteProgress(
                new ProgressRecord(
                    0,
                    "Creating Azure resources",
                    p + "%")
                {
                    PercentComplete = p,
                    CurrentOperation = x == string.Empty ? null : "Creating " + x + "."
                });
        }

        public void Start<TModel>(ResourceConfig<TModel> config) where TModel : class
        {
            _Set.TryAdd(config, new Void());
            _Cmdlet.WriteVerbose("Creating '" + config.Name + "' " + config.Strategy.Type + "...");
            Update();
        }
    }
}
