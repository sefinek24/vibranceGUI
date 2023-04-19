using System.Diagnostics;
using System.Drawing;

namespace vibrance.GUI.common
{
    public class ProcessExplorerEntry
    {
        public ProcessExplorerEntry(string path, Icon icon, Process process)
        {
            Path = path;
            Icon = icon;
            ProcessName = process.ProcessName;
        }

        public ProcessExplorerEntry(string path, Icon icon, string processName)
        {
            Path = path;
            Icon = icon;
            ProcessName = processName;
        }

        public string Path { get; set; }

        public Icon Icon { get; set; }

        public string ProcessName { get; set; }
    }
}
