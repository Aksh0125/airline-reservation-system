package Usermanagement;

public class user {
	private int user_Id;
	private String username;
	private String password;
	private String Name;
	private String email;
	private String phn_no;
	
	public void setuserid(int user_Id) {this.user_Id=user_Id;}
	public int getuserid() {return user_Id;}
	
	public void setusername(String username) {this.username=username;}
	public String getusername() {return username;}
	
	public void setpassword(String password) {this.password=password;}
	public String getpassword() {return password;}
	
	public void setName(String Name) {this.Name=Name;}
	public String getName() {return Name;}
	
	public void setemail(String email) {this.email=email;}
	public String getemail() {return email;}
	
	public void setphnno(String phn_no) {this.phn_no=phn_no;}
	public String getphnno() {return phn_no;}
}
