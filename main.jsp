<%@ page contentType="text/html;charset=utf-8" %>
<%@ page import = "java.sql.*" %>
<!doctype html>
<html>
<head>
	<title>main</title>
	<meta charset="utf-8"/>
</head>
<body>
	<%
	Connection conn = null;
	try{
	request.setCharacterEncoding("utf-8");
	Class.forName("com.mysql.jdbc.Driver");
	String myUrl = "jdbc:mysql://52.78.92.53/game_DB";
	conn = DriverManager.getConnection(myUrl,"root","panic123");
	out.println("연결");
}catch(Exception e){
e.printStackTrace();
}
%>
</body>