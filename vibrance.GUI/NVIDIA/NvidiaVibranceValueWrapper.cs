﻿using System.Collections.Generic;

namespace vibrance.GUI.NVIDIA
{
    internal class NvidiaVibranceValueWrapper
    {
        private const int NvapiDefaultLevel = 50;

        private static List<NvidiaVibranceValueWrapper> _settingsList;

        public NvidiaVibranceValueWrapper(int value, string percentage)
        {
            Value = value;
            Percentage = percentage;
        }

        public int Value { get; set; }

        public string Percentage { get; set; } = string.Empty;

        private static List<NvidiaVibranceValueWrapper> GenerateSettingsWrapper()
        {
            var settingsWrapperList = new List<NvidiaVibranceValueWrapper>();
            var staticValues = new List<int>
            {
                0, 1, 3, 4, 5, 6, 8, 9, 10, 11, 13, 14, 15, 16, 18, 19, 20, 21, 23, 24, 25, 26, 28, 29, 30, 32, 33, 34, 35, 37, 38, 39, 40, 42, 43, 44, 45,
                47, 48, 49, 50, 52, 53, 54, 55, 57, 58, 59, 60, 62, 63
            };

            var percentageValue = NvapiDefaultLevel;
            foreach (var value in staticValues)
            {
                settingsWrapperList.Add(new NvidiaVibranceValueWrapper(value, percentageValue + "%"));
                percentageValue++;
            }

            return settingsWrapperList;
        }

        public static NvidiaVibranceValueWrapper Find(int value)
        {
            if (_settingsList == null)
                _settingsList = GenerateSettingsWrapper();
            var returnWrapper = _settingsList.Find(x => x.Value == value) ?? Find(value + 1);

            return returnWrapper;
        }
    }
}
