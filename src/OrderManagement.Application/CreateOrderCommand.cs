using MediatR;

public record CreateOrderCommand(Guid UserId) : IRequest<Guid>;