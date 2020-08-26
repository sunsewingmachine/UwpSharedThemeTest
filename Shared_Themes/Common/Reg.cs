using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;

namespace Shared_Themes.Common
{
    public static class Reg
    {
        public static string CurrentUserName = "";
        public const string DefaultUser = "Player1";
        public static bool IsDeveloper = true;
        private const string Separator = ".";
        public static bool SaveDefaultPlayerAsEmpty = true;
        private static readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;

        public static async Task DeleteAllSettings(bool confirm)
        {
            if (confirm)
            {
                await ApplicationData.Current.ClearAsync();
                CoreApplication.Exit();
            }
        }

        public static void RemoveSetting(string key, bool userSpecific = false)
        {
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            LocalSettings.Values.Remove(key);
            Debug.WriteLine("Key Removed: " + key);
        }

        public static bool ContainsKey(string key, bool userSpecific = false)
        {
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            return LocalSettings.Values.ContainsKey(key);
        }

        private static string GetKeyWithUserNameIfAny(string key, bool userSpecific = false)
        {
            if (!userSpecific) return key;

            string username;
            if (SaveDefaultPlayerAsEmpty)
                username = (CurrentUserName == Reg.DefaultUser) ? "" : CurrentUserName;
            else
            {
                username = CurrentUserName;
            }
            return string.IsNullOrWhiteSpace(username) ? key : username + Separator + key;

        }

        public static string SaveSetting(string key, string value, bool userSpecific = false)
        {
            if (IsEmpty(key)) return string.Empty;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = value;
            return value;
        }

        public static int SaveSetting(string key, int value, bool userSpecific = false)
        {
            if (IsEmpty(key)) return 0;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = value;
            return value;
        }

        public static long SaveSetting(string key, long value, bool userSpecific = false)
        {
            if (IsEmpty(key)) return 0;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = value;
            return value;
        }

        public static double SaveSetting(string key, double value, bool userSpecific = false)
        {
            if (IsEmpty(key)) return 0;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = value;
            return value;
        }

        public static bool SaveSetting(string key, bool value, bool userSpecific = false)
        {
            if (IsEmpty(key)) return false;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = value;
            return value;
        }

        public static TimeSpan SaveSetting(string key, TimeSpan time, bool userSpecific = false)
        {
            // if (IsEmpty(key)) return TimeSpan.Zero;

            key = GetKeyWithUserNameIfAny(key, userSpecific);
            LocalSettings.Values[key] = time;
            return time;
        }


        public static string GetSetting_AsString_DoNotUse(string key, string defaultValue)
        {
            if (LocalSettings.Values.ContainsKey(key) == false) return defaultValue;

            if (LocalSettings.Values[key] == null) return defaultValue;
            var value = LocalSettings.Values[key].ToString();
            return value;
        }

        public static int GetSetting(string key, int defaultValue, bool userSpecific = false)
        {
            int value;
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            try
            {
                value = int.Parse(LocalSettings.Values[key].ToString());
            }
            catch (Exception)
            {
                value = defaultValue;
            }

            return value;
        }

        public static string GetSetting(string key, string defaultValue, bool userSpecific = false)
        {
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            var value = LocalSettings.Values[key].ToString();
            return value;
        }

        public static TimeSpan GetSetting(string key, TimeSpan defaultTime, bool userSpecific = false)
        {
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultTime;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultTime;

            try
            {
                var value = (TimeSpan)LocalSettings.Values[key];
                return value;
            }
            catch (Exception)
            {
                return DateTime.Now - DateTime.Now.AddHours(-1);
            }
        }

        public static long GetSetting(string key, long defaultValue, bool userSpecific = false)
        {
            long value;
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            try
            {
                value = long.Parse(LocalSettings.Values[key].ToString());
            }
            catch (Exception)
            {
                value = defaultValue;
            }

            return value;
        }

        public static double GetSetting(string key, double defaultValue, bool userSpecific = false)
        {
            double value;
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            try
            {
                value = double.Parse(LocalSettings.Values[key].ToString());
            }
            catch (Exception)
            {
                value = defaultValue;
            }

            return value;
        }


        public static bool GetSetting(string key, bool defaultValue, bool userSpecific = false)
        {
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            var value = bool.Parse(LocalSettings.Values[key].ToString());
            return value;
        }

        public static string SaveSetting(bool isSaving, string key, string key2, string defaultValue,
            bool userSpecific = false)
        {
            if (IsEmpty(key)) return string.Empty;

            var value = "";
            key = GetKeyWithUserNameIfAny(key, userSpecific);

            if (isSaving)
            {
                LocalSettings.Values[key] = defaultValue;
                return value;
            }

            if (LocalSettings.Values.ContainsKey(key) == false) LocalSettings.Values[key] = defaultValue;

            if (LocalSettings.Values[key] == null) LocalSettings.Values[key] = defaultValue;

            value = LocalSettings.Values[key].ToString();
            return value;
        }


        private static bool IsEmpty(string key)
        {
            if (!string.IsNullOrWhiteSpace(key)) return false;

            //if (Reg.IsDeveloper) AllGlob.MsgBox("Danger in SaveSetting IsNullOrWhiteSpace=true;");
            return true;
        }



    }
}