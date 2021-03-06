using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace streamscraper
{
    public static class ParserFactory
    {
        private static IDictionary<string, Type> _parsers;

        public static void RegisterParser<T>(string abbrevation) where T : IParser
        {
            if(_parsers == null)
                _parsers = new Dictionary<string, Type>();

            if(_parsers.ContainsKey(abbrevation))
                return;

            _parsers.Add(abbrevation, typeof(T));

        }

        public static IParser GetParser(string key)
        {
            if(_parsers == null || !_parsers.ContainsKey(key))
                return null;

            return (IParser)Activator.CreateInstance(_parsers[key]);
        }

        public static string[] GetAvailableParsers()
        {
            if(_parsers == null)
                return new string[0];
            else
                return _parsers.Keys.ToArray();
        }
    }
}