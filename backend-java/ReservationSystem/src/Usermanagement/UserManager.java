package Usermanagement;
import java.sql.*;

public class UserManager {
   

    
    public String loginUser(String username, String password) {
        String query = "SELECT password FROM customer WHERE loginid = ?";
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root");
                 PreparedStatement stmt = conn.prepareStatement(query)) {

                stmt.setString(1, username);
                ResultSet r = stmt.executeQuery();

                if (r.next()) {
                    String storedPassword = r.getString("password");
                    if (storedPassword.equals(password)) {
                        return "SUCCESS";
                    } else {
                        return "INVALID_PASSWORD";
                    }
                } else {
                    return "INVALID_USERNAME";
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            return "ERROR";
        }
    }
}
