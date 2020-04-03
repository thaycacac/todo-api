using System;
using System.Threading.Tasks;

namespace ToDoAPI.Entities
{
    public class VersionMasterEntities 
    {
        public string version { get; set; }

        public string sourcePath { get; set; }

        public string targetPath { get; set; }

        public int timeUpdate { get; set; }
    }
}