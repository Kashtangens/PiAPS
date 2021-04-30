using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Сводное описание для DataManager
/// </summary>
public class DataManager
{
    private string path;
    private XmlDocument xDoc;

    public DataManager(){}

    /// <summary>
    /// Функция инициализации менеджера данных - открытие файла с данными
    /// </summary>
    /// <param name="path">Путь до файла с данными</param>
    public void Init(string path)
    {
        xDoc = new XmlDocument();
        xDoc.Load(path);
        this.path = path;
    }

    /// <summary>
    /// Функция получения данных из файла
    /// </summary>
    /// <param name="trips">Список путевок</param>
    /// <param name="ways">Список маршрутов</param>
    public void GetData(ref List<Trip> trips, ref List<Way> ways)
    {
        trips = new List<Trip>();

        XmlElement xRoot = xDoc.DocumentElement;
        foreach (XmlNode childNode in xRoot)
        {
            // Загружаем список путевок
            if (childNode.Name == "trips")
            {
                foreach (XmlElement tripElement in childNode)
                {
                    Trip trip = new Trip();
                    foreach (XmlNode tripNode in tripElement)
                    {
                        if (tripNode.Name == "wayNumber")
                        {
                            trip.WayNumber = int.Parse(tripNode.InnerText);
                        }
                        if (tripNode.Name == "ticketsCount")
                        {
                            trip.TicketsCount = int.Parse(tripNode.InnerText);
                        }
                        if (tripNode.Name == "time")
                        {
                            trip.Time = tripNode.InnerText;
                        }
                    }
                    trips.Add(trip);
                }
            }
            // Загружаем список маршрутов
            else if (childNode.Name == "ways")
            {
                foreach(XmlElement wayElement in childNode)
                {
                    Way way = new Way();
                    foreach (XmlNode wayNode in wayElement)
                    {
                        if (wayNode.Name == "wayNumber")
                        {
                            way.WayNumber = int.Parse(wayNode.InnerText);
                        }
                        if (wayNode.Name == "name")
                        {
                            way.WayName = wayNode.InnerText;
                        }
                    }
                    ways.Add(way);
                }
            }
        }
    }

    /// <summary>
    /// Функция сохранения данных в файл
    /// </summary>
    /// <param name="trips">Список путевок</param>
    /// <param name="ways">Список маршрутов</param>
    public void SaveData(List<Trip> trips, List<Way> ways)
    {
        /*
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("D://users.xml");
        XmlElement xRoot = xDoc.DocumentElement;
        // создаем новый элемент user
        XmlElement userElem = xDoc.CreateElement("user");
        // создаем атрибут name
        XmlAttribute nameAttr = xDoc.CreateAttribute("name");
        // создаем элементы company и age
        XmlElement companyElem = xDoc.CreateElement("company");
        XmlElement ageElem = xDoc.CreateElement("age");
        // создаем текстовые значения для элементов и атрибута
        XmlText nameText = xDoc.CreateTextNode("Mark Zuckerberg");
        XmlText companyText = xDoc.CreateTextNode("Facebook");
        XmlText ageText = xDoc.CreateTextNode("30");
 
        //добавляем узлы
        nameAttr.AppendChild(nameText);
        companyElem.AppendChild(companyText);
        ageElem.AppendChild(ageText);
        userElem.Attributes.Append(nameAttr);
        userElem.AppendChild(companyElem);
        userElem.AppendChild(ageElem);
        xRoot.AppendChild(userElem);
        xDoc.Save("D://users.xml");


        */
        xDoc = new XmlDocument();
        xDoc.Load(path);
        XmlElement root = xDoc.DocumentElement;
        root.RemoveAll();
        XmlElement xmlTrips = xDoc.CreateElement("trips");
        XmlElement xmlWays = xDoc.CreateElement("ways");
        // Заполняем путевки
        foreach (Trip trip in trips)
        {
            XmlElement xmlTrip = xDoc.CreateElement("trip");
            XmlElement wayNumber = xDoc.CreateElement("wayNumber");
            XmlElement ticketsCount = xDoc.CreateElement("ticketsCount");
            XmlElement time = xDoc.CreateElement("time");
            XmlText wnText = xDoc.CreateTextNode(trip.WayNumber.ToString());
            XmlText tcText = xDoc.CreateTextNode(trip.TicketsCount.ToString());
            XmlText tText = xDoc.CreateTextNode(trip.Time);
            wayNumber.AppendChild(wnText);
            ticketsCount.AppendChild(tcText);
            time.AppendChild(tText);
            xmlTrip.AppendChild(wayNumber);
            xmlTrip.AppendChild(ticketsCount);
            xmlTrip.AppendChild(time);
            xmlTrips.AppendChild(xmlTrip);
        }
        // Заполняем маршруты
        foreach (Way way in ways)
        {
            XmlElement xmlWay = xDoc.CreateElement("way");
            XmlElement wayNumber = xDoc.CreateElement("wayNumber");
            XmlElement name = xDoc.CreateElement("name");
            XmlText wnText = xDoc.CreateTextNode(way.WayNumber.ToString());
            XmlText nText = xDoc.CreateTextNode(way.WayName);
            wayNumber.AppendChild(wnText);
            name.AppendChild(nText);
            xmlWay.AppendChild(wayNumber);
            xmlWay.AppendChild(name);
            xmlWays.AppendChild(xmlWay);
        }
        // Связываем все узлы
        root.AppendChild(xmlTrips);
        root.AppendChild(xmlWays);
        // Сохраняем
        xDoc.Save(path);
    }

}