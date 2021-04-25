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
		new Trip(0, 10),
		new Trip(0, 50),
		new Trip(1, 2),
		new Trip(2, 12),
		new Trip(2, 0)
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
	/// <param name="trip">Рейс</param>
	/// <returns>Количество билетов</returns>
    public int GetTicketsCount(Trip trip)
    {
        throw new NotImplementedException();
    }

	/// <summary>
	/// Функция получения списка рейсов по номеру пути
	/// </summary>
	/// <param name="wayName"></param>
	/// <returns></returns>
    public List<Trip> GetTrip(string wayName)
    {
        throw new NotImplementedException();
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
		throw new NotImplementedException();
	}
}
