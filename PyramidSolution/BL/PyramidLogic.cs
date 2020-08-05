using PyramidSolution.FileManipulation;
using PyramidSolution.FileValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PyramidSolution.BL
{
    public class PyramidLogic:IPyramidLogic
    {
        IProcessPyramidFile _fileReader;
        IValidateFile _validateFile;

        public PyramidLogic(IProcessPyramidFile fileReader, IValidateFile validateFile)
        {
            _fileReader = fileReader;
            _validateFile = validateFile;
        }
        /// <summary>
        /// Pyramid file processing logic
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <returns></returns>
        public  async Task<IList<Int32>> processPyramidData(string selectedFile)
        {
            var txtlines =  await _fileReader.ReadFileContent_Text(selectedFile);
            IList<Int32> lstnumbersforAddition = new List<Int32>();
            int PickedNum_Index = 0;
            bool previousvalue_IsEven = false;
            Int32 rowNum = 1;

            foreach (string line in txtlines)
            {
                var lineData = Regex.Split(line, " ");

                if (!_validateFile.Validate_File(lineData))
                {
                    throw new Exception("Data is not valid at line: " + rowNum.ToString(), new ApplicationException());
                }
                //Reading first line
                if (lineData.Length == 1)
                {
                    lstnumbersforAddition.Add(Convert.ToInt32(lineData[0]));
                    previousvalue_IsEven = CheckForEvenNum(Convert.ToInt32(lineData[0]));
                    PickedNum_Index = 0;
                }
                else
                {
                    //Find the next item in next line by comparing the index of the previous selected item in the previous row
                    //The next possible values will be in the previous item's index or index +1
                    int intNxtPossibleNumerFirst = Convert.ToInt32(lineData[PickedNum_Index]);
                    int intNxtPossibleNumerSecond = Convert.ToInt32(lineData[PickedNum_Index + 1]);

                    int intNextNo = NextValue_Get(previousvalue_IsEven, intNxtPossibleNumerFirst, intNxtPossibleNumerSecond);
                    PickedNum_Index = lineData.ToList().IndexOf(Convert.ToString(intNextNo));
                    lstnumbersforAddition.Add(intNextNo);
                    previousvalue_IsEven = CheckForEvenNum(intNextNo);
                }
                rowNum += 1;
            }

            return lstnumbersforAddition;
        }
        /// <summary>
        /// To check if the number is even
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        private bool CheckForEvenNum(int inputValue)
        {
            return inputValue % 2 == 0;
        }

        /// <summary>
        /// get next number
        /// </summary>
        /// <param name="isPrevNumberEven"></param>
        /// <param name="firstNo"></param>
        /// <param name="secondNo"></param>
        /// <returns></returns>
        private Int32 NextValue_Get(bool isPrevNum_Even, Int32 first_Num, Int32 second_Num)
        {
            bool isFirstNum_Even = CheckForEvenNum(first_Num);
            bool isSecondNum_Even = CheckForEvenNum(second_Num);
            int result = 0;
            
            if (isPrevNum_Even)
            {
                if (!isFirstNum_Even && !isSecondNum_Even)
                {
                    result = first_Num > second_Num ? first_Num : second_Num;
                }
                else if (!isFirstNum_Even && isSecondNum_Even)
                {
                    result = first_Num;
                }
                else if (isFirstNum_Even && !isSecondNum_Even)
                {
                    result = second_Num;
                }
            }            
            else
            {
                if (isFirstNum_Even && isSecondNum_Even)
                {
                    result = first_Num > second_Num ? first_Num : second_Num;
                }
                else if (!isFirstNum_Even && isSecondNum_Even)
                {
                    result = second_Num;
                }
                else if (isFirstNum_Even && !isSecondNum_Even)
                {
                    result = first_Num;
                }
            }
            return result;
        }
    }
}
