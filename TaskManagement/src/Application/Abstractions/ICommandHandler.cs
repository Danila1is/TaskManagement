using CSharpFunctionalExtensions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Abstractions
{
    public interface ICommandHandler<TResponse, TCommand>
    {
        Task<Result<TResponse, Failure>> Handle(TCommand command);
    }
}
