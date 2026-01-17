package FlightManagement;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
public class FlightManager {
	public boolean addflight(Flight flight) {
		String sql = "INSERT INTO flights (FlightNumber, Source, Destination, DepartureDate, DepartureTime, ArrivalDate, ArrivalTime, SeatsAvailable, TicketPrice) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
		try(Connection c=DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation","root","root");
				PreparedStatement stmt=c.prepareStatement(sql)) {
			stmt.setString(1, flight.getflightnumber());
            stmt.setString(2, flight.getsource());
            stmt.setString(3, flight.getdest());
            stmt.setDate(4, Date.valueOf(flight.getdate()));
            stmt.setTime(5, Time.valueOf(flight.getflightnumber()));
            stmt.setDate(6, Date.valueOf(flight.getarrdate()));
            stmt.setTime(7, Time.valueOf(flight.gettime()));
            stmt.setInt(8, flight.getseats());
            stmt.setDouble(9, flight.getprice());

            return stmt.executeUpdate() == 1;
		} catch(SQLException e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public boolean deleteFlight(int flightId) {
		String sql="DELETE FROM flights WHERE FlightID=?";
		try(Connection c=DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation","root","root");
				PreparedStatement stmt=c.prepareStatement(sql)){
			 stmt.setInt(1, flightId);
	            return stmt.executeUpdate() == 1;
		}catch(SQLException e) {
			e.printStackTrace();
			return false;
		}
	}
	public Flight getflightDetails(int flightId) {
		String sql="DELETE FROM flights WHERE FlightID=?";
		try(Connection c=DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation","root","root");
				PreparedStatement stmt=c.prepareStatement(sql)){
			stmt.setInt(1,flightId);
			ResultSet r=stmt.executeQuery();
			
			if(r.next()) {
				Flight flight = new Flight();
                flight.setflightid(r.getInt("FlightID"));
                flight.setflightnumber(r.getString("FlightNumber"));
                flight.setsource(r.getString("Source"));
                flight.setdest(r.getString("Destination"));
                flight.setdeptdate(r.getDate("DepartureDate").toLocalDate());
                flight.setdeptime(r.getTime("DepartureTime").toLocalTime());
                flight.setdate(r.getDate("ArrivalDate").toLocalDate());
                flight.settime(r.getTime("ArrivalTime").toLocalTime());
                flight.setseats(r.getInt("SeatsAvailable"));
                flight.setprice(r.getDouble("TicketPrice"));
                return flight;
			}	
		}catch(SQLException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	public List<Flight> listAllFlights(){
		List<Flight> flight= new ArrayList<>();
		String sql="SELECT * FROM flights";
		try(Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation","root","root");
				Statement stmt = conn.createStatement();
				ResultSet rs = stmt.executeQuery(sql)){
			while(rs.next()) {
				Flight f = new Flight();
                f.setflightid(rs.getInt("FlightID"));
                f.setflightnumber(rs.getString("FlightNumber"));
                f.setsource(rs.getString("Source"));
                f.setdest(rs.getString("Destination"));
                f.setdeptdate(rs.getDate("DepartureDate").toLocalDate());
                f.setdeptime(rs.getTime("DepartureTime").toLocalTime());
                f.setdate(rs.getDate("ArrivalDate").toLocalDate());
                f.settime(rs.getTime("ArrivalTime").toLocalTime());
                f.setseats(rs.getInt("SeatsAvailable"));
                f.setprice(rs.getDouble("TicketPrice"));
                flight.addAll(flight);
			}
		}catch(SQLException e) {
			e.printStackTrace();
		}
		return flight;
	}
}
