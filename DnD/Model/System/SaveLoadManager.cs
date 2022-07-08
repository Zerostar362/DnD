using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Model.System
{
    internal static class SaveLoadManager
    {
        private static readonly string _savePath = Environment.CurrentDirectory + "SaveFolder/";
        private class LoadedData
        {
            public Type ClassType { get; private set; }
            public string Name { get; private set; }
            public bool isInterface { get; private set; }


            public LoadedData(Type type)
            {
                this.ClassType   = type;
                this.Name        = type.Name;
                this.isInterface = type.IsInterface;
            }
        }
        public static LoadedData Load<TValue>()
        {
            Type tp = typeof(TValue);
            string svpth = _savePath + tp.Name;
            File.ReadAllText(svpth); //todo Convert from Json to readable format
        }
    }
}
