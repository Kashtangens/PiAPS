using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

	// TODO: Добавьте здесь операции служб
	// Посмотреть все рейсы по заданному маршруту
	[OperationContract]
	List<Trip> GetTrip(string wayName);

	// Посмотреть наличие билетов
	[OperationContract]
	int GetTicketsCount(string wayName, string time);

	// Заказать билет на рейс
	[OperationContract]
	bool BuyTicketOnTrip(string wayName, string time);
}

// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

[DataContract]
public class Trip
{
	int wayNumber;
	string time;
	int ticketsCount;

	[DataMember]
	public int WayNumber
	{
		get { return wayNumber; }
		set { wayNumber = value; }
	}

	[DataMember]
	internal int TicketsCount
	{
		get { return ticketsCount; }
		set { ticketsCount = value; }
	}

	[DataMember]
    public string Time
    {
		get { return time; }
		set { time = value; }
	}

	public Trip() { }

	public Trip(int wayNumber, int ticketsCount, string time)
    {
		this.wayNumber = wayNumber;
		this.ticketsCount = ticketsCount;
		this.time = time;
    }
}

[DataContract]
public class Way
{
	int wayNumber;
	string wayName;

	[DataMember]
	public int WayNumber
    { 
		get { return wayNumber; }
		set { wayNumber = value; } 
	}

	[DataMember]
	public string WayName
	{
		get { return wayName; }
		set { wayName = value; }
	}

	public Way() { }
	public Way(int wayNumber, string wayName)
    {
		this.wayNumber = wayNumber;
		this.wayName = wayName;
    }
}


