using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Text;
using System.IO;

namespace BookkeepingAssistant
{
    public class ConfigHelper
    {
        private static string _configFile = Path.Combine(Directory.GetCurrentDirectory(), "BA.config");
        public static void SaveConfig(Dictionary<string, string> dicConfig)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dicConfig)
            {
                sb.AppendLine(string.Join(':', item.Key, item.Value));
            }
            File.WriteAllText(_configFile, sb.ToString());
        }
        public static Dictionary<string, string> ReadConfig()
        {
            Dictionary<string, string> dicConfig = new Dictionary<string, string>();
            if (File.Exists(_configFile))
            {
                string[] lines = File.ReadAllLines(_configFile);
                foreach (var line in lines)
                {
                    string[] txts = line.Split(':');
                    if (txts.Length != 2)
                    {
                        continue;
                    }
                    string key = txts[0].Trim();
                    string value = txts[1].Trim();
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    dicConfig.Add(key, value);
                }
            }
            return dicConfig;
        }

        ///// <summary>  
        ///// 写入值  
        ///// </summary>  
        ///// <param name="key"></param>  
        ///// <param name="value"></param>  
        //public static void SetValue(string key, string value)
        //{
        //    //增加的内容写在appSettings段下 <add key="RegCode" value="0"/>  
        //    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    if (config.AppSettings.Settings[key] == null)
        //    {
        //        config.AppSettings.Settings.Add(key, value);
        //    }
        //    else
        //    {
        //        config.AppSettings.Settings[key].Value = value;
        //    }
        //    config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件   
        //}

        ///// <summary>  
        ///// 读取指定key的值  
        ///// </summary>  
        ///// <param name="key"></param>  
        ///// <returns></returns>  
        //public static string GetValue(string key)
        //{
        //    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    if (config.AppSettings.Settings[key] == null)
        //        return "";
        //    else
        //        return config.AppSettings.Settings[key].Value.Trim();
        //}
    }
}
