using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, NO_SUCH_COUNTRY, INCORRECT_HEADER
        }
        public ExceptionType etype;
        public CensusAnalyserException(string message, ExceptionType exceptiontype) : base(message)
        {
            this.etype = exceptiontype;
        }
    }
}
