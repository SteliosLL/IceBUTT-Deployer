using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceButt
{
    public class iniParser
    {
        private readonly List<string> sectionOrder = new List<string>();
        private readonly Dictionary<string, OrderedDictionary> data = new Dictionary<string, OrderedDictionary>();

        private string filePath;

        public iniParser(string path)
        {
            filePath = path;
            if (File.Exists(path))
                Load(path);
        }

        public string Get(string section, string key)
        {
            if (data.ContainsKey(section) && data[section].Contains(key))
                return data[section][key]?.ToString();
            return null;
        }

        public void Set(string section, string key, string value)
        {
            if (!data.ContainsKey(section))
            {
                data[section] = new OrderedDictionary();
                sectionOrder.Add(section);
            }

            data[section][key] = value;
        }

        public void Load(string path)
        {
            data.Clear();
            sectionOrder.Clear();

            string currentSection = null;
            foreach (string rawLine in File.ReadAllLines(path))
            {
                string line = rawLine.Trim();

                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#") || line.StartsWith(";"))
                    continue;

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Substring(1, line.Length - 2).Trim();
                    if (!data.ContainsKey(currentSection))
                    {
                        data[currentSection] = new OrderedDictionary();
                        sectionOrder.Add(currentSection);
                    }
                }
                else if (currentSection != null)
                {
                    string[] parts = line.Split(new char[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        data[currentSection][key] = value;
                    }
                }
            }
        }

        public void Save()
        {
            if (filePath == null)
                throw new InvalidOperationException("No file path specified.");

            using (var writer = new StreamWriter(filePath, false, new UTF8Encoding(false)))//do not write with BOM
            {
                writer.NewLine = "\n"; //default is \r\n. carriage return messes with BUTT
                foreach (string section in sectionOrder)
                {
                    writer.WriteLine("[" + section + "]");
                    foreach (DictionaryEntry kv in data[section])
                    {
                        writer.WriteLine(kv.Key + " = " + kv.Value);
                    }
                    writer.WriteLine();
                }
            }
        }

        public void SaveAs(string newPath)
        {
            using (var writer = new StreamWriter(newPath, false, new UTF8Encoding(false))) //do not write with BOM
            {
                writer.NewLine = "\n";
                foreach (string section in sectionOrder)
                {
                    writer.WriteLine("[" + section + "]");
                    foreach (DictionaryEntry kv in data[section])
                    {
                        writer.WriteLine(kv.Key + " = " + kv.Value);
                    }
                    writer.WriteLine();
                }
            }
        }

        public bool HasSection(string section)
        {
            return data.ContainsKey(section);
        }

        public bool HasKey(string section, string key)
        {
            return data.ContainsKey(section) && data[section].Contains(key);
        }
    }
}
