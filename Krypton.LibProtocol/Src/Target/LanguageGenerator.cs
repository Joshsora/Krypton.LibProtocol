﻿using System.IO;
using Antlr4.StringTemplate;
using Krypton.LibProtocol.File;

namespace Krypton.LibProtocol.Target
{
    public abstract class LanguageGenerator<TS>
    {
        protected abstract string TemplatesPath { get; }

        protected DefinitionFile File { get; }

        protected LanguageGenerator(DefinitionFile file)
        {
            File = file;
        }

        public abstract void Generate(TS settings);

        protected void WriteFile(string data, string filepath)
        {
            using (var f = new FileStream(filepath, FileMode.Create))
            {
                using (var s = new StreamWriter(f))
                {
                    s.Write(data);
                }
            }
        }

        public TemplateGroupString ReadTemplate(string template)
        {
            var full = Path.Combine(TemplatesPath, template);
            var resource = full.Replace('/', '.');
            
            var s = new TemplateGroupString(ReadResource(resource));
            s.Load();
            return s;
        }

        public static Stream OpenResource(string path)
        {
            return TargetResources.Assembly.GetManifestResourceStream(path);
        }

        public static string ReadResource(string path)
        {
            var ss = new StringWriter();
            using (var stream = OpenResource(path))
            {
                while (stream.Position < stream.Length)
                    ss.Write((char) stream.ReadByte());
            }
            return ss.ToString();
        }
    }
}
