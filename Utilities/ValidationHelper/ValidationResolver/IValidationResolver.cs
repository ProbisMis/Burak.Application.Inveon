using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Utilities.ValidationHelper.ValidationResolver
{
    public interface IValidatorResolver
    {
        T Resolve<T>() where T : class;
        T Resolve<T>(bool throwIfTypeNotFound) where T : class;
    }
}
