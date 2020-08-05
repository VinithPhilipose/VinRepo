using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidSolution.FileValidation
{
    class ValidateFile:IValidateFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pyramidnumber"></param>
        /// <returns></returns>
        public bool Validate_File(IList<string> Pyramidnumber)
        {
            bool IsValidFlag = true;
            int outval = 0;
            foreach (string value in Pyramidnumber)
            {
                
                bool flg = int.TryParse(value, out outval);
                if (!flg)
                {
                    IsValidFlag = false;
                    break;
                }
            }
            return IsValidFlag;
        }
    }
}
