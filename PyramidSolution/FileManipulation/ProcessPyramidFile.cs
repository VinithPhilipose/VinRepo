using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSolution.FileManipulation
{
    public class ProcessPyramidFile: IProcessPyramidFile
    {
        public async Task<IList<string>> ReadFileContent_Text(string selectedFile)
        {
            using (var rdr=File.OpenText(selectedFile))
            {
                var txtContent = await rdr.ReadToEndAsync();
                return txtContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);               
            }
           
        }
    }
}
