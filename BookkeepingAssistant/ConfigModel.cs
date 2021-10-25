using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingAssistant
{
    public class ConfigModel
    {
        public bool IsInit { get; set; }
        public string GitRepoDir { get; set; }
        public string GitPushUrl { get; set; }
        public string GitUsername { get; set; }
        public string GitEmail { get; set; }
    }
}
