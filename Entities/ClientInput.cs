namespace CarRentCalculator.Entities;

public class ClientInput
{
    public int ChosenCar { get; set; }
    public double DistanceDriven { get; set; }
    public int DriversLicenseObtainmentYear { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ClientInput(int chosenCar, double distanceDriven, int driversLicenseObtainmentYear, DateTime startDate,
        DateTime endDate)
    {
        ChosenCar = chosenCar;
        DistanceDriven = distanceDriven;
        DriversLicenseObtainmentYear = driversLicenseObtainmentYear;
        StartDate = startDate;
        EndDate = endDate;
    }
}