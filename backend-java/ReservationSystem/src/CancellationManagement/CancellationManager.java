package CancellationManagement;
import java.sql.*;
import java.time.LocalDate;
public class CancellationManager {
	 
	    
	    public boolean cancelBooking(int bookingId, String reason) {
	        String insertSql = "INSERT INTO cancellations (BookingID, CancellationDate, Reason) VALUES (?, ?, ?)";
	        String updateSql = "UPDATE bookings SET Status = 'CANCELLED' WHERE BookingID = ?";

	        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root")) {
	            
	            conn.setAutoCommit(false);
	            try (PreparedStatement insertStmt = conn.prepareStatement(insertSql);
	                 PreparedStatement updateStmt = conn.prepareStatement(updateSql)) {

	                
	                insertStmt.setInt(1, bookingId);
	                insertStmt.setDate(2, Date.valueOf(LocalDate.now()));
	                insertStmt.setString(3, reason);
	                insertStmt.executeUpdate();

	                
	                updateStmt.setInt(1, bookingId);
	                int affectedRows = updateStmt.executeUpdate();

	                if (affectedRows == 1) {
	                    conn.commit();
	                    return true;
	                } else {
	                    conn.rollback();
	                    return false;
	                }
	            } catch (SQLException e) {
	                conn.rollback();
	                e.printStackTrace();
	                return false;
	            } finally {
	                conn.setAutoCommit(true);
	            }
	        } catch (SQLException e) {
	            e.printStackTrace();
	            return false;
	        }
	    }

	    // Retrieve cancellation details
	    public Cancellation getCancellationDetails(int cancellationId) {
	        String sql = "SELECT * FROM cancellations WHERE CancellationID = ?";
	        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root");
	             PreparedStatement stmt = conn.prepareStatement(sql)) {
	            stmt.setInt(1, cancellationId);
	            ResultSet rs = stmt.executeQuery();
	            if (rs.next()) {
	                Cancellation c = new Cancellation();
	                c.setCancellationId(rs.getInt("CancellationID"));
	                c.setBookingId(rs.getInt("BookingID"));
	                c.setCancellationDate(rs.getDate("CancellationDate").toLocalDate());
	                c.setReason(rs.getString("Reason"));
	                return c;
	            }
	        } catch (SQLException e) {
	            e.printStackTrace();
	        }
	        return null;
	    }
	}

