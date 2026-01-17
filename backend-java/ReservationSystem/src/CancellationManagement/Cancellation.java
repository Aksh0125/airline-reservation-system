package CancellationManagement;
import java.time.LocalDate;

public class Cancellation {
	 private int cancellationId;
	    private int bookingId;
	    private LocalDate cancellationDate;
	    private String reason;

	    
	    public int getCancellationId() { return cancellationId; }
	    public void setCancellationId(int cancellationId) { this.cancellationId = cancellationId; }

	    public int getBookingId() { return bookingId; }
	    public void setBookingId(int bookingId) { this.bookingId = bookingId; }

	    public LocalDate getCancellationDate() { return cancellationDate; }
	    public void setCancellationDate(LocalDate cancellationDate) { this.cancellationDate = cancellationDate; }

	    public String getReason() { return reason; }
	    public void setReason(String reason) { this.reason = reason; }
	}

