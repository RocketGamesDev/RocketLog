///////////////////////////////////////////////////////////////
// Copyright - 2014 Rocket Games
// Project Name: RocLog
// File Name   : RocLog.cs
// Created On  : 15/11/2014 14:00
///////////////////////////////////////////////////////////////

using System;

namespace RocketLog
{
    public enum DebugLevels
    {
        None = 0,
        Debug = 5,
        Info = 10,
        Warning = 20,
        Exception = 30,
        Error = 40,
        Special = 50
    }


    public class RocLog
    {
        public static bool IsDebugModeOn = false;

        public DebugLevels DebugLevel;
        private string _componentName;
		//test
        public string ComponentName
        {
            get
            {
                return (string.IsNullOrEmpty(_componentName) ? string.Empty : string.Format("[{0}] ", _componentName));
            }
            set { _componentName = value; }
        }

        public RocLog(string componentName, DebugLevels debugLevel)
        {
            ComponentName = componentName;
            DebugLevel = debugLevel;
        }

        public void Debug(string log, string prefix = "")
        {
            if ((int)DebugLevel <= (int)DebugLevels.Debug)
            {
                ShowLog(log, DebugLevels.Debug, prefix);
            }
        }

        public void Info(string log, string prefix = "")
        {
            if ((int)DebugLevel <= (int)DebugLevels.Info)
            {
                ShowLog(log, DebugLevels.Info, prefix);
            }
        }

        public void Warning(string log, string prefix = "")
        {
            if ((int)DebugLevel <= (int)DebugLevels.Warning)
            {
                ShowLog(log, DebugLevels.Warning, prefix);
            }
        }

        public void Exception(string log, string prefix = "")
        {
            if ((int)DebugLevel <= (int)DebugLevels.Exception)
            {
                ShowLog(log, DebugLevels.Exception, prefix);
            }
        }

        public void Error(string log, string prefix = "")
        {
            if ((int)DebugLevel <= (int)DebugLevels.Error)
            {
                ShowLog(log, DebugLevels.Error, prefix);
            }
        }

        public void Special(string log, string prefix = "")
        {
            if ((int)DebugLevel == 50)
            {
                ShowLog(log, DebugLevels.Special, prefix);
            }
        }

        private void ShowLog(string log, DebugLevels debugLevel, string prefix)
        {
            if (!string.IsNullOrEmpty(prefix))
                prefix = "[" + prefix + "]";

            string logContent = ComponentName+prefix+ ": " + log;


            if (!IsDebugModeOn) return;

            switch (debugLevel)
            {
                case DebugLevels.Debug:
                    UnityEngine.Debug.LogWarning("[DEBUG] " + logContent);
                    break;
                case DebugLevels.Info:
                    UnityEngine.Debug.Log(logContent);
                    break;
                case DebugLevels.Warning:
                    UnityEngine.Debug.LogWarning(logContent);
                    break;
                case DebugLevels.Exception:
                    UnityEngine.Debug.LogException(new Exception(logContent));
                    break;
                case DebugLevels.Error:
                    UnityEngine.Debug.LogError(logContent);
                    break;
                case DebugLevels.Special:
                    UnityEngine.Debug.LogError(logContent);
                    break;
            }
        }
    }
}