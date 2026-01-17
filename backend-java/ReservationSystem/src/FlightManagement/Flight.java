package FlightManagement;
import java.time.LocalDate;
import java.time.LocalTime;
public class Flight {
	private int flight_id;
	private String flight_number;
	private String Source;
	private String destination;
	private LocalDate arr_date;
	private LocalTime arr_time;
	private LocalDate dep_date;
	private LocalTime dep_time;
	private int avail_seats;
	private double price;
	
	public void setflightid(int flight_id) {this.flight_id=flight_id;}
	public int getflightid() {return flight_id;}
	
	public void setflightnumber(String flight_number) {this.flight_number=flight_number;}
	public String getflightnumber() { return flight_number;}
	
	public void setsource(String Source) {this.Source=Source;}
	public String getsource() { return Source;}
	
	public void setdest(String destination) {this.destination=destination;}
	public String getdest() { return destination;}
	
	public void setdate(LocalDate arr_date) {
		
		this.arr_date=arr_date;
	}
	public void setdeptdate(LocalDate dep_date) {
		this.dep_date=dep_date;
	}
	public LocalDate getdate() {return dep_date;}
	public LocalDate getarrdate() {return arr_date;}
	
	public void settime(LocalTime arr_time) {
		this.arr_time=arr_time;
	}
	public void setdeptime(LocalTime dep_time) {
		this.dep_time=dep_time;
	}
	public LocalTime gettime() {return arr_time;}
	public LocalTime getdeptime() {return dep_time;}
	
	public void setseats(int avail_seats) {this.avail_seats=avail_seats;}
	public int getseats() {return avail_seats;}
	
	public void setprice(double price) {this.price=price;}
	public double getprice() {return price;}
	
}