package BookingManagement;
import java.time.LocalDateTime;
public class booking {
	private int booking_id;
	private int customer_id;
	private int flight_id;
	private LocalDateTime booking_date;
	private String status;
	
	
	
	public int getbookingid() { return booking_id;}
	public void setbookingid(int booking_id) {this.booking_id=booking_id;}
	
	public int getcustomerid() {return customer_id;}
	public void setcustomerid(int customer_id) {this.customer_id=customer_id;}
	
	public int getflightid() {return flight_id;}
	public void setflightid(int flight_id) {this.flight_id=flight_id;}
	
	public LocalDateTime getbookingdate() {return booking_date;}
	public void setbookingdate(LocalDateTime booking_date) {this.booking_date=booking_date;}
	
	public String getstatus() {return status;}
	public void setstatus(String status) {this.status=status;}
}
