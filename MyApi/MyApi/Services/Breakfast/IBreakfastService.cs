using MyApi.Contracts.Breakfast;

namespace MyApi.Services.Breakfast;
public class IBreakfastService
{
    BreakfastResponse CreateBreakfast(CreateBreakfastRequest request);
    BreakfastResponse GetBreakfast(Guid id);
    BreakfastResponse UpsertBreakfast(UpsertBreakfastRequest reques);
    BreakfastResponse DeleteBreakfast(Guid id);
}