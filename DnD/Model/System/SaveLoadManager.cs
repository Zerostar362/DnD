using DnD.Model.System.ExtensionMethods;
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
        public class LoadedData
        {
            public Type ClassType { get; private set; }
            public string Name { get; private set; }
            public bool isInterface { get; private set; }

            public object Data { get; private set; }


            public LoadedData(Type type, object data)
            {
                this.ClassType   = type;
                this.Name        = type.Name;
                this.isInterface = type.IsInterface;
                this.Data = data;
            }
        }

        public static LoadedData Load<TValue>()
        {
            Type tp = typeof(TValue);
            string svpth = _savePath + tp.Name;
            var obj = File.ReadAllText(svpth).ConvertJson<TValue>(); //todo Convert from Json to readable format
            return new LoadedData(tp,obj);
        }
    }
}
