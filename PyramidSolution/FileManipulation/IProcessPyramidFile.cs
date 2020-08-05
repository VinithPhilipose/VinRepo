using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSolution.FileManipulation
{
    public interface IProcessPyramidFile
    {
        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <returns></returns>
        Task<IList<string>> ReadFileContent_Text(string selectedFile);
    }
}
