using Domain.LocationsContext.ValueObjects;
using static Domain.LocationsContext.ValueObjects.LocationAdderss;

namespace Domain.LocationsContext;

/// <summary>
/// Представляет географическое местоположение.
/// </summary>
public class Location
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Location"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор местоположения.</param>
    /// <param name="name">Название местоположения.</param>
    /// <param name="address">Адрес местоположения.</param>
    /// <param name="lifeTime">Время жизни сущности (например, даты создания/обновления).</param>
    /// <param name="timeZone">Часовой пояс местоположения.</param>

    public Location(
        Locationid id,
        LocationName name,
        LocationAddress address,
        EntityLifeTime lifeTime,
        IanaTimeZone timeZone)
    {
        Id = id;
        Name = name;
        Address = address;
        LifeTime = lifeTime;
        TimeZone = timeZone;
    }

    /// <summary>
    /// Получает уникальный идентификатор местоположения.
    /// </summary>
    public Locationid Id { get; private set; }


    /// <summary>
    /// Получает название местоположения.
    /// </summary>
    public LocationName Name { get; private set; }

    /// <summary>
    /// Получает адрес местоположения.
    /// </summary>
    public LocationAddress Address { get; private set; }

    /// <summary>
    /// Получает метаданные времени жизни сущности.
    /// </summary>
    public EntityLifeTime LifeTime { get; private set; }

    /// <summary>
    /// Получает часовой пояс местоположения (в формате IANA).
    /// </summary>
    public IanaTimeZone TimeZone { get; private set; }

    public void Update(LocationName? name, LocationAddress? address, IanaTimeZone? timeZone)
    {
if(name is not null && Name != name )
{
    Name = name;
}
if(address is not null && Address != address)
{
    Address = address;
}
if (timeZone is not null && TimeZone != timeZone)
{
    TimeZone = timeZone;
}

}
public void Update(EntityLifeTime lifeTime)
   {
    if (lifeTime is not null && LifeTime!= lifeTime)
    {
        LifeTime = lifeTime;
    }
   }
}
// 1. как писать методы внутри класса
//2.get set как менять свойства класса