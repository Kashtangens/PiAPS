using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
{
	//инициализация маршрутов
	Way[] ways =
	{
		new Way(0, "Moscow-Spb"),
		new Way(1, "Spb-Kaliningrad"),
		new Way(2, "Kaliningrad-Moscow")
	};

	// инициализация рейсов
	Trip[] trips =
	{
		new Trip(0, 10, "10:00"),
		new Trip(0, 50, "20:00"),
		new Trip(1, 2, "12:00"),
		new Trip(2, 12, "14:30"),
		new Trip(2, 0, "15:45")
	};


	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	/// <summary>
	/// Функция получения количества билета по рейсу
	/// </summary>
	/// <param name="wayName">Название маршрута</param>
	/// <param name="time">Время маршрута</param>
	/// <returns>Количество билетов</returns>
	public int GetTicketsCount(string wayName, string time)
    {
		int res = -1;
		foreach (Trip trip in trips)
        {
			if (trip.Time == time)
            {
				foreach (Way way in ways)
                {
					if (way.WayName == wayName)
                    {
						res = trip.TicketsCount;
                    }
                }
            }
        }
		return res;
    }

	/// <summary>
	/// Функция получения списка рейсов по номеру пути
	/// </summary>
	/// <param name="wayName">Название маршрута</param>
	/// <returns></returns>
    public List<Trip> GetTrip(string wayName)
    {
		List<Trip> returnTrips = new List<Trip>();
		int wayNumber = -1;
		foreach (Way way in ways)
        {
			if (way.WayName == wayName)
            {
				wayNumber = way.WayNumber;
            }
        }
		foreach (Trip trip in trips)
        {
			if (trip.WayNumber == wayNumber)
            {
				returnTrips.Add(trip);
            }
        }
		return returnTrips;
    }

	/// <summary>
	/// Функция покупки билета на рейс
	/// </summary>
	/// <param name="trip">Рейс</param>
	/// <returns>
	/// true - если успешно купил билет;
	/// false - если билет купить не удалось.
	/// </returns>
	public bool BuyTicketOnTrip(Trip trip)
	{
		for (int i = 0; i < trips.Length; i++) {
			if (trips[i].Time == trip.Time && trips[i].WayNumber == trip.WayNumber)
			{
				if (trips[i].TicketsCount > 0)
				{
					trips[i].TicketsCount = trips[i].TicketsCount - 1;
					return true;
				}
			}
		}
		return false;
	}
}
