using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ReservationsLogic
{
    private static List<ReservationModel> _reservations = ReservationsAccess.LoadAll();

    public static void UpdateList(ReservationModel res)
    {
        //Find if there is already an model with the same id
        int index = _reservations.FindIndex(s => s.Id == res.Id);

        if (index != -1)
        {
            //update existing model
            _reservations[index] = res;
        }
        else
        {
            //add new model
            _reservations.Add(res);
        }
        ReservationsAccess.WriteAll(_reservations);

    }

    public ReservationModel GetById(int id)
    {
        return _reservations.Find(i => i.Id == id)!;
    }

    public static ReservationModel AddReservation(DateTime date, string time, int quantityPeople, string fullName, int accountId, string reservationCode)
    {
        List<ReservationModel> reservationsList = ReservationsAccess.LoadAll();
        int nextId = reservationsList[reservationsList.Count - 1].Id + 1;
        ReservationModel res = new ReservationModel(nextId, date, time, quantityPeople, fullName, accountId, reservationCode);
        reservationsList.Add(res);
        ReservationsAccess.WriteAll(reservationsList);
        return res;
    }

    public static void RemoveReservation(ReservationModel reservation)
    {
        // NOT YET DONE
        List<ReservationModel> reservationsList = ReservationsAccess.LoadAll();
        int index = reservationsList.FindIndex(x => x.Id == reservation.Id);
        reservationsList.RemoveAt(index);
        ReservationsAccess.WriteAll(reservationsList);
    }

    public static List<ReservationModel> FindAccountReservation()
    {
        List<ReservationModel> reservationsList = new List<ReservationModel>();
        _reservations = ReservationsAccess.LoadAll();
        foreach (ReservationModel reservation in _reservations)
        {
            if (reservation.AccountId == AccountsLogic.CurrentAccount!.Id) reservationsList.Add(reservation);
        }
        return reservationsList;
    }
}


