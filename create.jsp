<%@ page contentType="text/html;charset=utf-8" %>
<%@ page import = "java.sql.*" %>
<!doctype html>
<html>
<head>
	<title>create</title>
	<meta charset="utf-8"/>
</head>
<body>
	<%
	try{
	Connection conn = null;
	request.setCharacterEncoding("utf-8");
	Class.forName("com.mysql.jdbc.Driver");
	String myUrl = "jdbc:mysql://52.78.92.53:3306/game_DB";
	ResultSet rset;
	PreparedStatement pstmt;
	int temp;
	int overlap = 0;
	conn = DriverManager.getConnection(myUrl,"pooiuu","panic123");
	//nickname이 똑같을 때를 검사해야함.
	if(request.getParameter("nick") != null && overlap == 0){
	String nickName = request.getParameter("nick");
	PreparedStatement pstmt2;
	String query = "select user_id from user_info where user_id='"+ nickName + "'";
	pstmt2 = conn.prepareStatement(query);
	rset = pstmt2.executeQuery();
	if(!rset.first()){
	overlap = 0;
}else{
out.println("&");
out.println("Overlap data");
out.println("&");
overlap = 1;
}
pstmt2.close();
rset.close();
}
if(request.getParameter("nick") != null && request.getParameter("date") != null && request.getParameter("id") != null && overlap == 0){
out.println("&");
out.println("&");
String nickName = request.getParameter("nick");
String cur_date = request.getParameter("date");
String cur_time = request.getParameter("time");
String fb_id = request.getParameter("id");
String query = "insert into user_info (user_id, download_time, access_time, FB_ID, FB_Guest) values('" + nickName + "','"+ cur_date + " " + cur_time + "','" + cur_date + " " + cur_time + "','" + fb_id + "',1)";
pstmt = conn.prepareStatement(query);
temp = pstmt.executeUpdate();
pstmt.close();
conn.close();

}
}catch(Exception e){
out.println(e);
}
%>
</body>
</html>