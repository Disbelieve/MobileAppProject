using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HartRevalidatieApplication.Models
{
    public static class Settings
    {
        public static ApplicationDataContainer localSettings { get; private set; } = ApplicationData.Current.LocalSettings;

        public static void LoadSettings()
        {
            if (!localSettings.Values.ContainsKey("automaticLogin"))
                localSettings.Values["automaticLogin"] = true;
            if (!localSettings.Values.ContainsKey("largeFonts"))
                localSettings.Values["largeFonts"] = false;
            if (!localSettings.Values.ContainsKey("dailyReminders"))
                localSettings.Values["dailyReminders"] = true;
            if (!localSettings.Values.ContainsKey("sendMeasurements"))
                localSettings.Values["sendMeasurements"] = false;
        }

        public static void SetAutomaticLogin(bool newValue)
        {
            localSettings.Values["automaticLogin"] = newValue;
        }

        public static void SetLargeFonts(bool newValue)
        {
            localSettings.Values["largeFonts"] = newValue;
        }

        public static void SetDailyReminders(bool newValue)
        {
            localSettings.Values["dailyReminders"] = newValue;
        }

        public static void SetSendMeasurements(bool newValue)
        {
            localSettings.Values["sendMeasurements"] = newValue;
        }
    }
}
