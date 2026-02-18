using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class ScheduleMapper
{
    public static ScheduleModel MapResponseToSchedule(YemeksepetiVendorResponseModel response, int index)
    {
        ScheduleModel schedule = new ScheduleModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            ScheduleId = response?.Data?.Schedules?[index].ScheduleId,
            ScheduleWeekday = response?.Data?.Schedules?[index].ScheduleWeekday,
            ScheduleOpeningType = response?.Data?.Schedules?[index].ScheduleOpeningType,
            ScheduleOpeningTime = response?.Data?.Schedules?[index].ScheduleOpeningTime,
            ScheduleClosingTime = response?.Data?.Schedules?[index].ScheduleClosingTime
        };

        return schedule;
    }
}