using System;
using System.Linq;

namespace Xenia_Configurator
{

    internal class Toml
    {
        private Section[] sections;

        
        public Toml()
        {
        }

        public Toml(string path)
        {

        }

        public Toml(bool def)
        {
            string[] sectionNames = {
            "APU",
            "CPU",
            "Config",
            "Content",
            "D3D12",
            "GPU",
            "General",
            "HID",
            "Kernel",
            "Logging",
            "Memory",
            "SDL",
            "Storage",
            "UI",
            "Vulkan",
            "XConfig"
            };

        }

        public void Read(string path)
        {
            System.Collections.Generic.List<string> lines = System.IO.File.ReadLines(path).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Replace(" ", "");
                lines[i] = lines[i].Replace("\t", "");
                lines[i] = lines[i].Replace("\"", "");
                lines[i] = lines[i].Split('#')[0];
            }
            lines = lines.Where(value => !value.Equals("")).ToList();

            var prevSection = "";

            for (int i = 0; i < lines.Count; i++)
            {
                
                if (System.Text.RegularExpressions.Regex.IsMatch(lines[i], @"\[.+\]"))
                {
                    // Is section
                    prevSection = lines[i];
                }
            }
        }

        public System.Collections.Generic.IEnumerable<string> GetTest(string path)
        {
            return System.IO.File.ReadLines(path);
        }



        public string ToLiteral(string input)
        {
            using (var writer = new System.IO.StringWriter())
            {
                using (var provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new System.CodeDom.CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}