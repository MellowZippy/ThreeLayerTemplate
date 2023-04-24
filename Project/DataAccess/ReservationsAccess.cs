using System.Text.Json;

static class ReservationsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservations.json"));

    public static List<ReservationModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ReservationModel>>(json)!;
    }

    public static void WriteAll(List<ReservationModel> reservations)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(reservations.OrderBy(x => x.Id).ToList(), options);
        File.WriteAllText(path, json);
    }

    public static List<ReservationModel> AscIDMyJson()
    {
        var listOb = LoadAll();
        var descListOb = listOb!.OrderBy(x => x.Id).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscNameMyJson()
    {
        var listOb = LoadAll();
        var descListOb = listOb!.OrderBy(x => x.FullName).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscDateMyJson()
    {
        var listOb = LoadAll();
        var descListOb = listOb!.OrderBy(x => x.Date).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscPeopleMyJson()
    {
        var listOb = LoadAll();
        var descListOb = listOb!.OrderBy(x => x.QuantityPeople).ToList();
        return descListOb;
    }

    public static List<ReservationModel> TodaysReservations()
    {
        var listOb = LoadAll();
        List<ReservationModel> descListOb = new List<ReservationModel>();
        foreach (ReservationModel reservation in listOb)
        {
            if (reservation.Date.Day == DateTime.Now.Day) descListOb.Add(reservation);
        }
        return descListOb;
    }
}