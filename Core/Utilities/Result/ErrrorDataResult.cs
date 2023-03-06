using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrrorDataResult<T> : DataResult<T>
    {
        public ErrrorDataResult(T data, string message) : base(data, true, message)
        {

        }
        public ErrrorDataResult(T data) : base(data, true)
        {

        }
        public ErrrorDataResult(string message) : base(default, true, message)
        {

        }
        public ErrrorDataResult() : base(default, true)
        {

        }
    }
}
