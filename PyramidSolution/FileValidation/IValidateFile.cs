using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSolution.FileValidation
{
    public interface IValidateFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pyramidnumber"></param>
        /// <returns></returns>
        bool Validate_File(IList<string> Pyramidnumber);
    }
}
