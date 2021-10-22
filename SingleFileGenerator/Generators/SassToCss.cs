using System.Text;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using NUglify;
using SharpScss;

namespace SingleFileGenerator.Generators
{
    public class SassToCss : BaseCodeGeneratorWithSite
    {
        public const string Name = nameof(SassToCss);

        public const string Description = "Transpiles Sass/Scss files to CSS";

        public override string GetDefaultExtension() => ".css";

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            ScssResult results = Scss.ConvertToCss(inputFileContent);
            UglifyResult minified = Uglify.Css(results.Css);

            return Encoding.UTF8.GetBytes(minified.Code);
        }
    }
}
