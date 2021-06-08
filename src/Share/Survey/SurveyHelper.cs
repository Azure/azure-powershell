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

using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Share.Survey
{
    using Condition = Func<SurveyHelper, string, int, bool>;
    using UpdateModule = Action<SurveyHelper, string, int>;

    public class SurveyHelper
    {
        private const int _countExpiredDays = 30;
        private const int _lockExpiredDays = 30;
        private const int _surveyTriggerCount = 3;
        private const int _flushFrequecy = 5;
        private const int _delayForSecondPrompt = 2;
        private const int _delayForThirdPrompt = 5;

        private static SurveyHelper _instance;

        private int _flushCount;

        private static string SurveyScheduleInfoFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".Azure", "AzureRmSurvey.json");

        private const string _azurePSInterceptSurvey = "Azure_PS_Intercept_Survey";

        private const string _predictor = "Az.Predictor";

        private DateTime LastPromptDate { get; set; }

        private ConcurrentDictionary<string, ModuleInfo> Modules { get; }

        private bool _ignoreSchedule;

        private bool IsDisabledFromEnv => "Disabled".Equals(Environment.GetEnvironmentVariable(_azurePSInterceptSurvey), StringComparison.OrdinalIgnoreCase)
                                        || "False".Equals(Environment.GetEnvironmentVariable(_azurePSInterceptSurvey), StringComparison.OrdinalIgnoreCase);

        public string CurrentDate { get; }

        public DateTime Today { get; }

        private SurveyHelper()
        {
            CurrentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            Today = Convert.ToDateTime(CurrentDate);
            _ignoreSchedule = false;
            LastPromptDate = DateTime.MinValue;
            Modules = new ConcurrentDictionary<string, ModuleInfo>();
            Interlocked.Exchange(ref _flushCount, 0);
        }

        public static SurveyHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SurveyHelper();
            }
            return _instance;
        }

        public bool ShouldPropmtSurvey(string moduleName, Version moduleVersion)
        {
            if (_ignoreSchedule || IsDisabledFromEnv)
            {
                return false;
            }

            int majorVersion = moduleVersion.Major;

            if (Modules.Count == 0)
            {
                ReadFromStream();
            }

            if (ShouldFlush(moduleName, majorVersion, ShouldModuleAdd, ModuleAdd))
            {
                FlushWithWaitAsync();
                return false;
            }

            //LastPromptDate.CompareTo(DateTime.MinValue) > 0 means survey is locked, otherwise lock free
            if (LastPromptDate > DateTime.MinValue && Today > LastPromptDate.AddDays(_lockExpiredDays))
            {
                LastPromptDate = DateTime.MinValue;
            }

            if (ShouldFlush(moduleName, majorVersion, ShouldAzPredictorPrompt, AzPredictorPrompt) 
                || ShouldFlush(moduleName, majorVersion, ShouldModulePrompt, ModulePrompt))
            {
                FlushAsync();
                return true;
            }

            if ((ShouldFlush(moduleName, majorVersion, ShouldModuleBumpVersion, ModuleBumpVersion)
                || ShouldFlush(moduleName, majorVersion, ShouldModuleCount, ModuleCount)
                || ShouldFlush(moduleName, majorVersion, ShouldModuleCountExpire, ModuleCountExpire)
                || ShouldFlush(moduleName, majorVersion, ShouldModulePromptExpire, ModulePromptExpire)))
            {
                FlushWithWaitAsync();
            }
            return false;
        }

        private bool ShouldFlush(string moduleName, int majorVersion, Condition condition, UpdateModule updateModule = null)
        {
            if (condition.Invoke(this, moduleName, majorVersion) && ReadFromStream() && condition.Invoke(this, moduleName, majorVersion))
            {
                updateModule?.Invoke(this, moduleName, majorVersion);
                return true;
            }
            return false;
        }

        private bool ShouldModuleAdd(SurveyHelper helper, string moduleName, int majorVersion) => !helper.Modules.ContainsKey(moduleName);

        private void ModuleAdd(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName] = new ModuleInfo()
            {
                Name = moduleName,
                MajorVersion = majorVersion,
                ActiveDays = 1,
                FirstActiveDate = CurrentDate,
                LastActiveDate = CurrentDate,
                Enabled = true
            };
        }

        private bool ShouldModuleBumpVersion(SurveyHelper helper, string moduleName, int majorVersion) 
            => majorVersion > helper.Modules[moduleName].MajorVersion;

        private void ModuleBumpVersion(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName].MajorVersion = majorVersion;
            helper.Modules[moduleName].FirstActiveDate = CurrentDate;
            helper.Modules[moduleName].LastActiveDate = CurrentDate;
            helper.Modules[moduleName].ActiveDays = 1;
        }

        private bool ShouldModuleCount(SurveyHelper helper, string moduleName, int majorVersion) 
            => helper.Modules[moduleName].MajorVersion == majorVersion 
            && helper.Modules[moduleName].ActiveDays < _surveyTriggerCount 
            && helper.Today > Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate)
            && helper.Today <= Convert.ToDateTime(helper.Modules[moduleName].FirstActiveDate).AddDays(_countExpiredDays);

        private void ModuleCount(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName].ActiveDays += 1;
            helper.Modules[moduleName].LastActiveDate = CurrentDate;
        }

        private bool ShouldModuleCountExpire(SurveyHelper helper, string moduleName, int majorVersion)
            => helper.Modules[moduleName].MajorVersion == majorVersion
            && helper.Modules[moduleName].ActiveDays < _surveyTriggerCount
            && helper.Today > Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate)
            && helper.Today > Convert.ToDateTime(helper.Modules[moduleName].FirstActiveDate).AddDays(_countExpiredDays);

        private void ModuleCountExpire(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName].FirstActiveDate = CurrentDate;
            helper.Modules[moduleName].LastActiveDate = CurrentDate;
            helper.Modules[moduleName].ActiveDays = 1;
        }

        private bool ShouldModulePrompt(SurveyHelper helper, string moduleName, int majorVersion)
            => helper.Modules[moduleName].MajorVersion == majorVersion
            && ((helper.Modules[moduleName].ActiveDays == _surveyTriggerCount && helper.LastPromptDate == DateTime.MinValue)
                 || helper.Modules[moduleName].ActiveDays == _surveyTriggerCount + 1 && helper.LastPromptDate == Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate) && helper.Today == helper.LastPromptDate.AddDays(_delayForSecondPrompt)
                 || helper.Modules[moduleName].ActiveDays == _surveyTriggerCount + 2 && helper.LastPromptDate == Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate) && helper.Today == helper.LastPromptDate.AddDays(_delayForThirdPrompt));

        private void ModulePrompt(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.LastPromptDate = Today;
            helper.Modules[moduleName].LastActiveDate = CurrentDate;
            helper.Modules[moduleName].ActiveDays += 1;
        }

        private bool ShouldAzPredictorPrompt(SurveyHelper helper, string moduleName, int majorVersion)
            => _predictor.Equals(moduleName, StringComparison.OrdinalIgnoreCase)
            && helper.Modules[moduleName].MajorVersion == majorVersion
            && ((helper.Modules[moduleName].ActiveDays == _surveyTriggerCount && helper.Today <= Convert.ToDateTime(helper.Modules[moduleName].FirstActiveDate).AddDays(_countExpiredDays))
                 || helper.Modules[moduleName].ActiveDays == _surveyTriggerCount + 1 && helper.Today == Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate).AddDays(_delayForSecondPrompt)
                 || helper.Modules[moduleName].ActiveDays == _surveyTriggerCount + 2 && helper.Today == Convert.ToDateTime(helper.Modules[moduleName].LastActiveDate).AddDays(_delayForThirdPrompt));

        private void AzPredictorPrompt(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName].LastActiveDate = CurrentDate;
            helper.Modules[moduleName].ActiveDays += 1;
        }

        private bool ShouldModulePromptExpire(SurveyHelper helper, string moduleName, int majorVersion)
            => helper.Modules[moduleName].MajorVersion == majorVersion
            && (Modules[moduleName].ActiveDays == _surveyTriggerCount + 1 && helper.LastPromptDate == Convert.ToDateTime(Modules[moduleName].LastActiveDate) && helper.Today > helper.LastPromptDate.AddDays(_delayForSecondPrompt)
                || Modules[moduleName].ActiveDays == _surveyTriggerCount + 2 && helper.LastPromptDate == Convert.ToDateTime(Modules[moduleName].LastActiveDate) && helper.Today > LastPromptDate.AddDays(_delayForThirdPrompt));

        private void ModulePromptExpire(SurveyHelper helper, string moduleName, int majorVersion)
        {
            helper.Modules[moduleName].ActiveDays = 0;
        }

        private void MergeScheduleInfo(ScheduleInfo externalScheduleInfo)
        {
            DateTime externalLastPromptDate = Convert.ToDateTime(externalScheduleInfo?.LastPromptDate);
            IDictionary<string, ModuleInfo> externalModules = new Dictionary<string, ModuleInfo>();
            foreach(ModuleInfo info in externalScheduleInfo?.Modules)
            {
                externalModules[info.Name] = info;
            }

            HashSet<string> moduleNames = new HashSet<string>(Modules.Keys);
            moduleNames.UnionWith(new HashSet<string>(externalModules.Keys));

            foreach (string name in moduleNames)
            {
                if (externalModules.ContainsKey(name) && (!Modules.ContainsKey(name) || Convert.ToDateTime(Modules[name].LastActiveDate) < Convert.ToDateTime(externalModules[name].LastActiveDate)))
                {
                    if (externalLastPromptDate != DateTime.MinValue && Convert.ToDateTime(externalModules[name].LastActiveDate) == externalLastPromptDate)
                    {
                        LastPromptDate = externalLastPromptDate;
                    }
                    Modules[name] = new ModuleInfo(externalModules[name]);
                }
            }
        }

        private ScheduleInfo GetScheduleInfo()
        { 
            return new ScheduleInfo() { LastPromptDate = LastPromptDate.ToString("yyyy-MM-dd"), Modules = Modules.Values.ToList() };
        }

        private bool ReadFromStream()
        {
            StreamReader sr = null;
            try
            {
                if (File.Exists(SurveyScheduleInfoFile))
                {
                    sr = new StreamReader(new FileStream(SurveyScheduleInfoFile, FileMode.Open, FileAccess.Read, FileShare.None));                    
                    MergeScheduleInfo(JsonConvert.DeserializeObject<ScheduleInfo>(sr.ReadToEnd()));
                }
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {
                    _ignoreSchedule = true;
                }
                //deserialize failed, means content of file is incorrect, make file empty
                if (e is JsonException)
                {
                    if (sr != null)
                    {
                        sr.Dispose();
                    }
                    EmptyFileAsync();
                }
                return false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
            return true;
        }

        private bool WriteToStream(string info)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(new FileStream(SurveyScheduleInfoFile, FileMode.Create, FileAccess.Write, FileShare.None));
                sw.Write(info);
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {
                    _ignoreSchedule = true;
                }
                return false;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                }
            }
            return true;
        }

        private async void FlushAsync()
        {
            await Task.Run(() =>
            {
                WriteToStream(JsonConvert.SerializeObject(GetScheduleInfo()));
            });
        }

        private async void EmptyFileAsync()
        {
            await Task.Run(() =>
            {
                WriteToStream(string.Empty);
            });
        }

        private async void FlushWithWaitAsync()
        {
            await Task.Run(() =>
            {
                FlushWithWait();
            });
        }

        private void FlushWithWait()
        {
            int beforeExchange = Interlocked.CompareExchange(ref _flushCount, 0, _flushFrequecy);
            if (beforeExchange < _flushFrequecy)
            {
                Interlocked.Increment(ref _flushCount);
            }
            else if (beforeExchange > _flushFrequecy)
            {
                Interlocked.Exchange(ref _flushCount, 0);
            }
            else
            {
                if (!WriteToStream(JsonConvert.SerializeObject(GetScheduleInfo())))
                {
                    Interlocked.Exchange(ref _flushCount, beforeExchange);
                }
            }
        }
    }
}
