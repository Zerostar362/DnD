using DnD.Interfaces;
using DnD.Model.Interfaces;
using DnD.Model.System.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DnD.Model.System
{
    public static class SaveLoadManager
    {
        private static readonly string _savePathMain = Environment.CurrentDirectory + "SaveFolder/";
        private static readonly string _savePathMap = _savePathMain + "Map/";
        private static readonly string _savePathEntities = _savePathMain + "Entities/";
        private static readonly string _savePathPrefabricates = _savePathMain + "Prefabricates/";
        private static readonly string _savePathGame = _savePathMain + "SaveGame/";


        public static bool SaveData<TValue>(TValue obj)
        {
            try
            {
                if (!IsEligible(obj)) return false;
                var objType = obj.GetType();
                var objName = objType.Name + ".json";
                var json = obj.ToJson();

                var savePath = GetCorrectSavePath(objType);

                if (savePath == "") throw new Exception("Faulty save path");

                savePath += objName;

                if(File.Exists(savePath))
                {
                    var result = MessageBox.Show("Save with same name was found, do wish to overwrite ?", "", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            File.WriteAllText(savePath + objName, json);
                            return true;
                        case MessageBoxResult.No:
                            return false;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }

        }

        public static TValue? LoadData<TValue>(TValue obj)
        {
            if (!IsEligible(obj)) return default(TValue);

            var objType = obj.GetType();
            var objName = objType.Name + ".json";
            var savePath = GetCorrectSavePath(objType) + objName;
            return File.ReadAllText(savePath).ConvertJson<TValue>();
        }

        private static bool IsEligible<TValue>(TValue obj)
        {
            try
            {
                obj = obj ?? throw new ArgumentNullException(nameof(obj));
                if (!obj.GetType().IsInterface) throw new ArgumentException("TValue must be an interface");
                return true;
            }
            
            catch { return false; }
        }


        private static string GetCorrectSavePath(Type objType)
        {
            switch (objType)
            {
                case IConsumables: return _savePathEntities;
                case IDoor: return _savePathPrefabricates;
                case IEnemy: return _savePathEntities;
                case IInvestigationSpace: return _savePathPrefabricates;
                case IItem: return _savePathEntities;
                case IMap: return _savePathMap;
                case IObstacle: return _savePathPrefabricates;
                case IPlayableArea: return _savePathPrefabricates;
                case IPlayer: return _savePathEntities;
                case ISpell: return _savePathEntities;
                default:return "";
            }
        }

        public static void StartupPathCheck()
        {
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0: CheckOrCreateSavePath(_savePathMain);
                        break;
                    case 1: CheckOrCreateSavePath(_savePathPrefabricates);
                        break;
                    case 2: CheckOrCreateSavePath(_savePathGame);
                        break;
                    case 3: CheckOrCreateSavePath(_savePathMap);
                        break;
                    case 4: CheckOrCreateSavePath(_savePathEntities);
                        break;
                }
            }
        }


        private static void CheckOrCreateSavePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
