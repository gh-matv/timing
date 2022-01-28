using System;
using System.Collections.Generic;
using System.IO;

namespace timing
{
    [Serializable]
    class Db
    {
        [NonSerialized]
        public static Db _instance;

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static void save()
        {
            WriteToBinaryFile<Db>("timing.db", _instance);
        }

        public static void load()
        {
            if(!File.Exists("timing.db"))
            {
                _instance = new Db();
                _instance.works = new Dictionary<string, Work>();
                return;
            }

            try
            {
                _instance = ReadFromBinaryFile<Db>("timing.db");
            } catch (Exception e)
            {
                File.Delete("timing.db");
                load();
            }
        }

        // ==========================================

        public Dictionary<string, Work> works;



    }

    [Serializable]
    class Work
    {
        public string name;
        public string descr;
        public string group;
        public string path_to_observe;

        public long seconds_worked;
        public Dictionary<DateTime, long> SecondsPerDay = new Dictionary<DateTime, long>();

        public string GetWorkedToday()
        {
            if (!SecondsPerDay.ContainsKey(DateTime.Today))
                SecondsPerDay.Add(DateTime.Today, 0);
            var todayWorked = seconds_worked + SecondsPerDay[DateTime.Today];

            int hours = 0, minutes = 0;
            while(todayWorked > 3600) { ++hours; todayWorked -= 3600; }
            while(todayWorked > 60) { ++minutes; todayWorked -= 60; }

            string o = "" ;
            if (hours > 0) o += $"{hours}h";
            if (minutes > 0) o += $"{minutes}m";
            o += $"{todayWorked}s";

            return o;
        }

        public void AddTimeWorked(long time_in_sec)
        {
            if (!SecondsPerDay.ContainsKey(DateTime.Today))
                SecondsPerDay.Add(DateTime.Today, 0);
            SecondsPerDay[DateTime.Today] += time_in_sec;
        }

        [NonSerialized]
        public static Work current_working = null;

        public void TriggerUpdate() => onUpdate(null, this);
        [field:NonSerialized]
        public event EventHandler<object> onUpdate;

        public void TriggerStartWork()
        {
            current_working = this;
            onStartWork?.Invoke(this, EventArgs.Empty);
        }
        [field: NonSerialized]
        public event EventHandler onStartWork;

        public void TriggerEndWork()
        {
            onEndWork?.Invoke(this, EventArgs.Empty);
        }
        [field: NonSerialized]
        public event EventHandler onEndWork;
    }
}
