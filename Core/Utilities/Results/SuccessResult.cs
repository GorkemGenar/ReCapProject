using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //base:Inheritence olan class (Result) ve o classın constructer'ına değerler bu şekilde iletilir.

    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true, message)
        {

        }

        public SuccessResult():base(true)
        {

        }
    }
}
