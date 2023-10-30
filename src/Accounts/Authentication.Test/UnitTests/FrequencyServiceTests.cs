using System;
using Xunit;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Authentication.Test.UnitTests
{
    class MockClock : IClock
    {
        public DateTime fakeNow { get; set; }
        public bool IsDue(DateTime lastCheckTime, TimeSpan freq)
        {
            return fakeNow - lastCheckTime >= freq;
        }
        public void AddSecond(int sec)
        {
            fakeNow = fakeNow.AddSeconds(sec);
        }
    }

    public class FrequencyServiceTests
    {
        private FrequencyService _frequencyService;

        public FrequencyServiceTests()
        {
            _frequencyService = new FrequencyService(new MemoryDataStore(), new Clock());
        }

        [Fact]
        public void TestAdd()
        {
            // Arrange
            string featureName = "TestFeature";
            TimeSpan frequency = new TimeSpan(0, 0, 5); // 5 seconds

            // Act
            _frequencyService.Register(featureName, frequency);

            // Assert
            var frequencyInfo = new FrequencyService.FrequencyInfo(frequency, DateTime.Now);
            Assert.NotNull(frequencyInfo);
            Assert.Equal(frequency, frequencyInfo.Frequency);
        }

        [Fact]
        public void TestAddSession()
        {
            string featureName = "testFeature";
            _frequencyService.RegisterInSession(featureName);

            Assert.True(_frequencyService.SessionLogic.ContainsKey(featureName));
            Assert.False(_frequencyService.SessionLogic[featureName]);
        }

        [Fact]
        public void TestCheck_SessionLogic()
        {
            string featureName = "testFeature";
            _frequencyService.RegisterInSession(featureName);

            bool businessCheck = true;
            bool businessCalled = false;
            _frequencyService.TryRun(featureName, () => businessCheck, () => businessCalled = true);

            Assert.True(businessCalled);
            Assert.True(_frequencyService.SessionLogic[featureName]);
        }

        [Fact]
        public void TestCheck_Frequencies()
        {
            string featureName = "testFeature";
            TimeSpan frequency = new TimeSpan(0, 0, 1);
            _frequencyService.Register(featureName, frequency);

            bool businessCheck = true;
            bool businessCalled = false;
            _frequencyService.TryRun(featureName, () => businessCheck, () => businessCalled = true);

            Assert.True(businessCalled);
        }

        [Fact]
        public void AddsFeatureToFrequencyService()
        {
            // Arrange
            var featureName = "MyFeature";
            var frequency = TimeSpan.FromMinutes(5);

            // Act
            _frequencyService.Register(featureName, frequency);

            // Assert
            Assert.NotNull(_frequencyService);
            Assert.NotNull(_frequencyService.GetAllFeatureNames());
            Assert.Contains(featureName, _frequencyService.GetAllFeatureNames());
        }

        [Fact]
        public void DoesNotAddDuplicateToFrequencyService()
        {
            // Arrange
            var featureName = "MyFeature1";
            var frequency = TimeSpan.FromMinutes(5);

            // Act
            _frequencyService.Register(featureName, frequency);
            _frequencyService.Register(featureName, frequency);

            // Assert
            Assert.Equal(1, _frequencyService.GetAllFeatureNames().Count(n => n == featureName));
        }

        [Fact]
        public void AddsSessionFeatureToFrequencyService()
        {
            // Arrange
            var featureName = "MySessionFeature";

            // Act
            _frequencyService.RegisterInSession(featureName);

            // Assert
            Assert.Contains(featureName, _frequencyService.GetAllFeatureNames());
        }

        [Fact]
        public void DoesNotAddDuplicateSessionToFrequencyService()
        {
            // Arrange
            var frequencyService = new FrequencyService(new MemoryDataStore(), new Clock());
            var featureName = "MySessionFeature";

            // Act
            frequencyService.RegisterInSession(featureName);
            frequencyService.RegisterInSession(featureName);

            // Assert
            Assert.Equal(1, frequencyService.GetAllFeatureNames().Count(n => n == featureName));
        }

        [Fact]
        public void Check_FrequencyMet_ExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService(new MemoryDataStore(), new Clock());
            var featureName = "MyFeature2";
            var frequency = TimeSpan.FromMinutes(5);
            var businessLogicExecuted = false;
            frequencyService.Register(featureName, frequency);

            // Act
            frequencyService.TryRun(featureName, () => true, () => businessLogicExecuted = true);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_FrequencyNotMet_DoesNotExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService(new MemoryDataStore());
            var featureName = "MyFeature3";
            var frequency = TimeSpan.FromMinutes(5);
            var businessLogicExecuted = false;
            frequencyService.Register(featureName, frequency);

            // Act
            frequencyService.TryRun(featureName, () => false, () => businessLogicExecuted = true);

            // Assert
            Assert.False(businessLogicExecuted);
        }

        [Fact]
        public void Check_SessionFeatureFirstTime_ExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService(new MemoryDataStore(), new Clock());
            var featureName = "MySessionFeature";
            var businessLogicExecuted = false;
            frequencyService.RegisterInSession(featureName);

            // Act
            frequencyService.TryRun(featureName, () => true, () => businessLogicExecuted = true);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_SessionFeatureSecondTime_DoesNotExecuteBusinessLogic()
        {
            // Arrange
            var frequencyService = new FrequencyService(new MemoryDataStore(), new Clock());
            var featureName = "MySessionFeature";
            var businessLogicExecuted = false;
            frequencyService.RegisterInSession(featureName);

            // Act
            frequencyService.TryRun(featureName, () => true, () => businessLogicExecuted = true);
            frequencyService.TryRun(featureName, () => true, () => businessLogicExecuted = false);

            // Assert
            Assert.True(businessLogicExecuted);
        }

        [Fact]
        public void Check_Frequency_Logic()
        {
            var frequencyService = new FrequencyService(new MemoryDataStore(), new MockClock());
            var featureName = "MyFeature4";
            var frequency = TimeSpan.FromSeconds(1);
            int businessValue = 13;
            frequencyService.Register(featureName, frequency);

            ((MockClock)frequencyService._clock).fakeNow = DateTime.Now;
            frequencyService.Check(featureName, () => true, () => businessValue = 100, DateTime.Now);
            Assert.Equal(100, businessValue);

            ((MockClock)frequencyService._clock).AddSecond(2);
            frequencyService.Check(featureName, () => true, () => businessValue = -100, ((MockClock)frequencyService._clock).fakeNow);
            Assert.Equal(-100, businessValue);

            frequencyService.Check(featureName, () => true, () => businessValue = 16, ((MockClock)frequencyService._clock).fakeNow);
            Assert.Equal(-100, businessValue);


            ((MockClock)frequencyService._clock).AddSecond(2);
            frequencyService.Check(featureName, () => true, () => businessValue = 17, ((MockClock)frequencyService._clock).fakeNow);
            Assert.Equal(17, businessValue);
        }
    }
}