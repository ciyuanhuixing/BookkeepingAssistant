using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Text;
using System.IO;
using System.Reflection;

namespace BookkeepingAssistant
{
    public class ConfigHelper
    {
        private static string _configFile = Path.Combine(Directory.GetCurrentDirectory(), "BA.config");

        public static void SaveConfig(ConfigModel model)
        {
            File.WriteAllText(_configFile, ToConfigText(model));
        }

        private static string ToConfigText<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();
            var type = obj.GetType();
            var pros = type.GetProperties();
            foreach (var p in pros)
            {
                sb.AppendLine(string.Join(':', p.Name, p.GetValue(obj)));
            }
            return sb.ToString();
        }

        public static ConfigModel ReadConfig()
        {
            ConfigModel model = new ConfigModel();
            if (!File.Exists(_configFile))
            {
                return model;
            }

            string[] lines = File.ReadAllLines(_configFile);
            foreach (var line in lines)
            {
                int sepIndex = line.IndexOf(':');
                if (sepIndex < 1)
                {
                    continue;
                }
                string key = line.Substring(0, sepIndex).Trim();
                string value = line.Substring(sepIndex + 1).Trim();
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    continue;
                }
                var type = model.GetType();
                var pro = type.GetProperty(key);
                if (pro != null)
                {
                    pro.SetValue(model, Convert.ChangeType(value, pro.PropertyType));
                }
            }
            return model;
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
