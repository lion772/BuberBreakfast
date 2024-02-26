using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public interface IBreakfastService {
         BreakfastResponse CreateBreakfast(Breakfast request);
}