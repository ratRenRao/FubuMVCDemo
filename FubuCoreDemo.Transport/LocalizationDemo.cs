using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FubuCore;
using FubuCore.Binding;
using FubuCore.Csv;
using FubuMVC.Core;
using FubuMVC.Core.Localization;

namespace FubuCoreDemo.Transport
{
    public interface ILocalizationDemo
    {
        
    }

    public class LocalizationDemo : ILocalizationDemo
    {
        private static string FileName = "localization.csv";

        public LocalizationDemo()
        {
        }

        public IEnumerable<StringToken> LoadDataIntoStringTokens()
        {
            var csvHandler = new CsvFileHandler<KeyObject, ObjectMap>();
            var items = csvHandler.ReadFile(FileName);
            return items.Select(x => StringToken.FromKeyString(x.Key, x.Identifier));
        }
    }

    public class KeyObject
    {
        public string Key { get; set; }
        public string Identifier { get; set; }
    }

    public class ObjectMap : ColumnMapping<KeyObject>
    {
        public ObjectMap()
        {
            Column(x => x.Key);
            Column(x => x.Identifier);
        }
    }

    public static class FileLocation
    {
        public static string RootPath = AppDomain.CurrentDomain.BaseDirectory;
    }

    public class CsvFileHandler<T, TMap> where TMap : ColumnMapping<T>, new()
    {
        private readonly IList<T> _list = new List<T>();

        public IEnumerable<T> ReadFile(string fileName)
        {
            _list.Clear();

            var file = FileLocation.RootPath.AppendPath(fileName);
            if (!File.Exists(file))
            {
                file = FubuRuntime.DefaultApplicationPath().AppendPath("bin", fileName);
            }
            if (!File.Exists(file))
            {
                file = FubuRuntime.DefaultApplicationPath().AppendPath("bin\\release", fileName);
            }

            using (var stream = File.OpenRead(file))
            {
                Load(stream);
            }

            return _list;
        }

        private void Load(Stream stream)
        {
            _list.Clear();

            var request = new CsvRequest<T>
            {
                HeadersExist = false,
                UseHeaderOrdering = false,
                OpenStream = () => stream,
                Mapping = new TMap(),
                Callback = (obj) => _list.Add(obj)
            };

            var reader = new CsvReader(ObjectResolver.Basic());
            reader.Read(request);
        }
    }
}
