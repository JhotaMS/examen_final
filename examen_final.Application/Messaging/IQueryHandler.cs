using examen_final.Domain.Abstractions;
using MediatR;

namespace examen_final.Application.Messaging;

public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
