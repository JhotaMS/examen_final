using examen_final.Domain.Vegetables.Dtos;

namespace examen_final.Application.Features.Vegetables.Queries.Periods;
public record PeriodsQueryResponse(
    IEnumerable<PeriodDto> Periods
);