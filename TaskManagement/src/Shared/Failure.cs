using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Failure : IEnumerable<Error>
    {
        private readonly List<Error> _errors;

        public Failure(IEnumerable<Error> errors)
        {
            _errors = [..errors];
        }

        public IEnumerator<Error> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator Failure(Error[] errors)
        {
            return new Failure(errors);
        }

        public static implicit operator Failure(Error error)
        {
            return new Failure([error]);
        }
    }
}
