<%@ page contentType="text/html;charset=utf-8" %>
<%@ page import = "java.sql.*" %>
<!doctype html>
<html>
<head>
	<title>gameover</title>
	<meta charset="utf-8"/>
</head>
<body>
	<%
	try{
	Connection conn = null;
	request.setCharacterEncoding("utf-8");
	Class.forName("com.mysql.jdbc.Driver");
	String myUrl = "jdbc:mysql://52.78.92.53:3306/game_DB";
	int result;
	PreparedStatement pstmt;

	ResultSet rset;
	conn = DriverManager.getConnection(myUrl,"pooiuu","panic123");
	String user_id = request.getParameter("ID");
	String date = request.getParameter("date");
	String hour = request.getParameter("hour");
	String score = request.getParameter("score");
	Integer server_score = -10;
	String query = "update user_info set last_playtime = '" + date + " " + hour + "' where FB_ID = '" + user_id + "'";
	pstmt = conn.prepareStatement(query);
	result = pstmt.executeUpdate();
	String query2 = "select Score from user_info where FB_ID = '"+ user_id +"'";
	pstmt = conn.prepareStatement(query2);
	rset = pstmt.executeQuery();
	while(rset.next()){
	server_score = rset.getInt("Score");
}
if(server_score != null){
out.println(server_score);
}
if(server_score < Integer.parseInt(score)){
String query3 = "update user_info set Score = '" + score + "' where FB_ID = '" +user_id + "'";
pstmt = conn.prepareStatement(query3);
result = pstmt.executeUpdate();
}
pstmt.close();
rset.close();
}
catch(Exception e){
out.println(e);
}
%>
</body>
</html>